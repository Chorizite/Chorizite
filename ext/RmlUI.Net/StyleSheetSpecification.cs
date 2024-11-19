using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet
{
    public static class StyleSheetSpecification
    {
        public static PropertyDefinition RegisterProperty(string name, string defaultValue, bool inherited, bool forcesLayout = false) {
            var intPtr = RmlUiNet.Native.StyleSheetSpecification.RegisterProperty(name, defaultValue, inherited, forcesLayout);
            return new PropertyDefinition(intPtr);
        }
    }
}
