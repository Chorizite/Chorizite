using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API {
    /// <summary>
    /// Event arguments for when object cooldowns have been changed
    /// </summary>
    public class SharedCooldownsChangedEventArgs : EventArgs {
        /// <summary>
        /// Wether the cooldown was added or removed
        /// </summary>
        public AddRemoveEventType Type { get; }

        /// <summary>
        /// Cooldown information
        /// </summary>
        public SharedCooldown Cooldown { get; }

        internal SharedCooldownsChangedEventArgs(AddRemoveEventType type, SharedCooldown cooldown) {
            Type = type;
            Cooldown = cooldown;
        }
    }
}
