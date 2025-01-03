using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Send or receive a message using Turbine Chat.
    /// </summary>
    public class Communication_TurbineChat : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7DE;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Communication_TurbineChat;

        /// <summary>
        /// the number of bytes that follow after this DWORD
        /// </summary>
        public uint MessageSize;

        /// <summary>
        /// the type of data contained in this message
        /// </summary>
        public TurbineChatType Type;

        public uint BlobDispatchType;

        public int TargetType;

        public int TargetId;

        public int TransportType;

        public int TransportId;

        public int Cookie;

        /// <summary>
        /// the number of bytes that follow after this DWORD
        /// </summary>
        public uint PayloadSize;

        /// <summary>
        /// the channel number of the message
        /// </summary>
        public uint RoomId;

        /// <summary>
        /// the name of the player sending the message
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// the message text
        /// </summary>
        public string Text;

        /// <summary>
        /// the number of bytes that follow after this DWORD
        /// </summary>
        public uint ExtraDataSize;

        /// <summary>
        /// the object Id of the player sending the message
        /// </summary>
        public uint SpeakerId;

        public int HResult;

        public ChatType ChatType;

        public uint ContextId;

        public uint ResponseId;

        public uint MethodId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            MessageSize = reader.ReadUInt32();
            Type = (TurbineChatType)reader.ReadUInt32();
            BlobDispatchType = reader.ReadUInt32();
            TargetType = reader.ReadInt32();
            TargetId = reader.ReadInt32();
            TransportType = reader.ReadInt32();
            TransportId = reader.ReadInt32();
            Cookie = reader.ReadInt32();
            PayloadSize = reader.ReadUInt32();
            switch((int)Type) {
                case 0x01:
                    switch((int)BlobDispatchType) {
                        case 0x01:
                            RoomId = reader.ReadUInt32();
                            DisplayName = reader.ReadWString();
                            Text = reader.ReadWString();
                            ExtraDataSize = reader.ReadUInt32();
                            SpeakerId = reader.ReadUInt32();
                            HResult = reader.ReadInt32();
                            ChatType = (ChatType)reader.ReadUInt32();
                            break;
                    }
                    break;
                case 0x03:
                    switch((int)BlobDispatchType) {
                        case 0x02:
                            ContextId = reader.ReadUInt32();
                            ResponseId = reader.ReadUInt32();
                            MethodId = reader.ReadUInt32();
                            RoomId = reader.ReadUInt32();
                            Text = reader.ReadWString();
                            ExtraDataSize = reader.ReadUInt32();
                            SpeakerId = reader.ReadUInt32();
                            HResult = reader.ReadInt32();
                            ChatType = (ChatType)reader.ReadUInt32();
                            break;
                    }
                    break;
                case 0x05:
                    switch((int)BlobDispatchType) {
                        case 0x01:
                            ContextId = reader.ReadUInt32();
                            ResponseId = reader.ReadUInt32();
                            MethodId = reader.ReadUInt32();
                            HResult = reader.ReadInt32();
                            break;
                        case 0x02:
                            ContextId = reader.ReadUInt32();
                            ResponseId = reader.ReadUInt32();
                            MethodId = reader.ReadUInt32();
                            HResult = reader.ReadInt32();
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(MessageSize);
            writer.Write((uint)Type);
            writer.Write(BlobDispatchType);
            writer.Write(TargetType);
            writer.Write(TargetId);
            writer.Write(TransportType);
            writer.Write(TransportId);
            writer.Write(Cookie);
            writer.Write(PayloadSize);
            switch((int)Type) {
                case 0x01:
                    switch((int)BlobDispatchType) {
                        case 0x01:
                            writer.Write(RoomId);
                            writer.Write(DisplayName);
                            writer.Write(Text);
                            writer.Write(ExtraDataSize);
                            writer.Write(SpeakerId);
                            writer.Write(HResult);
                            writer.Write((uint)ChatType);
                            break;
                    }
                    break;
                case 0x03:
                    switch((int)BlobDispatchType) {
                        case 0x02:
                            writer.Write(ContextId);
                            writer.Write(ResponseId);
                            writer.Write(MethodId);
                            writer.Write(RoomId);
                            writer.Write(Text);
                            writer.Write(ExtraDataSize);
                            writer.Write(SpeakerId);
                            writer.Write(HResult);
                            writer.Write((uint)ChatType);
                            break;
                    }
                    break;
                case 0x05:
                    switch((int)BlobDispatchType) {
                        case 0x01:
                            writer.Write(ContextId);
                            writer.Write(ResponseId);
                            writer.Write(MethodId);
                            writer.Write(HResult);
                            break;
                        case 0x02:
                            writer.Write(ContextId);
                            writer.Write(ResponseId);
                            writer.Write(MethodId);
                            writer.Write(HResult);
                            break;
                    }
                    break;
            }
        }

    }

}
