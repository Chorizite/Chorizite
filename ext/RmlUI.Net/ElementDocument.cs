using System;

namespace RmlUiNet
{
    public class ElementDocument : Element<ElementDocument>
    {
        #region Properties

        #endregion

        #region Methods

        protected ElementDocument(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
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

        #endregion
    }
}
