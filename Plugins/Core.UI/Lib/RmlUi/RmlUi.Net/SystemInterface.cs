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

        public SystemInterface() : base(IntPtr.Zero)
        {
            _onGetElapsedTime = OnGetElapsedTimeInternal;
            _onTranslateString = OnTranslateStringInternal;
            _onLogMessage = LogMessage;
            _onJoinPath = JoinPath;

            NativePtr = Native.SystemInterface.Create(
                _onGetElapsedTime,
                _onTranslateString,
                _onLogMessage,
                _onJoinPath
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
