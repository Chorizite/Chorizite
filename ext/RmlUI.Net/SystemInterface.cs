using System;
using System.Text;

namespace RmlUiNet
{
    public abstract class SystemInterface : RmlBase<SystemInterface>
    {
        private Native.SystemInterface.OnGetElapsedTime _onGetElapsedTime;
        private Native.SystemInterface.OnTranslateString _onTranslateString;
        private Native.SystemInterface.OnLogMessage _onLogMessage;
        private Native.SystemInterface.OnJoinPath _onJoinPath;
        private Native.SystemInterface.OnSetMouseCursor _onSetMouseCursor;

        public SystemInterface() : base(IntPtr.Zero)
        {
            _onGetElapsedTime = OnGetElapsedTimeInternal;
            _onTranslateString = OnTranslateStringInternal;
            _onLogMessage = LogMessage;
            _onJoinPath = JoinPath;
            _onSetMouseCursor = OnSetMouseCursor;

            NativePtr = Native.SystemInterface.Create(
                _onGetElapsedTime,
                _onTranslateString,
                _onLogMessage,
                _onJoinPath,
                _onSetMouseCursor
            );

            ManuallyRegisterCache(NativePtr, this);
        }

        public virtual string JoinPath(string path, string file) {
            return System.IO.Path.Combine(path, file);
        }

        private double OnGetElapsedTimeInternal()
        {
            return ElapsedTime;
        }

        private string OnTranslateStringInternal(ref int changeCount, string input)
        {
            return TranslateString(out changeCount, input);
        }

        private void OnSetMouseCursor(string mouseCursor)
        {
            SetMouseCursor(mouseCursor);
        }

        /// <summary>
        /// Get the number of seconds elapsed since the start of the application.
        /// </summary>
        public abstract double ElapsedTime { get; }

        /// <summary>
        /// Translate the input string into the translated string.
        /// </summary>
        /// <param name="changeCount">Number of translations that occurred.</param>
        /// <param name="input">String as received from XML.</param>
        /// <returns>Translated string ready for display.</returns>
        public virtual string TranslateString(out int changeCount, string input)
        {
            changeCount = 0;
            return input;
        }

        public virtual bool LogMessage(LogType type, string message)
        {
            Console.WriteLine("[{0}] {1}", type, message);

            return true;
        }

        public virtual void SetMouseCursor(string cursor) {
            
        }
    }

    public enum LogType
    {
        Always = 0,
        Error,
        Assert,
        Warning,
        Info,
        Debug,
    }
}
