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
    /// Information describing your character.
    /// </summary>
    public class Login_PlayerDescription : ACGameEvent {
        /// <summary>
        /// Contains basic data types (int, float bool, etc.)
        /// </summary>
        public ACBaseQualities BaseQualities;

        public ACQualities Qualities;

        public PlayerModule PlayerModule;

        /// <summary>
        /// Number of items in your main pack
        /// </summary>
        public List<ContentProfile> ContentProfile = new();

        /// <summary>
        /// Items being equipt.
        /// </summary>
        public List<InventoryPlacement> InventoryPlacement = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            BaseQualities = new ACBaseQualities();
            BaseQualities.Read(reader);
            Qualities = new ACQualities();
            Qualities.Read(reader);
            PlayerModule = new PlayerModule();
            PlayerModule.Read(reader);
            ContentProfile = reader.ReadPackableList<ContentProfile>();
            InventoryPlacement = reader.ReadPackableList<InventoryPlacement>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            BaseQualities.Write(writer);
            Qualities.Write(writer);
            PlayerModule.Write(writer);
            writer.WritePackableList(ContentProfile);
            writer.WritePackableList(InventoryPlacement);
        }

    }

}
