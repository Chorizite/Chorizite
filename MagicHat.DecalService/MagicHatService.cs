using Autofac;
using Decal.Adapter;
using Decal.Interop.Core;
using MagicHat.Core.Dats;
using MagicHat.Core.Input;
using MagicHat.Core.Logging;
using MagicHat.Core.Render;
using MagicHat.Service.Lib.Input;
using MagicHat.Service.Lib.Render;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace MagicHat.Service {
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("dcfb2961-ea07-43fa-4D61-676963486174")]
    [ProgId("MagicHat.Service")]
    [ComVisible(true)]
    [ComDefaultInterface(typeof(IDecalService))]
    internal sealed class MagicHatService : MarshalByRefObject, IDecalService, IDecalRender, IDecalWindowsMessageSink {
        private bool _hasServices = false;
        private bool _hasFilters = false;

        internal DecalCore? IDecal;
        private ILogger<MagicHatService>? _log;
        private DX9RenderInterface _render;
        private Win32InputManager _input;
        private bool didInit;

        /// <summary>
        /// The absolute path to the magic hat service dll directory.
        /// </summary>
        public static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetAssembly(typeof(MagicHatService)).Location);

        public Core.MagicHat? MagicHatInstance { get; private set; }

        public MagicHatService() {
            _log = new MagicHatLogger<MagicHatService>(GetType(), AssemblyDirectory);
        }

        void IDecalService.Initialize(DecalCore pDecal) {
            try {
                IDecal = pDecal;
                IDecal.InitializeComplete += IDecal_InitializeComplete;
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during IDecalService.Initialize: {ex.Message}");
            }
        }

        private void IDecal_InitializeComplete(eDecalComponentType Type) {
            try {
                if (Type == eDecalComponentType.eNetworkFilter) {
                    _hasFilters = true;
                }
                if (Type == eDecalComponentType.eService) {
                    _hasServices = true;
                }
                if (_hasServices && _hasFilters) {
                    IDecal!.InitializeComplete -= IDecal_InitializeComplete;
                }
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during IDecal_InitializeComplete: {ex.Message}");
            }
        }
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);
        
        private void Startup() {
            try {
                MagicHatInstance = new Core.MagicHat((builder) => {
                    builder.Register(c => new DX9RenderInterface(c.Resolve<ILogger<DX9RenderInterface>>(), c.Resolve<IDatReaderInterface>()))
                        .As<IRenderInterface>()
                        .SingleInstance();
                    builder.Register(c => new Win32InputManager(c.Resolve<ILogger<Win32InputManager>>()))
                        .As<IInputManager>()
                        .SingleInstance();

                    return new Core.MagicHatConfig(Path.Combine(AssemblyDirectory, "plugins"), AssemblyDirectory);
                });

                _render = (MagicHatInstance.Container.Resolve<IRenderInterface>() as DX9RenderInterface)!;
                _input = (MagicHatInstance.Container.Resolve<IInputManager>() as Win32InputManager)!;
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during Startup: {ex.Message}");
            }
        }

        unsafe public bool WindowMessage(int HWND, short uMsg, int wParam, int lParam) {
            try {
                if (uMsg == 0x20/*setcursor*/ || uMsg == 0x84/*WM_NCHITTEST*/) {
                    return false;
                }

                return _input?.HandleWindowMessage(HWND, (WindowMessageType)uMsg, wParam, lParam) ?? false;
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during WindowMessage: {ex.Message}");
            }
            return false;
        }

        void IDecalService.BeforePlugins() {
            try {
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during IDecalService.BeforePlugins: {ex.Message}");
            }
        }

        void IDecalService.AfterPlugins() {
            try {
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during IDecalService.AfterPlugins: {ex.Message}");
            }
        }

        void IDecalService.Terminate() {
            try {
                MagicHatInstance?.Dispose();
                _log?.LogDebug("\n\n\n");
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during IDecalService.Terminate: {ex.Message}");
            }
        }

        public unsafe void ChangeDirectX() {
            try {
                if (!didInit) {
                    didInit = true;
                    Startup();
                }
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during ChangeDirectX: {ex.Message}");
            }
        }

        public void ChangeHWND() {
            try {
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during ChangeHWND: {ex.Message}");
            }
        }

        public void PreReset() {
            try {
                _render?.TriggerOnGraphicsPreReset(this, EventArgs.Empty);
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during PreReset: {ex.Message}");
            }
        }

        public void PostReset() {
            try {
                _render?.TriggerOnGraphicsPostReset(this, EventArgs.Empty);
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during PostReset: {ex.Message}");
            }
        }

        public void Render2D() {
            try {
                _render?.Render2D();
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during Render2D: {ex.Message}");
            }
        }

        public void Render3D() {
            try {
                //OnRender3D?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during Render3D: {ex.Message}");
            }
        }
    }
}
