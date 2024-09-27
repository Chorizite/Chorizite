using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.Lib.Enums {
    /// <summary>
    /// Represents the current state of the game client.
    /// </summary>
    public enum GameState {
        /// <summary>
        /// Initial state. This is when the client as first started and has not connected to the server.
        /// </summary>
        Initial = 0,

        /// <summary>
        /// Client is done initializing, has connected to the server, and recieved a character list / world info.
        /// </summary>
        Connected = 1,

        /// <summary>
        /// Character select screen
        /// </summary>
        CharacterSelect = 2,

        /// <summary>
        /// Character creation screen
        /// </summary>
        CreatingCharacter = 3,

        /// <summary>
        /// Logging into a game character
        /// </summary>
        LoggingIn = 4,

        /// <summary>
        /// Got character details after logging in
        /// </summary>
        PlayerDescReceived = 5,

        /// <summary>
        /// Fully logged in to a game character
        /// </summary>
        InGame = 6,

        /// <summary>
        /// Logging out of a game character
        /// </summary>
        LoggingOut = 7,

        /// <summary>
        /// Disconnected from server
        /// </summary>
        Disconnected = 8
    }
}
