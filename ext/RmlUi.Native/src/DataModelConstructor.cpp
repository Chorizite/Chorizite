#include "RmlNative.h"
#include "RmlUi/Core.h"
#include <string>
#include <sstream>
#include <unordered_map>

typedef void (*dataEventFunc)(Rml::DataModelHandle* model_handle, Rml::Event& evt, Rml::Variant** variants, int num_variants);

static std::unordered_map<Rml::DataModelHandle*, Rml::DataModelHandle> dataModelHandlePool;

RMLUI_CAPI bool rml_DataModelConstructor_BindFloat(Rml::DataModelConstructor* data_model, const char* name, float* data) {
  return data_model->Bind(name, data);
}

RMLUI_CAPI bool rml_DataModelConstructor_BindUInt(Rml::DataModelConstructor* data_model, const char* name, unsigned int* data) {
  return data_model->Bind(name, data);
}

RMLUI_CAPI bool rml_DataModelConstructor_BindInt(Rml::DataModelConstructor* data_model, const char* name, int* data) {
  return data_model->Bind(name, data);
}

RMLUI_CAPI bool rml_DataModelConstructor_BindBool(Rml::DataModelConstructor* data_model, const char* name, bool* data) {
  return data_model->Bind(name, data);
}

RMLUI_CAPI bool rml_DataModelConstructor_BindString(Rml::DataModelConstructor* data_model, const char* name, Rml::String* data) {
  return data_model->Bind(name, data);
}

RMLUI_CAPI bool rml_DataModelConstructor_BindVariable(Rml::DataModelConstructor* data_model, const char* name, Rml::DataVariable* data) {
  return data_model->BindCustomDataVariable(name, *data);
}

std::string GenerateKey(Rml::DataModelConstructor* data_model, const char* name) {
    std::stringstream key;
    key << data_model << "_" << name;
    return key.str();
}

Rml::DataEventFunc MakeEventCallbackWrapper(::dataEventFunc func) {
  return [func](Rml::DataModelHandle model_handle, Rml::Event &event, const Rml::VariantList &variants) {
    int size = static_cast<int>(variants.size());
    Rml::Variant** pointer_array = new Rml::Variant*[size];

    for (int i = 0; i < size; ++i) {
      pointer_array[i] = const_cast<Rml::Variant*>(&variants[i]);
    }

    func(&model_handle, event, pointer_array, size);

    delete[] pointer_array;
  };
}

RMLUI_CAPI bool rml_DataModelConstructor_BindEventCallback(Rml::DataModelConstructor* data_model, const char* name, ::dataEventFunc func) {
  return data_model->BindEventCallback(name, MakeEventCallbackWrapper(func));
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
