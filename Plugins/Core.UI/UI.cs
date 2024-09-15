using ACClientLib.DatReaderWriter;
using ACUI.Lib;
using ACUI.Lib.Input;
using ACUI.Lib.RmlUi;
using MagicHat.Service.Lib;
using MagicHat.Service.Lib.Events;
using MagicHat.Service.Lib.Plugins;
using Microsoft.DirectX.Direct3D;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI {
    /// <summary>
    /// UI replacement system
    /// </summary>
    public class UI {
        private Device? _device;
        private DX9RenderInterface? _renderInterface;
        private ACSystemInterface? _systemInterface;
        private bool _didInit;
        private Context? _ctx;
        private ElementDocument? _doc;

        internal PluginManager? PluginManager;
        internal IBackendProvider Backend;
        internal ILogger? Log;
        internal int _id = new Random().Next(1000);

        internal InputManager InputManager { get; private set; }
        public PanelManager? PanelManager { get; private set; }

        public static UI Instance { get; private set; }
        public DatDatabaseReader PortalDat { get; }

        public UI() {
            Instance = this;

            PortalDat = new DatDatabaseReader(options => {
                options.FilePath = $"client_Portal.dat";
                options.IndexCachingStrategy = ACClientLib.DatReaderWriter.Options.IndexCachingStrategy.Upfront;
            });
        }

        internal void Init(PluginManager pluginManager, IBackendProvider backend, ILogger? logger) {
            PluginManager = pluginManager;
            Backend = backend;
            _device = Backend?.GetD3DDevice();
            Log = logger;

            logger?.LogTrace($"Initializing UI {Rml.Test()}");

            if (Backend is null) {
                throw new Exception($"IBackendProvider is null");
            }
            if (_device is null) {
                throw new Exception($"D3D device is null");
            }

            _renderInterface = new DX9RenderInterface(_device, pluginManager, logger);
            _systemInterface = new ACSystemInterface(logger);

            Rml.SetSystemInterface(_systemInterface);
            Rml.SetRenderInterface(_renderInterface);

            var size = new Vector2i(_device.Viewport.Width, _device.Viewport.Height);
            logger?.LogTrace($"Window size: {size.X}x{size.Y}");

            if (Rml.Initialise()) {
                _didInit = true;
                _ctx = Rml.CreateContext("viewport", new Vector2i(size.X, size.Y));

                if (_ctx is null) {
                    throw new Exception("Unable to create RmlUi context");
                }

                InputManager = new InputManager(_ctx, Log);
                PanelManager = new PanelManager(_ctx, Log);

                Backend.OnWindowMessage += Backend_OnWindowMessage;

                //Debugger.Initialise(_ctx);
                //Debugger.SetVisible(true);

                Backend.OnRender2D += Backend_OnRender2D;
            }
        }

        private void Backend_OnWindowMessage(object sender, WindowMessageEventArgs e) {
            if (_ctx is null) return;

            e.Eat = InputManager.HandleWindowMessage(e);
        }

        private void Backend_OnRender2D(object sender, EventArgs e) {
            PanelManager?.Update();
            _ctx?.Update();

            _renderInterface?.BeginFrame();
            _ctx?.Render();
        }

        internal void Dispose() {
            if (Backend is not null) {
                Backend.OnRender2D -= Backend_OnRender2D;
                Backend.OnWindowMessage -= Backend_OnWindowMessage;
            }

            PanelManager?.Dispose();

            if (_didInit) {
                Rml.Shutdown();
            }
            _renderInterface?.Dispose();
            _systemInterface?.Dispose();

            PortalDat?.Dispose();

            _didInit = false;
        }
    }
}
