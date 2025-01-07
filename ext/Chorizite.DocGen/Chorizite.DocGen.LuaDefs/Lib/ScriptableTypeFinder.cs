using Chorizite.Core;
using Chorizite.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.DocGen.LuaDefs.Lib {
    public class ScriptableTypeFinder {
        private string _chorizitePath;
        private string _outPath;

        public ScriptableTypeFinder(IChoriziteConfig config) {
            _chorizitePath = chorizitePath;
            _outPath = Path.Combine(_chorizitePath, "Lua", "defs");

            if (!Directory.Exists(_outPath)) {
                Directory.CreateDirectory(_outPath);
            }

            var x = new PluginManager();
        }

        internal void GenerateCoreDocs() {
            
        }

        internal void GeneratePluginDocs() {
            var pluginDir = Path.Combine(_chorizitePath, "plugins");
            foreach (var dir in Directory.GetDirectories(pluginDir)) {

            }
        }
    }
}
