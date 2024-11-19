using Core.UI.Lib.Fonts;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ACUI.Lib.RmlUi {
    public class ACSystemInterface : SystemInterface {
        private readonly DateTime _start;
        private readonly ILogger? _log;
        private readonly FontManager _fontManager;
        private readonly Regex _missingFontRegex = new(@"No font face defined. Ensure \(1\) that Context::Update is run after new elements are constructed, before Context::Render, and \(2\) that the specified font face '([^']+)' \[([^\]]+)\] has been successfully loaded\.", RegexOptions.IgnoreCase);

        public override double ElapsedTime => (DateTime.UtcNow - _start).TotalSeconds;

        internal bool HasNewFontsLoaded { get; set; }
        private List<string> _loadedFonts = [];

        public ACSystemInterface(FontManager fontManager, ILogger? logger) {
            _start = DateTime.UtcNow;
            _log = logger;
            _fontManager = fontManager;
        }

        public override string TranslateString(out int changeCount, string input) {
            //UIPluginCore.Log($"TranslateString called with {input}");
            return base.TranslateString(out changeCount, input);
        }

        public override bool LogMessage(LogType type, string message) {
            // attempt to load missing fonts.
            if (_missingFontRegex.IsMatch(message)) {
                var match = _missingFontRegex.Match(message);
                var fontName = match.Groups[1].Value;
                var fontStyle = match.Groups[2].Value;

                if (_fontManager.TryGetFont(fontName, fontStyle, out var font)) {
                    if (_loadedFonts.Contains(font.Filename)) {
                        return true;
                    }
                    _loadedFonts.Add(font.Filename);
                    Rml.LoadFontFace(font.Filename);
                    HasNewFontsLoaded = true;
                    return true;
                }

                _log?.LogWarning($"[RmlUi] Missing font: {fontName} ({fontStyle}) - this may cause text to not display correctly.");
                return true;
            }
            switch (type) {
                case LogType.Assert:
                    _log?.LogTrace($"[RmlUi] {message}");
                    break;
                case LogType.Debug:
                    _log?.LogDebug($"[RmlUi] {message}");
                    break;
                case LogType.Info:
                    _log?.LogInformation($"[RmlUi] {message}");
                    break;
                case LogType.Warning:
                    _log?.LogWarning($"[RmlUi] {message}");
                    break;
                case LogType.Error:
                    _log?.LogError($"[RmlUi] {message}");
                    break;
                default:
                    _log?.LogDebug($"[RmlUi] {message}");
                    break;
            }
            return true;
        }

        public override string JoinPath(string path, string file) {
            if (file.Contains("://")) {
                return file;
            }
            path = System.IO.Path.GetDirectoryName(path);
            string newPath;
            if (System.IO.Path.DirectorySeparatorChar == '\\') {
                newPath = base.JoinPath(path.Replace(@"/", @"\"), file.Replace(@"/", @"\"));
            }
            else {
                newPath = base.JoinPath(path, file);
            }
            return newPath;
        }
    }
}
