using Autofac.Core;
using Microsoft.Extensions.Logging;
using RoyT.TrueType;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.Lib.Fonts {
    public class FontManager : IDisposable {
        private readonly ILogger? _log;
        private Dictionary<string, FontInfo> _availableFonts = new Dictionary<string, FontInfo>();

        public IEnumerable<FontInfo> AvailableFonts => _availableFonts.Values;

        internal FontManager(ILogger? log) {
            _log = log;

            var fontFiles = new List<string>();
            /*
            var fontsList = Directory.GetFiles(Path.Combine(UBService.AssemblyDirectory, "fonts"), "*.ttf");
            foreach (var file in fontsList) {
                fontFiles.Add(file);
            }
            */

#if NET48_OR_GREATER
            var winfontsList = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "*.ttf");
            foreach (var file in winfontsList) {
                var fontName = Path.GetFileNameWithoutExtension(file).ToLower();
                fontFiles.Add(file);
            }
#endif
            foreach (var file in fontFiles) {
                RegisterFontFile(file);
            }
        }

        public bool RegisterFontFile(string filename) {
            try {
                if (!File.Exists(filename)) {
                    _log?.LogWarning($"Font file does not exist: {filename}");
                }

                // TODO: i dunno why these dont work... skip for now
                var font = TrueTypeFont.FromFile(filename);
                var fontInfo = new FontInfo(filename, font);
                if (fontInfo.Family.ToLower().Contains("webdings") || fontInfo.Family.ToLower().Contains("wingdings")) {
                    return false;
                }

                if (_availableFonts.ContainsKey(filename)) {
                    _availableFonts.Remove(filename);
                }

                _availableFonts.Add(filename, fontInfo);
            }
            catch (Exception ex) {
                _log?.LogError($"Error registering font: {filename}: {ex}");
            }
            return false;
        }

        public void Dispose() {
            
        }
    }
}
