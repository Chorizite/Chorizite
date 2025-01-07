namespace Chorizite.Core {
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

        ChoriziteEnvironment Environment { get; }
        string DatDirectory { get; init; }
    }
}