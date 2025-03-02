using Autofac;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Chorizite.Common;
using Chorizite.Core.Lib;

namespace Chorizite.Core.Plugins {
    /// <summary>
    /// Represents an instance of a plugin.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PluginInstance<T> : PluginInstance where T : PluginManifest {
        /// <summary>
        /// The manifest
        /// </summary>
        public new T Manifest { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manifest"></param>
        /// <param name="serviceProvider"></param>
        public PluginInstance(T manifest, ILifetimeScope serviceProvider) : base(manifest, serviceProvider) {
            Manifest = manifest;
        }

        /// <summary>
        /// Initialize the plugin
        /// </summary>
        public override void Initialize() {

        }

        /// <summary>
        /// Update the manifest
        /// </summary>
        internal override void UpdateManifest() {

        }
    }

    /// <summary>
    /// Represents an instance of a plugin.
    /// </summary>
    public abstract class PluginInstance {
        /// <summary>
        /// The service provider
        /// </summary>
        protected ILifetimeScope _serviceProvider;

        /// <summary>
        /// The logger
        /// </summary>
        protected ILogger _log;

        /// <summary>
        /// The file watcher
        /// </summary>
        protected FileWatcher FileWatcher;

        /// <summary>
        /// The id of this plugin
        /// </summary>
        public string Id => Manifest.Id;

        /// <summary>
        /// The display name of this plugin
        /// </summary>
        public string DisplayName => Manifest.Name;

        /// <summary>
        /// Wether to enable live reloading for this plugin. It will live reload when the files changes on disk.
        /// </summary>
        public bool LiveReload { get; set; } = true;

        /// <summary>
        /// True if the plugin is loaded.
        /// </summary>
        public bool IsLoaded { get; protected set; }

        /// <summary>
        /// Wether the plugin wants to be reloaded. It is up to the PluginManager to reload it and all dependent plugins.
        /// </summary>
        public bool WantsReload { get; protected set; }

        /// <summary>
        /// The plugin instance.
        /// </summary>
        public abstract object? Instance { get; }

        /// <summary>
        /// The plugin manifest.
        /// </summary>
        public PluginManifest Manifest { get; }

        /// <summary>
        /// The plugin dev manifest.
        /// </summary>
        public PluginDevManifest? DevManifest { get; }

        /// <summary>
        /// Fired directly before the plugin will be loaded.
        /// </summary>
        public event EventHandler<EventArgs> OnBeforeLoad {
            add { _OnBeforeLoad.Subscribe(value); }
            remove { _OnBeforeLoad.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnBeforeLoad = new WeakEvent<EventArgs>();

        /// <summary>
        /// Fired directly after the plugin has been loaded.
        /// </summary>
        public event EventHandler<EventArgs> OnLoad {
            add { _OnLoad.Subscribe(value); }
            remove { _OnLoad.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnLoad = new WeakEvent<EventArgs>();

        /// <summary>
        /// Fired before the plugin is unloaded, during a live reload.
        /// </summary>
        public event EventHandler<EventArgs> OnBeforeReload {
            add { _OnBeforeReload.Subscribe(value); }
            remove { _OnBeforeReload.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnBeforeReload = new WeakEvent<EventArgs>();

        /// <summary>
        /// Fired before the plugin is unloaded, during a live reload.
        /// </summary>
        public event EventHandler<EventArgs> OnAfterReload {
            add { _OnAfterReload.Subscribe(value); }
            remove { _OnAfterReload.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnAfterReload = new WeakEvent<EventArgs>();

        /// <summary>
        /// Fired after this plugin has been unloaded.
        /// </summary>
        public event EventHandler<EventArgs> OnBeforeUnload {
            add { _OnBeforeUnload.Subscribe(value); }
            remove { _OnBeforeUnload.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnBeforeUnload = new WeakEvent<EventArgs>();

        /// <summary>
        /// Fired after this plugin has been unloaded.
        /// </summary>
        public event EventHandler<EventArgs> OnUnload {
            add { _OnUnload.Subscribe(value); }
            remove { _OnUnload.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnUnload = new WeakEvent<EventArgs>();


        /// <summary>
        /// Fired when the plugin requests a reload.
        /// </summary>
        public event EventHandler<EventArgs> OnRequestReload {
            add { _OnRequestReload.Subscribe(value); }
            remove { _OnRequestReload.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnRequestReload = new WeakEvent<EventArgs>();

        /// <summary>
        /// Create a new plugin instance from a manifest
        /// </summary>
        /// <param name="manifest">The plugin manigest</param>
        /// <param name="serviceProvider"></param>
        /// <param name="configure">A configuration callback that allows you to configure advanced options</param>
        public PluginInstance(PluginManifest manifest, ILifetimeScope serviceProvider, Action<PluginInstance>? configure = null) {
            _serviceProvider = serviceProvider;
            Manifest = manifest;

            if (PluginDevManifest.TryLoadManifest(Path.Combine(Manifest.BaseDirectory, "manifest.dev.json"), out var devManifest, out string? errors)) {
                DevManifest = devManifest;
            }

            FileWatcher = new FileWatcher(Manifest.BaseDirectory, Manifest.EntryFile, (file) => {
                WantsReload = true;
            });

            _log = _serviceProvider.Resolve<ILogger<PluginInstance>>();
            configure?.Invoke(this);
        }

        internal abstract void UpdateManifest();

        /// <summary>
        /// Load the plugin.
        /// </summary>
        /// <returns></returns>
        public virtual bool Load() {
            WantsReload = false;
            return true;
        }

        /// <summary>
        /// Unload the plugin.
        /// </summary>
        /// <returns></returns>
        public virtual bool Unload(bool isReloading) {
            return true;
        }

        #region Event triggers
        /// <summary>
        /// Trigger the <see cref="OnBeforeLoad"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnBeforeLoad(object sender, EventArgs e) {
            _OnBeforeLoad?.Invoke(sender, e);
        }

        /// <summary>
        /// Trigger the <see cref="OnLoad"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnLoad(object sender, EventArgs e) {
            _OnLoad?.Invoke(sender, e);
        }

        /// <summary>
        /// Trigger the <see cref="OnBeforeReload"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnBeforeReload(object sender, EventArgs e) {
            _OnBeforeReload?.Invoke(sender, e);
        }

        /// <summary>
        /// Trigger the <see cref="OnAfterReload"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnAfterReload(object sender, EventArgs e) {
            _OnAfterReload?.Invoke(sender, e);
        }

        /// <summary>
        /// Trigger the <see cref="OnBeforeUnload"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnBeforeUnload(object sender, EventArgs e) {
            _OnBeforeUnload?.Invoke(sender, e);
        }

        /// <summary>
        /// Trigger the <see cref="OnUnload"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TriggerOnUnload(object sender, EventArgs e) {
            _OnUnload?.Invoke(sender, e);
        }
        #endregion // Event Triggers

        /// <summary>
        /// Initialize the plugin
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Dispose
        /// </summary>
        public virtual void Dispose() {
            Unload(true);
            FileWatcher?.Dispose();
        }
    }
}
