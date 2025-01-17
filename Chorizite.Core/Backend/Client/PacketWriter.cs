using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Client {

    public class PacketWriter : IDisposable {
        private readonly MemoryStream _stream;
        private readonly BinaryWriter _writer;

        public PacketWriter() {
            _stream = new MemoryStream();
            _writer = new BinaryWriter(_stream);
        }

        public void WriteBytes(byte[] data) {
            _writer.Write(data);
        }

        public void WriteInt8(sbyte value) => _writer.Write(value);
        public void WriteInt16(short value) => _writer.Write(value);
        public void WriteInt32(int value) => _writer.Write(value);
        public void WriteInt64(long value) => _writer.Write(value);
        public void WriteUInt8(byte value) => _writer.Write(value);
        public void WriteUInt16(ushort value) => _writer.Write(value);
        public void WriteUInt32(uint value) => _writer.Write(value);
        public void WriteUInt64(ulong value) => _writer.Write(value);
        public void WriteString(string value) => _writer.Write(value);

        public byte[] ToArray() => _stream.ToArray();

        public void Dispose() {
            _writer.Dispose();
        }
    }
}
