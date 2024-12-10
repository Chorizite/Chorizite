using Chorizite.ACProtocol.Enums;
using Chorizite.Common.Enums;
using System.Text.Json.Serialization;

namespace Core.AC.API {
    /// <summary>
    /// Some skills use a formula to boost the level based on attributes. If `UseFormula` is
    /// false the skill has no formula boost. These formulas are read from the portal.dat
    /// 
    /// The formula is `(Attribute1 + Attribute2) / Divisor`.
    /// 
    /// For example, the formula for Melee Defense is `(Coordination + Quickness) / 3`
    /// 
    /// If HasAttribute2 is false, only Attribute1 should be used.
    /// </summary>
    public class SkillFormula {
        /// <summary>
        /// Wether or not to use this formula when calculating the skill total
        /// </summary>
        public bool UseFormula { get; set; }

        /// <summary>
        /// Used for dividing the results of the attribute additions
        /// </summary>
        public float Divisor { get; set; }

        /// <summary>
        /// The first attribute this formula uses
        /// </summary>
        public AttributeId Attribute1 { get; set; }

        /// <summary>
        /// The second attribute this formula uses. Check HasAttribute2 to see if this should be used
        /// </summary>
        public AttributeId Attribute2 { get; set; }

        /// <summary>
        /// True if this formula uses Attribute2
        /// </summary>
        [JsonIgnore]
        public bool HasAttribute2 => Attribute2 == 0;

        public SkillFormula() { }

        /// <summary>
        /// Initialize a new formula
        /// </summary>
        /// <param name="useFormula">Wether or not to use this formula when calculating the skill total</param>
        /// <param name="divisor">Used for dividing the results of the attribute additions</param>
        /// <param name="attribute1">The first attribute this formula uses</param>
        /// <param name="attribute2">The second attribute this formula uses. This is added to the first if it is not 0</param>
        internal SkillFormula(bool useFormula, int divisor, AttributeId attribute1, AttributeId attribute2) {
            UseFormula = useFormula;
            Divisor = divisor;
            Attribute1 = attribute1;
            Attribute2 = attribute2;
        }
    }
}