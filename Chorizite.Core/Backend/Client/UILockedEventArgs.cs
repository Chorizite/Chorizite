using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Client {
    /// <summary>
    /// Args for when the UI is locked
    /// </summary>
    public class UILockedEventArgs : EventArgs {
        /// <summary>
        /// Whether the UI is locked
        /// </summary>
        public bool IsLocked { get; init; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isLocked"></param>
        public UILockedEventArgs(bool isLocked) => IsLocked = isLocked;
    }
}
