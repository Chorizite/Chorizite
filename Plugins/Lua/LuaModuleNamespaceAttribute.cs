using System;

namespace Lua {
    internal class LuaModuleNamespaceAttribute : Attribute {
        public LuaModuleNamespaceAttribute(params string[] ns) {
            Namespaces = ns;
        }

        /// <summary>
        /// The namespace to include in this lua module
        /// </summary>
        public string[] Namespaces { get; }
    }
}