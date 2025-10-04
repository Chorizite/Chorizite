using Chorizite.ACProtocol.Types;
using Chorizite.Core.Dats;
using FontStashSharp;
using FontStashSharp.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Manages fonts
    /// </summary>
    public class FontManager : IFontManager {
        private Dictionary<string, string> _availableFonts = new Dictionary<string, string>();
        private Dictionary<uint, IFont> _acFonts = [];
        private readonly ILogger _log;
        private readonly IGraphicsDevice _graphicsDevice;
        private readonly IDatReaderInterface _dat;
        private FontSystem fontSystem;

        public FontManager(ILogger log, IGraphicsDevice graphicsDevice, IDatReaderInterface dat) {
            _graphicsDevice = graphicsDevice;
            _dat = dat;
            _log = log;
            fontSystem = new FontSystem(new FontSystemSettings() {
                FontResolutionFactor = 2,
                KernelWidth = 2,
                KernelHeight = 2
            });

            //_availableFonts = GetFontFileInfoInReg();

        }

        /// <inheritdoc/>
        public virtual IFont GetFont(uint id) {
            if (!_acFonts.TryGetValue(id, out var font)) {
                font = new ACFont(_graphicsDevice, _dat, id);
                _acFonts.Add(id, font);
            }
            return font;
        }

        /// <inheritdoc/>
        public virtual IFont GetFont(string name, int size) {
            return null;
        }

        private Dictionary<string, string> GetFontFileInfoInReg() {
            Dictionary<string, string> result = new Dictionary<string, string>();

            try {
                RegistryKey localMachineKey = Registry.LocalMachine;
                RegistryKey localMachineKeySub = localMachineKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", false);

                string[] mynames = localMachineKeySub.GetValueNames();

                foreach (string name in mynames) {
                    string myvalue = localMachineKeySub.GetValue(name).ToString();

                    if (myvalue.Substring(myvalue.Length - 4).ToUpper() == ".TTF" && myvalue.Substring(1, 2).ToUpper() != @":") {
                        string val = name.Substring(0, name.Length - 11);
                        result[val] = myvalue;
                    }
                }
                localMachineKeySub.Close();
            }
            catch (Exception ex) {
                _log.LogWarning($"Failed to get fonts from registry: {ex.Message}");
            }
            return result;
        }

        public void Dispose() {
            foreach (var font in _acFonts) {
                font.Value.Dispose();
            }
            _acFonts.Clear();

        }
    }
}
