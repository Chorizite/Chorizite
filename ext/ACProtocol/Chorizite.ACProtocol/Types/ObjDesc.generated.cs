//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;
using System.Numerics;
using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.Common.Enums;
using Chorizite.ACProtocol.Extensions;
namespace Chorizite.ACProtocol.Types {
    /// <summary>
    /// The ObjDesc structure defines an object&#39;s visual appearance.
    /// </summary>
    public class ObjDesc : IACDataType {
        /// <summary>
        /// always 0x11
        /// </summary>
        public byte Version;

        /// <summary>
        /// the number of palettes associated with this object
        /// </summary>
        public byte PaletteCount;

        /// <summary>
        /// the number of textures associated with this object
        /// </summary>
        public byte TextureCount;

        /// <summary>
        /// the number of models associated with this object
        /// </summary>
        public byte ModelCount;

        /// <summary>
        /// palette DataId (minus 0x04000000)
        /// </summary>
        public uint Palette;

        public List<Subpalette> Subpalettes = new List<Subpalette>();

        public List<TextureMapChange> TMChanges = new List<TextureMapChange>();

        public List<AnimPartChange> APChanges = new List<AnimPartChange>();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Version = reader.ReadByte();
            PaletteCount = reader.ReadByte();
            TextureCount = reader.ReadByte();
            ModelCount = reader.ReadByte();
            if (PaletteCount > 0) {
                Palette = reader.ReadPackedDWORD();
            }
            for (var i=0; i < PaletteCount; i++) {
                Subpalettes.Add(reader.ReadItem<Subpalette>());
            }
            for (var i=0; i < TextureCount; i++) {
                TMChanges.Add(reader.ReadItem<TextureMapChange>());
            }
            for (var i=0; i < ModelCount; i++) {
                APChanges.Add(reader.ReadItem<AnimPartChange>());
            }
            if ((reader.BaseStream.Position % 4) != 0) {
                reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Version);
            writer.Write(PaletteCount);
            writer.Write(TextureCount);
            writer.Write(ModelCount);
            if (PaletteCount > 0) {
                writer.Write(Palette);
            }
            for (var i=0; i < PaletteCount; i++) {
            }
            for (var i=0; i < TextureCount; i++) {
            }
            for (var i=0; i < ModelCount; i++) {
            }
            if ((writer.BaseStream.Position % 4) != 0) {
                writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
            }
        }

    }

}
