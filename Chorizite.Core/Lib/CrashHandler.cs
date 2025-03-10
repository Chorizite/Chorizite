using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.NativeClientBootstrapper.Lib {
        internal class ManagedCrashHandler {
            // Native method imports
            [DllImport("Chorizite.Injector.dll", CallingConvention = CallingConvention.Cdecl)]
            private static extern void RegisterManagedCrashHandler();

            // Singleton pattern
            private static ManagedCrashHandler? _instance;
            private static readonly object _lock = new object();

            public static ManagedCrashHandler Instance {
                get {
                    if (_instance == null) {
                        lock (_lock) {
                            if (_instance == null) {
                                _instance = new ManagedCrashHandler();
                            }
                        }
                    }
                    return _instance;
                }
            }

            // Event for custom exception handling
            public event EventHandler<UnhandledExceptionEventArgs>? CrashDetected;

            private bool _initialized = false;

            private ManagedCrashHandler() {
            }

            public void Initialize() {
                if (_initialized)
                    return;

                // Register with native crash handler
                RegisterManagedCrashHandler();

                // Set up managed exception handlers
                //AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
                //TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

                // For .NET Core 3.0+ we can also use the following:
                // AppDomain.CurrentDomain.FirstChanceException += OnFirstChanceException;

                _initialized = true;
            }

            private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e) {
                try {
                    Exception? ex = e.ExceptionObject as Exception;
                    if (ex != null) {
                        // Log managed exception details
                        LogManagedException(ex, "UnhandledException");

                        // Notify any subscribers
                        CrashDetected?.Invoke(this, e);
                    }
                }
                catch {
                    // Failsafe - ensure we don't throw from our exception handler
                }
            }

            private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e) {
                try {
                    if (e.Exception != null) {
                        // Log Task exception details
                        LogManagedException(e.Exception, "UnobservedTaskException");

                        // Mark as observed to prevent process termination
                        e.SetObserved();
                    }
                }
                catch {
                    // Failsafe
                }
            }

            // For .NET Core 3.0+
            private void OnFirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e) {
                // Only log certain exceptions of interest
                if (ShouldCaptureFirstChanceException(e.Exception)) {
                    LogManagedException(e.Exception, "FirstChanceException", true);
                }
            }

            private bool ShouldCaptureFirstChanceException(Exception ex) {
                // Decide which first-chance exceptions are worth logging
                // Typically we only care about severe exceptions
                return ex is AccessViolationException ||
                       ex is StackOverflowException ||
                       ex is OutOfMemoryException;
            }

            private void LogManagedException(Exception ex, string source, bool isFirstChance = false) {
                try {
                    string dumpDir = Path.Combine(@"C:\CrashDumps\");

                    Directory.CreateDirectory(dumpDir);

                    string logFile = Path.Combine(
                        dumpDir,
                        $"managed_exception_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

                    using (StreamWriter writer = new StreamWriter(logFile)) {
                        writer.WriteLine($"Managed Exception Report ({source})");
                        writer.WriteLine("=======================================");
                        writer.WriteLine();
                        writer.WriteLine($"Time: {DateTime.Now}");
                        writer.WriteLine($"Is First Chance: {isFirstChance}");
                        writer.WriteLine();

                        writer.WriteLine("Exception Details:");
                        writer.WriteLine($"  Type: {ex.GetType().FullName}");
                        writer.WriteLine($"  Message: {ex.Message}");
                        writer.WriteLine($"  Source: {ex.Source}");
                        writer.WriteLine();

                        writer.WriteLine("Stack Trace:");
                        WriteEnhancedStackTrace(writer, ex);

                        writer.WriteLine();
                        writer.WriteLine("Additional Information:");
                        writer.WriteLine($"  AppDomain: {AppDomain.CurrentDomain.FriendlyName}");
                        writer.WriteLine($"  Base Directory: {AppDomain.CurrentDomain.BaseDirectory}");
                        writer.WriteLine($"  Runtime Version: {Environment.Version}");
                        writer.WriteLine($"  Process ID: {Process.GetCurrentProcess().Id}");
                        writer.WriteLine($"  Thread ID: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                    }
                }
                catch {
                    // Failsafe
                }
            }

            private void WriteEnhancedStackTrace(StreamWriter writer, Exception ex) {
                if (ex == null) return;

                // Use reflection or a stack trace enhancer library to get IL offsets and more detailed source info
                StackTrace trace = new StackTrace(ex, true);

                for (int i = 0; i < trace.FrameCount; i++) {
                    StackFrame? frame = trace.GetFrame(i);
                    MethodBase? method = frame?.GetMethod();

                    if (method != null) {
                        writer.Write($"  {method.DeclaringType?.FullName ?? "Unknown"}.{method.Name}(");

                        // Parameters
                        ParameterInfo[] parameters = method.GetParameters();
                        for (int p = 0; p < parameters.Length; p++) {
                            writer.Write($"{parameters[p].ParameterType.Name} {parameters[p].Name}");
                            if (p < parameters.Length - 1) writer.Write(", ");
                        }

                        writer.Write(")");

                        // Source file info
                        if (frame?.GetFileName() != null) {
                            writer.Write($" in {frame.GetFileName()}:line {frame.GetFileLineNumber()}");
                            if (frame.GetFileColumnNumber() > 0) {
                                writer.Write($" col {frame.GetFileColumnNumber()}");
                            }
                        }

                        // IL offset
                        writer.Write($" IL offset: 0x{frame?.GetILOffset():X}");

                        writer.WriteLine();
                    }
                    else {
                        writer.WriteLine($"  <Unknown Method>");
                    }
                }

                // Handle inner exceptions
                if (ex.InnerException != null) {
                    writer.WriteLine();
                    writer.WriteLine($"Inner Exception ({ex.InnerException.GetType().Name}):");
                    WriteEnhancedStackTrace(writer, ex.InnerException);
                }

                // Handle aggregate exceptions
                if (ex is AggregateException aex) {
                    int index = 0;
                    foreach (var innerEx in aex.InnerExceptions) {
                        writer.WriteLine();
                        writer.WriteLine($"Aggregate Exception [{index++}] ({innerEx.GetType().Name}):");
                        WriteEnhancedStackTrace(writer, innerEx);
                    }
                }
            }
        }
}
