using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Set Turbine Chat channel numbers.
    /// </summary>
    public class Communication_ChatRoomTracker : ACGameEvent {
        /// <summary>
        /// the channel number of the allegiance channel
        /// </summary>
        public uint AllegianceRoomId;

        /// <summary>
        /// the channel number of the general channel
        /// </summary>
        public uint GeneralChatRoomId;

        /// <summary>
        /// the channel number of the trade channel
        /// </summary>
        public uint TradeChatRoomId;

        /// <summary>
        /// the channel number of the looking-for-group channel
        /// </summary>
        public uint LFGChatRoomId;

        /// <summary>
        /// the channel number of the roleplay channel
        /// </summary>
        public uint RoleplayChatRoomId;

        /// <summary>
        /// the channel number of the olthoi channel
        /// </summary>
        public uint OlthoiChatRoomId;

        /// <summary>
        /// the channel number of the society channel
        /// </summary>
        public uint SocietyChatRoomId;

        /// <summary>
        /// the channel number of the Celestial Hand channel
        /// </summary>
        public uint SocietyCelestialHandChatRoomId;

        /// <summary>
        /// the channel number of the Eldrich Web channel
        /// </summary>
        public uint SocietyEldrichWebChatRoomId;

        /// <summary>
        /// the channel number of the Radiant Blood channel
        /// </summary>
        public uint SocietyRadiantBloodChatRoomId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            AllegianceRoomId = reader.ReadUInt32();
            GeneralChatRoomId = reader.ReadUInt32();
            TradeChatRoomId = reader.ReadUInt32();
            LFGChatRoomId = reader.ReadUInt32();
            RoleplayChatRoomId = reader.ReadUInt32();
            OlthoiChatRoomId = reader.ReadUInt32();
            SocietyChatRoomId = reader.ReadUInt32();
            SocietyCelestialHandChatRoomId = reader.ReadUInt32();
            SocietyEldrichWebChatRoomId = reader.ReadUInt32();
            SocietyRadiantBloodChatRoomId = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(AllegianceRoomId);
            writer.Write(GeneralChatRoomId);
            writer.Write(TradeChatRoomId);
            writer.Write(LFGChatRoomId);
            writer.Write(RoleplayChatRoomId);
            writer.Write(OlthoiChatRoomId);
            writer.Write(SocietyChatRoomId);
            writer.Write(SocietyCelestialHandChatRoomId);
            writer.Write(SocietyEldrichWebChatRoomId);
            writer.Write(SocietyRadiantBloodChatRoomId);
        }

    }

}
