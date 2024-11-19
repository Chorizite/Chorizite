using System;

namespace RmlUiNet
{
    public class ElementDocument : Element<ElementDocument>
    {
        private List<Action> _loadHandlers = [];
        private bool _isCustomElement;
        private Native.ElementDocument.OnLoadInlineScript? _onLoadInlineScript;
        private MyEventListener _eventListener;
        #region Properties

        #endregion

        #region Methods

        private class MyEventListener : EventListener
        {
            private List<Action> _handlers;

            public MyEventListener(List<Action> handlers) : base() {
                _handlers = handlers;
            }

            public override void ProcessEvent(Event ev)
            {
                foreach (var handler in _handlers) {
                    try
                    {
                        handler();
                    }
                    catch { }
                }
            }

            public override void Dispose()
            {
                _handlers = null;
                base.Dispose();
            }
        }

        public ElementDocument() : base(IntPtr.Zero, false) {
            _isCustomElement = true;
            _onLoadInlineScript = OnLoadInlineScript;

            NativePtr = Native.ElementDocument.Create(_onLoadInlineScript);
            _eventListener = new MyEventListener(_loadHandlers);
            AddEventListener("load", _eventListener);
        }

        protected ElementDocument(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        public void OnLoad(Action onLoad) {
            _loadHandlers.Add(onLoad);
        }

        public virtual void OnLoadInlineScript(string context, string source_path, int source_line) {
        
        }

        /// <summary>
        /// Show the document.
        /// </summary>
        /// <param name="modalFlag">Flags controlling the modal state of the document, see the 'ModalFlag' description for details.</param>
        /// <param name="focusFlag">Flags controlling the focus, see the 'FocusFlag' description for details.</param>
        public void Show(ModalFlag modalFlag = ModalFlag.None, FocusFlag focusFlag = FocusFlag.Auto)
        {
            Native.ElementDocument.Show(NativePtr, modalFlag, focusFlag);
        }

        /// <summary>
        /// Hide the document.
        /// </summary>
        public void Hide()
        {
            Native.ElementDocument.Hide(NativePtr);
        }

        /// <summary>
        /// Merge a style sheet container into the document.
        /// </summary>
        /// <param name="container"></param>
        public void AddStyleSheetContainer(StyleSheetContainer container)
        {
            Native.ElementDocument.AddStyleSheetContainer(NativePtr, container.NativePtr);
        }

        /// <summary>
        /// Close the document.
        /// </summary>
        /// <remarks>
        /// The destruction of the document is deferred until the next call to Context::Update().
        /// </remarks>
        public void Close()
        {
            Native.ElementDocument.Close(NativePtr);
        }

        internal static ElementDocument? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementDocument(ptr, false));
        }

        public override void Dispose()
        {
            if (_isCustomElement)
            {
                RemoveEventListener("load", _eventListener);
                _eventListener.Dispose();
                _eventListener = null;
                _loadHandlers = null;
                Native.ElementDocument.Free(NativePtr);
            }
            base.Dispose();
        }

        #endregion
    }
}
