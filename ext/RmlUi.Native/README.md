```
git submodule update --init --recursive

cd mkdir build && cd build

cmake .. -DCMAKE_GENERATOR_PLATFORM=win32 -DCMAKE_SYSTEM_PROCESSOR=x86 -DCMAKE_BUILD_TYPE=Debug
cmake --build .
```