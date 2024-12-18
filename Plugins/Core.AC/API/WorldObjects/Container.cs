using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.AC.API.WorldObjects {
    public class Container : Item {
        /// <summary>
        /// child items, excluding containers // equipped (assuming this item is a container) (not recursive,
        /// meaning it doesn't include child container items, just non-container items contained directly in this container)
        /// </summary>
        public List<WorldObject> Items { get; } = [];

        /// <summary>
        /// child containers, including foci
        /// </summary>
        public List<Container> Containers { get; } = [];

        /// <summary>
        /// Type of container
        /// </summary>
        public ContainerProperties ContainerType { get; set; } = ContainerProperties.None;
    }
}
