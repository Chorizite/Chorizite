using Autofac;
using Decal.Adapter;
using MagicHat.Service.Lib.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Service.Lib.Plugins {

    public class PluginInstance<T> : PluginInstance where T : PluginManifest {
        public new T Manifest { get; }

        public PluginInstance(T manifest, IContainer serviceProvider) : base(manifest, serviceProvider) {
            Manifest = manifest;
        }
    }

    /// <summary>
    /// Represents an instance of a plugin.
    /// </summary>
    public class PluginInstance {
        protected ILifetimeScope _serviceProvider;
        protected ILogger _log;

        /// <summary>
        /// The name of this plugin. Can be overriden with the configure callback during instantiation.
        /// </summary>
        public string Name => Manifest.Name;

        /// <summary>
        /// Wether to enable live reloading for this plugin. It will live reload when the files changes on disk.
        /// </summary>
        public bool LiveReload { get; set; } = true;

        /// <summary>
        /// True if the plugin is loaded.
        /// </summary>
        public bool IsLoaded { get; protected set; }

        /// <summary>
        /// The plugin manifest.
        /// </summary>
        public PluginManifest Manifest { get; }

        /// <summary>
        /// Fired directly before the plugin will be loaded.
        /// </summary>
        public event EventHandler<EventArgs>? OnBeforeLoad;

        /// <summary>
        /// Fired directly after the plugin has been loaded.
        /// </summary>
        public event EventHandler<EventArgs>? OnLoad;

        /// <summary>
        /// Fired before the plugin is unloaded, during a live reload.
        /// </summary>
        public event EventHandler<EventArgs>? OnBeforeReload;

        /// <summary>
        /// Fired before the plugin is unloaded, during a live reload.
        /// </summary>
        public event EventHandler<EventArgs>? OnAfterReload;

        /// <summary>
        /// Fired after this plugin has been unloaded.
        /// </summary>
        public event EventHandler<EventArgs>? OnBeforeUnload;

        /// <summary>
        /// Fired after this plugin has been unloaded.
        /// </summary>
        public event EventHandler<EventArgs>? OnUnload;

        /// <summary>
        /// Create a new plugin instance from a manifest
        /// </summary>
        /// <param name="manifest">The plugin manigest</param>
        /// <param name="serviceProvider"></param>
        /// <param name="configure">A configuration callback that allows you to configure advanced options</param>
        public PluginInstance(PluginManifest manifest, IContainer serviceProvider, Action<PluginInstance>? configure = null) {
            _serviceProvider = serviceProvider;
            Manifest = manifest;

            _log = _serviceProvider.Resolve<ILogger<PluginInstance>>();
            configure?.Invoke(this);
        }

        /// <summary>
        /// Load the plugin.
        /// </summary>
        /// <returns></returns>
        public virtual bool Load() {
            return true;
        }

        /// <summary>
        /// Unload the plugin.
        /// </summary>
        /// <returns></returns>
        public virtual bool Unload() {
            return true;
        }

        #region Event triggers
        /// <summary>
        /// Trigger the <see cref="OnBeforeLoad"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnBeforeLoad(object sender, EventArgs e) {
            OnBeforeLoad?.Invoke(sender, e);
        }

        /// <summary>
        /// Trigger the <see cref="OnLoad"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnLoad(object sender, EventArgs e) {
            OnLoad?.Invoke(sender, e);
        }

        /// <summary>
        /// Trigger the <see cref="OnBeforeReload"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnBeforeReload(object sender, EventArgs e) {
            OnBeforeReload?.Invoke(sender, e);
        }

        /// <summary>
        /// Trigger the <see cref="OnAfterReload"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnAfterReload(object sender, EventArgs e) {
            OnAfterReload?.Invoke(sender, e);
        }

        /// <summary>
        /// Trigger the <see cref="OnBeforeUnload"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnBeforeUnload(object sender, EventArgs e) {
            OnBeforeUnload?.Invoke(sender, e);
        }

        /// <summary>
        /// Trigger the <see cref="OnUnload"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnUnload(object sender, EventArgs e) {
            OnUnload?.Invoke(sender, e);
        }
        #endregion // Event Triggers

        public virtual void Dispose() {
            Unload();
        }
    }
}
