using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend {
    public class IconData {
        public uint Icon { get; init; }
        public uint Overlay { get; init; }
        public uint Underlay { get; init; }
        public UiEffects Effects { get; init; }

        public IconData() {

        }

        public IconData(uint icon, uint overlay, uint underlay, UiEffects effects) {
            Icon = icon;
            Overlay = overlay;
            Underlay = underlay;
            Effects = effects;
        }
    }
}
