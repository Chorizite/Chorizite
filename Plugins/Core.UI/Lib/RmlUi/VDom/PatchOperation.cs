using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.RmlUi.VDom {
    public enum DomPatchType {
        Replace,
        Add,
        Remove,
        UpdateProps,
        UpdateText
    }

    // Represents the differences between two Virtual DOM trees
    public class PatchOperation {

        public DomPatchType Type { get; set; }
        public VirtualNode? NewNode { get; set; }
        public int Index { get; set; }
        public VirtualNode Parent { get; internal set; }
        public VirtualNode OldNode { get; internal set; }

        public PatchOperation() {
        }
    }
}
