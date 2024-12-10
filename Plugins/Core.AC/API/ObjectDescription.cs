using Chorizite.ACProtocol.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API {
    public class ObjectDescription {
        public byte Version { get; set; }

        public uint Palette { get; set; }

        public List<Subpalette> Subpallettes { get; set; } = new List<Subpalette>();

        public List<TextureMapChange> TMChanges { get; set; } = new List<TextureMapChange>();

        public List<AnimPartChange> APChanges { get; set; } = new List<AnimPartChange>();
    }
}
