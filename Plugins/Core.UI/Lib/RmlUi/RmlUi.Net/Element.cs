using System;
using System.Runtime.InteropServices;

namespace RmlUiNet
{
    public interface Element
    {
        public IntPtr NativePtr { get; }

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        public string TagName { get; }

        /// <summary>
        /// Gets the document this element belongs to.
        /// </summary>
        public ElementDocument OwnerDocument { get; }

        /// <summary>
        /// Adds an event listener to this element.
        /// </summary>
        /// <param name="name">The name of the event to attach to.</param>
        /// <param name="eventListener">Listener object to be attached.</param>
        /// <param name="inCapturePhase">True if the listener is to be attached to the capture phase, false for the bubble phase.</param>
        public void AddEventListener(string name, EventListener eventListener, bool inCapturePhase = false);

        /// <summary>
        /// Adds an event listener to this element.
        /// </summary>
        /// <param name="name">The name of the event to attach to.</param>
        /// <param name="eventListener">Listener object to be attached.</param>
        /// <param name="inCapturePhase">True if the listener is to be attached to the capture phase, false for the bubble phase.</param>
        public void RemoveEventListener(string name, EventListener eventListener, bool inCapturePhase = false);

        /// <summary>
        /// Get a child element by its ID.
        /// </summary>
        /// <param name="id">ID of the the child element</param>
        /// <returns>The child of this element with the given ID, or null if no such child exists.</returns>
        public Element? GetElementById(string id);

        /// <summary>
        /// Sets the markup and content of the element. All existing children will be replaced.
        /// </summary>
        /// <param name="rml">The new content of the element.</param>
        public void SetInnerRml(string rml);

        /// <summary>
        /// Gives focus to the current element.
        /// </summary>
        /// <returns>True if the change focus request was successful.</returns>
        public bool Focus();

        /// <summary>
        /// Removes focus from from this element.
        /// </summary>
        public void Blur();

        /// <summary>
        /// Fakes a mouse click on this element.
        /// </summary>
        public void Click();

        public Box GetBox();
        float GetOffsetTop();
    }

    public abstract class Element<T> : RmlBase<T>, Element
        where T : class
    {
        #region Properties

        public string TagName => Marshal.PtrToStringAnsi(Native.Element.GetTagName(NativePtr));

        /// <summary>
        /// Gets the document this element belongs to.
        /// </summary>
        public ElementDocument OwnerDocument {
            get {
                var elementType = Marshal.PtrToStringAnsi(
                    Native.Element.GetOwnerDocument(NativePtr, out var elementPtr)
                );

                return Util.GetOrThrowElementByTypeName(elementPtr, elementType) as ElementDocument;
            }
        }

        #endregion

        #region Methods

        protected Element(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        /// <summary>
        /// Adds an event listener to this element.
        /// </summary>
        /// <param name="name">The name of the event to attach to.</param>
        /// <param name="eventListener">Listener object to be attached.</param>
        /// <param name="inCapturePhase">True if the listener is to be attached to the capture phase, false for the bubble phase.</param>
        public void AddEventListener(string name, EventListener eventListener, bool inCapturePhase = false)
        {
            Native.Element.AddEventListener(NativePtr, name, eventListener.NativePtr, inCapturePhase);
        }

        /// <summary>
        /// Adds an event listener to this element.
        /// </summary>
        /// <param name="name">The name of the event to attach to.</param>
        /// <param name="eventListener">Listener object to be attached.</param>
        /// <param name="inCapturePhase">True if the listener is to be attached to the capture phase, false for the bubble phase.</param>
        public void RemoveEventListener(string name, EventListener eventListener, bool inCapturePhase = false)
        {
            Native.Element.RemoveEventListener(NativePtr, name, eventListener.NativePtr, inCapturePhase);
        }

        /// <summary>
        /// Get a child element by its ID.
        /// </summary>
        /// <param name="id">ID of the the child element</param>
        /// <returns>The child of this element with the given ID, or null if no such child exists.</returns>
        public Element? GetElementById(string id)
        {
            var nativeElementType = Native.Element.GetElementById(NativePtr, id, out var elementPtr);
            var elementType = Marshal.PtrToStringAnsi(nativeElementType);

            if (null == elementType) {
                return null;
            }

            return Util.GetOrThrowElementByTypeName(elementPtr, elementType);
        }

        /// <summary>
        /// Sets the markup and content of the element. All existing children will be replaced.
        /// </summary>
        /// <param name="rml">The new content of the element.</param>
        public void SetInnerRml(string rml)
        {
            Native.Element.SetInnerRml(NativePtr, rml);
        }

        /// <summary>
        /// Gives focus to the current element.
        /// </summary>
        /// <returns>True if the change focus request was successful.</returns>
        public bool Focus()
        {
            return Native.Element.Focus(NativePtr);
        }

        /// <summary>
        /// Removes focus from from this element.
        /// </summary>
        public void Blur()
        {
            Native.Element.Blur(NativePtr);
        }

        /// <summary>
        /// Fakes a mouse click on this element.
        /// </summary>
        public void Click()
        {
            Native.Element.Click(NativePtr);
        }

        public Box GetBox() {
            return new Box(Native.Element.GetBox(NativePtr));
        }

        public float GetOffsetTop() {
            return Native.Element.GetOffsetTop(NativePtr);
        }

        #endregion
    }
}