using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Lib {
    public static class PathHelpers {
        private static string _devPathPattern = $"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}net8.0{Path.DirectorySeparatorChar}";

        /// <summary>
        /// This will try and find a "development" version of a file path by looking for the source directory
        /// (instead of the bin directory). If one is found, it will be returned. Otherwise the original path is returned.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string TryMakeDevPath(string path) {
            if (path.Contains(_devPathPattern)) {
                try {
                    var dir = path.Split(_devPathPattern);
                    if (dir.Length == 2) {
                        var devPath = Path.Combine(dir[0], dir[1]);
                        if (File.Exists(devPath)) {
                            path = Path.Combine(dir[0], dir[1]);
                        }
                    }
                }
                catch { }
            }

            return path;
        }
    }
}
