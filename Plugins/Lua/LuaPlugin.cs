using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO.Compression;
using Autofac;
using System.Collections.Generic;
using Chorizite.Core.Backend.Client;
using Chorizite.Core.Backend;
using Chorizite.Core.Backend.Launcher;
using Chorizite.Core.Net;
using Chorizite.Core.Render;
using Chorizite.Core.Input;
using Chorizite.Core.Dats;

namespace Lua {
    public class LuaPluginCore : IPluginCore {
        internal static ILogger Log;
        internal readonly ILifetimeScope Scope;
        internal readonly IChoriziteBackend Backend;
        internal readonly Dictionary<string, object> LuaModules = [];

        public LuaContext Context { get; private set; }

        protected LuaPluginCore(AssemblyPluginManifest manifest, IChoriziteBackend backend, ILifetimeScope scope, ILogger log) : base(manifest) {
            Log = log;
            Scope = scope;
            Backend = backend;
        }

        protected override void Initialize() {
            Context = new LuaContext(this, Log);

            RegisterLuaModule("Backend", Backend);
            RegisterLuaModule("Renderer", Scope.Resolve<IRenderInterface>());
            RegisterLuaModule("InputManager", Scope.Resolve<IInputManager>());
            RegisterLuaModule("PluginManager", Scope.Resolve<IPluginManager>());
            RegisterLuaModule("DatReader", Scope.Resolve<IDatReaderInterface>());

            if (Backend.Environment.HasFlag(ChoriziteEnvironment.Client)) {
                RegisterLuaModule("ClientBackend", Scope.Resolve<IClientBackend>());
                RegisterLuaModule("NetworkParser", Scope.Resolve<NetworkParser>());
            }

            if (Backend.Environment.HasFlag(ChoriziteEnvironment.Launcher)) {
                RegisterLuaModule("LauncherBackend", Scope.Resolve<ILauncherBackend>());
            }

            Backend.Renderer.OnRender2D += OnRender2D;
        }

        #region Public API
        /// <summary>
        /// Register a lua module
        /// </summary>
        /// <param name="name"></param>
        /// <param name="module"></param>
        public virtual bool RegisterLuaModule(string name, object module) {
            if (!LuaModules.TryAdd(name, module)) {
                Log.LogWarning($"Failed to register lua module: {name}. Already exists with value: {LuaModules[name]}");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Unregister a lua module
        /// </summary>
        /// <param name="name"></param>
        public virtual bool UnregisterLuaModule(string name) => LuaModules.Remove(name);
        #endregion //Public API

        private void OnRender2D(object? sender, EventArgs e) {
            try {
                LuaContext.UpdateAll();
            }
            catch (Exception ex) {
                Log?.LogError(ex, "Error in OnRender2D");
            }
        }

        protected override void Dispose() {
            Backend.Renderer.OnRender2D -= OnRender2D;
            Context?.Dispose();
        }
    }
}
