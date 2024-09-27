using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.RmlUi.Elements {
    public class DatIconElement : ElementCustom {
        public DatIconElement() : base("daticon") {
            //ACUI.UI.Instance?.Log?.LogDebug($"HELLO FROM DatImgElement::DatImgElement() 0x{NativePtr:X8} // {Rml.GetRenderInterface()} // {Rml.GetRenderInterface()?.NativePtr:X8}");
            //Rml.GetRenderInterface()?.Test();
        }

        public override void OnRender() {
            //ACUI.UI.Instance?.Log?.LogDebug($"HELLO FROM DatImgElement::Render(): {GetClientWidth()}x{GetClientHeight()} @ ({GetAbsoluteLeft()}, {GetAbsoluteTop()}): {GetAttributeString("fileid")}");
        }
    }
}
