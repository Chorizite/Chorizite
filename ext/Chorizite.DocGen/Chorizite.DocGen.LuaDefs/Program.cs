using Chorizite.DocGen.LuaDefs.Lib;

namespace Chorizite.DocGen.LuaDefs {
    internal class Program {
        private static ScriptableTypeFinder _typeFinder;

        static void Main(string[] args) {
            _typeFinder = new ScriptableTypeFinder(@"D:\projects\Chorizite\bin\net8.0");

            _typeFinder.GenerateCoreDocs();
            _typeFinder.GeneratePluginDocs();
        }
    }
}
