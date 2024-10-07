using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core {
    /// <summary>
    /// The configuration for MagicHat
    /// </summary>
    public class MagicHatConfig : IMagicHatConfig {
        /// <inheritdoc/>
        public string PluginDirectory { get; }

        /// <inheritdoc/>
        public string DataDirectory { get; }

        /// <inheritdoc/>
        public string LogDirectory { get; }

        /// <summary>
        /// Create a new <see cref="MagicHatConfig"/>
        /// </summary>
        /// <param name="pluginDirectory">The directory where plugins are stored.</param>
        /// <param name="logDirectory">The directory where log files are stored.</param>
        public MagicHatConfig(string pluginDirectory, string dataDirectory, string logDirectory) {
            PluginDirectory = pluginDirectory;
            DataDirectory = dataDirectory;
            LogDirectory = logDirectory;
        }
    }
}
