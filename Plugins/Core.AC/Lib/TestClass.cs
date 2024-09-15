using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.Lib {
    public class TestClassScripting {
        public int Test() {
            CoreACPlugin.Log?.LogDebug($"TestClassScripting::Test()");
            return 123;
        }
    }
}
