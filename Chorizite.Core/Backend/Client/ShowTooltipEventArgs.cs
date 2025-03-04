using Chorizite.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Client {
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

        /// <summary>
        /// The icon id
        /// </summary>
        public uint IconId { get; init; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text"></param>
        /// <param name="objectId"></param>
        /// <param name="iconId"></param>
        public ShowTooltipEventArgs(string text, uint objectId, uint iconId) {
            Text = text;
            ObjectId = objectId;
            IconId = iconId;
        }
    }
}
