using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Changes an account squelch
    /// </summary>
    public class Communication_ModifyCharacterSquelch : ACGameAction {
        /// <summary>
        /// 0 = unsquelch, 1 = squelch
        /// </summary>
        public bool Add;

        /// <summary>
        /// The character id who&#39;s acount should be squelched
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The character&#39;s name who&#39;s acount should be squelched
        /// </summary>
        public string CharacterName;

        /// <summary>
        /// The message type to squelch or unsquelch
        /// </summary>
        public ChatFragmentType Type;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Add = reader.ReadBool();
            ObjectId = reader.ReadUInt32();
            CharacterName = reader.ReadString16L();
            Type = (ChatFragmentType)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Add);
            writer.Write(ObjectId);
            writer.Write(CharacterName);
            writer.Write((uint)Type);
        }

    }

}
