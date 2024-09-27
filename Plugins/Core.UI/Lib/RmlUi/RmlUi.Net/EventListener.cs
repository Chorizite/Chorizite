using ACUI;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;

namespace RmlUiNet
{
    public class Event : RmlBase<Event>
    {
        /// <summary>
        /// The event id.
        /// </summary>
        public EventId Id => (EventId)Native.Event.GetId(NativePtr);

        /// <summary>
        /// The current propagation phase.
        /// </summary>
        public EventPhase Phase => (EventPhase)Native.Event.GetPhase(NativePtr);

        /// <summary>
        /// The current element in the propagation.
        /// </summary>
        public Element CurrentElement {
            get {
                var elementType = Marshal.PtrToStringAnsi(
                    Native.Event.GetCurrentElement(NativePtr, out var elementPtr)
                );

                return Util.GetOrThrowElementByTypeName(elementPtr, elementType);
            }
        }

        /// <summary>
        /// The target element of this event.
        /// </summary>
        public Element TargetElement {
            get {
                var elementType = Marshal.PtrToStringAnsi(
                    Native.Event.GetTargetElement(NativePtr, out var elementPtr)
                );

                return Util.GetOrThrowElementByTypeName(elementPtr, elementType);
            }
        }

        /// <summary>
        /// True if the event can be interrupted, that is, stopped from propagating.
        /// </summary>
        public bool IsInterruptible => Native.Event.IsInterruptible(NativePtr);

        /// <summary>
        /// True if the event is still propagating.
        /// </summary>
        public bool IsPropagating => Native.Event.IsPropagating(NativePtr);

        /// <summary>
        /// True if the event is still immediate propagating.
        /// </summary>
        public bool IsImmediatePropagating => Native.Event.IsImmediatePropagating(NativePtr);

        public Event(IntPtr ptr, bool automaticallyRegisterInCache = false) : base(ptr, automaticallyRegisterInCache)
        {
        }

        /// <summary>
        /// Stops propagation of the event if it is interruptible, but finish all listeners on the current element.
        /// </summary>
        public void StopPropagation()
        {
            Native.Event.StopPropagation(NativePtr);
        }

        /// <summary>
        /// Stops propagation of the event if it is interruptible, including to any other listeners on the current element.
        /// </summary>
        public void StopImmediatePropagation()
        {
            Native.Event.StopImmediatePropagation(NativePtr);
        }
    }

    public abstract class EventListener : RmlBase<EventListener>
    {

        private Native.Rml.OnProcessEvent _onProcessEvent;
        private Native.Rml.OnAttachEvent _onAttachEvent;
        private Native.Rml.OnDetachEvent _onDetachEvent;

        public EventListener() : base(IntPtr.Zero)
        {
            _onProcessEvent = ProcessEventInternal;
            _onAttachEvent = AttachEventInternal;
            _onDetachEvent = DetachEventInternal;

            NativePtr = Native.Rml.CreateEventListener(
                _onProcessEvent,
                _onAttachEvent,
                _onDetachEvent
            );

            ManuallyRegisterCache(NativePtr, this);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            Native.Rml.ReleaseEventListener(NativePtr);
        }

        internal void ProcessEventInternal(IntPtr eventPtr) {
            //CoreUIPlugin.UI.Log?.LogTrace($"ProcessEventInternal: {eventPtr}");
            ProcessEvent(
                Event.GetOrCreateCache(eventPtr, ptr => new Event(ptr))
            );
        }

        internal void AttachEventInternal(IntPtr elementPtr, string elementType) {
            //CoreUIPlugin.UI.Log?.LogTrace($"AttachEventInternal: {elementPtr}");
            try {
                OnAttach(
                    Util.GetOrThrowElementByTypeName(elementPtr, elementType)
                );
            }
            catch (Exception ex) {
                //CoreUIPlugin.UI.Log?.LogTrace($"AttachEvent: {ex}");
            }
        }

        internal void DetachEventInternal(IntPtr elementPtr, string elementType) {
            //CoreUIPlugin.UI.Log?.LogTrace($"DetachEventInternal: {elementPtr}");
            OnDetach(
                Util.GetOrThrowElementByTypeName(elementPtr, elementType)
            );
        }

        public abstract void ProcessEvent(Event ev);

        public virtual void OnAttach(Element element)
        {
        }

        public virtual void OnDetach(Element element)
        {
        }
    }

    public enum EventId : ushort
    {
        Invalid,

        // Core events
        MouseDown,
        MouseScroll,
        MouseOver,
        MouseOut,
        Focus,
        Blur,
        KeyDown,
        KeyUp,
        TextInput,
        MouseUp,
        Click,
        DoubleClick,
        Load,
        Unload,
        Show,
        Hide,
        MouseMove,
        DragMove,
        Drag,
        DragStart,
        DragOver,
        DragDrop,
        DragOut,
        DragEnd,
        HandleDrag,
        Resize,
        Scroll,
        AnimationEnd,
        TransitionEnd,

        // Form control events
        Change,
        Submit,
        TabChange,
        ColumnAdd,
        RowAdd,
        RowChange,
        RowRemove,
        RowUpdate,
    }

    public enum EventPhase
    {
        None,
        Capture,
        Target,
        Bubble,
    }
}
