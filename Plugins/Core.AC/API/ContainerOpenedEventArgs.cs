using Core.AC.API.WorldObjects;

namespace Core.AC.API {
    /// <summary>
    /// ContainerOpenedEventArgs
    /// </summary>
    public class ContainerOpenedEventArgs : System.EventArgs {
        /// <summary>
        /// The container weenie that was opened
        /// </summary>
        public Container Container { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container"></param>
        public ContainerOpenedEventArgs(Container container) {
            Container = container;
        }
    }
}