using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Titles for the current character.
    /// </summary>
    public class Social_CharacterTitleTable : ACGameEvent {
        /// <summary>
        /// the title Id of the currently active title
        /// </summary>
        public uint DisplayTitle;

        /// <summary>
        /// Titles character currently has.
        /// </summary>
        public List<uint> Titles = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            DisplayTitle = reader.ReadUInt32();
            Titles = reader.ReadPackableList<uint>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(DisplayTitle);
            writer.WritePackableList(Titles);
        }

    }

}
