using Autofac;
using Chorizite.Core;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.DocGen.LuaDefs.Lib.models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Chorizite.DocGen.LuaDefs.Lib {
    public class ScriptableTypeFinder {
        private Chorizite<DocGenBackend> _chorizite;
        private string _chorizitePath;

        public CoreTypeRegistry CoreRegistry { get; private set; }
        public SystemTypeRegistry SystemRegistry { get; private set; }
        public Dictionary<string, PluginTypeRegistry> PluginRegistry { get; } = [];

        public ScriptableTypeFinder(Chorizite<DocGenBackend> chorizite, ILogger log) {
            _chorizite = chorizite;
            _chorizitePath = chorizite.Config.BaseDirectory;

            Init();
        }

        private void Init() {
            SystemRegistry = new SystemTypeRegistry(_chorizite, this);
            CoreRegistry = new CoreTypeRegistry(_chorizite, this);
            LoadPluginTypes();
        }

        internal void LoadPluginTypes() {
            var pluginManager = _chorizite.Scope.Resolve<IPluginManager>();
            pluginManager.LoadPlugins();
            foreach (var plugin in pluginManager.PluginManifests) {
                Console.WriteLine($"Loading types for plugin: {plugin.Id}");
                try {
                    PluginRegistry.Add(plugin.Id, new PluginTypeRegistry(this, _chorizite, plugin));
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error loading types for plugin: {plugin.Id}");
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        internal Def? GetTypeDef(Type propertyType) {
            var id = propertyType.GetXMLDocId();

            if (SystemRegistry.Definitions.TryGetValue(id, out var def)) return def;
            if (CoreRegistry.Definitions.TryGetValue(id, out def)) return def;

            foreach (var plugin in PluginRegistry.Values) {
                if (plugin.Definitions.TryGetValue(id, out def)) return def;
            }

            return null;
        }
    }
}
