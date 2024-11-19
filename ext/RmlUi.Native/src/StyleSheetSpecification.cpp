#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/StyleSheetSpecification.h"
#include "Pool.h"

Rml::PropertyDefinition* def;

RMLUI_CAPI Rml::PropertyDefinition* rml_StyleSheetSpecification_RegisterProperty(const char* property_name, const char* default_value, bool inherited, bool forces_layout) {
  def = &Rml::StyleSheetSpecification::RegisterProperty(property_name, default_value, inherited, forces_layout);
  return def;
}