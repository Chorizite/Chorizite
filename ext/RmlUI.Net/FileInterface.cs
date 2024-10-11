using System;

namespace RmlUiNet
{
    public abstract class FileInterface : RmlBase<FileInterface>
    {
        private Native.FileInterface.OnOpen _onOpen;
        private Native.FileInterface.OnClose _onClose;
        private Native.FileInterface.OnRead _onRead;
        private Native.FileInterface.OnSeek _onSeek;
        private Native.FileInterface.OnTell _onTell;
        private Native.FileInterface.OnLength _onLength;
        private Native.FileInterface.OnLoadFile _onLoadFile;

        public unsafe FileInterface() : base(IntPtr.Zero)
        {
            _onOpen = Open;
            _onClose = Close;
            _onRead = _Read;
            _onSeek = Seek;
            _onTell = Tell;
            _onLength = Length;
            _onLoadFile = LoadFile;

            NativePtr = Native.FileInterface.Create(
                _onOpen,
                _onClose,
                _onLoadFile,
                _onRead,
                _onSeek,
                _onTell,
                _onLength
            );

            ManuallyRegisterCache(NativePtr, this);
        }

        internal unsafe ulong _Read(byte* buffer, ulong size, ulong file)
        {
            byte[] bytes = new byte[size];
            var len = Read(bytes, size, file);

            for (var i = 0; i < (int)len; i++)
            {
                buffer[i] = bytes[i];
            }

            return len;
        }

        public abstract ulong Open(string path);
        public abstract void Close(ulong file);
        public abstract ulong Read(byte[] buffer, ulong size, ulong file);
        public abstract bool Seek(ulong file, long offset, int origin);
        public abstract ulong Tell(ulong file);
        public abstract ulong Length(ulong file);
        public abstract string LoadFile(string path);
    }
}
