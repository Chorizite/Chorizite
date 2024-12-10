#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "EventListener.h"
#include <string>

static std::unordered_map<Rml::String*, Rml::String> dataModelPool;

RMLUI_CAPI bool rml_Initialise() {
    return Rml::Initialise();
}

RMLUI_CAPI void rml_Shutdown() {
    Rml::Shutdown();
}

RMLUI_CAPI void rml_SetRenderInterface(Rml::RenderInterface *renderInterface) {
    Rml::SetRenderInterface(renderInterface);
}

RMLUI_CAPI void rml_SetSystemInterface(Rml::SystemInterface *systemInterface) {
    Rml::SetSystemInterface(systemInterface);
}

RMLUI_CAPI void rml_SetFileInterface(Rml::FileInterface* fileInterface) {
    Rml::SetFileInterface(fileInterface);
}

RMLUI_CAPI void rml_LoadFontFace(const char *fileName, bool fallbackFace, Rml::Style::FontWeight weight) {
    Rml::LoadFontFace(fileName, fallbackFace, weight);
}

RMLUI_CAPI Rml::EventId rml_RegisterEventType(const char* type, bool interruptible, bool bubbles, Rml::DefaultActionPhase default_action_phase) {
    return Rml::RegisterEventType(type, interruptible, bubbles, default_action_phase);
}

RMLUI_CAPI Rml::EventListener *rml_CreateEventListener(::onProcessEvent onProcessEvent, ::onAttachEvent onAttachEvent, ::onDetachEvent onDetachEvent) {
    return new EventListenerProxy(onProcessEvent, onAttachEvent, onDetachEvent);
}

RMLUI_CAPI void rml_ReleaseEventListener(Rml::EventListener *eventListener) {
    delete eventListener;
}

RMLUI_CAPI void rml_RemoveContext(const char *name) {
    Rml::RemoveContext(name);
}

RMLUI_CAPI void rml_RegisterPlugin(Rml::Plugin *plugin) {
    Rml::RegisterPlugin(plugin);
}

RMLUI_CAPI Rml::RenderInterface* rml_GetRenderInterface() {
    return Rml::GetRenderInterface();
}

RMLUI_CAPI Rml::SystemInterface* rml_GetSystemInterface() {
    return Rml::GetSystemInterface();
}

RMLUI_CAPI std::string* rml_CreateString(const char* value) {
    auto str = new Rml::String(value);
    dataModelPool[str] = *str;
    return str;
}

RMLUI_CAPI void rml_Log(Rml::Log::Type type,  char* message) {
    Rml::Log::Message(type, message);
}

RMLUI_CAPI void rml_UpdateString(std::string* str, const char* new_value) {
    *str = new_value;
}

RMLUI_CAPI void rml_FreeString(std::string* str) {
        dataModelPool.erase(str);
}