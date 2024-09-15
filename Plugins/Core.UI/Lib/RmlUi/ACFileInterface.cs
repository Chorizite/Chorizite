using RmlUiNet;
using System;
using System.Collections.Generic;
using System.IO;
namespace ACUI.Lib.RmlUi {
    public class ACFileInterface : FileInterface {
        private readonly string BasePath = "rml";
        private List<FileStream> m_Streams = new List<FileStream>();

        public override void Close(ulong file) {
            //UIPluginCore.Log($"ACFileInterface::Close({file})");
            if (m_Streams[(int)file - 1] == null) {
                //UIPluginCore.Log("ERROR: Invalid FileHandle!");
            }

            m_Streams[(int)file - 1].Dispose();
            m_Streams[(int)file - 1] = null;
        }

        public override ulong Length(ulong file) {
            //UIPluginCore.Log($"ACFileInterface::Length({file})");
            if (m_Streams[(int)file - 1] == null) {
                //UIPluginCore.Log("ERROR: Invalid FileHandle!");
            }

            return (ulong)m_Streams[(int)file - 1].Length;
        }

        public override string LoadFile(string path) {
            //UIPluginCore.Log($"ACFileInterface::LoadFile({path})");
            if (!File.Exists(path)) {
                //UIPluginCore.Log($"ERR: File {path} doesn't exist within RmlUi files!");
                return "";
            }

            return File.ReadAllText(path);
        }

        public override ulong Open(string path) {
            //UIPluginCore.Log($"ACFileInterface::Open({path})");
            if (!File.Exists(path)) {
                //UIPluginCore.Log($"ERR: File {path} doesn't exist within RmlUi files!");
                return 0;
            }

            try {
                // check if we have an open position within the list
                var openIndex = m_Streams.FindIndex((e) => e == null);
                if (openIndex != -1) {
                    m_Streams[openIndex] = File.Open(path, FileMode.Open, FileAccess.Read);
                    //UIPluginCore.Log($"ACFileInterface::Open({path}) RETURN {(ulong)openIndex + 1}");
                    return (ulong)openIndex + 1;
                }
                else {
                    m_Streams.Add(File.Open(path, FileMode.Open, FileAccess.Read));
                    //UIPluginCore.Log($"ACFileInterface::Open({path}) RETURN {(ulong)m_Streams.Count}");
                    return (ulong)m_Streams.Count;
                }
            }
            catch (Exception ex) {
                //UIPluginCore.Log($"ERR: {ex}");
            }
            //UIPluginCore.Log($"ACFileInterface::Open({path}) RETURN 0");

            return 0;
        }

        public override ulong Read(byte[] buffer, ulong size, ulong file) {
            //UIPluginCore.Log($"ACFileInterface::Read({file})");
            if (m_Streams[(int)file - 1] == null) {
                //UIPluginCore.Log("ERROR: Invalid FileHandle!");
            }

            return (ulong)m_Streams[(int)file - 1].Read(buffer, (int)m_Streams[(int)file - 1].Position, (int)size);
        }

        public override bool Seek(ulong file, long offset, int origin) {
            //UIPluginCore.Log($"ACFileInterface::Seek({file})");
            if (m_Streams[(int)file - 1] == null) {
                //UIPluginCore.Log("ERROR: Invalid FileHandle!");
            }

            m_Streams[(int)file - 1].Seek(offset, (SeekOrigin)origin);

            return true; // we can't really tell if it was successful or not?
        }

        public override ulong Tell(ulong file) {
            //UIPluginCore.Log($"ACFileInterface::Tell({file})");
            if (m_Streams[(int)file - 1] == null) {
               //UIPluginCore.Log("ERROR: Invalid FileHandle!");
            }

            return (ulong)m_Streams[(int)file - 1].Position;
        }
    }
}
