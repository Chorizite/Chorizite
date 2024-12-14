using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API.WorldObjects {
    public class Equipment : WorldObject {
        /// <summary>
        /// The wielder of this equipment, if any
        /// </summary>
        public Creature? Wielder => CoreACPlugin.Instance.Game.World.Get((uint)Value(PropertyInstanceId.Wielder)) as Creature;

        public Equipment() {
        }
    }
}
