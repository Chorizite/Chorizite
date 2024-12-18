using Chorizite.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend {
    public class ObjectSelectedEventArgs : EatableEventArgs {
        /// <summary>
        /// The id of the object that was selected
        /// </summary>
        public uint ObjectId { get; }

        public ObjectSelectedEventArgs(uint objectId) {
            ObjectId = objectId;
        }
    }
}
