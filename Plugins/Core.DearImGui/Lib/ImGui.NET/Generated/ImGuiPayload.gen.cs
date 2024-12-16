using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiPayload
    {
        public void* Data;
        public int DataSize;
        public uint SourceId;
        public uint SourceParentId;
        public int DataFrameCount;
        public fixed byte DataType[33];
        public byte Preview;
        public byte Delivery;
    }
    public unsafe partial struct ImGuiPayloadPtr
    {
        public ImGuiPayload* NativePtr { get; }
        public ImGuiPayloadPtr(ImGuiPayload* nativePtr) => NativePtr = nativePtr;
        public ImGuiPayloadPtr(IntPtr nativePtr) => NativePtr = (ImGuiPayload*)nativePtr;
        public static implicit operator ImGuiPayloadPtr(ImGuiPayload* nativePtr) => new ImGuiPayloadPtr(nativePtr);
        public static implicit operator ImGuiPayload* (ImGuiPayloadPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiPayloadPtr(IntPtr nativePtr) => new ImGuiPayloadPtr(nativePtr);
        public IntPtr Data { get => (IntPtr)NativePtr->Data; set => NativePtr->Data = (void*)value; }
        public int DataSize { get { return NativePtr->DataSize; } set { NativePtr->DataSize = value; } }
        public uint SourceId { get { return NativePtr->SourceId; } set { NativePtr->SourceId = value; } }
        public uint SourceParentId { get { return NativePtr->SourceParentId; } set { NativePtr->SourceParentId = value; } }
        public int DataFrameCount { get { return NativePtr->DataFrameCount; } set { NativePtr->DataFrameCount = value; } }
        public RangeAccessor<byte> DataType => new RangeAccessor<byte>(NativePtr->DataType, 33);
        public bool Preview { get { return NativePtr->Preview == 1; } set { NativePtr->Preview = value ? (byte)1 : (byte)0; } }
        public bool Delivery { get { return NativePtr->Delivery == 1; } set { NativePtr->Delivery = value ? (byte)1 : (byte)0; } }
        public void Clear()
        {
            ImGuiNative.ImGuiPayload_Clear((ImGuiPayload*)(NativePtr));
        }
        public void Destroy()
        {
            ImGuiNative.ImGuiPayload_destroy((ImGuiPayload*)(NativePtr));
        }
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public bool IsDataType(ReadOnlySpan<char> type)
#else
        public bool IsDataType(string type)
#endif
        {
            byte* native_type;
            int type_byteCount = 0;
            if (type != null)
            {
                type_byteCount = Encoding.UTF8.GetByteCount(type);
                if (type_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_type = Util.Allocate(type_byteCount + 1);
                }
                else
                {
                    byte* native_type_stackBytes = stackalloc byte[type_byteCount + 1];
                    native_type = native_type_stackBytes;
                }
                int native_type_offset = Util.GetUtf8(type, native_type, type_byteCount);
                native_type[native_type_offset] = 0;
            }
            else { native_type = null; }
            byte ret = ImGuiNative.ImGuiPayload_IsDataType((ImGuiPayload*)(NativePtr), native_type);
            if (type_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_type);
            }
            return ret != 0;
        }
        public bool IsDelivery()
        {
            byte ret = ImGuiNative.ImGuiPayload_IsDelivery((ImGuiPayload*)(NativePtr));
            return ret != 0;
        }
        public bool IsPreview()
        {
            byte ret = ImGuiNative.ImGuiPayload_IsPreview((ImGuiPayload*)(NativePtr));
            return ret != 0;
        }
    }
}
