#include "RmlNative.h"
#include "RmlUi/Core.h"
#include <string>

RMLUI_CAPI void rml_DataModelHandle_DirtyAllVariables(Rml::DataModelHandle* model_handle) {
  model_handle->DirtyAllVariables();
}

RMLUI_CAPI void rml_DataModelHandle_DirtyVariable(Rml::DataModelHandle* model_handle, const char* variable_name) {
  model_handle->DirtyVariable(variable_name);
}

RMLUI_CAPI bool rml_DataModelHandle_IsVariableDirty(Rml::DataModelHandle* model_handle, const char* variable_name) {
  return model_handle->IsVariableDirty(variable_name);
}
