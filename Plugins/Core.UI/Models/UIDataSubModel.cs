using ACUI.Lib;
using RmlUiNet;

namespace Core.UI.Models {
    public class UIDataSubModel : DataVariable {
        public UIDataSubModel([System.Runtime.CompilerServices.CallerMemberName] string memberName = "") {
            var def = new VariableDefinition<DataVariable>(memberName, this);
            Definition = def;
            CreateNative(Definition);
        }
    }
}