using Autofac;
using Chorizite.Core.Plugins;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Lib {
    public static class PathHelpers {
        /// <summary>
        /// This will try and find a "development" version of a file path by looking for a manifest.dev.json.
        /// If it finds one, it will first attempt to load the file from the source directory defined in the manifest.dev.json.
        /// Then it attempts to load the file from the build firectory defined in the manifest.dev.json.
        /// If it doesn't find a dev manifest, it will return the original path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string TryMakeDevPath(string path) {
            if (ChoriziteStatics.Scope.Resolve<IPluginManager>()?.TryGetPluginFromPath(path, out var plugin) == true) {
                var relativePath = path.Replace(plugin.Manifest.BaseDirectory, string.Empty).TrimStart(['/', '\\']);

                // first attempt to load from the source defined in manifest.dev.json
                if (!string.IsNullOrWhiteSpace(plugin.DevManifest?.Source)) {
                    var sourcePath = Path.Combine(plugin.DevManifest.Source, relativePath);
                    if (File.Exists(sourcePath)) {
                        return sourcePath;
                    }
                }

                // second attempt to load from the build directory defined in manifest.dev.json
                if (!string.IsNullOrWhiteSpace(plugin.DevManifest?.Bin)) {
                    var binPath = Path.Combine(plugin.DevManifest.Bin, relativePath);
                    if (File.Exists(binPath)) {
                        return binPath;
                    }
                }
            }

            return path;
        }
    }
}
