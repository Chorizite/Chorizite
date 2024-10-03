using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Render {
    /// <summary>
    /// Game screen
    /// </summary>
    public enum GameScreen {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Intro videos
        /// </summary>
        Intro = 0x10000001,

        /// <summary>
        /// Disconnected
        /// </summary>
        Disconnected = 0x10000002,

        /// <summary>
        /// Dat patching / connecting
        /// </summary>
        DatPatch = 0x10000003,

        /// <summary>
        /// Credits
        /// </summary>
        Credits = 0x10000005,

        /// <summary>
        /// In-game
        /// </summary>
        GamePlay = 0x10000008,

        // Epilogue = 0x10000009, // Not used in the client?

        /// <summary>
        /// Character select
        /// </summary>
        CharSelect = 0x1000000A,

        /// <summary>
        /// Character creation
        /// </summary>
        CharCreate = 0x1000000B
    }
}
