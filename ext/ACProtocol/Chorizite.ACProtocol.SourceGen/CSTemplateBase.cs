using Chorizite.ACProtocol.SourceGen.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.ACProtocol.SourceGen {
    /// <summary>
    /// Template base for generate csharp code
    /// </summary>
    public abstract class CSTemplateBase : TextTemplateBase {

        public string GetTypeDeclaration(ACDataMember member) {
            var simplifiedType = SimplifyType(member.MemberType);
            if (MessageReader.ACTemplatedTypes.ContainsKey(member.MemberType)) {
                simplifiedType = MessageReader.ACTemplatedTypes[member.MemberType].ParentType;
            }
            if (!string.IsNullOrWhiteSpace(member.GenericKey) && !string.IsNullOrWhiteSpace(member.GenericValue))
                return $"{simplifiedType}<{SimplifyType(member.GenericKey)}, {SimplifyType(member.GenericValue)}>";
            if (!string.IsNullOrWhiteSpace(member.GenericType))
                return $"{simplifiedType}<{SimplifyType(member.GenericType)}>";
            return simplifiedType;
        }

        public string GetTypeDeclaration(ACDataType member) {
            foreach (var child in member.Children) {
                if (child is ACVector) {
                    var memberTypes = child.Children.Where(c => c is ACDataMember).Select(
                        c => SimplifyType((c as ACDataMember).MemberType)
                    );
                    return member.Name + "<" + string.Join(", ", memberTypes) + ">";
                }
            }

            return member.Name;
        }

        public string GetTypeDeclaration(ACVector vector) {
            if (vector.Children.Count == 1) {
                return $"List<{SimplifyType((vector.Children.First() as ACDataMember).MemberType)}>";
            }
            else {
                return $"List<{GetVectorClassName(vector, true)}>";
            }
        }

        public override void WriteUsingAliases(Dictionary<string, string> typeAliases) {
            //foreach (var kv in typeAliases) {
            //    WriteLine($"using {kv.Key} = {kv.Value};");
            //}
        }

        private void WriteVectorItemClassDefinition(ACVector vector) {
            WriteSummary($"Vector collection data for the {vector.Name} vector");
            WriteLine($"public class {GetVectorClassName(vector)} {{");
            using (new IndentHelper(this)) {
                var usedNames = new List<string>();
                foreach (var child in vector.Children) {
                    GenerateClassProperties(child, ref usedNames);
                }
            }
            WriteLine("}\n");
        }

        private string GetVectorClassName(ACVector vector, bool fullyQualified = false) {
            var parent = "";
            if (fullyQualified && vector.HasParentOfType(typeof(ACVector))) {
                var p = vector.GetParentOfType<ACVector>();
                while (p != null) {
                    parent = GetVectorClassName(p) + "." + parent;
                    p = p.GetParentOfType<ACVector>();
                }
            }
            return vector.Type;
        }

        /// <summary>
        /// Writes out a csharp xml summary comment
        /// </summary>
        /// <param name="text"></param>
        public override void WriteSummary(string text) {
            if (string.IsNullOrWhiteSpace(text))
                return;

            WriteLine("/// <summary>");
            WriteLine("/// " + WebUtility.HtmlEncode(text));
            WriteLine("/// </summary>");
        }

        /// <summary>
        /// Writes out a csharp class property definition
        /// </summary>
        /// <param name="member"></param>
        public override void WriteClassProperty(ACDataMember member) {
            WriteSummary(member.Text);
            if (MessageReader.ACTemplatedTypes.ContainsKey(member.MemberType)) {
                WriteLine("public " + GetTypeDeclaration(member) + " " + member.Name + " = new();\n");
            }
            else {
                WriteLine("public " + GetTypeDeclaration(member) + " " + member.Name + ";\n");
            }
        }

        /// <summary>
        /// Write out a class property definition for a submember
        /// </summary>
        /// <param name="member"></param>
        public override void WriteClassProperty(ACSubMember member) {
            var parent = member.Parent as ACDataMember;
            var simplifiedType = SimplifyType(member.Type);
            var getter = member.Value;
            if (!string.IsNullOrWhiteSpace(member.Shift))
                getter = "(" + parent.Name + " >> " + member.Shift + ")";
            if (!string.IsNullOrWhiteSpace(member.And))
                getter = "(" + (string.IsNullOrWhiteSpace(getter) ? parent.Name : getter) + " & " + member.And + ")";
            WriteSummary("Derived from " + parent.Name + ". " + member.Text);
            WriteLine("public " + simplifiedType + " " + member.Name + " { get => (" + simplifiedType + ")(" + getter + "); }\n");
        }

        /// <summary>
        /// Write out a class property definition for a vector
        /// </summary>
        /// <param name="vector"></param>
        public override void WriteClassVectorProperty(ACVector vector) {
            if (vector.Children.Count > 1)
                WriteVectorItemClassDefinition(vector);

            WriteSummary(vector.Text);
            WriteLine($"public {GetTypeDeclaration(vector)} {vector.Name} = new {GetTypeDeclaration(vector)}();\n");
        }

        /// <summary>
        /// Writes out csharp to read an ACEnum
        /// </summary>
        /// <param name="member"></param>
        public override void WriteEnumReader(ACDataMember member) {
            var reader = GetBinaryReaderForType(MessageReader.ACEnums[member.MemberType].ParentType);
            if (member.HasParentOfType(typeof(ACVector))) {
                WriteLine("var " + member.Name + " = (" + member.MemberType + ")" + reader + ";");
            }
            else {
                WriteLine(member.Name + " = (" + member.MemberType + ")" + reader + ";");
            }
        }

        /// <summary>
        /// Writes out csharp to read an ACDataType
        /// </summary>
        /// <param name="member"></param>
        public override void WriteDataReader(ACDataMember member) {
            if (member.MemberType == "Vector3") {
                WriteLine($"{member.Name} = reader.ReadVector3();");
                return;
            }
            if (member.MemberType == "Quaternion") {
                WriteLine($"{member.Name} = reader.ReadQuaternion();");
                return;
            }

            if (member.HasParentOfType(typeof(ACVector))) {
                WriteLine("var " + member.Name + " = new " + GetTypeDeclaration(member) + "()" + ";");
            }
            else {
                WriteLine(member.Name + " = new " + GetTypeDeclaration(member) + "()" + ";");
            }
            WriteLine(member.Name + ".Read(reader);");
        }

        /// <summary>
        /// Writes out csharp to read a primitive
        /// </summary>
        /// <param name="member"></param>
        public override void WritePrimitiveReader(ACDataMember member) {
            if (member.Parent is ACVector)
                WriteLine("var " + member.Name + " = " + GetBinaryReaderForType(member.MemberType) + ";");
            else
                WriteLine(member.Name + " = " + GetBinaryReaderForType(member.MemberType) + ";");
        }

        /// <summary>
        /// Write out a csharp if statement condition
        /// </summary>
        /// <param name="condition"></param>
        public override void WriteIfStatementStart(string condition) {
            WriteLine($"if ({condition}) {{");
            Indent();
        }

        /// <summary>
        /// Write out a csharp if statement ending
        /// </summary>
        /// <param name="condition"></param>
        public override void WriteIfStatementEnding(string condition) {
            Outdent();
            WriteLine("}");
        }

        /// <summary>
        /// Write out a csharp else statement condition
        /// </summary>
        public override void WriteElseStatementStart() {
            WriteLine("else {");
            Indent();
        }

        /// <summary>
        /// Write out a csharp else statement ending
        /// </summary>
        public override void WriteElseStatementEnding() {
            Outdent();
            WriteLine("}");
        }

        /// <summary>
        /// Write out csharp code for the start of a mask map check
        /// </summary>
        /// <param name="mask"></param>
        public override void WriteMaskMapCheckStart(ACMaskMap maskMap, ACMask mask) {
            if (!string.IsNullOrEmpty(maskMap.XOR)) {
                WriteIfStatementStart($"(((uint){maskMap.Name} ^ {maskMap.XOR}) & {mask.Value}) != 0");
            }
            else if (mask.Value.StartsWith("0x")) {
                WriteIfStatementStart($"((uint){maskMap.Name} & (uint){mask.Value}) != 0");
            }
            else {
                WriteIfStatementStart($"{maskMap.Name}.HasFlag({mask.Value})");
            }
        }

        /// <summary>
        /// Write out csharp code for the ending of a mask map check
        /// </summary>
        /// <param name="mask"></param>
        public override void WriteMaskMapCheckEnding(ACMaskMap maskMap, ACMask mask) {
            if (!string.IsNullOrEmpty(maskMap.XOR))
                WriteIfStatementEnding($"((uint)({maskMap.Name} ^ {maskMap.XOR}) & {mask.Value}) != 0");
            else
                WriteIfStatementEnding($"((uint){(mask.Parent as ACMaskMap).Name} & {mask.Value}) != 0");
        }

        /// <summary>
        /// Write out the code to align the buffer
        /// </summary>
        /// <param name="align"></param>
        public override void WriteAlignmentCheck(ACAlign align) {
            var condition = "(reader.BaseStream.Position % 4) != 0";
            WriteIfStatementStart(condition);
            WriteLine("reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);");
            WriteIfStatementEnding(condition);
        }

        /// <summary>
        /// Write out the start of a switch statement
        /// </summary>
        /// <param name="acswitch"></param>
        public override void WriteSwitchStart(ACSwitch acswitch) {
            WriteLine($"switch((int){acswitch.Name}) {{");
            Indent();
        }

        /// <summary>
        /// Write out csharp code for the ending of a switch statement
        /// </summary>
        /// <param name="acswitch"></param>
        public override void WriteSwitchEnding(ACSwitch acswitch) {
            Outdent();
            WriteLine("}");
        }

        /// <summary>
        /// Write out csharp code for the start of a switch case statement
        /// </summary>
        /// <param name="scase"></param>
        public override void WriteSwitchCaseStart(ACSwitchCase scase) {
            var cases = scase.Value.Split(new string[] { " | " }, StringSplitOptions.None);
            foreach (var s in cases) {
                WriteLine("case " + s + ":");
            }
            Indent();
        }

        /// <summary>
        /// Write out csharp code for the ending of a switch case statement
        /// </summary>
        /// <param name="scase"></param>
        public override void WriteSwitchCaseEnding(ACSwitchCase scase) {
            WriteLine("break;");
            Outdent();
        }

        /// <summary>
        /// Write out the csharp code for the start of a for loop
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="depth"></param>
        public override void WriteForLoopStart(ACVector vector, int depth) {
            var indexVar = new string[] { "i", "x", "y", "z", "q", "p", "t", "r", "f", "g", "h", "k", "u", "v" }[depth];

            if (!string.IsNullOrEmpty(vector.Skip)) {
                WriteLine($"for (var {indexVar}=0; {indexVar} < {vector.Length} - {vector.Skip}; {indexVar}++) {{");
            }
            else {
                WriteLine($"for (var {indexVar}=0; {indexVar} < {vector.Length}; {indexVar}++) {{");
            }
            Indent();
        }

        /// <summary>
        /// Write out the csharp code for the end of a for loop
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="depth"></param>
        public override void WriteForLoopEnding(ACVector vector, int depth) {
            Outdent();
            WriteLine("}");
        }

        /// <summary>
        /// Write out the csharp code to push a single item to a vector
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="child"></param>
        public override void WriteVectorPusher(ACVector vector, ACBaseModel child) {
            var name = child is ACVector ? (child as ACVector).Name : (child as ACDataMember).Name;
            WriteLine($"{vector.Name}.Add({name});");
        }

        /// <summary>
        /// Write out the csharp code to push a complex item to a vector
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="children"></param>
        public override void WriteVectorPusher(ACVector vector, List<ACBaseModel> children) {
            WriteLine($"{vector.Name}.Add(reader.ReadItem<{GetVectorClassName(vector, true)}>());");
        }

        private void WriteVectorChildDefinition(ACBaseModel child) {
            if (child.GetType() != typeof(ACVector) && child.GetType() != typeof(ACDataMember) && child.GetType() != typeof(ACSwitch)) {
                WriteLine("Unknown Child: " + child.GetType());
                return;
            }

            if (child is ACSwitch) {
                foreach (var cchild in (child as ACSwitch).Cases) {
                    foreach (var ccchild in cchild.Children) {
                        WriteVectorChildDefinition(ccchild);
                    }
                }
                return;
            }

            var name = child is ACVector ? (child as ACVector).Name : (child as ACDataMember).Name;
            WriteLine($"{name} = {name},");
        }

        /// <summary>
        /// Write out the csharp code to define a local child vector
        /// </summary>
        /// <param name="vector"></param>
        public override void WriteLocalVectorDefinition(ACVector vector) {
            WriteLine($"var {vector.Name} = new {GetTypeDeclaration(vector)}();");
        }

        /// <summary>
        /// Write out the code to define a local child variable
        /// </summary>
        /// <param name="child"></param>
        public override void WriteLocalChildDefinition(ACDataMember child) {
            var type = SimplifyType(child.MemberType);
            switch (type) {
                case "SpellID":
                case "ushort":
                case "short":
                case "ObjectID":
                case "uint":
                case "int":
                case "ulong":
                case "long":
                case "float":
                case "double":
                case "byte":
                    WriteLine($"{type} {child.Name} = 0;");
                    break;
                case "bool":
                    WriteLine($"{type} {child.Name} = false;");
                    break;
                default:
                    WriteLine($"{type} {child.Name} = null;");
                    break;
            }
        }

        /// <summary>
        /// Writes out csharp code to read a type from a buffer
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override string GetBinaryReaderForType(string type) {
            switch (type) {
                case "WORD":
                case "SpellId":
                case "ushort":
                    return "reader.ReadUInt16()";
                case "short":
                    return "reader.ReadInt16()";
                case "DWORD":
                case "ObjectId":
                case "LandcellId":
                case "uint":
                    return "reader.ReadUInt32()";
                case "int":
                    return "reader.ReadInt32()";
                case "ulong":
                    return "reader.ReadUInt64()";
                case "long":
                    return "reader.ReadInt64()";
                case "float":
                    return "reader.ReadSingle()";
                case "double":
                    return "reader.ReadDouble()";
                case "bool":
                    return "reader.ReadBool()";
                case "byte":
                    return "reader.ReadByte()";
                case "string":
                    return "reader.ReadString16L()";
                case "WString":
                    return "reader.ReadString32L()";
                case "PackedWORD":
                    return "reader.ReadPackedWORD()";
                case "DataID":
                case "DataId":
                case "PackedDWORD":
                    return "reader.ReadPackedDWORD()";
                default:
                    return "UnknownType:" + type;
            }
        }
    }
}
