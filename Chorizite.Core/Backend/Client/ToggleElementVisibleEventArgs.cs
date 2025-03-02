using Chorizite.Common;
using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Client {
    /// <summary>
    /// Event args for when a ui element is toggled
    /// </summary>
    public class ToggleElementVisibleEventArgs : EatableEventArgs {
        /// <summary>
        /// The id of the element
        /// </summary>
        public RootElementId ElementId { get; init; }

        /// <summary>
        /// Whether the element is showing
        /// </summary>
        public bool IsShowing { get; init; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="isShowing"></param>
        public ToggleElementVisibleEventArgs(RootElementId elementId, bool isShowing) {
            ElementId = elementId;
            IsShowing = isShowing;
        }
    }
}
