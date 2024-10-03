#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/DataStructHandle.h"
#include <string>

union OffsetToMemberPointer {
    int offset;
    float FakeStruct::*member_pointer_float;
    int FakeStruct::*member_pointer_int;
    Rml::String FakeStruct::*member_pointer_string;
};

RMLUI_CAPI bool rml_StructHandle_RegisterMemberFloat(Rml::StructHandle<FakeStruct>* struct_handle, const char* name, int offset) {
    OffsetToMemberPointer converter;
    converter.offset = offset;

    return struct_handle->RegisterMember(name, converter.member_pointer_float);
}

RMLUI_CAPI bool rml_StructHandle_RegisterMemberInt(Rml::StructHandle<FakeStruct>* struct_handle, const char* name, int offset) {
    OffsetToMemberPointer converter;
    converter.offset = offset;

    return struct_handle->RegisterMember(name, converter.member_pointer_int);
}

RMLUI_CAPI bool rml_StructHandle_RegisterMemberString(Rml::StructHandle<FakeStruct>* struct_handle, const char* name, int offset) {
    OffsetToMemberPointer converter;
    converter.offset = offset;

    return struct_handle->RegisterMember(name, converter.member_pointer_string);
}