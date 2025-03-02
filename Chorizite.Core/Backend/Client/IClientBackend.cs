using Autofac;
using Chorizite.ACProtocol;
using Chorizite.Core.Input;
using Chorizite.Core.Net;
using Chorizite.Core.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chorizite.Common;
using System.IO;
using System.Numerics;

namespace Chorizite.Core.Backend.Client {
    /// <summary>
    /// Interface for the ac client
    /// </summary>
    public interface IClientBackend : IDisposable {
        /// <summary>
        /// The current game screen
        /// </summary>
        int GameScreen { get; set; }

        /// <summary>
        /// The current selected object id
        /// </summary>
        uint SelectedObjectId { get; set; }

        /// <summary>
        /// Fired when a packet is sent
        /// </summary>
        public event EventHandler<PacketDataEventArgs> OnC2SData;

        /// <summary>
        /// Fired when a packet is received
        /// </summary>
        public event EventHandler<PacketDataEventArgs> OnS2CData;

        /// <summary>
        /// Fired when text is entered into the chat box
        /// </summary>
        public event EventHandler<ChatInputEventArgs> OnChatInput;

        /// <summary>
        /// Fired when chat text is added
        /// </summary>
        public event EventHandler<ChatTextAddedEventArgs> OnChatTextAdded;

        /// <summary>
        /// Fired when an object is selected. (Or when selection changed from something to nothing)
        /// </summary>
        public event EventHandler<ObjectSelectedEventArgs> OnObjectSelected;

        /// <summary>
        /// The UI backend
        /// </summary>
        public IClientUIBackend UIBackend { get; }

        /// <summary>
        /// Enter the game as a specified character id. Only valid on the character select screen.
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        public bool EnterGame(uint characterId);

        /// <summary>
        /// Log off the current character
        /// </summary>
        /// <param name="immediate"></param>
        /// <returns></returns>
        public bool LogOff(bool immediate);

        /// <summary>
        /// Exit the game
        /// </summary>
        public void Exit();

        /// <summary>
        /// Add chat text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        public void AddChatText(string text, ChatType type = ChatType.Default);

        /// <summary>
        /// Issue a command / text to the chat box, as if the user typed it
        /// </summary>
        /// <param name="text"></param>
        /// <param name="windowId"></param>
        void InvokeChat(string text, int windowId = 1);

        /// <summary>
        /// Send a custom message on the UI queue
        /// </summary>
        /// <param name="message"></param>
        void SendProtoUIMessage(byte[] message);

        /// <summary>
        /// Send a custom message on the UI queue
        /// </summary>
        /// <param name="stream"></param>
        void SendProtoUIMessage(PacketWriter stream);
    }
}
