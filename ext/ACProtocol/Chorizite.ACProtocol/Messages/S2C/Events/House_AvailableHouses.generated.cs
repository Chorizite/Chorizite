using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Display a list of available dwellings in the chat window.
    /// </summary>
    public class House_AvailableHouses : ACGameEvent {
        /// <summary>
        /// The type of house (1=cottage, 2=villa, 3=mansion, 4=apartment)
        /// </summary>
        public HouseType Type;

        /// <summary>
        /// Landcell location of the houses
        /// </summary>
        public List<uint> Houses = new();

        /// <summary>
        /// The total number of houses of this type available
        /// </summary>
        public int NumHouses;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Type = (HouseType)reader.ReadUInt32();
            Houses = reader.ReadPackableList<uint>();
            NumHouses = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Type);
            writer.WritePackableList(Houses);
            writer.Write(NumHouses);
        }

    }

}
