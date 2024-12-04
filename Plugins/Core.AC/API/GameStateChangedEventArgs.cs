using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API {
    /// <summary>
    /// Client state changed
    /// </summary>
    public class GameStateChangedEventArgs : EventArgs {
        /// <summary>
        /// The new state the client is in
        /// </summary>
        public ClientState NewState { get; set; }

        /// <summary>
        /// The old state the client is in
        /// </summary>
        public ClientState OldState { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="newState"></param>
        public GameStateChangedEventArgs(ClientState newState, ClientState oldState) {
            NewState = newState;
            OldState = oldState;
        }
    }
}
