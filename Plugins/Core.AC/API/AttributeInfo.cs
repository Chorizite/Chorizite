using Chorizite.ACProtocol.Enums;
using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API {
    /// <summary>
    /// Represents a specific Attribute on a creature (Like Strength, Endurance, etc)
    /// </summary>
    public class AttributeInfo {
        private WorldObject _weenie;

        /// <summary>
        /// Attribute type
        /// </summary>
        public virtual AttributeId Type { get; set; }

        /// <summary>
        /// The amount of times this attribute has been raised
        /// </summary>
        public virtual uint PointsRaised { get; set; }

        /// <summary>
        /// starting point for advancement of the attribute (eg bonus points)
        /// </summary>
        public virtual uint InnatePoints { get; set; }

        /// <summary>
        /// Total XP spent on this attribute
        /// </summary>
        public virtual uint Experience { get; set; }

        /// <summary>
        /// Base (unbuffed) attribute level
        /// </summary>
        public virtual int Base => (int)(InnatePoints + PointsRaised);

        /// <summary>
        /// Current attribute level. Includes buffs/debuffs/vitae
        /// </summary>
        public virtual int Current {
            get {
                if (_weenie is Character character) {
                    var multiplier = character.GetEnchantmentsMultiplierModifier(Type);
                    var additives = character.GetEnchantmentsAdditiveModifier(Type);

                    var effective = (int)Math.Round(Base * multiplier + additives);
                    return Math.Max(effective, Base >= 10 ? 10 : 1);
                }
                else {
                    // TODO (is this right for creatures? do we have any enchantment data?)
                    return Base;
                }
            }
        }

        public AttributeInfo() {
        
        }

        internal AttributeInfo(AttributeId attributeId, WorldObject weenie) {
            Type = attributeId;
            _weenie = weenie;
        }
    }
}
