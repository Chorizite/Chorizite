using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Modify whether allegiance members are guests, /house guest add_allegiance/remove_allegiance
    /// </summary>
    public class House_ModifyAllegianceGuestPermission : ACGameAction {
        /// <summary>
        /// Whether we are adding or removing permissions
        /// </summary>
        public bool Add;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Add = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Add);
        }

    }

}
