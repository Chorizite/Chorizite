using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher.Lib {
    class DecalHelpers {
        public static string DecalRegistryKey = "SOFTWARE\\Decal";

        public static string GetDecalLocation() {
            try {
                RegistryKey sk1 = Registry.LocalMachine.OpenSubKey(DecalRegistryKey + "\\Agent");
                if (sk1 == null) {
                    throw new Exception("Decal registry key not found: " + DecalRegistryKey);
                }

                string decalInjectionFile = (string)sk1.GetValue("AgentPath", "");
                if (string.IsNullOrEmpty(decalInjectionFile)) { throw new Exception("Decal AgentPath"); }

                decalInjectionFile += "Inject.dll";

                if (decalInjectionFile.Length > 5 && File.Exists(decalInjectionFile)) {
                    return decalInjectionFile;
                }
            }
            catch (Exception exc) {
                throw new Exception("No Decal in registry: " + exc.Message);
            }

            return "NoDecal";
        }
    }
}
