using Chorizite.ACProtocol.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API {
    public class EnchantmentsChangedEventArgs : System.EventArgs {

        /// <summary>
        /// Wether the enchantment was added or removed
        /// </summary>
        public AddRemoveEventType Type { get; }

        /// <summary>
        /// The layered id of the spell for this enchantment
        /// </summary>
        public LayeredSpellId LayeredSpellId { get; }

        /// <summary>
        /// The spell id
        /// </summary>
        public uint SpellId => LayeredSpellId.Id;

        /// <summary>
        /// Enchantment information
        /// </summary>
        public Enchantment Enchantment { get; }

        public EnchantmentsChangedEventArgs(AddRemoveEventType type, Enchantment enchantment) {
            Type = type;
            LayeredSpellId = enchantment.LayeredId;
            Enchantment = enchantment;
        }
    }
}
