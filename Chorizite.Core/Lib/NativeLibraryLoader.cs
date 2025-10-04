using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Lib {
    public static class NativeLibraryLoader {
        private static IntPtr _libraryHandle;

        public static void Initialize() {
            // Set the resolver early
            //NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
        }

        public static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath) {
            string dllPath = GetNativeLibraryPath(libraryName);
            try {
                Console.WriteLine($"Resolver loading: {dllPath}");
                return NativeLibrary.Load(dllPath);
            }
            catch (Exception ex) {
                Console.WriteLine($"Resolver failed: {ex.Message}");
                return IntPtr.Zero;
            }
        }

        public static string GetNativeLibraryPath(string libraryName, string? searchPath = null) {
            string extension = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ".dll" :
                              RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? ".so" :
                              RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? ".dylib" :
                              throw new PlatformNotSupportedException("Unsupported platform");

            string arch = RuntimeInformation.ProcessArchitecture switch {
                Architecture.X64 => "x64",
                Architecture.X86 => "x86",
                Architecture.Arm64 => "arm64",
                _ => throw new PlatformNotSupportedException("Unsupported architecture")
            };

            string platform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "win" :
                             RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "linux" :
                             RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "osx" : "unknown";

            string basePath = searchPath ?? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string nativePath = Path.Combine(basePath, "runtimes", $"{platform}-{arch}", "native", $"{libraryName}{extension}");

            if (!File.Exists(nativePath)) {
                throw new FileNotFoundException($"Native library not found at {nativePath}");
            }

            return nativePath;
        }

        public static void Unload() {
            if (_libraryHandle != IntPtr.Zero) {
                NativeLibrary.Free(_libraryHandle);
                _libraryHandle = IntPtr.Zero;
            }
        }
    }
}
