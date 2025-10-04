using DatReaderWriter.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Handles text layout, including line wrapping and width measurement.
    /// </summary>
    public class TextLayout {
        private readonly Func<char, FontCharDesc?> _getCharDesc;

        public TextLayout(Func<char, FontCharDesc?> getCharDesc) {
            _getCharDesc = getCharDesc;
        }

        /// <summary>
        /// Lays out the text into lines based on an optional maximum width.
        /// </summary>
        /// <param name="text">The text to layout</param>
        /// <param name="maxWidth">Optional maximum width to wrap at; if null, no wrapping occurs</param>
        /// <returns>A tuple containing the list of lines and their corresponding widths</returns>
        public (List<string> lines, List<float> lineWidths) LayoutText(string text, float? maxWidth = null) {
            List<string> lines = new List<string>();
            List<float> lineWidths = new List<float>();

            if (maxWidth == null) {
                // No wrapping, split only on explicit newlines
                var explicitLines = text.Split('\n');
                foreach (var line in explicitLines) {
                    string trimmedLine = line.TrimEnd();
                    float trimmedWidth = MeasureLineWidth(trimmedLine);
                    lines.Add(line);
                    lineWidths.Add(trimmedWidth);
                }
            }
            else {
                float maxW = maxWidth.Value;
                var explicitLines = text.Split('\n');
                foreach (var explicitLine in explicitLines) {
                    var words = explicitLine.Split(' ', StringSplitOptions.None);
                    var currentLine = new StringBuilder();
                    float currentLineWidth = 0;

                    foreach (var word in words) {
                        var wordText = word + (word != words.Last() ? " " : "");
                        float wordWidth = MeasureLineWidth(wordText);

                        if (currentLineWidth + wordWidth <= maxW || currentLine.Length == 0) {
                            currentLine.Append(wordText);
                            currentLineWidth += wordWidth;
                        }
                        else {
                            if (currentLine.Length > 0) {
                                string lineText = currentLine.ToString();
                                string trimmedLine = lineText.TrimEnd();
                                float trimmedWidth = MeasureLineWidth(trimmedLine);
                                lines.Add(lineText);
                                lineWidths.Add(trimmedWidth);
                                currentLine.Clear();
                                currentLineWidth = 0;
                            }

                            if (wordWidth > maxW) {
                                var chars = word.ToCharArray();
                                for (int i = 0; i < chars.Length; i++) {
                                    var c = chars[i];
                                    var charWidth = MeasureLineWidth(c.ToString());
                                    if (currentLineWidth + charWidth > maxW && currentLine.Length > 0) {
                                        string lineText = currentLine.ToString();
                                        string trimmedLine = lineText.TrimEnd();
                                        float trimmedWidth = MeasureLineWidth(trimmedLine);
                                        lines.Add(lineText);
                                        lineWidths.Add(trimmedWidth);
                                        currentLine.Clear();
                                        currentLineWidth = 0;
                                    }
                                    currentLine.Append(c);
                                    currentLineWidth += charWidth;
                                }
                                if (word != words.Last()) {
                                    var spaceWidth = MeasureLineWidth(" ");
                                    if (currentLineWidth + spaceWidth <= maxW) {
                                        currentLine.Append(' ');
                                        currentLineWidth += spaceWidth;
                                    }
                                }
                            }
                            else {
                                currentLine.Append(wordText);
                                currentLineWidth += wordWidth;
                            }
                        }
                    }

                    if (currentLine.Length > 0) {
                        string lineText = currentLine.ToString();
                        string trimmedLine = lineText.TrimEnd();
                        float trimmedWidth = MeasureLineWidth(trimmedLine);
                        lines.Add(lineText);
                        lineWidths.Add(trimmedWidth);
                    }
                }
            }

            return (lines, lineWidths);
        }

        /// <summary>
        /// Measures the width of a single line of text.
        /// </summary>
        /// <param name="line">The line to measure</param>
        /// <returns>The width of the line</returns>
        private float MeasureLineWidth(string line) {
            float width = 0;
            foreach (char c in line) {
                var charDesc = _getCharDesc(c);
                if (charDesc != null) {
                    width += charDesc.HorizontalOffsetBefore + charDesc.Width + charDesc.HorizontalOffsetAfter;
                }
            }
            return width;
        }
    }
}