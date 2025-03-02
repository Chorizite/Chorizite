using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Client {
    /// <summary>
    /// Represents an icon.
    /// </summary>
    public class IconData {
        /// <summary>
        /// The dat id of the icon
        /// </summary>
        public uint Icon { get; init; }

        /// <summary>
        /// The dat id of the overlay, or 0 if no overlay
        /// </summary>
        public uint Overlay { get; init; }

        /// <summary>
        /// The dat id of the underlay, or 0 if no underlay
        /// </summary>
        public uint Underlay { get; init; }

        /// <summary>
        /// The icon effects. This is the border highlight.
        /// </summary>
        public UiEffects Effects { get; init; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public IconData() {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="icon"></param>
        /// <param name="overlay"></param>
        /// <param name="underlay"></param>
        /// <param name="effects"></param>
        public IconData(uint icon, uint overlay, uint underlay, UiEffects effects) {
            Icon = icon;
            Overlay = overlay;
            Underlay = underlay;
            Effects = effects;
        }
    }
}
