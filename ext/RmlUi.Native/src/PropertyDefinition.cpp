#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/StyleSheetSpecification.h"
#include <string>

RMLUI_CAPI Rml::PropertyDefinition* rml_PropertyDefinition_AddParser(Rml::PropertyDefinition* property_definition, const char* parser_name, const char* parser_params) {
  return &property_definition->AddParser(parser_name, parser_params);
}

RMLUI_CAPI Rml::PropertyId rml_PropertyDefinition_GetId(Rml::PropertyDefinition* property_definition) {
  return property_definition->GetId();
}

RMLUI_CAPI const char* rml_PropertyDefinition_GetValueString(Rml::PropertyDefinition* property_definition, Rml::Property* property, const char* default_value) {
  auto str = new Rml::String();
  if (property_definition->GetValue(*str, *property)) {
    return _strdup(str->c_str());
  }
  return _strdup(default_value);
}