using Chorizite.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend {
    /// <summary>
    /// Flags that show what type of object is being dragged
    /// </summary>
    [Flags]
    public enum DragDropFlags : uint {
        None = 0,
        Container = 1,
        Vendor = 2,
        Shortcut = 4,
        Salvage = 8,
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
        public DragDropFlags Flags { get; init;  }

        /// <summary>
        /// The name of the object / spell
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// The id of the object (or spell id)
        /// </summary>
        public uint Id { get; init; }

        /// <summary>
        /// True if the object is a spell
        /// </summary>
        public bool IsSpell { get; init; }

        public GameObjectDragDropEventArgs(string name, uint id, DragDropFlags flags, bool isDropping, bool isSpell) {
            IsDropping = isDropping;
            Flags = flags;
            Name = name;
            Id = id;
            IsSpell = isSpell;
        }
    }
}
