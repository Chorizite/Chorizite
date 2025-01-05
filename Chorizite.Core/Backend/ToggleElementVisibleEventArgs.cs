using Chorizite.Common;
using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend {
    public class ToggleElementVisibleEventArgs : EatableEventArgs {
        public RootElementId ElementId { get; init; }
        public bool IsShowing { get; init; }

        public ToggleElementVisibleEventArgs() {
        
        }

        public ToggleElementVisibleEventArgs(RootElementId elementId, bool isShowing) {
            ElementId = elementId;
            IsShowing = isShowing;
        }
    }
}
