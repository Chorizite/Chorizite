using System;

namespace Core.AC.API {
    /// <summary>
    /// ObjectCreatedEventArgs
    /// </summary>
    public class ObjectCreatedEventArgs : EventArgs {
        /// <summary>
        /// The object that was created
        /// </summary>
        public WorldObject Object { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectId"></param>
        public ObjectCreatedEventArgs(WorldObject wobject) {
            Object = wobject;
        }
    }
}