using ACUI.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib {
    public class PanelRemovedEventArgs : EventArgs {
        public Panel Panel { get; init; }

        public PanelRemovedEventArgs(Panel panel) => Panel = panel;
    }
}
