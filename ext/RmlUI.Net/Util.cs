using System;
using System.Runtime.InteropServices;
using RmlUiNet.Exceptions;
using RmlUiNet.Native;

namespace RmlUiNet
{
    /*
    internal static unsafe partial class Extern
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl)]
        public static extern Buffer cs_buffer_new(ulong size);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl)]
        public static extern void cs_buffer_free(Buffer* str);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct Buffer
    {
        public long size;
        public unsafe byte* data;
    }
    
    internal static unsafe class BufferUtils
    {
        public static byte[] ConvertToArrayAndDelete(ref Buffer buffer)
        {
            var result = new Span<byte>(buffer.data, (int)buffer.size).ToArray();

            fixed (Buffer* bufferPtr = &buffer)
            {
                Extern.cs_buffer_free(bufferPtr);
            }

            return result;
        }
    }*/

    internal static class Util
    {
        public static Element GetOrThrowElementByTypeName(IntPtr elementPtr, string elementType)
        {
            var element = GetElementByTypeName(elementPtr, elementType);

            if (null == element) {
                throw new Exception($"Element type not supported[IntPtr: {elementPtr:X8}]: {elementType} ({elementType == "class Rml::ElementFormControlInput"})");
            }

            return element;
        }

        public static Element? GetElementByTypeName(IntPtr elementPtr, string elementType)
        {
            if (elementType == "class Rml::ElementDocument" || elementType == "class ElementDocumentCustom") {
                return ElementDocument.Create(elementPtr);
            } else if (elementType == "class Rml::ElementDocument") {
                return ElementDocument.Create(elementPtr);
            } else if (elementType == "class Rml::ElementForm") {
                return ElementForm.Create(elementPtr);
            } else if (elementType == "class Rml::ElementFormControl") {
                return ElementFormControl.Create(elementPtr);
            } else if (elementType == "class Rml::ElementFormControlDataSelect") {
                return ElementFormControlDataSelect.Create(elementPtr);
            } else if (elementType == "class Rml::ElementFormControlInput") {
                return ElementFormControlInput.Create(elementPtr);
            } else if (elementType == "class Rml::ElementFormControlSelect") {
                return ElementFormControlSelect.Create(elementPtr);
            } else if (elementType == "class Rml::ElementFormControlTextArea") {
                return ElementFormControlTextArea.Create(elementPtr);
            } else if (elementType == "class Rml::ElementProgress") {
                return ElementProgress.Create(elementPtr);
            } else if (elementType == "class Rml::ElementTabSet") {
                return ElementTabSet.Create(elementPtr);
            } else if (elementType == "class Rml::ElementText") {
                return ElementText.Create(elementPtr);
            }
            else if (elementType == "class Rml::Element")
            {
                return ElementGeneric.Create(elementPtr);
            }
            else if (elementType == "class Rml::ElementLabel")
            {
                return ElementGeneric.Create(elementPtr);
            }

            return ElementGeneric.Create(elementPtr);
        }

        public static Variant? ToVariant(object value)
        {
            if (value is string stringValue)
            {
                return new Variant(Native.Variant.CreateString(stringValue));
            }
            else if (value is int intValue)
            {
                return new Variant(Native.Variant.CreateInt(intValue));
            }
            else if (value is uint uintValue)
            {
                return new Variant(Native.Variant.CreateUInt(uintValue));
            }
            else if (value is float floatValue)
            {
                return new Variant(Native.Variant.CreateFloat(floatValue));
            }
            else if (value is double doubleValue)
            {
                return new Variant(Native.Variant.CreateDouble(doubleValue));
            }
            else if (value is bool boolValue)
            {
                return new Variant(Native.Variant.CreateBool(boolValue));
            }
            else
            {
                Rml.Log($"Unsupport variant value type: {value?.GetType().Name ?? "null"}, must be one of: string, int, uint, float, double, bool.", LogType.Error);
            }
            return null;
        }
    }
}
