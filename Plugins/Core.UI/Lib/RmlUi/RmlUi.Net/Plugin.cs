using ACUI;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet {
    public abstract class Plugin : RmlBase<Plugin> {
        private Native.Plugin.OnInitialise _onInitialise;
        private Native.Plugin.OnShutdown _onShutdown;
        private Native.Plugin.OnDocumentOpen _onDocumentOpen;
        private Native.Plugin.OnDocumentLoad _onDocumentLoad;
        private Native.Plugin.OnDocumentUnload _onDocumentUnload;
        private Native.Plugin.OnContextCreate _onContextCreate;
        private Native.Plugin.OnContextDestroy _onContextDestroy;
        private Native.Plugin.OnElementCreate _onElementCreate;
        private Native.Plugin.OnElementDestroy _onElementDestroy;

        public Plugin() : base(IntPtr.Zero) {
            _onInitialise = OnInitialise;
            _onShutdown = OnShutdown;
            _onDocumentOpen = OnDocumentOpenInternal;
            _onDocumentLoad = OnDocumentLoadInternal;
            _onDocumentUnload = OnDocumentUnloadInternal;
            _onContextCreate = OnContextCreateInternal;
            _onContextDestroy = OnContextDestroyInternal;
            _onElementCreate = OnElementCreateInternal;
            _onElementDestroy = OnElementDestroyInternal;

            NativePtr = Native.Plugin.Create(
                _onInitialise,
                _onShutdown,
                _onDocumentOpen,
                _onDocumentLoad,
                _onDocumentUnload,
                _onContextCreate,
                _onContextDestroy,
                _onElementCreate,
                _onElementDestroy
            );

            ManuallyRegisterCache(NativePtr, this);
        }

        public virtual void OnInitialise() {

        }

        public virtual void OnShutdown() {

        }

        public virtual void OnDocumentOpen(Context context, string documentPath) {

        }

        public virtual void OnDocumentLoad(ElementDocument context) {

        }

        public virtual void OnDocumentUnload(ElementDocument context) {

        }

        public virtual void OnContextCreate(Context context) {

        }

        public virtual void OnContextDestroy(Context context) {

        }

        public virtual void OnElementCreate(Element context) {

        }

        public virtual void OnElementDestroy(Element context) {

        }

        internal virtual void OnDocumentOpenInternal(IntPtr contextPtr, string documentPath) {
            OnDocumentOpen(RmlInstanceCache.Instance.GetOrCreate<Context>(contextPtr, contextPtr => new Context(contextPtr)), documentPath);
        }

        internal virtual void OnDocumentLoadInternal(IntPtr documentPtr) {
            OnDocumentLoad(ElementDocument.Create(documentPtr));
        }

        internal virtual void OnDocumentUnloadInternal(IntPtr documentPtr) {
            OnDocumentUnload(ElementDocument.Create(documentPtr));
        }

        internal virtual void OnContextCreateInternal(IntPtr contextPtr) {
            OnContextCreate(RmlInstanceCache.Instance.GetOrCreate<Context>(contextPtr, contextPtr => new Context(contextPtr)));
        }

        internal virtual void OnContextDestroyInternal(IntPtr contextPtr) {
            OnContextDestroy(RmlInstanceCache.Instance.GetOrCreate<Context>(contextPtr, contextPtr => new Context(contextPtr)));
        }

        internal virtual void OnElementCreateInternal(IntPtr elementPtr) {
            OnElementCreate(new ElementGeneric(elementPtr, false));
        }

        internal virtual void OnElementDestroyInternal(IntPtr elementPtr) {
            OnElementDestroy(new ElementGeneric(elementPtr, false));
        }
    }
}
