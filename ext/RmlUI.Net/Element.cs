using RmlUiNet.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static RmlUiNet.Native.VariableDefinition;

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

        /// <summary>
        /// The distance from this element’s top border to its offset parent’s top border.
        /// </summary>
        float GetOffsetTop();

        /// <summary>
        /// The distance from the context’s left edge and the element’s left border.
        /// </summary>
        float GetAbsoluteLeft();

        /// <summary>
        /// The distance from the context’s top edge and the element’s top border.
        /// </summary>
        float GetAbsoluteTop();

        /// <summary>
        /// The inner width of an element.
        /// </summary>
        float GetClientWidth();

        /// <summary>
        /// The inner height of an element.
        /// </summary>
        float GetClientHeight();

        /// <summary>
        /// Get a properties value as a string.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetProperty(string name);

        /// <summary>
        /// Get a css/style attributes value as a string.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetAttribute(string name);
        Element AppendChild(Element child, bool addToDom = true);
        Element AppendChildTag(string tagName, bool addToDom = true);
        void ScrollTo(float x, float y, ScrollBehavior behavior);
        void AddClass(string className);
        void RemoveClass(string className);
        void SetAttribute(string attributeName, string value);
        void SetProperty(string propertyName, string value);
        void AddEventListener(string name, Action<Event> action);
        string GetInnerRml();
        Element GetParentNode();
        void ReplaceChild(Element elementToinsert, Element elementToReplace);
        Element? QuerySelector(string selector);
        bool HasClass(string className);
        void RemoveChild(Element child);
        void RemoveEventListener(string name, Action<Event> action);
        void RemoveAttribute(string prop);
        bool HasAttribute(string attributeName);
    }

    public abstract class Element<T> : RmlBase<T>, Element
        where T : class
    {
        private ElementEventListener _listener;
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

        public override bool Equals(object? obj)
        {
            return obj is Element el && el.GetInnerRml() == GetInnerRml();
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

        internal class ElementEventListener : EventListener
        {
            internal Dictionary<string, List<Action<Event>>> _handlers = [];
            private Element _owningElement;

            public ElementEventListener(Element owningElement) : base()
            {
                _owningElement = owningElement;
            }

            public void AddHandler(string eventName, Action<Event> handler)
            {
                if (!_handlers.TryGetValue(eventName.ToLower(), out var handlers))
                {
                    handlers = new();
                    _handlers[eventName.ToLower()] = handlers;
                    _owningElement.AddEventListener(eventName.ToLower(), this);
                }
                handlers.Add(handler);
            }

            public void RemoveHandler(string eventName, Action<Event> handler) {
                if (_handlers.TryGetValue(eventName.ToLower(), out var handlers))
                {
                    handlers.Remove(handler);
                }
            }

            public override void ProcessEvent(Event ev)
            {
                if (_handlers.TryGetValue(ev.Id.ToString().ToLower(), out var handlers)) {
                    handlers.ToList().ForEach(handler => handler.Invoke(ev));
                }
            }

            public override void OnAttach(Element element)
            {
                base.OnAttach(element);
            }

            public override void OnDetach(Element element)
            {
                base.OnDetach(element);
            }

            public override void Dispose()
            {
                foreach (var evtName in _handlers.Keys.ToArray()) {
                    _owningElement.RemoveEventListener(evtName.ToLower(), this);
                }
                _handlers.Clear();
                _handlers = null;
                base.Dispose();
            }
        }

        public void AddEventListener(string name, Action<Event> action)
        {
            _listener ??= new ElementEventListener(this);
            _listener.AddHandler(name.ToLower(), action);
        }

        public void RemoveEventListener(string name, Action<Event> action)
        {
            _listener?.RemoveHandler(name.ToLower(), action);
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

        public bool DispatchEvent(string event_id, Dictionary<string, object> parameters, bool interruptible, bool bubbles)
        {
            var dict = Native.RmlDictionary.Create();
            List<IntPtr> variants = [];
            try {
                foreach (var kv in parameters) {
                    var variant = Util.ToVariant(kv.Value);

                    if (variant is not null)
                    {
                        variants.Add(variant.NativePtr);
                        Native.RmlDictionary.Insert(dict, kv.Key, variant.NativePtr);
                    }
                }
                return Native.Element.DispatchEvent(NativePtr, event_id, dict, interruptible, bubbles);
            }
            finally {
                foreach (var variant in variants) {
                    Native.Variant.Free(variant);
                }
                Native.RmlDictionary.Free(dict);
            }
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

        public bool HasClass(string className)
        {
            return Native.Element.HasClass(NativePtr, className);
        }

        public bool HasAttribute(string attributeName)
        {
            return Native.Element.HasAttribute(NativePtr, attributeName);
        }

        internal string GetElementTypeName()
        {
            var typePtr = Native.Element.GetElementTypeName(NativePtr);
            return Marshal.PtrToStringAnsi(typePtr) ?? "Unknown";
        }

        /// <summary>
        /// Append child element
        /// </summary>
        /// <param name="child"></param>
        /// <param name="addToDom"></param>
        /// <returns></returns>
        public Element AppendChild(Element child, bool addToDom = true) {
            var nativeElement = Native.Element.AppendChild(NativePtr, child.NativePtr, addToDom);
            var typePtr = Native.Element.GetElementTypeName(nativeElement);
            var elementType = Marshal.PtrToStringAnsi(typePtr);
            return Util.GetOrThrowElementByTypeName(nativeElement, elementType);
        }

        /// <summary>
        /// Create and append a child element
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="addToDom"></param>
        /// <returns></returns>
        public Element AppendChildTag(string tagName, bool addToDom = true)
        {
            var nativeElement = Native.Element.AppendChildTag(NativePtr, tagName, addToDom);
            var typePtr = Native.Element.GetElementTypeName(nativeElement);
            var elementType = Marshal.PtrToStringAnsi(typePtr);
            return Util.GetOrThrowElementByTypeName(nativeElement, elementType);
        }

        public void RemoveChild(Element child) { 
            Native.Element.RemoveChild(NativePtr, child.NativePtr);
        }

        /// <summary>
        /// Scroll to the specified offset with the specified behavior
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="behavior"></param>
        public void ScrollTo(float x, float y, ScrollBehavior behavior = ScrollBehavior.Auto) {
            Native.Element.ScrollTo(NativePtr, x, y, (int)behavior);
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
        /// Get the markup content of this element
        /// </summary>
        /// <returns></returns>
        public string GetInnerRml()
        {
            var strPtr = Native.Element.GetInnerRml(NativePtr);
            var strValue = Marshal.PtrToStringAnsi(strPtr);
            Marshal.FreeHGlobal(strPtr);
            return strValue ?? "";
        }

        public void AddClass(string className)
        {
            Native.Element.SetClass(NativePtr, className, true);
        }

        public void RemoveClass(string className)
        {
            Native.Element.SetClass(NativePtr, className, false);
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

        /// <inheritdoc cref="Element.GetOffsetTop"/>
        public float GetOffsetTop() {
            return Native.Element.GetOffsetTop(NativePtr);
        }

        /// <inheritdoc cref="Element.GetAbsoluteLeft"/>
        public float GetAbsoluteLeft() {
            return Native.Element.GetAbsoluteLeft(NativePtr);
        }

        /// <inheritdoc cref="Element.GetAbsoluteTop"/>
        public float GetAbsoluteTop() {
            return Native.Element.GetAbsoluteTop(NativePtr);
        }

        /// <inheritdoc cref="Element.GetClientWidth"/>
        public float GetClientWidth() {
            return Native.Element.GetClientWidth(NativePtr);
        }

        /// <inheritdoc cref="Element.GetClientHeight"/>
        public float GetClientHeight() {
            return Native.Element.GetClientHeight(NativePtr);
        }

        public string GetProperty(string name)
        {
            var strPtr = Native.Element.GetPropertyString(NativePtr, name);
            if (strPtr == IntPtr.Zero) return "";

            var strValue = Marshal.PtrToStringAnsi(strPtr);
            Marshal.FreeHGlobal(strPtr);
            return strValue ?? "";
        }

        public void SetProperty(string propertyName, string value)
        {
            Native.Element.SetProperty(NativePtr, propertyName, value);
        }

        /// <inheritdoc cref="Element.GetAttributeString(string, string)"/>
        public string GetAttribute(string attributeName)
        {
            var strPtr = Native.Element.GetAttributeString(NativePtr, attributeName, "");
            if (strPtr == IntPtr.Zero) return "";

            var strValue = Marshal.PtrToStringAnsi(strPtr);
            Marshal.FreeHGlobal(strPtr);
            return strValue ?? "";
        }

        public void SetAttribute(string attributeName, string value) {
            Native.Element.SetAttributeString(NativePtr, attributeName, value);
        }

        public Element GetParentNode()
        {
            var elementPtr = Native.Element.GetParentNode(NativePtr);
            var nativeElementType = Native.Element.GetElementTypeName(elementPtr);
            var elementType = Marshal.PtrToStringAnsi(nativeElementType);

            if (null == elementType)
            {
                return null;
            }

            return Util.GetOrThrowElementByTypeName(elementPtr, elementType);
        }

        public void ReplaceChild(Element elementToinsert, Element elementToReplace)
        {
            Native.Element.ReplaceChild(NativePtr, elementToinsert.NativePtr, elementToReplace.NativePtr);
        }

        public Element? QuerySelector(string selector)
        {
            var elementPtr = Native.Element.QuerySelector(NativePtr, selector);
            if (elementPtr == IntPtr.Zero) return null;
            var nativeElementType = Native.Element.GetElementTypeName(elementPtr);
            var elementType = Marshal.PtrToStringAnsi(nativeElementType);

            if (null == elementType)
            {
                return null;
            }

            return Util.GetOrThrowElementByTypeName(elementPtr, elementType);
        }

        public void RemoveAttribute(string prop)
        {
            Native.Element.RemoveAttribute(NativePtr, prop);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        #endregion
    }
}