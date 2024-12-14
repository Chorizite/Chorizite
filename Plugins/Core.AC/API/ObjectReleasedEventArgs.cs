using System;

namespace Core.AC.API {
    /// <summary>
    /// ObjectReleasedEventArgs
    /// </summary>
    public class ObjectReleasedEventArgs : EventArgs {
        /// <summary>
        /// The object that was released
        /// </summary>
        public WorldObject Object { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectId"></param>
        public ObjectReleasedEventArgs(WorldObject wobject) {
            Object = wobject;
        }
    }
}