using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Client {
    /// <summary>
    /// Helper class for writing packets
    /// </summary>
    public class PacketWriter : IDisposable {
        private readonly MemoryStream _stream;
        private readonly BinaryWriter _writer;

        /// <summary>
        /// Creates a new packet writer
        /// </summary>
        public PacketWriter() {
            _stream = new MemoryStream();
            _writer = new BinaryWriter(_stream);
        }

        /// <summary>
        /// Writes a byte array
        /// </summary>
        /// <param name="data"></param>
        public void WriteBytes(byte[] data) {
            _writer.Write(data);
        }

        /// <summary>
        /// Writes an 8 bit signed integer
        /// </summary>
        /// <param name="value"></param>
        public void WriteInt8(sbyte value) => _writer.Write(value);

        /// <summary>
        /// Writes a 16 bit signed integer
        /// </summary>
        /// <param name="value"></param>
        public void WriteInt16(short value) => _writer.Write(value);

        /// <summary>
        /// Writes a 32 bit signed integer
        /// </summary>
        /// <param name="value"></param>
        public void WriteInt32(int value) => _writer.Write(value);

        /// <summary>
        /// Writes a 64 bit signed integer
        /// </summary>
        /// <param name="value"></param>
        public void WriteInt64(long value) => _writer.Write(value);

        /// <summary>
        /// Writes a 8 bit unsigned integer
        /// </summary>
        /// <param name="value"></param>
        public void WriteUInt8(byte value) => _writer.Write(value);

        /// <summary>
        /// Writes a 16 bit unsigned integer
        /// </summary>
        /// <param name="value"></param>
        public void WriteUInt16(ushort value) => _writer.Write(value);

        /// <summary>
        /// Writes a 32 bit unsigned integer
        /// </summary>
        /// <param name="value"></param>
        public void WriteUInt32(uint value) => _writer.Write(value);

        /// <summary>
        /// Writes a 64 bit unsigned integer
        /// </summary>
        /// <param name="value"></param>
        public void WriteUInt64(ulong value) => _writer.Write(value);

        /// <summary>
        /// Writes a string
        /// </summary>
        /// <param name="value"></param>
        public void WriteString(string value) => _writer.Write(value);

        /// <summary>
        /// Returns the packet as a byte array
        /// </summary>
        /// <returns></returns>
        public byte[] ToArray() => _stream.ToArray();

        /// <summary>
        /// Disposes the writer
        /// </summary>
        public void Dispose() {
            _writer.Dispose();
        }
    }
}
