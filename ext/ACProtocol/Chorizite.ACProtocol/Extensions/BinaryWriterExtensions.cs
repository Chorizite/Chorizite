using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using Chorizite.ACProtocol.Types;

namespace Chorizite.ACProtocol.Extensions {
    public static class BinaryWriterExtensions {
        public static void WritePackableList<T>(this BinaryWriter writer, List<T> value) {
            writer.Write(value.Count);
            for (var i = 0; i < value.Count; i++) {
                writer.WriteItem<T>(value[i]);
            }
        }
        public static void WriteVector3(this BinaryWriter writer, Vector3 value) {
            writer.Write(value.X);
            writer.Write(value.Y);
            writer.Write(value.Z);
        }
        public static void WriteQuaternion(this BinaryWriter writer, Quaternion value) {
            writer.Write(value.W);
            writer.Write(value.X);
            writer.Write(value.Y);
            writer.Write(value.Z);
        }

        public static void WritePackableHashTable<T, U>(this BinaryWriter writer, Dictionary<T, U> value) {
            writer.Write(value.Count);
            foreach (var item in value) {
                writer.WriteItem<T>(item.Key);
                writer.WriteItem<U>(item.Value);
            }
        }
        public static void WritePHashTable<T, U>(this BinaryWriter reader, Dictionary<T, U> items) {
            // TODO
            /*
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
             */
        }

        /// <summary>
        /// Read an item of type T from the buffer and return its value
        /// </summary>
        /// <typeparam name="T">type of item to read</typeparam>
        /// <param name="buffer">buffer to read from</param>
        /// <returns></returns>
        internal static void WriteItem<T>(this BinaryWriter writer, object item) {
            if (typeof(T).GetInterfaces().Contains(typeof(IACDataType))) {
                (item as IACDataType).Write(writer);
            }
            else {
                var type = typeof(T).IsEnum ? Enum.GetUnderlyingType(typeof(T)) : typeof(T);

                if (type == typeof(ushort))
                    writer.Write((ushort)item);
                else if (type == typeof(short))
                    writer.Write((short)item);
                else if (type == typeof(uint))
                    writer.Write((uint)item);
                else if (type == typeof(int))
                    writer.Write((int)item);
                else if (type == typeof(ulong))
                    writer.Write((ulong)item);
                else if (type == typeof(long))
                    writer.Write((long)item);
                else if (type == typeof(float))
                    writer.Write((float)item);
                else if (type == typeof(double))
                    writer.Write((double)item);
                else if (type == typeof(byte))
                    writer.Write((byte)item);
                else if (type == typeof(bool))
                    writer.Write((bool)item);
                else if (type == typeof(string))
                    writer.Write((string)item);
            }
        }
    }
}
