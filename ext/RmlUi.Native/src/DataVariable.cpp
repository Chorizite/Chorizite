#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/DataVariable.h"
#include <string>

RMLUI_CAPI Rml::DataVariable* rml_DataVariable_Create(Rml::VariableDefinition* definition, void* ptr) {
  return new Rml::DataVariable(definition, ptr);
}

RMLUI_CAPI void rml_DataVariable_Free(Rml::DataVariable* data_variable) {
  delete data_variable;
}