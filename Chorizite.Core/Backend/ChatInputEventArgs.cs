using Chorizite.Core.Lib;

namespace Chorizite.Core.Backend {
    /// <summary>
    /// Used when chat text is typed and submitted into the chat box.
    /// </summary>
    public class ChatInputEventArgs : EatableEventArgs {
        /// <summary>
        /// The text that was typed.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The chat window that the text was typed into.
        /// </summary>
        public ChatWindowId WindowId { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="text">The text that was typed.</param>
        /// <param name="windowId"></param>
        public ChatInputEventArgs(string text, ChatWindowId windowId) {
            Text = text;
            WindowId = windowId;
        }
    }
}