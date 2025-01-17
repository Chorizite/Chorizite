using Chorizite.Core;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using Chorizite.DocGen.LuaDefs.Lib.models;
using System.Text.RegularExpressions;

namespace Chorizite.DocGen.LuaDefs.Lib {
    public class SystemTypeRegistry : TypeRegistry {
        private HttpClient _http;
        private MetadataLoadContext _loadContext;

        public override MetadataLoadContext LoadContext => _loadContext;
        public override Assembly ChoriziteAssembly => null;

        public SystemTypeRegistry(Chorizite<DocGenBackend> chorizite, ScriptableTypeFinder scriptableTypeFinder) : base(chorizite, scriptableTypeFinder) {
            Init();
        }

        private void Init() {
            List<string> paths = [];

            // Create the list of assembly paths consisting of runtime assemblies and the inspected assembly.
            paths.AddRange(Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll"));
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll")) {
                paths.Add(file);
            }

            // Create PathAssemblyResolver that can resolve assemblies using the created list.
            var resolver = new PathAssemblyResolver(paths);

            _loadContext = new MetadataLoadContext(resolver, "mscorlib");

            LoadType(typeof(System.Object));
            LoadType(typeof(System.Type));
            LoadType(typeof(System.IDisposable));
            LoadType(typeof(System.Version));
            LoadType(typeof(System.IntPtr));
            LoadType(typeof(System.Text.Rune));
            LoadType(typeof(System.TypeCode));
            LoadType(typeof(System.Globalization.Calendar));
            LoadType(typeof(System.Globalization.CalendarAlgorithmType));
            LoadType(typeof(System.Globalization.CalendarWeekRule));
            LoadType(typeof(System.Globalization.CompareInfo));
            LoadType(typeof(System.Globalization.TextInfo));
            LoadType(typeof(System.Globalization.CultureTypes));
            LoadType(typeof(System.Globalization.CompareOptions));
            LoadType(typeof(System.Globalization.SortVersion));
            LoadType(typeof(System.Globalization.SortKey));
            LoadType(typeof(System.Globalization.NumberFormatInfo));
            LoadType(typeof(System.Globalization.DateTimeFormatInfo));
            LoadType(typeof(System.Globalization.DigitShapes));
            LoadType(typeof(System.TimeSpan));
            LoadType(typeof(System.DateTime));
            LoadType(typeof(System.DateOnly));
            LoadType(typeof(System.TimeOnly));
            LoadType(typeof(System.IFormatProvider));
            LoadType(typeof(System.DayOfWeek));
            LoadType(typeof(System.DateTimeKind));
            LoadType(typeof(System.IO.Stream));
            LoadType(typeof(System.IO.FileAccess));
            LoadType(typeof(System.IO.FileMode));
            LoadType(typeof(System.IO.FileShare));
            LoadType(typeof(System.IO.FileStream));
            LoadType(typeof(System.IO.FileStreamOptions));
            LoadType(typeof(System.IO.FileOptions));
            LoadType(typeof(System.IO.UnixFileMode));
            LoadType(typeof(System.IO.BinaryReader));
            LoadType(typeof(System.IO.BinaryWriter));
            LoadType(typeof(System.IO.SeekOrigin));
            LoadType(typeof(System.Text.Encoding));
            LoadType(typeof(System.Globalization.CultureInfo));
            LoadType(typeof(System.Reflection.ManifestResourceInfo));
            LoadType(typeof(System.Reflection.ResourceLocation));
            LoadType(typeof(System.Reflection.AssemblyName));
            LoadType(typeof(System.Reflection.BindingFlags));
            LoadType(typeof(System.Reflection.ParameterModifier));
            LoadType(typeof(System.Reflection.InterfaceMapping));
            LoadType(typeof(System.Reflection.MemberInfo));
            LoadType(typeof(System.Reflection.Assembly));
            LoadType(typeof(System.Reflection.Module));
            LoadType(typeof(System.Reflection.ConstructorInfo));
            LoadType(typeof(System.Reflection.FieldInfo));
            LoadType(typeof(System.Reflection.MethodInfo));
            LoadType(typeof(System.Reflection.PropertyInfo));
            LoadType(typeof(System.Reflection.EventInfo));
            LoadType(typeof(System.Reflection.ParameterInfo));
            LoadType(typeof(System.Reflection.CustomAttributeData));
            LoadType(typeof(System.Reflection.MemberFilter));
            LoadType(typeof(System.Reflection.MemberTypes));
            LoadType(typeof(System.Reflection.MethodBase));
            LoadType(typeof(System.Reflection.GenericParameterAttributes));
            LoadType(typeof(System.Reflection.PropertyAttributes));
            LoadType(typeof(System.Reflection.MethodAttributes));
            LoadType(typeof(System.Reflection.ParameterAttributes));
            LoadType(typeof(System.Reflection.EventAttributes));
            LoadType(typeof(System.Reflection.TypeAttributes));
            LoadType(typeof(System.Reflection.FieldAttributes));
            LoadType(typeof(System.Reflection.MethodImplAttributes));
            LoadType(typeof(System.Reflection.CallingConventions));
            LoadType(typeof(System.Reflection.TypeInfo));
            LoadType(typeof(System.RuntimeTypeHandle));
            LoadType(typeof(System.RuntimeMethodHandle));
            LoadType(typeof(System.RuntimeFieldHandle));
            LoadType(typeof(System.RuntimeArgumentHandle));
            LoadType(typeof(System.Reflection.Binder));
            LoadType(typeof(System.Security.SecurityRuleSet));
            LoadType(typeof(System.Reflection.TypeFilter));
            LoadType(typeof(System.ModuleHandle));
            LoadType(typeof(System.Runtime.InteropServices.StructLayoutAttribute));
            LoadType(typeof(System.Attribute));
            LoadType(typeof(System.EventArgs));
            LoadType(typeof(System.Guid));
            LoadType(typeof(System.Runtime.InteropServices.LayoutKind));
            LoadType(typeof(System.Runtime.InteropServices.CharSet));
            LoadType(typeof(System.Reflection.CustomAttributeTypedArgument));
            LoadType(typeof(System.Reflection.CustomAttributeNamedArgument));
            LoadType(typeof(System.Reflection.ICustomAttributeProvider));
            LoadType(typeof(System.Numerics.Vector2));
            LoadType(typeof(System.Numerics.Vector3));
            LoadType(typeof(System.Numerics.Vector4));
            LoadType(typeof(System.Numerics.Matrix3x2));
            LoadType(typeof(System.Numerics.Matrix4x4));
            LoadType(typeof(System.Numerics.Quaternion));
            LoadType(typeof(System.Numerics.Plane));
            LoadType(typeof(System.Net.IPAddress));
            LoadType(typeof(System.Net.Sockets.AddressFamily));
            LoadType(typeof(System.Net.NetworkInformation.PhysicalAddress));
            LoadType(typeof(Microsoft.Extensions.Logging.LogLevel));
            LoadType(typeof(Microsoft.Extensions.Logging.ILogger));
            LoadType(typeof(System.Exception));
            LoadType(typeof(System.Collections.IEnumerable));
            LoadType(typeof(System.Collections.ICollection));
            LoadType(typeof(System.Collections.IDictionary));
        }

