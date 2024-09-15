using RoyT.TrueType;
using RoyT.TrueType.Helpers;
using RoyT.TrueType.Tables.Name;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.Lib.Fonts {
    public class FontInfo {
        public string Filename { get; }
        public string Family { get; }
        public FontSubFamily SubFamily { get; }

        public FontInfo(string filename, TrueTypeFont font) {
            Filename = filename;

            Family = NameHelper.GetName(NameId.FontFamilyName, CultureInfo.CurrentCulture, font);
            var subFamily = NameHelper.GetName(NameId.FontSubfamilyName, CultureInfo.CurrentCulture, font);
            switch (subFamily.ToLower()) {
                case "italic":
                    SubFamily = FontSubFamily.Italic;
                    break;
                case "bold":
                    SubFamily = FontSubFamily.Bold;
                    break;
                case "italic bold":
                case "bold italic":
                    SubFamily = FontSubFamily.BoldItalic;
                    break;
                default:
                    SubFamily = FontSubFamily.Regular;
                    break;
            }
        }

        public override bool Equals(object obj) {
            return obj is FontInfo info && info.Family == Family && info.SubFamily == SubFamily;
        }

        public override int GetHashCode() {
            unchecked {
                int hash = 17;
                hash = hash * 23 + Family.GetHashCode();
                hash = hash * 23 + SubFamily.GetHashCode();
                return hash;
            }
        }
    }
}
