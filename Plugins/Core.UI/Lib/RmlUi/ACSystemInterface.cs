using Core.UI;
using Core.UI.Lib.Fonts;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ACUI.Lib.RmlUi {
    public class ACSystemInterface : SystemInterface {
        private readonly DateTime _start;
        private readonly ILogger? _log;
        private readonly FontManager _fontManager;
        private readonly Regex _missingFontRegex = new(@"No font face defined. Ensure \(1\) that Context::Update is run after new elements are constructed, before Context::Render, and \(2\) that the specified font face '([^']+)' \[([^\]]+)\] has been successfully loaded\.", RegexOptions.IgnoreCase);

        public override double ElapsedTime => (DateTime.UtcNow - _start).TotalSeconds;

        internal bool HasNewFontsLoaded { get; set; }
        public bool HasKeyboardFocus { get; private set; }
        public string WantedCursor { get; private set; }

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

            // loaded font face
            if (message.Contains("Loaded font face")) {
                type = LogType.Assert;
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
            if (path is null) {
                return file;
            }

            string newPath;
            if (System.IO.Path.DirectorySeparatorChar == '\\') {
                newPath = base.JoinPath(path.Replace(@"/", @"\"), file.Replace(@"/", @"\"));
            }
            else {
                newPath = base.JoinPath(path, file);
            }
            return newPath;
        }

        public override void SetMouseCursor(string cursor) {
            WantedCursor = cursor;

            if (WantedCursor?.StartsWith("0x") == true && WantedCursor.Length > 2) {
                var hotX = 0;
                var hotY = 0;
                uint cursorDid = 0;
                var parts = WantedCursor.Substring(2).Split(' ');
                // try parse hex string to uint
                if (!uint.TryParse(parts[0], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out cursorDid)) {
                    CoreUIPlugin.Log.LogError($"Invalid cursor did: {WantedCursor}");
                    return;
                }

                if (parts.Length > 1 && !int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out hotX)) {
                    CoreUIPlugin.Log.LogError($"Invalid hotX: {parts[1]}");
                }

                if (parts.Length > 2 && !int.TryParse(parts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out hotY)) {
                    CoreUIPlugin.Log.LogError($"Invalid hotX: {parts[2]}");
                }
                CoreUIPlugin.Instance.Backend.SetCursorDid(cursorDid, hotX, hotY);
                return;
            }
            CoreUIPlugin.Instance.Backend.SetCursorDid(0);
        }

        public override void SetClipboardText(string text) {
            CoreUIPlugin.Instance.Backend.SetClipboardText(text);
        }

        public override string GetClipboardText() {
            return CoreUIPlugin.Instance.Backend.GetClipboardText() ?? "";
        }

        public override void ActivateKeyboard(float caretX, float caretY, float lineHeight) {
            HasKeyboardFocus = true;
        }

        public override void DeactivateKeyboard() {
            HasKeyboardFocus = false;
        }
    }
}
