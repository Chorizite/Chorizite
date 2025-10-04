using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;
using DatReaderWriter.DBObjs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.DrawCommands {
    /// <summary>
    /// A draw command for rendering text
    /// </summary>
    public class DrawTextCommand : IDrawCommand {
        public DrawCommandType Type => DrawCommandType.DrawText;
        public IFont Font { get; }
        public string Text { get; }
        public Rectangle Dest { get; }
        public ColorVec Color { get; }
        public TextOptions Options { get; set; }

        public DrawTextCommand(IFont font, string text, Rectangle dest, ColorVec color, TextOptions options) {
            Font = font;
            Text = text;
            Dest = dest;
            Color = color;
            Options = options;
        }
    }
}
