using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Add or update a dat file Resource.
    /// </summary>
    public class DDD_DataMessage : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7E2;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.DDD_DataMessage;

        /// <summary>
        /// which dat file should store this resource
        /// </summary>
        public DatFileType DatFile;

        /// <summary>
        /// the resource type
        /// </summary>
        public uint ResourceType;

        /// <summary>
        /// the resource Id number
        /// </summary>
        public uint ResourceId;

        /// <summary>
        /// the file version number
        /// </summary>
        public uint Iteration;

        /// <summary>
        /// the type of compression used
        /// </summary>
        public CompressionType Compression;

        /// <summary>
        /// version of some sort
        /// </summary>
        public uint Version;

        /// <summary>
        /// the number of bytes required for the remainder of this message, including this DWORD
        /// </summary>
        public uint DataSize;

        public List<byte> Data = new List<byte>();

        /// <summary>
        /// the size of the uncompressed file
        /// </summary>
        public uint FileSize;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            DatFile = (DatFileType)reader.ReadInt64();
            ResourceType = reader.ReadUInt32();
            ResourceId = reader.ReadPackedDWORD();
            Iteration = reader.ReadUInt32();
            Compression = (CompressionType)reader.ReadByte();
            Version = reader.ReadUInt32();
            DataSize = reader.ReadUInt32();
            switch((int)Compression) {
                case 0x00:
                    for (var i=0; i < DataSize; i++) {
                        Data.Add(reader.ReadItem<byte>());
                    }
                    break;
                case 0x01:
                    FileSize = reader.ReadUInt32();
                    for (var i=0; i < DataSize; i++) {
                        Data.Add(reader.ReadItem<byte>());
                    }
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((long)DatFile);
            writer.Write(ResourceType);
            writer.Write(ResourceId);
            writer.Write(Iteration);
            writer.Write((byte)Compression);
            writer.Write(Version);
            writer.Write(DataSize);
            switch((int)Compression) {
                case 0x00:
                    for (var i=0; i < DataSize; i++) {
                    }
                    break;
                case 0x01:
                    writer.Write(FileSize);
                    for (var i=0; i < DataSize; i++) {
                    }
                    break;
            }
        }

    }

}
