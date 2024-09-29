using MagicHat.Core.Backend;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.UI.Models {
    public class DatPatchModel : UIDataModel {
        private float _connectPercentage;
        private float _patchPercentage;

        public float ConnectPercentage {
            get => _connectPercentage;
            set {
                if (value != _connectPercentage) {
                    _connectPercentage = value;
                    InvokePropertyChange();
                }
            }
        }

        public float PatchPercentage {
            get => _patchPercentage;
            set {
                if (value != _patchPercentage) {
                    _patchPercentage = value;
                    InvokePropertyChange();
                }
            }
        }

        private Random _rnd = new Random();

        public DatPatchModel(Context context, IMagicHatBackend backend) : base("DatPatchScreen", context) {
            var _lastCheck = DateTime.Now;
            backend.Renderer.OnRender2D += (s, e) => {
                if (DateTime.Now - _lastCheck > TimeSpan.FromMilliseconds(100)) {
                    _lastCheck = DateTime.Now;
                    PatchPercentage = _rnd.NextSingle();
                    ConnectPercentage = _rnd.NextSingle();
                }
            };
        }

        public override void Dispose() {
            base.Dispose();
        }
    }
}
