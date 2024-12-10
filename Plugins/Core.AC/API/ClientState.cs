namespace Core.AC.API {
    /// <summary>
    /// Represents the current state of the game client.
    /// </summary>
    public enum ClientState {
        /// <summary>
        /// Initial client state.
        /// </summary>
        Initial = 0,
        
        /// <summary>
        /// Client is done initializing.
        /// </summary>
        GameStarted = 1,
        
        /// <summary>
        /// Character select screen
        /// </summary>
        CharacterSelect = 2,
        
        /// <summary>
        /// Character creation screen
        /// </summary>
        CreatingCharacter = 3,
        
        /// <summary>
        /// Logging into the game
        /// </summary>
        EnteringGame = 4,
        
        /// <summary>
        /// Fully logged in to the game
        /// </summary>
        InGame = 5,
        
        /// <summary>
        /// Logging out
        /// </summary>
        LoggingOut = 6,

        /// <summary>
        /// Disconnected from server
        /// </summary>
        Disconnected = 7
    }
}