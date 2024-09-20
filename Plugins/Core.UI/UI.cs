using ACClientLib.DatReaderWriter;
using ACUI.Lib;
using ACUI.Lib.Input;
using ACUI.Lib.RmlUi;
using Core.DatService;
using Core.UI.Lib.RmlUi;
using MagicHat.Core.Input;
using MagicHat.Core.Plugins;
using MagicHat.Core.Plugins.AssemblyLoader;
using MagicHat.Core.Render;
using MagicHat.Service.Lib;
using MagicHat.Service.Lib.Input;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI {
    /// <summary>
    /// UI replacement system
    /// </summary>
    public class UI {
        private TestPlugin _testPlugin;
        private RmlUIRenderInterface? _renderInterface;
        private ACSystemInterface? _systemInterface;
        private TestElementInstancer _instancer;
        private bool _didInit;
        private Context? _ctx;
        private RmlInputManager _rmlInput;
        private ElementDocument? _doc;
        private readonly AssemblyPluginManifest _manifest;

        internal IPluginManager? PluginManager;
        private IRenderInterface _renderer;
        internal ILogger? Log;
        private CoreDatService? _datService;

        public PanelManager? PanelManager { get; private set; }

        public static UI Instance { get; private set; }

        public UI(AssemblyPluginManifest manifest) {
            _manifest = manifest;
            Instance = this;
        }

        internal void Init(IPluginManager pluginManager, IRenderInterface renderer, IInputManager input, ILogger? logger) {
            PluginManager = pluginManager;
            _renderer = renderer;
            Log = logger;

            logger?.LogTrace($"Initializing UI");

            _testPlugin = new TestPlugin(logger);
            _renderInterface = new RmlUIRenderInterface(_renderer);
            _systemInterface = new ACSystemInterface(logger);

            Rml.SetSystemInterface(_systemInterface);
            Rml.SetRenderInterface(_renderInterface);

            var size = new Vector2i((int)_renderer.ViewportSize.X, (int)_renderer.ViewportSize.Y);
            logger?.LogTrace($"Window size: {size.X}x{size.Y}");

            if (Rml.Initialise()) {
                Rml.RegisterPlugin(_testPlugin);
                _instancer = new TestElementInstancer(logger);
                _didInit = true;
                _ctx = Rml.CreateContext("viewport", size);
                _rmlInput = new RmlInputManager(input, _ctx, Log);

                if (_ctx is null) {
                    throw new Exception("Unable to create RmlUi context");
                }

                PanelManager = new PanelManager(_ctx, Log);

                Rml.LoadFontFace(Path.Combine(Path.GetDirectoryName(_manifest.ManifestFile), "assets", "LatoLatin-Regular.ttf"));
                PanelManager.LoadPanelFile(Path.Combine(Path.GetDirectoryName(_manifest.ManifestFile), "assets", "charselect.rml").Replace("/", @"\"));

                _renderer.OnRender2D += Renderer_OnRender2D;
            }
        }

        private void Renderer_OnRender2D(object sender, EventArgs e) {
            PanelManager?.Update();
            _ctx?.Update();
            _ctx?.Render();
        }

        internal void Dispose() {
            if (_renderer is not null) {
                _renderer.OnRender2D -= Renderer_OnRender2D;
            }

            PanelManager?.Dispose();

            if (_didInit) {
                Rml.Shutdown();
            }

            _renderInterface?.Dispose();
            _systemInterface?.Dispose();
            _testPlugin.Dispose();

            _didInit = false;
        }
    }
}
