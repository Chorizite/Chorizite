using System;
using System.Runtime.InteropServices;

namespace RmlUiNet
{

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
            ProcessEvent(new Event(eventPtr));
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
            try
            {
                OnDetach(
                    Util.GetOrThrowElementByTypeName(elementPtr, elementType)
                );
            }
            catch (Exception ex)
            {
                //CoreUIPlugin.UI.Log?.LogTrace($"DetachEvent: {ex}");
            }
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
