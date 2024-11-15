```
git submodule update --init --recursive

cd mkdir build && cd build

cmake .. -DCMAKE_GENERATOR_PLATFORM=win32 -DCMAKE_SYSTEM_PROCESSOR=x86 -DCMAKE_BUILD_TYPE=Debug
cmake --build .
cp ../bin/Debug/RmlUiNative.dll ../../../ext/RmlUI.Net/runtimes/win-x86/native/RmlUiNative.dll
```