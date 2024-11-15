using Autofac.Core;
using Microsoft.Extensions.Logging;
using RoyT.TrueType;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.Fonts {
    public class FontManager : IDisposable {
        private readonly ILogger? _log;
        private Dictionary<string, FontInfo> _availableFonts = new Dictionary<string, FontInfo>();

        public IEnumerable<FontInfo> AvailableFonts => _availableFonts.Values;

        internal FontManager(ILogger? log) {
            _log = log;

            var fontFiles = new List<string>();
            var fontDir = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            if (Directory.Exists(fontDir)) {
                var winfontsList = Directory.GetFiles(fontDir, "*.ttf");

                foreach (var file in winfontsList) {
                    var fontName = Path.GetFileNameWithoutExtension(file).ToLower();
                    fontFiles.Add(file);
                }

                foreach (var file in fontFiles) {
                    RegisterFontFile(file);
                }
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

                _log?.LogTrace($"Registered font: {fontInfo.Family}: {filename}");

                _availableFonts.Add(filename, fontInfo);
            }
            catch (Exception ex) {
                _log?.LogError($"Error registering font: {filename}: {ex}");
            }
            return false;
        }

        public bool TryGetFont(string fontName, string fontStyle, [MaybeNullWhen(false)] out FontInfo font) {
            fontName = fontName.ToLowerInvariant();
            fontStyle = fontStyle.ToLowerInvariant();

            font = _availableFonts.Values.FirstOrDefault(f => f.Family.ToLowerInvariant().Contains(fontName) && f.SubFamily.ToString().ToLowerInvariant().Contains(fontStyle));

            return font != null;
        }

        public void Dispose() {
            
        }
    }
}
