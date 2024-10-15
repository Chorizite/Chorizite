using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Set a single character option.
    /// </summary>
    public class Character_PlayerOptionChangedEvent : ACGameAction {
        /// <summary>
        /// the option being set
        /// </summary>
        public CharacterOptions1 Option;

        /// <summary>
        /// the value of the option
        /// </summary>
        public bool Value;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Option = (CharacterOptions1)reader.ReadUInt32();
            Value = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Option);
            writer.Write(Value);
        }

    }

}
