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
        private Character character => CoreACPlugin.Instance.Game.Character;

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
                var multiplier = character.GetEnchantmentsMultiplierModifier(Type);
                var additives = character.GetEnchantmentsAdditiveModifier(Type);

                var effective = (int)Math.Round(Base * multiplier + additives);
                return Math.Max(effective, Base >= 10 ? 10 : 1);
            }
        }

        public AttributeInfo() {
        
        }

        internal AttributeInfo(AttributeId attributeId) {
            Type = attributeId;
        }

        public override string ToString() {
            return $"[{Type} Base: {Base}, Current: {Current}]";
        }
    }
}
