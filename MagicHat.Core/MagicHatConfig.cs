using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core {
    /// <summary>
    /// The configuration for MagicHat
    /// </summary>
    public class MagicHatConfig : IMagicHatConfig {
        /// <inheritdoc/>
        public string PluginDirectory { get; init; }

        /// <inheritdoc/>
        public string StorageDirectory { get; init; }

        /// <inheritdoc/>
        public string LogDirectory { get; init; }

        /// <inheritdoc/>
        public string DatDirectory { get; init; }

        /// <inheritdoc/>
        public MagicHatEnvironment Environment { get; init; }

        /// <summary>
        /// Create a new <see cref="MagicHatConfig"/>
        /// </summary>
        /// <param name="env">The environment to run the MagicHat in.</param>
        /// <param name="pluginDirectory">The directory where plugins are stored.</param>
        /// <param name="dataDirectory"></param>
        /// <param name="logDirectory">The directory where log files are stored.</param>
        /// <param name="datDirectory">The where game dat files are stored.</param>
        public MagicHatConfig(MagicHatEnvironment env, string pluginDirectory, string dataDirectory, string logDirectory, string datDirectory) {
            Environment = env;
            PluginDirectory = pluginDirectory;
            StorageDirectory = dataDirectory;
            LogDirectory = logDirectory;
            DatDirectory = datDirectory;

            if (!Directory.Exists(PluginDirectory)) {
                Directory.CreateDirectory(PluginDirectory);
            }

            if (!Directory.Exists(StorageDirectory)) {
                Directory.CreateDirectory(StorageDirectory);
            }

            if (!Directory.Exists(LogDirectory)) {
                Directory.CreateDirectory(LogDirectory);
            }
        }
    }
}
