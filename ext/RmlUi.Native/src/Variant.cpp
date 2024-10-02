#include "RmlNative.h"
#include "RmlUi/Core.h"
#include <string>
#include <unordered_map>

RMLUI_CAPI int rml_Variant_GetType(Rml::Variant* variant) {
  return (int)variant->GetType();
}

RMLUI_CAPI double rml_Variant_GetAsDouble(Rml::Variant* variant, double default_value) {
  return variant->Get(default_value);
}

RMLUI_CAPI const char* rml_Variant_GetAsString(Rml::Variant* variant, const char* default_value) {
  return _strdup(variant->Get((Rml::String)default_value).c_str());
}
