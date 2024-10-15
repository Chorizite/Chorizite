using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Chorizite.Injector {

    internal static class Program {
        public class Options {
            [Option('i', "inject", Required = false, HelpText = "Assemblies to inject")]
            public IEnumerable<string>? InjectFiles { get; set; }

            [Option('c', "client-path", Required = false, HelpText = "Path to acclient.exe", Default = @"C:\Turbine\Asheron's Call\acclient.exe")]
            public string? ClientPath { get; set; }

            [Option('a', "client-args", Required = false, HelpText = "Arguments to pass to acclient.exe")]
            public string? ClientArgs { get; set; }
        }

        [DllImport("Chorizite.Bootstrapper.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern int LaunchInjected(string command_line, string working_directory, IntPtr entryPts, int numEntries);

        static void Main(string[] args) {
            Parser.Default.ParseArguments<Options>(args)
               .WithParsed<Options>(o => {
                   Console.WriteLine($"Running");
                   var entryPointParams = o.InjectFiles?.Select(file => {
                       var assemblyFile = file.Split(';').First();
                       var entryPoint = file.Split(';').LastOrDefault() ?? "";
                       return new EntryPointParameters(assemblyFile, entryPoint);
                   }).ToArray() ?? [];

                   if (o.ClientPath is null || !File.Exists(o.ClientPath)) {
                       Console.WriteLine($"Could not find acclient at: {o.ClientPath}");
                       return;
                   }

                   if (o.ClientArgs is null) {
                       Console.WriteLine("No client args specified");
                       return;
                   }

                   LaunchClient(o.ClientPath, o.ClientArgs, entryPointParams);
               });
        }

        private unsafe static void LaunchClient(string clientPath, string clientArgs, EntryPointParameters[] entryPointParams) {
            var dir = Path.GetDirectoryName(typeof(Program).Assembly.Location) ?? Environment.CurrentDirectory;

            var cbase = Marshal.AllocHGlobal(entryPointParams.Length * sizeof(EntryPointParameters));
            var ccur = cbase;
            for (int i = 0; i < entryPointParams.Length; i++, ccur += sizeof(EntryPointParameters)) {
                Console.WriteLine($"Injecting: {entryPointParams[i].dll_path} {entryPointParams[i].entry_point}");
                Marshal.StructureToPtr(entryPointParams[i], ccur, false);
            }

            LaunchInjected($"{clientPath} {clientArgs}", Path.GetDirectoryName(clientPath)!, cbase, entryPointParams.Length);
            Marshal.FreeHGlobal(cbase);
        }
    }
}