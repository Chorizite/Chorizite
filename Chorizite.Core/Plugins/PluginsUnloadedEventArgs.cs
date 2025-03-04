namespace Chorizite.Core.Plugins {
    /// <summary>
    /// Arguments for the PluginsUnloaded event.
    /// </summary>
    public class PluginsUnloadedEventArgs : System.EventArgs {
        /// <summary>
        /// Whether the plugins are being reloaded.
        /// </summary>
        public bool IsReloading { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isReloading"></param>
        public PluginsUnloadedEventArgs(bool isReloading) {
            IsReloading = isReloading;
        }
    }
}