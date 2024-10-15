using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core {
    /// <summary>
    /// The configuration for Chorizite
    /// </summary>
    public class ChoriziteConfig : IChoriziteConfig {
        /// <inheritdoc/>
        public string PluginDirectory { get; init; }

        /// <inheritdoc/>
        public string StorageDirectory { get; init; }

        /// <inheritdoc/>
        public string LogDirectory { get; init; }

        /// <inheritdoc/>
        public string DatDirectory { get; init; }

        /// <inheritdoc/>
        public ChoriziteEnvironment Environment { get; init; }

        /// <summary>
        /// Create a new <see cref="ChoriziteConfig"/>
        /// </summary>
        /// <param name="env">The environment to run the Chorizite in.</param>
        /// <param name="pluginDirectory">The directory where plugins are stored.</param>
        /// <param name="dataDirectory"></param>
        /// <param name="logDirectory">The directory where log files are stored.</param>
        /// <param name="datDirectory">The where game dat files are stored.</param>
        public ChoriziteConfig(ChoriziteEnvironment env, string pluginDirectory, string dataDirectory, string logDirectory, string datDirectory) {
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
