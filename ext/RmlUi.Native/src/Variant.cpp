#include "RmlNative.h"
#include "RmlUi/Core.h"
#include <string>
#include <unordered_map>

RMLUI_CAPI void rml_Variant_Free(Rml::Variant* variant) {
  delete variant;
}

RMLUI_CAPI Rml::Variant* rml_Variant_CreateInt(int value) {
  return new Rml::Variant(value);
}

RMLUI_CAPI Rml::Variant* rml_Variant_CreateString(const char* value) {
  return new Rml::Variant(value);
}

RMLUI_CAPI Rml::Variant* rml_Variant_CreateUInt(unsigned int value) {
  return new Rml::Variant(value);
}

RMLUI_CAPI Rml::Variant* rml_Variant_CreateFloat(float value) {
  return new Rml::Variant(value);
}

RMLUI_CAPI Rml::Variant* rml_Variant_CreateDouble(double value) {
  return new Rml::Variant(value);
}

RMLUI_CAPI Rml::Variant* rml_Variant_CreateBool(bool value) {
  return new Rml::Variant(value);
}

RMLUI_CAPI int rml_Variant_GetType(Rml::Variant* variant) {
  return (int)variant->GetType();
}

RMLUI_CAPI int rml_Variant_GetAsInt(Rml::Variant* variant, int default_value) {
  return variant->Get(default_value);
}

RMLUI_CAPI unsigned int rml_Variant_GetAsUInt(Rml::Variant* variant, unsigned int default_value) {
  return variant->Get(default_value);
}

RMLUI_CAPI float rml_Variant_GetAsFloat(Rml::Variant* variant, float default_value) {
  return variant->Get(default_value);
}

RMLUI_CAPI double rml_Variant_GetAsDouble(Rml::Variant* variant, double default_value) {
  return variant->Get(default_value);
}

RMLUI_CAPI bool rml_Variant_GetAsBool(Rml::Variant* variant, bool default_value) {
  return variant->Get(default_value);
}

RMLUI_CAPI const char* rml_Variant_GetAsString(Rml::Variant* variant, const char* default_value) {
  return _strdup(variant->Get((Rml::String)default_value).c_str());
}
