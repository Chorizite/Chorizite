#pragma once

/* For C# source, see EntryPoint.cs */
#define CURRENT_VERSION 8

enum EntryPointFlags : int
{
	None = 0
};

/**
 * Defines the parameters.
 */
struct EntryPointParameters
{
public:
	int version { CURRENT_VERSION };
	EntryPointFlags flags { None };
	LPWSTR dll_path{ nullptr };
	LPWSTR entry_point { nullptr };
	
	EntryPointParameters() = default;
};

DEFINE_ENUM_FLAG_OPERATORS(EntryPointFlags);