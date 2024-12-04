#include "RmlNative.h"
#include "RmlUi/Core/Elements/ElementFormControlInput.h"
#include "RmlUi/Core/StyleSheet.h"
#include "RmlUi/Core/StyleSheetContainer.h"
#include "RmlUi/Core/StyleSheetTypes.h"
#include "Pool.h"

RMLUI_CAPI const char* rml_ElementFormControlInput_GetValue(Rml::ElementFormControlInput* element) {
  return strdup(element->GetValue().c_str());
}

RMLUI_CAPI void rml_ElementFormControlInput_SetValue(Rml::ElementFormControlInput* element, const char* value) {
  element->SetValue(value);
}