// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <iostream>
#include <fstream>
#include "Shlobj_core.h"
#include "CoreCLR.hpp"

#include <locale>
#include <codecvt>
#include <string>
#include <shellapi.h>
#include <sstream>
#include "EntryPointParameter.h"

// Global Variables
CoreCLR* CLR;
HMODULE thisProcessModule;
EntryPointParameters entryPointParameters;
string_t launcherPath;

string_t get_current_directory(HMODULE hModule);

/* Entry point */
BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
	launcherPath = get_current_directory(hModule);
    switch (ul_reason_for_call)
    {
		case DLL_PROCESS_ATTACH:
			thisProcessModule = hModule;
			break;

		case DLL_THREAD_ATTACH:
		case DLL_THREAD_DETACH:
		case DLL_PROCESS_DETACH:
			break;
    }
    return TRUE;
}

string_t get_current_directory(HMODULE mHandle)
{
	char_t host_path[MAX_PATH];
	int bufferSize = sizeof(host_path) / sizeof(char_t);
	GetModuleFileNameW(mHandle, host_path, bufferSize);

	string_t root_path = host_path;
	auto pos = root_path.find_last_of('\\');
	root_path = root_path.substr(0, pos + 1);

	return root_path;
}

DWORD __fastcall InjectPayloadAndExecute(HANDLE hProcess, LPTHREAD_START_ROUTINE lpStartAddress, LPCVOID lpBuffer, SIZE_T dwSize) {
	void* pimple;
	DWORD(__stdcall * v5)(LPVOID);
	HANDLE RemoteThread;
	DWORD ExitCode;
	pimple = 0;
	v5 = lpStartAddress;
	if (lpBuffer && dwSize) {
		pimple = VirtualAllocEx(hProcess, 0, dwSize, 0x3000u, 4u);
		WriteProcessMemory(hProcess, pimple, lpBuffer, dwSize, 0);
		v5 = lpStartAddress;
	}
	RemoteThread = CreateRemoteThread(hProcess, 0, 0, v5, pimple, 0, 0);
	ExitCode = 0;
	WaitForSingleObject(RemoteThread, 0xFFFFFFFF);
	GetExitCodeThread(RemoteThread, &ExitCode);
	if (pimple) {
		VirtualFreeEx(hProcess, pimple, 0, 0x8000u);
	}
	return ExitCode;
}

LPSTR ToLPCSTR(LPWSTR wstr) {
	std::wstring ws(wstr);
	return (LPSTR)(ws.c_str());
}

extern "C"
{
	__declspec(dllexport) void Bootstrap() {
		int success = 0;
		CLR = new CoreCLR(&success);

		if (!success) {

			MessageBoxA(nullptr, "Failed", "Failed to load the `hostfxr` library. Did you copy nethost.dll?", MB_OK);
			throw std::exception("Failed to load the `hostfxr` library. Did you copy nethost.dll?");
		}

		// Load runtime and execute our method.
		if (!CLR->load_runtime(launcherPath + L"Launcher.runtimeconfig.json")) {

			MessageBoxA(nullptr, "Failed", "Failed to load .NET Core Runtime", MB_OK);
			throw std::exception("Failed to load .NET Core Runtime");
		}

		const string_t assembly_path = launcherPath + L"Reloaded.Core.Bootstrap.ExampleDll.dll";
		const string_t type_name = L"Reloaded.Core.Bootstrap.ExampleDll.Hello, Reloaded.Core.Bootstrap.ExampleDll";
		const string_t method_name = L"SayHello";
		component_entry_point_fn initialize = nullptr;

		if (!CLR->load_assembly_and_get_function_pointer(assembly_path.c_str(), type_name.c_str(), method_name.c_str(),
			nullptr, nullptr, (void**)&initialize))
		{
			MessageBoxA(nullptr, "Failed", "Failed to load .NET assembly.", MB_OK);
			throw std::exception("Failed to load .NET assembly.");
		}

		// Set path to current dll
		// Using GetModuleFileNameW
		entryPointParameters.dll_path = new wchar_t[MAX_PATH];
		GetModuleFileNameW(thisProcessModule, entryPointParameters.dll_path, MAX_PATH);
		initialize(&entryPointParameters, sizeof(EntryPointParameters));
	}

#pragma warning(disable : 4996) //_CRT_SECURE_NO_WARNINGS
	__declspec(dllexport) DWORD LaunchInjected(wchar_t* Source, LPCWSTR lpCurrentDirectory, EntryPointParameters* entryPointParameters, int numParams) {
		size_t SourceLen;
		wchar_t* CmdLine_s;
		HMODULE ModuleHandleW;
		HMODULE(__stdcall * LoadLibraryW)(LPCWSTR);
		HMODULE LibraryW;
		char* v10;
		struct _STARTUPINFOW StartupInfo;
		struct _PROCESS_INFORMATION ProcessInformation;
		wchar_t* Sourcea;

		if (!Source || !lpCurrentDirectory) {
			return 0;
		}
		memset(&ProcessInformation, 0, sizeof(ProcessInformation));
		memset(&StartupInfo, 0, sizeof(StartupInfo));
		StartupInfo.cb = 68;
		SourceLen = wcslen(Source);
		CmdLine_s = (wchar_t*)operator new((unsigned __int64)(SourceLen + 1) >> 31 != 0 ? -1 : 2 * (SourceLen + 1));
		wcsncpy(CmdLine_s, Source, SourceLen);
		CmdLine_s[SourceLen] = 0;
		if (!CreateProcessW(0, CmdLine_s, 0, 0, 0, 4u, 0, lpCurrentDirectory, &StartupInfo, &ProcessInformation)) {
			return 0;
		}
		delete(CmdLine_s);
		ModuleHandleW = GetModuleHandleW(L"kernel32.dll");
		LoadLibraryW = (HMODULE(__stdcall*)(LPCWSTR))GetProcAddress(ModuleHandleW, "LoadLibraryW");

		for (int i = 0; i < numParams; i++) {
			LPCWSTR lpLibFileName = entryPointParameters[i].dll_path;
			char aText[200] = { 0 };
			sprintf(aText, "%S", entryPointParameters[i].entry_point);
			LPCSTR lpProcName = aText;
			Sourcea = (wchar_t*)InjectPayloadAndExecute(
				ProcessInformation.hProcess,
				(LPTHREAD_START_ROUTINE)LoadLibraryW,
				lpLibFileName,
				2 * wcslen(lpLibFileName));
			if (!Sourcea) {
				TerminateProcess(ProcessInformation.hProcess, 0);
				return 0;
			}
			LibraryW = ::LoadLibraryW(lpLibFileName);
			v10 = (char*)((char*)GetProcAddress(LibraryW, lpProcName) - (char*)LibraryW);
			FreeLibrary(LibraryW);
			InjectPayloadAndExecute(ProcessInformation.hProcess, (LPTHREAD_START_ROUTINE)((char*)Sourcea + (DWORD)v10), 0, 0);
		}

		ResumeThread(ProcessInformation.hThread);
		CloseHandle(ProcessInformation.hThread);
		CloseHandle(ProcessInformation.hProcess);
		return ProcessInformation.dwProcessId;
	}
}
