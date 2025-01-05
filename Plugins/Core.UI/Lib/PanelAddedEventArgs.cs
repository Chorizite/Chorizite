using System;

namespace ACUI.Lib {
    public class PanelAddedEventArgs : EventArgs {
        public Panel Panel { get; init; }

        public PanelAddedEventArgs(Panel panel) => Panel = panel;
    }
}