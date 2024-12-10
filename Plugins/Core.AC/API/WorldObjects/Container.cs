using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.AC.API.WorldObjects {
    public class Container : WorldObject {
        /// <summary>
        /// child item ids, excluding containers // equipped (assuming this item is a container) (not recursive,
        /// meaning it doesn't include child container items, just non-container items contained directly in this container)
        /// </summary>
        public List<uint> ItemIds { get; } = [];

        /// <summary>
        /// child container ids, including foci
        /// </summary>
        public List<uint> ContainerIds { get; } = [];

        /// <summary>
        /// Type of container
        /// </summary>
        public ContainerProperties ContainerProperties { get; set; }

        /// <summary>
        /// List of weenie ids contained with this item. It also returns item ids contained within containers within this container.
        /// </summary>
        [JsonIgnore]
        public IEnumerable<uint> AllItemIds {
            get {
                var itemIds = new List<uint>();

                itemIds.AddRange(ItemIds);
                //foreach (var container in Containers) {
                //    itemIds.AddRange(container.ItemIds);
                //}

                return itemIds;
            }
        }
    }
}
