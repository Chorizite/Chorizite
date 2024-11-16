using Chorizite.Core.Lib;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.IO;
namespace ACUI.Lib.RmlUi {
    public class ACFileInterface : FileInterface {
        private readonly ILogger _log;
        private List<FileStream> m_Streams = new List<FileStream>();

        public ACFileInterface(ILogger log) {
            _log = log;
        }

        public override void Close(ulong file) {
            if (m_Streams[(int)file - 1] == null) {
                _log.LogError($"ACFileInterface.Close: Invalid FileHandle: {file}");
                return;
            }

            m_Streams[(int)file - 1].Dispose();
            m_Streams[(int)file - 1] = null;
        }

        public override ulong Length(ulong file) {
            if (m_Streams[(int)file - 1] == null) {
                _log.LogError($"ACFileInterface.Length: Invalid FileHandle: {file}");
                return 0;
            }

            return (ulong)m_Streams[(int)file - 1].Length;
        }

        public override string LoadFile(string path) {
            path = PathHelpers.TryMakeDevPath(path);
            if (!File.Exists(path)) {
                _log.LogError($"ACFileInterface.LoadFile: Invalid File: {path}");
                return "";
            }

            return File.ReadAllText(path);
        }

        public override ulong Open(string path) {
            path = PathHelpers.TryMakeDevPath(path);
            if (!File.Exists(path)) {
                _log.LogError($"ACFileInterface.Open: Invalid File: {path}");
                return 0;
            }

            try {
                // check if we have an open position within the list
                var openIndex = m_Streams.FindIndex((e) => e == null);
                if (openIndex != -1) {
                    m_Streams[openIndex] = File.Open(path, FileMode.Open, FileAccess.Read);
                    return (ulong)openIndex + 1;
                }
                else {
                    m_Streams.Add(File.Open(path, FileMode.Open, FileAccess.Read));
                    return (ulong)m_Streams.Count;
                }
            }
            catch (Exception ex) {
                _log.LogError(ex, $"ACFileInterface.Open");
            }

            return 0;
        }

        public override ulong Read(byte[] buffer, ulong size, ulong file) {
            if (m_Streams[(int)file - 1] == null) {
                _log.LogError($"ACFileInterface.Read: Invalid FileHandle: {file}");
                return 0;
            }

            return (ulong)m_Streams[(int)file - 1].Read(buffer, (int)m_Streams[(int)file - 1].Position, (int)size);
        }

        public override bool Seek(ulong file, long offset, int origin) {
            if (m_Streams[(int)file - 1] == null) {
                _log.LogError($"ACFileInterface.Seek: Invalid FileHandle: {file}");
                return false;
            }

            m_Streams[(int)file - 1].Seek(offset, (SeekOrigin)origin);

            return true;
        }

        public override ulong Tell(ulong file) {
            if (m_Streams[(int)file - 1] == null) {
                _log.LogError($"ACFileInterface.Tell: Invalid FileHandle: {file}");
                return 0;
            }

            return (ulong)m_Streams[(int)file - 1].Position;
        }
    }
}
