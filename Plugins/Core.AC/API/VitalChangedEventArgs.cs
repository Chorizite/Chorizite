using Chorizite.ACProtocol.Enums;
using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API {
    /// <summary>
    /// Event args for when a vital changes
    /// </summary>
    public class VitalChangedEventArgs : EventArgs {

        /// <summary>
        /// The vital that changed
        /// </summary>
        public VitalId Type { get; }

        /// <summary>
        /// The new vital current value
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// The old vital current value
        /// </summary>
        public int OldValue { get; }

        internal VitalChangedEventArgs(VitalId type, int value, int oldValue) {
            Type = type;
            Value = value;
            OldValue = oldValue;
        }
    }
}
