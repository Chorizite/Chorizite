using Chorizite.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend.Client {
    /// <summary>
    /// Event arguments for when an object is selected
    /// </summary>
    public class ObjectSelectedEventArgs : EatableEventArgs {
        /// <summary>
        /// The id of the object that was selected
        /// </summary>
        public uint ObjectId { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectId"></param>
        public ObjectSelectedEventArgs(uint objectId) {
            ObjectId = objectId;
        }
    }
}
