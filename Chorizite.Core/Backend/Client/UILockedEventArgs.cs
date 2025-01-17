using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Client {
    public class UILockedEventArgs : EventArgs {
        public bool IsLocked { get; init; }

        public UILockedEventArgs(bool isLocked) => IsLocked = isLocked;
    }
}
