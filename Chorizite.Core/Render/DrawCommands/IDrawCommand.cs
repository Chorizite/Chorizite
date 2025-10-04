using Chorizite.Core.Render.Enums;

namespace Chorizite.Core.Render.DrawCommands {
    /// <summary>
    /// Interface for draw commands
    /// </summary>
    public interface IDrawCommand {
        /// <summary>
        /// Type of draw command
        /// </summary>
        public DrawCommandType Type { get; }
    }
}