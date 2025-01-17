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

        public string BaseDirectory { get; init; }

        public ChoriziteConfig(ChoriziteEnvironment env, string baseDirectory, string datDirectory) {
            Environment = env;
            BaseDirectory = baseDirectory;

            PluginDirectory = Path.Combine(baseDirectory, "plugins");
            StorageDirectory = Path.Combine(baseDirectory, "data");
            LogDirectory = Path.Combine(baseDirectory, "logs");
            DatDirectory = datDirectory;
        }
    }
}
