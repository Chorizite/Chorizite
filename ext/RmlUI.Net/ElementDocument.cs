using System;
using System.Runtime.InteropServices;

namespace RmlUiNet
{
    public class ElementDocument : Element<ElementDocument>
    {
        private bool _isCustomElement;
        private Native.ElementDocument.OnLoadInlineScript? _onLoadInlineScript;

        internal Dictionary<Element, ElementEventListener> _elementEventListeners = [];

        #region Properties

        #endregion

        #region Methods
        public ElementDocument() : base(IntPtr.Zero, false) {
            _isCustomElement = true;
            _onLoadInlineScript = OnLoadInlineScript;

            NativePtr = Native.ElementDocument.Create(_onLoadInlineScript);
        }

        protected ElementDocument(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
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
        /// Set the title of the document.
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title) {
            Native.ElementDocument.SetTitle(NativePtr, title);
        }

        /// <summary>
        /// Get the title of the document.
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            var strPtr = Native.ElementDocument.GetTitle(NativePtr);
            var strValue = Marshal.PtrToStringAnsi(strPtr);
            Marshal.FreeHGlobal(strPtr);
            return strValue ?? "";
        }

        public string GetSourceURL()
        {
            var strPtr = Native.ElementDocument.GetSourceURL(NativePtr);
            var strValue = Marshal.PtrToStringAnsi(strPtr);
            Marshal.FreeHGlobal(strPtr);
            return strValue ?? "";
        }

        /*
        /// <summary>
        /// Create an element with the given tag name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IntPtr CreateElement(string tagName)
        {
            return Native.ElementDocument.CreateElement(NativePtr, tagName);
        }
        */

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
            var listeners = _elementEventListeners.ToArray();
            foreach (var kv in listeners)
            {
                kv.Value.Dispose();
            }
            _elementEventListeners.Clear();
            if (_isCustomElement)
            {
                Native.ElementDocument.Free(NativePtr);
            }
            base.Dispose();
        }

        #endregion
    }
}
