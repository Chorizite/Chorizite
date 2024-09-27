using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Types;
using Microsoft.Extensions.Logging;

namespace MagicHat.ACProtocol.Extensions {
    public static class BinaryReaderExtensions {
        public static ushort ReadUInt16BigEndian(this BinaryReader reader) {
            return BitConverter.ToUInt16(reader.ReadBytes(2).Reverse().ToArray(), 0);
        }

        public static string ReadString16L(this BinaryReader buffer) {
            long start = buffer.BaseStream.Position;
            int length = buffer.ReadInt16();
            if (length == -1) {
                length = buffer.ReadInt32();
            }

            byte[] tmp = buffer.ReadBytes(length);

            int align = (int)((buffer.BaseStream.Position - start) % 4);
            if (align > 0)
                buffer.ReadBytes(4 - align);

            var val = System.Text.Encoding.ASCII.GetString(tmp);

            return val;
        }

        // from ACE
        public static string ReadString32L(this BinaryReader reader, bool pad = false) {
            long start = reader.BaseStream.Position;
            uint length = reader.ReadUInt32();

            // 32L strings are crazy.  the only place this is known as of time of writing this is in the
            // Login header packet.  it's a DWORD of the data length, followed by a packed word of the 
            // string length.  for most cases, this means the string comes out with a 1 or 2 character
            // prefix that just needs to get tossed.

            if (length == 0)
                return "";

            _ = reader.ReadByte();
            length--;

            if (length > 255) {
                _ = reader.ReadByte();
                length--;
            }

            string rdrStr = (length != 0 ? new string(reader.ReadChars((int)length)) : string.Empty);

            if (pad) {
                int align = (int)((reader.BaseStream.Position - start) % 4);
                if (align > 0)
                    _ = reader.ReadBytes(4 - align);
            }

            return rdrStr;
        }

        public static List<T> ReadList<T>(this BinaryReader reader) {
            var count = reader.ReadInt32();
            var items = new List<T>();
            for (var i = 0; i < count; i++) {
                items.Add(reader.ReadItem<T>());
            }

            return items;
        }

        public static List<T> ReadPackableList<T>(this BinaryReader reader) {
            var count = reader.ReadInt32();
            var items = new List<T>();
            for (var i = 0; i < count; i++) {
                items.Add(reader.ReadItem<T>());
            }

            return items;
        }
        public static Dictionary<T, U> ReadPHashTable<T, U>(this BinaryReader reader) {
            var items = new Dictionary<T, U>();
            var PackedSize = reader.ReadUInt32();
            var Count = (PackedSize & 0xFFFFFF);
            for (var i = 0; i < Count; i++) {
                T key = reader.ReadItem<T>();
                U value = reader.ReadItem<U>();

                if (!items.ContainsKey(key)) {
                    items.Add(key, value);
                }
            }

            return items;
        }

        public static Dictionary<T, U> ReadPackableHashTable<T, U>(this BinaryReader reader) {
            var count = reader.ReadInt16();
            var size = reader.ReadInt16();
            var items = new Dictionary<T, U>();
            for (var i = 0; i < count; i++) {
                T key = reader.ReadItem<T>();
                U value = reader.ReadItem<U>();

                if (!items.ContainsKey(key)) {
                    items.Add(key, value);
                }
            }

            return items;
        }

        public static Vector3 ReadVector3(this BinaryReader reader) {
            return new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }
        public static Quaternion ReadQuaternion(this BinaryReader reader) {
            var w = reader.ReadSingle();
            return new Quaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), w);
        }

        /// <summary>
        /// Read an item of type T from the buffer and return its value
        /// </summary>
        /// <typeparam name="T">type of item to read</typeparam>
        /// <param name="buffer">buffer to read from</param>
        /// <returns></returns>
        internal static T ReadItem<T>(this BinaryReader buffer) {
            if (typeof(T).GetInterfaces().Contains(typeof(IACDataType))) {
                var item = Activator.CreateInstance<T>();
                (item as IACDataType).Read(buffer);
                return item;
            }
            else {
                var type = typeof(T).IsEnum ? Enum.GetUnderlyingType(typeof(T)) : typeof(T);

                if (type == typeof(ushort))
                    return (T)(object)buffer.ReadUInt16();
                else if (type == typeof(short))
                    return (T)(object)buffer.ReadInt16();
                else if (type == typeof(uint))
                    return (T)(object)buffer.ReadUInt32();
                else if (type == typeof(int))
                    return (T)(object)buffer.ReadInt32();
                else if (type == typeof(ulong))
                    return (T)(object)buffer.ReadUInt64();
                else if (type == typeof(long))
                    return (T)(object)buffer.ReadInt64();
                else if (type == typeof(float))
                    return (T)(object)buffer.ReadSingle();
                else if (type == typeof(double))
                    return (T)(object)buffer.ReadDouble();
                else if (type == typeof(byte))
                    return (T)(object)buffer.ReadByte();
                else if (type == typeof(bool))
                    return (T)(object)buffer.ReadBool();
                else if (type == typeof(string))
                    return (T)(object)buffer.ReadString16L();
                else {
                    return (T)(object)null;
                }
            }
        }

        /// <summary>
        /// Read a bool from the buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static bool ReadBool(this BinaryReader buffer) {
            var val = buffer.ReadInt32();
            return val == 1;
        }

        /// <summary>
        /// Read a PackedWORD (short) from the buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static short ReadPackedWORD(this BinaryReader buffer) {
            short tmp = buffer.ReadByte();
            if ((tmp & 0x80) != 0)
                tmp = (short)(((tmp & 0x7f) << 8) | buffer.ReadByte());

            return tmp;
        }

        /// <summary>
        /// Read a PackedDWORD (UInt32) from the buffer 
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static uint ReadPackedDWORD(this BinaryReader buffer) {
            int tmp = buffer.ReadInt16();
            int otmp = tmp;
            if ((tmp & 0x8000) != 0) {
                tmp <<= 16;
                tmp &= 0x7FFFFFFF;
                tmp |= (ushort)buffer.ReadInt16();
            }
            return (uint)tmp;
        }

        /// <summary>
        /// Read a WString (unicode) from the buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string ReadWString(this BinaryReader buffer) {
            int length = buffer.ReadByte();
            if ((length & 0x80) != 0) {
                length = ((length & 0x7f) << 8) | buffer.ReadByte();
            }

            byte[] tmp = buffer.ReadBytes(length * 2);

            var val = System.Text.Encoding.Unicode.GetString(tmp);
            return val;
        }
    }
}
