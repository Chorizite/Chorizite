namespace Chorizite.Core.Plugins {
    public class PluginsUnloadedEventArgs : System.EventArgs {
        /// <summary>
        /// Whether the plugins are being reloaded.
        /// </summary>
        public bool IsReloading { get; set; }

        public PluginsUnloadedEventArgs(bool isReloading) {
            IsReloading = isReloading;
        }
    }
}