        private void LoadType(Type type) {
            try {
                var xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "SystemXml");
                if (!Directory.Exists(xmlPath)) {
                    Directory.CreateDirectory(xmlPath);
                }
                string xml = null;
                if (!File.Exists(Path.Combine(xmlPath, $"{type.Name}.xml"))) {
                    _http ??= new HttpClient();
                    //https://raw.githubusercontent.com/dotnet/dotnet-api-docs/refs/heads/main/xml/System/Type.xml
                    var task = _http.GetStringAsync($"https://raw.githubusercontent.com/dotnet/dotnet-api-docs/refs/heads/main/xml/{type.Namespace}/{type.Name}.xml");

                    if (!string.IsNullOrEmpty(task.Result)) {
                        File.WriteAllText(Path.Combine(xmlPath, $"{type.Name}.xml"), task.Result);
                    }
                }

                if (File.Exists(Path.Combine(xmlPath, $"{type.Name}.xml"))) {
                    xml = File.ReadAllText(Path.Combine(xmlPath, $"{type.Name}.xml"));
                }

                if (string.IsNullOrEmpty(xml)) {
                    Console.WriteLine($"No xml for {type.Name}");
                    return;
                }

                XDocument xdoc = new XDocument();
                xdoc = XDocument.Parse(xml);

                foreach (var e in xdoc.Descendants("MemberSignature")) {
                    if (e.Attribute("Language")?.Value == "DocId") {
                        DocEntries.Add(e.Attribute("Value").Value, new XMLDocEntry() {
                            Id = e.Attribute("Value").Value,
                            Summary = e.Parent.Descendants("summary").FirstOrDefault()?.ToString()
                        });
                    }
                }

                if (type.IsEnum) {
                    var enumDef = new EnumDef(type, this);
                    DocEntries.Add(XMLDocEntry.MakeId(enumDef), new XMLDocEntry() {
                        Id = XMLDocEntry.MakeId(enumDef),
                        Summary = xdoc.Descendants("summary").FirstOrDefault()?.Value
                    });

                    Enums.Add(type.Name, enumDef);
                }
                else {
                    var classDef = new ClassDef(type, this);
                    DocEntries.Add(XMLDocEntry.MakeId(classDef), new XMLDocEntry() {
                        Id = XMLDocEntry.MakeId(classDef),
                        Summary = xdoc.Descendants("summary").FirstOrDefault()?.Value
                    });

                    Classes.Add(type.Name, classDef);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
