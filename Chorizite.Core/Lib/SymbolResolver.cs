using Autofac;
using Chorizite.Core.Dats;
using Chorizite.Core.Plugins;
using Microsoft.Diagnostics.Runtime;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Chorizite.Core.Lib {
    internal static class SymbolResolver {
        // Cache of resolved symbols to improve performance
        private static readonly System.Collections.Concurrent.ConcurrentDictionary<ulong, string> SymbolCache =
            new System.Collections.Concurrent.ConcurrentDictionary<ulong, string>();

        // Delegate type that matches the function pointer expected by C++
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr ResolveSymbolDelegate(ulong address);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr ResolveExtraInfoDelegate();

        // Buffer for passing strings to native code
        private static readonly StringBuilder Buffer = new StringBuilder(1024);

        // Lock to protect the shared buffer
        private static readonly object BufferLock = new object();

        // Cache for method handles to avoid repeated lookups
        private static readonly Dictionary<ulong, MethodBase> MethodCache = new Dictionary<ulong, MethodBase>();

        // Track if we've initialized the ClrMD runtime
        private static bool _runtimeInitialized = false;
        private static ClrRuntime? _runtime = null;
        private static readonly object _runtimeLock = new object();

        // The actual resolver function that will be called from C++
        public static IntPtr ResolveSymbol(ulong address) {
            try {
                // Check cache first
                if (SymbolCache.TryGetValue(address, out string? cachedSymbol)) {
                    return StringToNative(cachedSymbol);
                }

                // Try to resolve symbol
                string symbol = ResolveSymbolInternal(address);

                // Cache for future use
                if (!string.IsNullOrEmpty(symbol)) {
                    SymbolCache[address] = symbol;
                }

                return StringToNative(symbol);
            }
            catch {
                return IntPtr.Zero;
            }
        }

        // Provides extra info in the crash report
        public static IntPtr ResolveExtraInfo() {
            try {
                var str = new StringBuilder();
                var choriziteVersion = "unknown";
                try {
                    choriziteVersion = FileVersionInfo.GetVersionInfo(typeof(Chorizite.Core.ChoriziteConfig).Assembly.Location).ProductVersion;
                }
                catch {}

                str.AppendLine($"Chorizite Version: {choriziteVersion}");
                try {
                    var versionInfo = FileVersionInfo.GetVersionInfo("acclient.exe");
                    str.AppendLine($"AC Client Version: {versionInfo.FileMajorPart}.{versionInfo.FileMinorPart}.{versionInfo.FileBuildPart}.{versionInfo.FilePrivatePart}");

                }
                catch { }
                str.AppendLine($"OS: {Environment.OSVersion.VersionString}");
                str.AppendLine($"CLR Version: {Environment.Version}");
                str.AppendLine($"CLR Runtime: {RuntimeInformation.RuntimeIdentifier}");
                str.AppendLine($"CLR Architecture: {RuntimeInformation.ProcessArchitecture}");

                str.AppendLine();

                try {
                    str.AppendLine("Dat Iterations:");
                    str.AppendLine($"  Portal Dat: {ChoriziteStatics.Scope.Resolve<IDatReaderInterface>().Portal.Iteration.CurrentIteration}");
                    str.AppendLine($"  Cell Dat: {ChoriziteStatics.Scope.Resolve<IDatReaderInterface>().Cell.Iteration.CurrentIteration}");
                    str.AppendLine();
                }
                catch { }

                try {
                    str.AppendLine("Loaded Plugins:");
                    foreach (var plugin in ChoriziteStatics.Scope.Resolve<IPluginManager>().Plugins.ToArray()) {
                        str.AppendLine($"  {plugin.Manifest.Name}{(plugin.DevManifest != null ? " (dev)" : "")} ({plugin.Manifest.Version})");
                    }
                    str.AppendLine();
                }
                catch { }

                str.AppendLine("Plugin Data:");
                try {
                    var lua = ChoriziteStatics.Scope.Resolve<IPluginManager>().GetPlugin("Lua")?.Instance;
                    if (lua != null) {
                        var luaInfo = (string?)lua.GetType().GetMethod("EnhanceStackTraceWithLuaInfo", BindingFlags.Public | BindingFlags.Static)?.Invoke(null, new object[] { }) ?? null;
                        if (luaInfo != null) {
                            str.AppendLine(luaInfo);
                        }
                    }
                }
                catch (Exception ex) {
                    ChoriziteStatics.Log.LogError($"Failed to enhance stack trace with lua info: {ex.Message}");
                }
                str.AppendLine();

                str.AppendLine("Loaded Modules:");
                var modules = Process.GetCurrentProcess().Modules.Cast<ProcessModule>().ToList();
                modules.Sort((a, b) => a.BaseAddress.ToInt64().CompareTo(b.BaseAddress.ToInt64()));
                foreach (ProcessModule module in modules) {
                    str.AppendLine($"  {module.ModuleName} ({module.BaseAddress.ToInt64():X}) - {module.ModuleMemorySize} bytes");
                }

                str.AppendLine();
                return StringToNative(str.ToString());

            }
            catch (Exception ex) {
                try {
                    ChoriziteStatics.Log.LogError($"Failed to resolve extra info: {ex.Message}");
                }
                catch { }
                return IntPtr.Zero;
            }
        }

        private static string ResolveSymbolInternal(ulong address) {
            try {
                // First try using ClrMD if available (most accurate for managed code)
                string? clrMdSymbol = ResolveUsingClrMd(address);
                if (!string.IsNullOrEmpty(clrMdSymbol)) {
                    return clrMdSymbol;
                }

                // Get loaded modules
                foreach (ProcessModule module in Process.GetCurrentProcess().Modules) {
                    ulong moduleStart = (ulong)module.BaseAddress.ToInt64();
                    ulong moduleEnd = moduleStart + (ulong)module.ModuleMemorySize;

                    // Check if address is in this module
                    if (address >= moduleStart && address < moduleEnd) {
                        // Check if this is a .NET module
                        if (IsDotNetModule(module.FileName)) {
                            // Get method info using reflection
                            MethodBase? method = GetMethodFromAddress(address);
                            if (method != null) {
                                // Get source location if available
                                string sourceInfo = GetSourceLocation(method);
                                if (!string.IsNullOrEmpty(sourceInfo)) {
                                    return $"{method.DeclaringType?.FullName}.{method.Name} at {sourceInfo}";
                                }
                                return $"{method.DeclaringType?.FullName}.{method.Name}";
                            }

                            // Fallback: Just report module info
                            return $"{Path.GetFileName(module.FileName)} + 0x{address:x}";
                        }
                        else {
                            var myNativeModules = new List<string> { "rml", "lua", "coreclr" };

                            // For native modules, just return module + offset
                            var p = Path.GetFileName(module.FileName);
                            if (p == "acclient.exe") {
                                return $"{Path.GetFileName(module.FileName)}!0x{address:x} {ResolveACClientSymbol(address - 0x401000)}";
                            }
                            else if (myNativeModules.Any(p.Contains)) {
                                return $"{Path.GetFileName(module.FileName)}!0x{address:x}";
                            }
                            return $"";
                        }
                    }
                }

                // If we get here, we couldn't resolve it
                return "";
            }
            catch {
                // Return basic info on any error to avoid crashing
                return "";
            }
        }

        private static string ResolveACClientSymbol(ulong v) {
            try {
                var offset = (uint)v;
                var last = "unknown";
                // loop all lines of acclient.map, format is <offset hex> <symbol name>
                // until we find a match that is lower / equal to our offset
                foreach (var line in File.ReadAllLines(Path.Combine(ChoriziteStatics.Config.BaseDirectory, "acclient.map"))) {
                    var split = line.Split(' ');
                    if (split.Length < 2)
                        continue;
                    var o = Convert.ToUInt32(split[0], 16);
                    if (o >= offset) {
                        return last;
                    }
                    last = string.Join(' ', split.Skip(1));
                }
                return last;
            }
            catch (Exception ex) {
                ChoriziteStatics.Log.LogError($"Failed to resolve ACClient symbol: {ex.Message}");
                return "unknown";
            }
        }

        private static string? ResolveUsingClrMd(ulong address) {
            try {
                InitializeClrRuntime();

                if (_runtime == null)
                    return null;

                // Try to find the method containing this address
                ClrMethod? method = _runtime.GetMethodByInstructionPointer(address);
                if (method != null) {
                    // Get source information if available
                    string sourceInfo = GetSourceFromPdb(method, address);
                    if (!string.IsNullOrEmpty(sourceInfo)) {
                        return $"{method.Type.Name}.{method.Name} at {sourceInfo}";
                    }

                    return $"{method.Type.Name}.{method.Name}";
                }

                return null;
            }
            catch {
                // Fall back to other methods if ClrMD fails
                return null;
            }
        }

        private static void InitializeClrRuntime() {
            if (_runtimeInitialized)
                return;

            lock (_runtimeLock) {
                if (_runtimeInitialized)
                    return;

                try {
                    int currentProcessId = Process.GetCurrentProcess().Id;
                    DataTarget dataTarget = DataTarget.AttachToProcess(currentProcessId, false);

                    ClrInfo? clrInfo = dataTarget.ClrVersions.FirstOrDefault();
                    if (clrInfo != null) {
                        _runtime = clrInfo.CreateRuntime();
                    }
                }
                catch (Exception ex) {
                    ChoriziteStatics.Log.LogError($"Failed to initialize ClrMD: {ex.Message}");
                }
                finally {
                    _runtimeInitialized = true;
                }
            }
        }

        private static bool IsDotNetModule(string fileName) {
            try {
                if (string.IsNullOrEmpty(fileName))
                    return false;

                // First check file extension
                string? ext = Path.GetExtension(fileName)?.ToLowerInvariant();
                if (string.IsNullOrEmpty(ext) || (ext != ".dll" && ext != ".exe"))
                    return false;

                // More accurate check - try to load as assembly and check metadata
                try {
                    // Don't actually load the assembly, just check if it has the right metadata
                    AssemblyName.GetAssemblyName(fileName);
                    return true;
                }
                catch (BadImageFormatException) {
                    // If it's a bad image, it's likely not a .NET assembly
                    return false;
                }
                catch {
                    // On any other error, fall back to assuming it might be .NET
                    return true;
                }
            }
            catch {
                return false;
            }
        }

        private static MethodBase? GetMethodFromAddress(ulong address) {
            try {
                // Check cache first
                lock (MethodCache) {
                    if (MethodCache.TryGetValue(address, out MethodBase? cachedMethod)) {
                        return cachedMethod;
                    }
                }

                // Use RuntimeMethodHandle to find the method
                // This part is tricky and requires enumerating loaded methods
                // to find ones that match the address range

                // For all loaded assemblies
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                    try {
                        // For all types in the assembly
                        foreach (Type type in assembly.GetTypes()) {
                            // Check all methods of the type
                            foreach (MethodInfo method in type.GetMethods(BindingFlags.Public |
                                                                         BindingFlags.NonPublic |
                                                                         BindingFlags.Static |
                                                                         BindingFlags.Instance)) {
                                try {
                                    // Prepare method to get it JIT-compiled
                                    RuntimeHelpers.PrepareMethod(method.MethodHandle);

                                    // Get method start address
                                    IntPtr methodStart = method.MethodHandle.GetFunctionPointer();
                                    ulong methodStartAddr = (ulong)methodStart.ToInt64();

                                    // We don't know the method size, so we'll use a heuristic
                                    // Assume methods are reasonably sized (e.g., less than 2KB)
                                    // This is a big simplification and won't work perfectly
                                    const ulong MAX_METHOD_SIZE = 2048;

                                    if (address >= methodStartAddr && address < methodStartAddr + MAX_METHOD_SIZE) {
                                        // Found a potential match - cache and return
                                        lock (MethodCache) {
                                            MethodCache[address] = method;
                                        }
                                        return method;
                                    }
                                }
                                catch {
                                    // Skip methods that can't be analyzed
                                    continue;
                                }
                            }
                        }
                    }
                    catch {
                        // Skip assemblies that can't be analyzed
                        continue;
                    }
                }

                return null;
            }
            catch {
                return null;
            }
        }

        private static string GetSourceLocation(MethodBase method) {
            try {
                // Try to get sequence points using System.Reflection.Metadata
                // This requires additional NuGet packages for PDB reading

                // For simplicity, let's use the StackTrace class
                StackFrame frame = new StackFrame(0, true);
                if (frame.GetFileName() != null) {
                    return $"{Path.GetFileName(frame.GetFileName())}:{frame.GetFileLineNumber()}";
                }

                return string.Empty;
            }
            catch {
                return string.Empty;
            }
        }

        private static string GetSourceFromPdb(ClrMethod method, ulong address) {
            try {
                // Try to get source info using ClrMD

                // Find corresponding PDB file
                string? pdbPath = Path.ChangeExtension(method.Type.Module.Name, ".pdb");
                if (string.IsNullOrWhiteSpace(pdbPath) || !File.Exists(pdbPath))
                    return string.Empty;

                // Convert address to IL offset
                uint ilOffset = (uint)method.GetILOffset(address);

                // Get source line info from PDB
                // This would require a PDB reader library like Microsoft.DiaSymReader
                // For now, just return the IL offset
                return $"IL_0x{ilOffset:x4}";
            }
            catch {
                return string.Empty;
            }
        }

        // Helper to convert .NET string to native char*
        private static IntPtr StringToNative(string str) {
            if (string.IsNullOrEmpty(str)) {
                return IntPtr.Zero;
            }

            lock (BufferLock) {
                Buffer.Clear();
                Buffer.Append(str);

                // Return a pointer to the buffer that will be valid until next call
                return Marshal.StringToHGlobalAnsi(Buffer.ToString());
            }
        }
        public static void RegisterWithNativeCrashHandler() {
            try {
                // Create the delegate
                ResolveSymbolDelegate resolver = ResolveSymbol;
                // Keep the delegate alive (important!)
                GC.KeepAlive(resolver);
                // Get a function pointer to the delegate
                IntPtr resolverPtr = Marshal.GetFunctionPointerForDelegate(resolver);
                // Call the native function to register
                RegisterManagedSymbolResolver(resolverPtr);

                ResolveExtraInfoDelegate extraInfoResolver = ResolveExtraInfo;
                GC.KeepAlive(extraInfoResolver);
                IntPtr extraInfoResolverPtr = Marshal.GetFunctionPointerForDelegate(extraInfoResolver);
                RegisterManagedExtraInfoResolver(extraInfoResolverPtr);

            }
            catch (Exception ex) {
                ChoriziteStatics.Log.LogError($"Failed to register managed symbol resolver: {ex.Message}");
            }
        }

        public static void UnregisterWithNativeCrashHandler() {
            RegisterManagedSymbolResolver(IntPtr.Zero);
            RegisterManagedExtraInfoResolver(IntPtr.Zero);
        }

        // Import the native function
        [DllImport("Chorizite.Injector.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RegisterManagedSymbolResolver(IntPtr resolverFunc);

        // Import the native function
        [DllImport("Chorizite.Injector.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RegisterManagedExtraInfoResolver(IntPtr resolverFunc);
    }
}
