using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API.WorldObjects {
    /// <summary>
    /// Represents a door
    /// </summary>
    public class Door : Static {
        /// <summary>
        /// True if the door is locked
        /// </summary>
        public bool IsLocked => Value(PropertyBool.Locked);
    }
}
