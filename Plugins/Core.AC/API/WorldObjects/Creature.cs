using Chorizite.ACProtocol.Enums;
using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API.WorldObjects {
    /// <summary>
    /// Represents a creature
    /// </summary>
    public class Creature : Container {
        private MotionStance _stance = MotionStance.NonCombat;

        /// <summary>
        /// Radar blip color
        /// </summary>
        public RadarColor RadarColor => (RadarColor)Value(PropertyInt.RadarBlipColor);

        /// <summary>
        /// Radar Behavior
        /// </summary>
        public RadarBehavior RadarBehavior => (RadarBehavior)Value(PropertyInt.ShowableOnRadar);

        /// <summary>
        /// The stance the weenie is in, only applies to creatures.
        /// </summary>
        public MotionStance Stance {
            get => _stance == 0 ? MotionStance.NonCombat : _stance;
            set {
                if (value != 0)
                    _stance = value;
            }
        }

        /// <summary>
        /// The combat mode the weenie is in, only applies to creatures.
        /// </summary>
        public CombatMode CombatMode {
            get {
                switch (Stance) {
                    case MotionStance.HandCombat:
                    case MotionStance.DualWieldCombat:
                    case MotionStance.SwordCombat:
                    case MotionStance.SwordShieldCombat:
                    case MotionStance.TwoHandedStaffCombat:
                    case MotionStance.TwoHandedSwordCombat:
                        return CombatMode.Melee;
                    case MotionStance.BowCombat:
                    case MotionStance.AtlatlCombat:
                    case MotionStance.CrossbowCombat:
                    case MotionStance.CrossBowNoAmmo:
                    case MotionStance.ThrownShieldCombat:
                    case MotionStance.ThrownWeaponCombat:
                        return CombatMode.Missile;
                    case MotionStance.Magic:
                        return CombatMode.Magic;
                    default:
                        return CombatMode.NonCombat;
                }
            }
        }
    }
}
