using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core;
using Core.UI;
using ACUI.Lib;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO.Compression;

namespace PluginManagerUI {
    public class PluginManagerUICore : IPluginCore {
        internal static ILogger Log;
        private Panel? _panel;
        private HttpClient _http = new HttpClient();

        internal CoreUIPlugin UI { get; }
        internal IPluginManager Manager { get; }

        protected PluginManagerUICore(AssemblyPluginManifest manifest, IPluginManager manager, CoreUIPlugin coreUI, ILogger log) : base(manifest) {
            Log = log;
            UI = coreUI;
            Manager = manager;
        }

        public override void Initialize() {
            _panel = UI.CreatePanel("PluginManagerUI", Path.Combine(AssemblyDirectory, "assets", "manager.rml"));
            
            if (_panel is not null) {
                _panel.ShowInBar = true;
                _panel.Show();
            }
        }

        /// <summary>
        /// Get the releases json
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetReleasesJson() {
            // download the releases json
            return File.ReadAllText(@"D:\projects\Chorizite.PluginIndex\site\index.json");
            var releases = await _http.GetStringAsync("https://chorizite.github.io/plugin-index/index.json");
            return releases;
        }

        /// <summary>
        /// Get release json for a specific plugin
        /// </summary>
        /// <param name="name">The name of the plugin</param>
        /// <returns>Release json</returns>
        public async Task<string?> GetPluginReleasesJson(string name) {
            try {
                if (name == "PluginManagerUI") {
                    return File.ReadAllText(@"D:\projects\Chorizite.PluginIndex\site\plugins\PluginManagerUI.json");
                }
                var releases = await _http.GetStringAsync($"https://chorizite.github.io/plugin-index/plugins/{name}.json");
                return releases;
            }
            catch {
                return null;
            }
        }

        public async Task<bool> UninstallPlugin(string name) {
            try {
                Manager.UnloadPlugin(name);
                Directory.Delete(Path.Combine(Manager.PluginDirectory, name), true);
                return true;
            }
            catch (Exception ex) {
                Log.LogError(ex, "Failed to uninstall plugin");
                return false;
            }
        }

        /// <summary>
        /// Install a plugin by name and zip url / file
        /// </summary>
        /// <param name="name">The name of the plugin</param>
        /// <param name="zipUri">A url or local file path to the zip that contains the plugin.</param>
        /// <returns>True if successful</returns>
        public async Task<bool> InstallPlugin(string name, string zipUri) {
            var zipTmpPath = Path.GetTempFileName();
            try {
                byte[] zipBytes;
                if (zipUri.StartsWith("http")) {
                    zipBytes = await _http.GetByteArrayAsync(zipUri);
                }
                else {
                    zipBytes = File.ReadAllBytes(zipUri);
                }
                File.WriteAllBytes(zipTmpPath, zipBytes);
                var zip = ZipFile.OpenRead(zipTmpPath);
                var pluginDir = Path.Combine(Manager.PluginDirectory, name);
                if (Directory.Exists(pluginDir)) {
                    //Directory.Delete(pluginDir, true);
                }
                if (!Directory.Exists(pluginDir)) {
                    Directory.CreateDirectory(pluginDir);
                }
                zip.ExtractToDirectory(pluginDir, true);
                if (!Manager.Plugins.ContainsKey(name)) {
                    //Manager.LoadPlugin(name);
                }
                return true;
            }
            catch (Exception ex) {
                Log.LogError(ex, "Failed to install plugin");
                return false;
            }
            finally {
                try {
                    File.Delete(zipTmpPath);
                }
                catch { }
            }
        }

        protected override void Dispose() {
            _panel?.Dispose();
            _http?.Dispose();
        }
    }
}
