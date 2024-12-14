using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.API {
    internal class WorldObjectManager {
        private ConcurrentDictionary<uint, WorldObject> _weenies = new();
    }
}
