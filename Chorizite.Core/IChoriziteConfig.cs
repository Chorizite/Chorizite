using Chorizite.Common.Enums;

namespace Chorizite.Core {
    /// <summary>
    /// Configuration for Chorizite
    /// </summary>
    public interface IChoriziteConfig {
        /// <summary>
        /// The directory where the core chorizite files are stored.
        /// </summary>
        string BaseDirectory { get; }

        /// <summary>
        /// The directory where plugins are stored.
        /// </summary>
        string PluginDirectory { get; }

        /// <summary>
        /// The directory where data is stored.
        /// </summary>
        string StorageDirectory { get; }

        /// <summary>
        /// The directory where log files are stored.
        /// </summary>
        string LogDirectory { get; }

        /// <summary>
        /// The environment Chorizite is running in
        /// </summary>
        ChoriziteEnvironment Environment { get; }

        /// <summary>
        /// The directory where dat files are stored
        /// </summary>
        string DatDirectory { get; init; }
    }
}