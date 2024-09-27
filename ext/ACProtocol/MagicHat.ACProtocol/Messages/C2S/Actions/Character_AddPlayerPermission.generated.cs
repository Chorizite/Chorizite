using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Grants a player corpse looting permission, /permit add
    /// </summary>
    public class Character_AddPlayerPermission : ACGameAction {
        /// <summary>
        /// Name of player to grant permission to loot the playes corpses
        /// </summary>
        public string TargetName;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            TargetName = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(TargetName);
        }

    }

}
