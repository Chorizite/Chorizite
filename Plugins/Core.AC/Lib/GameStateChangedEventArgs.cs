using Core.AC.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.Lib {
    /// <summary>
    /// Client state changed
    /// </summary>
    public class GameStateChangedEventArgs : System.EventArgs {
        /// <summary>
        /// The new state the client is in
        /// </summary>
        public GameState NewState { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="newState"></param>
        public GameStateChangedEventArgs(GameState newState) {
            NewState = newState;
        }
    }
}
