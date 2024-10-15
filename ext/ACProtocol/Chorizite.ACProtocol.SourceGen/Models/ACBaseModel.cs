using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Chorizite.ACProtocol.SourceGen.Models {
    public abstract class ACBaseModel {
        public ACBaseModel Parent { get; set; } = null;
        public XElement Element { get; }
        public List<ACBaseModel> Children { get; set; } = new List<ACBaseModel>();

        public List<ACBaseModel> AllChildren {
            get {
                var names = new List<string>();
                return FindChildren(this).Distinct().Where(c => {
                    if (c is ACDataMember && !names.Contains((c as ACDataMember).Name)) {
                        names.Add((c as ACDataMember).Name);
                        return true;
                    }
                    if (c is ACVector && !names.Contains((c as ACVector).Name)) {
                        names.Add((c as ACVector).Name);
                        return true;
                    }
                    return false;
                }).ToList();
            }
        }

        public List<ACVector> AllVectors {
            get {
                var names = new List<string>();
                return FindChildren(this, false).Distinct().Where(c => {
                    if (c is ACVector && !names.Contains((c as ACVector).Name)) {
                        names.Add((c as ACVector).Name);
                        return true;
                    }
                    return false;
                }).Select(c => c as ACVector).ToList();
            }
        }

        private static List<ACBaseModel> FindChildren(ACBaseModel model, bool skipVectors = true) {
            var models = new List<ACBaseModel>();
            var children = model.Children.ToList();

            if (model is ACIf) {
                children.AddRange((model as ACIf).TrueMembers);
                children.AddRange((model as ACIf).FalseMembers);
            }

            if (model is ACMaskMap) {
                children.AddRange((model as ACMaskMap).Masks);
            }

            if (model is ACSwitch) {
                children.AddRange((model as ACSwitch).Cases);
            }

            if (model is ACDataMember) {
                children.AddRange((model as ACDataMember).SubMembers);
            }

            if (skipVectors && model is ACVector)
                return models;

            foreach (var child in children) {
                models.Add(child);
                models.AddRange(FindChildren(child, skipVectors));
            }

            return models;
        }

        public ACBaseModel(ACBaseModel parent, XElement element) {
            Parent = parent;
            Element = element;
            Children = ParseChildren(element);
        }

        internal bool HasParentOfType(Type type) {
            if (Parent == null)
                return false;
            else if (Parent.GetType() == type)
                return true;
            else
                return Parent.HasParentOfType(type);
        }

        internal T GetParentOfType<T>() {
            if (Parent == null)
                return (T)(object)null;
            else if (Parent is T)
                return (T)(object)Parent;
            else
                return Parent.GetParentOfType<T>();
        }

        public List<ACBaseModel> ParseChildren(XElement element) {
            var children = new List<ACBaseModel>();

            if (element == null) {
                return children;
            }

            var childNodes = element.XPathSelectElements("./*");
            foreach (var childNode in childNodes) {
                switch (childNode.Name.LocalName) {
                    case "member":
                    case "field":
                        children.Add(ACDataMember.FromXElement(this, childNode));
                        break;
                    case "vector":
                        children.Add(ACVector.FromXElement(this, childNode));
                        break;
                    case "maskmap":
                        children.Add(ACMaskMap.FromXElement(this, childNode));
                        break;
                    case "align":
                        children.Add(ACAlign.FromXElement(this, childNode));
                        break;
                    case "if":
                        children.Add(ACIf.FromXElement(this, childNode));
                        break;
                    case "switch":
                        children.Add(ACSwitch.FromXElement(this, childNode));
                        break;
                    default:
                        //Logger.Log($"Unhandled ACDataType child node type: {childNode.Name.LocalName}");
                        break;
                }
            }

            return children;
        }
    }
}
