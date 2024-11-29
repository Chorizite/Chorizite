using Chorizite.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend {
    /// <summary>
    /// Used to show a tooltip
    /// </summary>
    public class ShowTooltipEventArgs : EatableEventArgs {
        /// <summary>
        /// The text of the tooltip
        /// </summary>
        public string Text { get; init; }

        /// <summary>
        /// The object id, if applicable
        /// </summary>
        public uint ObjectId { get; init; }

        public ShowTooltipEventArgs(string text, uint objectId) {
            Text = text;
            ObjectId = objectId;
        }
    }
}
