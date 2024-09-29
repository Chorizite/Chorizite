#include "RmlNative.h"
#include "RmlUi/Core.h"
#include <string>
#include <unordered_map>

static std::unordered_map<Rml::DataModelHandle*, Rml::DataModelHandle> dataModelHandlePool;


RMLUI_CAPI bool rml_DataModelConstructor_BindFloat(Rml::DataModelConstructor* data_model, const char* name, float* data) {
  return data_model->Bind(name, data);
}

RMLUI_CAPI bool rml_DataModelConstructor_BindString(Rml::DataModelConstructor* data_model, const char* name, Rml::String* data) {
  return data_model->Bind(name, data);
}

RMLUI_CAPI Rml::DataModelHandle* rml_DataModelConstructor_GetModelHandle(Rml::DataModelConstructor* data_model) {
    Rml::DataModelHandle handle = data_model->GetModelHandle();
    dataModelHandlePool[&handle] = handle;
    return &dataModelHandlePool[&handle];
}

RMLUI_CAPI void rml_DataModelHandle_Free(Rml::DataModelHandle* handle_ptr) {
  auto it = dataModelHandlePool.find(handle_ptr);
  if (it != dataModelHandlePool.end()) {
    dataModelHandlePool.erase(it);
  }
}
