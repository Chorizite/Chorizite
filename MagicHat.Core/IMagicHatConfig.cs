namespace MagicHat.Core {
    public interface IMagicHatConfig {
        /// <summary>
        /// The directory where plugins are stored.
        /// </summary>
        string PluginDirectory { get; }

        /// <summary>
        /// The directory where log files are stored.
        /// </summary>
        string LogDirectory { get; }
    }
}