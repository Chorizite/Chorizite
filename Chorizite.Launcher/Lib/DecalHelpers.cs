using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LauncherApp.Lib {
    class DecalHelpers {
        public static string DecalRegistryKey = "SOFTWARE\\Decal";

        /// <summary>
        /// Get Decal location
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string? GetDecalLocation() {
            try {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    var sk1 = Registry.LocalMachine.OpenSubKey(DecalRegistryKey + "\\Agent");
                    if (sk1 == null) {
                        return null;
                    }

                    string decalPath = (string)sk1.GetValue("AgentPath", "");
                    if (string.IsNullOrEmpty(decalPath)) return null;

                    var decalInjectLocation = Path.Combine(decalPath, "Inject.dll");

                    if (File.Exists(decalInjectLocation)) {
                        return decalInjectLocation;
                    }
                }
            }
            catch (Exception exc) {
                throw new Exception("No Decal in registry: " + exc.Message);
            }

            return null;
        }
    }
}
