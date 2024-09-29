cmake_minimum_required(VERSION 3.14...3.23)

project(RmlUiNative VERSION 1.0 LANGUAGES CXX)

set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR}/bin)
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/lib)

if(WIN32)    
    set(CMAKE_EXE_LINKER_FLAGS "/SUBSYSTEM:WINDOWS /DEBUG:FASTLINK")
    set(CMAKE_VS_PLATFORM_TOOLSET_HOST_ARCHITECTURE "x64")

    if ("${CMAKE_CXX_COMPILER_ID}" STREQUAL "MSVC")
        set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /std:c++17")

        if (USE_STATIC_MSVC_RUNTIME_LIBRARY)
		    set(CMAKE_MSVC_RUNTIME_LIBRARY "MultiThreaded$<$<CONFIG:Debug>:Debug>")
	    else()
		    set(CMAKE_MSVC_RUNTIME_LIBRARY "MultiThreaded")
	    endif()
    endif()
elseif(LINUX)
    set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++17 -I. -Wall -Werror")
endif()

# add external libraries
add_subdirectory("ext/freetype")
set(FREETYPE_LIBRARY "${CMAKE_CURRENT_SOURCE_DIR}/build/lib/Debug/freetyped.lib")
set(FREETYPE_INCLUDE_DIRS "${CMAKE_CURRENT_SOURCE_DIR}/ext/freetype/include")

set(BUILD_SHARED_LIBS OFF)
add_subdirectory("ext/RmlUi")

add_library(${PROJECT_NAME} SHARED
    "src/Context.cpp"

    "src/Element.cpp"
    "src/ElementDocument.cpp"
    "src/ElementCustom.cpp"
    "src/ElementInstancer.cpp"

    "src/DataModelHandle.cpp"
    "src/DataModelConstructor.cpp"
    "src/Event.cpp"
    "src/EventListener.h"

    "src/Box.cpp"
    "src/RenderManager.cpp"

    "src/RenderInterface.cpp"
    "src/SystemInterface.cpp"
    "src/FileInterface.cpp"
    "src/Plugin.cpp"
    
    "src/XMLAttributes.cpp"
    "src/Rml.cpp"
    "src/Debugger.cpp"
    "src/Util.h"
    "src/Buffer.cpp"
    "include/Buffer.h"
)

include_directories(${PROJECT_NAME}
    PRIVATE include
)

target_compile_definitions(${PROJECT_NAME} PUBLIC "RMLUI_STATIC_LIB")

target_link_libraries(${PROJECT_NAME}
    freetype
    RmlUi::Core
    RmlUi::Debugger
)
