#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/Property.h"
#include <string>

RMLUI_CAPI Rml::Variant* rml_Property_Get(Rml::Property* property) {
  return &property->value;
}

RMLUI_CAPI const char* rml_Property_GetString(Rml::Property* property, const char *default_value) {
  auto res = property->Get<Rml::String>();
	return _strdup(res.c_str());
}