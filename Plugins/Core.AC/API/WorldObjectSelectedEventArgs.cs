using Chorizite.Common;

namespace Core.AC.API {
    /// <summary>
    /// Event args for when a world object is selected
    /// </summary>
    public class WorldObjectSelectedEventArgs : EatableEventArgs {
        /// <summary>
        /// The selected world object, if any
        /// </summary>
        public WorldObject? Object { get; }

        public WorldObjectSelectedEventArgs(WorldObject? obj) {
            Object = obj;
        }
    }
}