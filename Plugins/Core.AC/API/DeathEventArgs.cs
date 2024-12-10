namespace Core.AC.API {
    /// <summary>
    /// Death event args
    /// </summary>
    public class DeathEventArgs : System.EventArgs {
        /// <summary>
        /// Death message
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The object id of your killer
        /// </summary>
        public uint KillerId { get; }

        internal DeathEventArgs(string text, uint killerId) {
            Text = text;
            KillerId = killerId;
        }
    }
}