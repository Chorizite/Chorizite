using System;

namespace Chorizite.NativeClientBootstrapper.Lib {
    internal class SigScanAttribute : Attribute {
        public SigScanAttribute(string v) {
            V = v;
        }

        public string V { get; }
    }
}