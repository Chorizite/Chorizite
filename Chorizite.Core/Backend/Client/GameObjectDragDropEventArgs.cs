using Chorizite.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Client {
    /// <summary>
    /// Flags that show what type of object is being dragged
    /// </summary>
    [Flags]
    public enum DragDropFlags : uint {
        /// <summary>
        /// No flags
        /// </summary>
        None = 0,

        /// <summary>
        /// The object is in a container
        /// </summary>
        Container = 1,

        /// <summary>
        /// The object is a vendor item
        /// </summary>
        Vendor = 2,
        
        /// <summary>
        /// The object is a shortcut
        /// </summary>
        Shortcut = 4,

        /// <summary>
        /// The object is a salvage. Unused?
        /// </summary>
        Salvage = 8,

        /// <summary>
        /// The object is an alias. Unused?
        /// </summary>
        Alias = 14
    }

    /// <summary>
    /// Used when an game object <see cref="DragDropFlags"/> is dragged and dropped.
    /// </summary>
    public class GameObjectDragDropEventArgs : EatableEventArgs {
        /// <summary>
        /// True if the object is being dropped.
        /// </summary>
        public bool IsDropping { get; init; }

        /// <summary>
        /// Flags that show what type of object is being dragged
        /// </summary>
        public DragDropFlags Flags { get; init; }

        /// <summary>
        /// The name of the object / spell
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The id of the object (or spell id)
        /// </summary>
        public uint Id { get; init; }

        /// <summary>
        /// The icon data
        /// </summary>
        public IconData IconData { get; init; }

        /// <summary>
        /// True if the object is a spell
        /// </summary>
        public bool IsSpell { get; init; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="flags"></param>
        /// <param name="isDropping"></param>
        /// <param name="isSpell"></param>
        /// <param name="iconData"></param>
        public GameObjectDragDropEventArgs(string name, uint id, DragDropFlags flags, bool isDropping, bool isSpell, IconData iconData) {
            IsDropping = isDropping;
            Flags = flags;
            Name = name;
            Id = id;
            IsSpell = isSpell;
            IconData = iconData;
        }
    }
}
