using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API.WorldObjects {
    public class Armor : Equippable {
        /// <summary>
        /// The armor level
        /// </summary>
        public int ArmorLevel => Value(PropertyInt.ArmorLevel);
    }
}
