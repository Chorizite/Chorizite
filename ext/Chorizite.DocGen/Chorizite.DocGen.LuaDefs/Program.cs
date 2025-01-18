using Chorizite.Core;
using Chorizite.Core.Logging;
using Chorizite.DocGen.LuaDefs.Lib;
using Microsoft.Extensions.Logging;

namespace Chorizite.DocGen.LuaDefs {
    internal class Program {
        public static Chorizite<DocGenBackend> Chorizite { get; private set; }
        public static ChoriziteLogger Log { get; private set; }

        private static ScriptableTypeFinder _typeFinder;

        static void Main(string[] args) {
            var baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "..", "..", "bin", "net8.0");
            var datDirectory = @"C:\Turbine\Asheron's Call\";

            if (!Directory.Exists(datDirectory)) {
                throw new Exception("Dat directory not found: " + datDirectory);
            }

            if (!Directory.Exists(baseDirectory)) {
                throw new Exception($"Base directory not found: " + baseDirectory);
            }

            var config = new ChoriziteConfig(ChoriziteEnvironment.DocGen, baseDirectory, datDirectory);

            Log = new ChoriziteLogger("DocGen", config.LogDirectory);
            Chorizite = new Chorizite<DocGenBackend>(config);

            _typeFinder = new ScriptableTypeFinder(Chorizite, Log);

            var luaGen = new LuaDefsGenerator(Chorizite, Log, _typeFinder);
        }
    }
}
