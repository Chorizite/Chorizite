using Chorizite.Common;
using Chorizite.Core.Lib;

namespace Chorizite.Core.Backend.Client {
    public class ChatTextAddedEventArgs : EatableEventArgs {
        /// <summary>
        /// The text being added to the chat window
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The type of the chat
        /// </summary>
        public ChatType Type { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        public ChatTextAddedEventArgs(string text, ChatType type) {
            Text = text;
            Type = type;
        }
    }
}