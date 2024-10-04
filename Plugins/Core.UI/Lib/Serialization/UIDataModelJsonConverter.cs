using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Core.UI.Models;
using System.Reflection;
using RmlUiNet;
using Microsoft.Extensions.Logging;
using System.Collections;
using Autofac;

namespace Core.UI.Lib.Serialization {
    // lol
    public class UIDataModelJsonConverter : JsonConverter<UIDataModel> {
        private readonly CoreUIPlugin _plugin;

        public UIDataModelJsonConverter(CoreUIPlugin plugin) {
            _plugin = plugin;
        }

        public override UIDataModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            return ReadObj(ref reader) as UIDataModel;
        }

        private object ReadObj(ref Utf8JsonReader reader) {
            reader.Read(); // open Obj

            reader.GetString(); // type prop
            reader.Read();
            var modelTypeName = reader.GetString();
            var type = GetType().Assembly.GetType(modelTypeName);
            reader.Read();

            object obj = null;
            if (reader.GetString() == "name") {
                reader.Read();
                var modelName = reader.GetString();
                reader.Read();
                obj = Activator.CreateInstance(type, new object[] { modelName, _plugin });
            }
            else {
                obj = Activator.CreateInstance(type);
            }

            reader.GetString(); // props prop 
            reader.Read();

            ReadObjProps(ref reader, obj);

            reader.Read(); // close Obj

            return obj;
        }

        private void ReadObjProps(ref Utf8JsonReader reader, object obj) {
            reader.Read(); // open Obj
            while (reader.TokenType != JsonTokenType.EndObject) {
                var propName = reader.GetString();
                reader.Read();
                ReadObjValue(ref reader, obj, propName);
            }
            //reader.Read(); // close Obj
        }

        private object ReadValue(ref Utf8JsonReader reader, Type type) {
            if (reader.TokenType == JsonTokenType.Number) {
                if (type == typeof(float)) {
                    return JsonSerializer.Deserialize<float>(ref reader);
                }
                else if (type == typeof(double)) {
                    return JsonSerializer.Deserialize<double>(ref reader);
                }
                else if (type == typeof(int)) {
                    return JsonSerializer.Deserialize<int>(ref reader);
                }
                else if (type == typeof(uint)) {
                    return JsonSerializer.Deserialize<uint>(ref reader);
                }
                else {
                    throw new Exception($"Could not read number: {type}");
                }
            }
            else if (reader.TokenType == JsonTokenType.String) {
                return JsonSerializer.Deserialize<string>(ref reader);
            }
            else if (reader.TokenType == JsonTokenType.StartObject) {
                return ReadObj(ref reader);
            }
            else {
                throw new Exception($"Could not read type: {type}");
            }
        }

        private void ReadObjValue(ref Utf8JsonReader reader, object obj, string propName) {
            var prop = obj.GetType().GetProperty(propName).GetValue(obj);
            var valueProp = prop.GetType().GetProperty("Value");

            if (reader.TokenType == JsonTokenType.StartArray) {
                reader.Read();
                while (reader.TokenType != JsonTokenType.EndArray) {
                    var childObj = ReadValue(ref reader, valueProp.GetValue(prop).GetType().GetGenericArguments().First());
                    valueProp.GetValue(prop).GetType().GetMethod("Add")
                        .Invoke(valueProp.GetValue(prop), new object[] { childObj });
                    reader.Read();
                }
            }
            else {
                valueProp.SetValue(prop, ReadValue(ref reader, valueProp.PropertyType));
            }


            reader.Read();
        }


        public override void Write(Utf8JsonWriter writer, UIDataModel model, JsonSerializerOptions options) {
            WriteModel(writer, model.Name, model, options);
        }

        private void WriteModel(Utf8JsonWriter writer, string name, object model, JsonSerializerOptions options) {
            writer.WriteStartObject(); // start object

            writer.WritePropertyName("type");
            writer.WriteStringValue($"{model.GetType().FullName}");

            writer.WritePropertyName("name");
            writer.WriteStringValue(name);

            WriteProps(model.GetType(), writer, model, options);
            writer.WriteEndObject(); // end object
        }

