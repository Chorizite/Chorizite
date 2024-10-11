namespace MagicHat.Core {
    public interface IMagicHatConfig {
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

        MagicHatEnvironment Environment { get; }
        string DatDirectory { get; init; }
    }
}