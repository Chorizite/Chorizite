#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "EventListener.h"
#include "Pool.h"
#include <string>

static std::unordered_map<std::string, Rml::DataModelConstructor> dataModelPool;

RMLUI_CAPI void *rml_Context_New(const char *name, Rml::Vector2i dimensions, Rml::RenderInterface *renderInterface) {
    return Rml::CreateContext(name, dimensions, renderInterface);
}

RMLUI_CAPI void rml_Context_Delete(Rml::Context *context) {
    if (context != nullptr)
        delete context;
}

RMLUI_CAPI void rml_Context_Update(Rml::Context *context) {
    context->Update();
}

RMLUI_CAPI Rml::Element* rml_Context_GetHoverElement(Rml::Context *context) {
    return context->GetHoverElement();
}

RMLUI_CAPI void rml_Context_SetDimensions(Rml::Context *context, int x, int y) {
    auto vec = Rml::Vector2i(x, y);
    context->SetDimensions(vec);
}

RMLUI_CAPI void rml_Context_Render(Rml::Context *context) {
    context->Render();
}

RMLUI_CAPI void *rml_Context_LoadDocument(Rml::Context *context, const char *documentPath) {
    return context->LoadDocument(documentPath);
}

RMLUI_CAPI void *rml_Context_LoadDocumentFromMemory(Rml::Context *context, const char *documentRml, const char *sourceUrl) {
    return context->LoadDocumentFromMemory(documentRml, sourceUrl);
}

RMLUI_CAPI bool rml_Context_IsMouseInteracting(Rml::Context *context) {
    return context->IsMouseInteracting();
}

RMLUI_CAPI bool rml_Context_ProcessMouseLeave(Rml::Context *context) {
    return context->ProcessMouseLeave();
}

RMLUI_CAPI Rml::Element* rml_Context_GetFocusElement(Rml::Context *context) {
    return context->GetFocusElement();
}

RMLUI_CAPI Rml::Element* rml_Context_GetRootElement(Rml::Context *context) {
    return context->GetRootElement();
}

RMLUI_CAPI void rml_Context_UnfocusDocument(Rml::Context *context, Rml::ElementDocument* document) {
    return context->UnfocusDocument(document);
}

RMLUI_CAPI bool rml_Context_ProcessMouseMove(Rml::Context *context, int x, int y, int keyModifierState) {
    return context->ProcessMouseMove(x, y, keyModifierState);
}

RMLUI_CAPI bool rml_Context_ProcessMouseButtonDown(Rml::Context *context, int button_index, int keyModifierState) {
    return context->ProcessMouseButtonDown(button_index, keyModifierState);
}

RMLUI_CAPI bool rml_Context_ProcessMouseButtonUp(Rml::Context *context, int button_index, int keyModifierState) {
    return context->ProcessMouseButtonUp(button_index, keyModifierState);
}

RMLUI_CAPI bool rml_Context_ProcessMouseWheel(Rml::Context* context, Rml::Vector2f wheel_delta, int key_modifier_state) {
    return context->ProcessMouseWheel(wheel_delta, key_modifier_state);
}

RMLUI_CAPI bool rml_Context_ProcessKeyDown(Rml::Context *context, Rml::Input::KeyIdentifier identifier, int keyModifierState) {
    return context->ProcessKeyDown(identifier, keyModifierState);
}

RMLUI_CAPI bool rml_Context_ProcessKeyUp(Rml::Context *context, Rml::Input::KeyIdentifier identifier, int keyModifierState) {
    return context->ProcessKeyUp(identifier, keyModifierState);
}

RMLUI_CAPI bool rml_Context_ProcessTextInput(Rml::Context* context, const char* input) {
    return context->ProcessTextInput(input);
}

RMLUI_CAPI void rml_Context_AddEventListener(Rml::Context *context, const char *event, Rml::EventListener *eventListener,
                             bool inCapturePhase) {
    context->AddEventListener(event, eventListener, inCapturePhase);
}

RMLUI_CAPI void rml_Context_RemoveEventListener(Rml::Context *context, const char *event, Rml::EventListener *eventListener,
                                bool inCapturePhase) {
    context->RemoveEventListener(event, eventListener, inCapturePhase);
}

RMLUI_CAPI const char* rml_Context_GetName(Rml::Context *context) {
    return context->GetName().c_str();
}

RMLUI_CAPI Rml::DataModelConstructor* rml_Context_CreateDataModel(Rml::Context* context, const char* name) {
    if (!context || !name) return nullptr;

    auto result = context->CreateDataModel(name);
    dataModelPool[name] = result;

    return &dataModelPool[name];
}

RMLUI_CAPI Rml::DataModelConstructor* rml_Context_GetDataModel(Rml::Context* context, const char* name) {
    if (!context || !name) return nullptr;

    auto it = dataModelPool.find(name);
    if (it != dataModelPool.end()) {
        return &it->second;
    }

    auto data_model = context->GetDataModel(name);
    if (data_model) {
        dataModelPool[name] = data_model;
        return &dataModelPool[name];
    }

    return nullptr;
  }

RMLUI_CAPI bool rml_Context_RemoveDataModel(Rml::Context* context, const char* name) {
    if (!context || !name) return false;
    bool removed = context->RemoveDataModel(name);
    if (removed) {
        dataModelPool.erase(name);
    }
    return removed;
}
