using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.Debugger {


    /// <summary>
    /// An inspected object is an object wrapped with MemberInfo/Parent,
    /// so we can reflect against the parent to get the current value of
    /// primitives.
    /// </summary>
    public class InspectedObject {
        /// <summary>
        /// MemberInfo of an inspected object
        /// </summary>
        public MemberInfo MemberInfo = null;

        /// <summary>
        /// Parent object
        /// </summary>
        public object Parent = null;

        /// <summary>
        /// The type
        /// </summary>
        public Type Type {
            get {
                switch (MemberInfo.MemberType) {
                    case MemberTypes.Property:
                        return (MemberInfo as PropertyInfo).PropertyType;
                    case MemberTypes.Field:
                        return (MemberInfo as FieldInfo).FieldType;
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Value
        /// </summary>
        public object Value => Inspector.GetMemberValue(Parent, MemberInfo);

        public InspectedObject(MemberInfo memberInfo, object parent) {
            MemberInfo = memberInfo;
            Parent = parent;
        }
    }
}
