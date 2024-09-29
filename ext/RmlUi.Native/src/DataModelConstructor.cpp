#include "RmlNative.h"
#include "RmlUi/Core.h"
#include <string>

RMLUI_CAPI bool rml_DataModelConstructor_BindFloat(Rml::DataModelConstructor* data_model, const char* name, float* data) {
  return data_model->Bind(name, data);
}

RMLUI_CAPI bool rml_DataModelConstructor_BindString(Rml::DataModelConstructor* data_model, const char* name, const char* data) {
  return data_model->Bind(name, data);
}