        private void WriteSubModel(Utf8JsonWriter writer, object model, JsonSerializerOptions options) {
            writer.WriteStartObject(); // start object

            writer.WritePropertyName("type");
            writer.WriteStringValue($"{model.GetType().FullName}");

            WriteProps(model.GetType(), writer, model, options);
            writer.WriteEndObject(); // end object
        }

        private void WriteProps(Type type, Utf8JsonWriter writer, object model, JsonSerializerOptions options) {
            writer.WriteStartObject("props"); // start props
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsAssignableTo(typeof(DataVariable)));


            foreach (var prop in props) {
                if (prop.PropertyType.IsAssignableTo(typeof(DataVariable))) {
                    WriteDataVariable(prop.PropertyType, prop.Name, model, prop.GetValue(model), writer, options);
                }
                else if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(DataVariableList<>)) {
                    WriteDataVariableList(model, writer, options);
                }
                else {
                    CoreUIPlugin.Log.LogWarning($"Property {model.GetType().Name}.{prop.Name} ({prop.PropertyType}) is not serializable 1");
                }
            }

            writer.WriteEndObject(); // end props
        }

        private void WriteDataVariableList(object model, Utf8JsonWriter writer, JsonSerializerOptions options) {
            var listProp = model.GetType().GetProperty("Value");
            var items = (IList)listProp.GetValue(model);
            writer.WriteStartArray();
            for (var i = 0; i < items.Count; i++) {
                var item = items[i];
                WriteDataVariable(item.GetType(), null, model, item, writer, options);
            }
            writer.WriteEndArray();
        }

        private void WriteDataVariable(Type type, string name, object model, object value, Utf8JsonWriter writer, JsonSerializerOptions options) {
            if (!string.IsNullOrEmpty(name)) {
                writer.WritePropertyName(name);
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(DataVariable<>)) {
                if (type.GenericTypeArguments.First() == typeof(string)) {
                    var dataVariable = (DataVariable<string>)value;
                    writer.WriteStringValue(dataVariable.Value);
                    return;
                }
                else if (type.GenericTypeArguments.First() == typeof(uint)) {
                    var dataVariable = (DataVariable<uint>)value;
                    writer.WriteNumberValue(dataVariable.Value);
                    return;
                }
                else if (type.GenericTypeArguments.First() == typeof(int)) {
                    var dataVariable = (DataVariable<int>)value;
                    writer.WriteNumberValue(dataVariable.Value);
                    return;
                }
                else if (type.GenericTypeArguments.First() == typeof(float)) {
                    var dataVariable = (DataVariable<float>)value;
                    writer.WriteNumberValue(dataVariable.Value);
                    return;
                }
                else if (type.GenericTypeArguments.First() == typeof(double)) {
                    var dataVariable = (DataVariable<double>)value;
                    writer.WriteNumberValue(dataVariable.Value);
                    return;
                }
                else if (type.GetGenericArguments().First().IsAssignableTo(typeof(UIDataSubModel))) {
                    WriteSubModel(writer, value.GetType().GetProperty("Value").GetValue(value), options);
                    return;
                }
            }
            else if (value.GetType() == typeof(string)) {
                writer.WriteStringValue((string)value);
                return;
            }
            else if (value.GetType() == typeof(uint)) {
                writer.WriteNumberValue((uint)value);
                return;
            }
            else if (value.GetType() == typeof(int)) {
                writer.WriteNumberValue((int)value);
                return;
            }
            else if (value.GetType() == typeof(float)) {
                writer.WriteNumberValue((float)value);
                return;
            }
            else if (value.GetType() == typeof(double)) {
                writer.WriteNumberValue((double)value);
                return;
            }
            else if (value.GetType().IsAssignableTo(typeof(UIDataSubModel))) {
                WriteSubModel(writer, value, options);
                return;
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(DataVariableList<>)) {
                WriteDataVariableList(value, writer, options);
                return;
            }
            writer.WriteStringValue($"Property {model.GetType().Name}.{name} ({type}) is not serializable");
            CoreUIPlugin.Log.LogWarning($"Property {model.GetType().Name}.{name} ({type}) is not serializable 2");
        }
    }
}
