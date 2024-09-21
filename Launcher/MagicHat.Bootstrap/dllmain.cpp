// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <iostream>
#include <fstream>
#include "Shlobj_core.h"
#include "ReloadedPaths.h"
#include "CoreCLR.hpp"
#include "nlohmann/json.hpp"

#include <locale>
#include <codecvt>
#include <string>
#include <shellapi.h>
#include <sstream>
#include "EntryPointParameter.h"

using json = nlohmann::json;

// Global Variables
CoreCLR* CLR;
HMODULE thisProcessModule;
HANDLE initializeThreadHandle;
HANDLE bootstrapperMemoryMappedFileHandle;
EntryPointParameters entryPointParameters;
string_t launcherPath;

// Reloaded Init Functions
DWORD WINAPI load_reloaded_async(LPVOID lpParam);

bool is_reloaded_already_loaded();
bool is_reloaded_bootstrapper_already_loaded();
void set_reloaded_bootstrapper_already_loaded();
std::wstring get_reloaded_bootstrapper_name();
bool load_reloaded();
string_t get_current_directory(HMODULE hModule);

/* Entry point */
BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
	launcherPath = get_current_directory(hModule);
    switch (ul_reason_for_call)
    {
		case DLL_PROCESS_ATTACH:
			thisProcessModule = hModule;
			//load_reloaded();
			//initializeThreadHandle = CreateThread(nullptr, 0, &load_reloaded_async, 0, 0, nullptr);
			break;

		case DLL_THREAD_ATTACH:
		case DLL_THREAD_DETACH:
			break;

		case DLL_PROCESS_DETACH:
			// Unloading mod loader not supported.
			CloseHandle(bootstrapperMemoryMappedFileHandle);
			break;
    }
    return TRUE;
}

DWORD WINAPI load_reloaded_async(LPVOID lpParam)
{
	load_reloaded();
	return 0;
}

/**
 * \brief Loads the Reloaded Mod Loader into the current process given a set of paths.
 * \param reloadedPaths The paths to Reloaded components.
 * \return false if failed to load Reloaded, true otherwise./
 */
bool load_reloaded()
{
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
		nullptr, nullptr, (void**) &initialize))
	{
		MessageBoxA(nullptr, "Failed", "Failed to load .NET assembly.", MB_OK);
		throw std::exception("Failed to load .NET assembly.");
	}

	// Set path to current dll
	// Using GetModuleFileNameW
	entryPointParameters.dll_path = new wchar_t[MAX_PATH];
	GetModuleFileNameW(thisProcessModule, entryPointParameters.dll_path, MAX_PATH);
	initialize(&entryPointParameters, sizeof(EntryPointParameters));
	
	return true;
}

/**
 * \brief Returns true if Reloaded is already loaded, else false.
 */
bool is_reloaded_already_loaded()
{
	const std::wstring memoryMappedFileName = L"Reloaded-Mod-Loader-Server-PID-" + std::to_wstring(GetCurrentProcessId());
	const HANDLE hMapFile = OpenFileMappingW(FILE_MAP_ALL_ACCESS, FALSE, memoryMappedFileName.c_str());

	const bool loaded = (hMapFile != nullptr);
	if (hMapFile != nullptr)
		CloseHandle(hMapFile);
	
	return loaded;
}

/**
 * \brief Returns true if Reloaded is already loaded, else false.
 */
bool is_reloaded_bootstrapper_already_loaded()
{
	const std::wstring memoryMappedFileName = get_reloaded_bootstrapper_name();
	const HANDLE hMapFile = OpenFileMappingW(FILE_MAP_ALL_ACCESS, FALSE, memoryMappedFileName.c_str());

	const bool loaded = (hMapFile != nullptr);
	if (hMapFile != nullptr)
		CloseHandle(hMapFile);

	return loaded;
}

/**
 * \brief Returns true if Reloaded is already loaded, else false.
 */
void set_reloaded_bootstrapper_already_loaded()
{
	const std::wstring memoryMappedFileName = get_reloaded_bootstrapper_name();
	bootstrapperMemoryMappedFileHandle = CreateFileMappingW(INVALID_HANDLE_VALUE, nullptr, PAGE_READWRITE, 0, 4, memoryMappedFileName.c_str());
}

/**
 * \brief Returns the name of the memory mapped file for the Reloaded Bootstrapper.
 */
std::wstring get_reloaded_bootstrapper_name()
{
	return L"Reloaded-Mod-Loader-Bootstrapper-PID-" + std::to_wstring(GetCurrentProcessId());
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



/* Exports for different mod loaders. */
struct ModInfoDummy
{
	int version;
	char padding[256];
};

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

extern "C"
{
	// Note: MainMemory's Mod Loaders have inconsistent entry points (some having helper functions, some not). Not exporting proper defs.
	__declspec(dllexport) ModInfoDummy MainMemoryModInfo = { 1 };

	// Entry point for Ultimate ASI Loader, to allow waiting for Reloaded II creation thread to terminate.
	__declspec(dllexport) void InitializeASI()
	{
		std::cout << "[Reloaded II Bootstrapper] Ultimate ASI Loader Entrypoint Hit" << std::endl;
		entryPointParameters.flags |= LoadedExternally;
		WaitForSingleObject(initializeThreadHandle, INFINITE);
	}

	/*
		[DllImport("injector.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool Bootstrap();
	*/
	__declspec(dllexport) void Bootstrap() {
		load_reloaded();
	}

	/*
		[DllImport("injector.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		public static extern int LaunchInjected(string command_line, string working_directory, string inject_dll_path, [MarshalAs(UnmanagedType.LPStr)] string initialize_function);
	*/
#pragma warning(disable : 4996) //_CRT_SECURE_NO_WARNINGS
	__declspec(dllexport) DWORD LaunchInjected(wchar_t* Source, LPCWSTR lpCurrentDirectory, LPCWSTR lpLibFileName, LPCSTR lpProcName) {
		size_t SourceLen;
		wchar_t* CmdLine_s;
		HMODULE ModuleHandleW;
		HMODULE(__stdcall * LoadLibraryW)(LPCWSTR);
		HMODULE LibraryW;
		char* v10;
		struct _STARTUPINFOW StartupInfo;
		struct _PROCESS_INFORMATION ProcessInformation;
		wchar_t* Sourcea;

		if (!Source || !lpCurrentDirectory || !lpLibFileName || !lpProcName) {
			return 0;
		}
		memset(&ProcessInformation, 0, sizeof(ProcessInformation));
		memset(&StartupInfo, 0, sizeof(StartupInfo));
		StartupInfo.cb = 68;
		SourceLen = wcslen(Source);
		CmdLine_s = (wchar_t*)operator new((unsigned __int64)(SourceLen + 1) >> 31 != 0 ? -1 : 2 * (SourceLen + 1));
		wcsncpy(CmdLine_s, Source, SourceLen);
		CmdLine_s[SourceLen] = 0;
		if (!CreateProcessW(0, CmdLine_s, 0, 0, 0, 4u, 0, lpCurrentDirectory, &StartupInfo, &ProcessInformation))
			return 0;
		delete(CmdLine_s);
		ModuleHandleW = GetModuleHandleW(L"kernel32.dll");
		LoadLibraryW = (HMODULE(__stdcall*)(LPCWSTR))GetProcAddress(ModuleHandleW, "LoadLibraryW");
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
		ResumeThread(ProcessInformation.hThread);
		CloseHandle(ProcessInformation.hThread);
		CloseHandle(ProcessInformation.hProcess);
		return ProcessInformation.dwProcessId;
	}
}
