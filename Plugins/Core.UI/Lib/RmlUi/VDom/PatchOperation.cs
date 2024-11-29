using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.RmlUi.VDom {
    // Represents the differences between two Virtual DOM trees
    public class PatchOperation {
        public enum OperationType {
            Replace,
            Add,
            Remove,
            UpdateProps,
            UpdateText
        }

        public OperationType Type { get; set; }
        public VirtualNode? NewNode { get; set; }
        public int Index { get; set; }
        public uint NodeId { get; internal set; }

        public PatchOperation(uint nodeId) {
            NodeId = nodeId;
        }
    }
}
