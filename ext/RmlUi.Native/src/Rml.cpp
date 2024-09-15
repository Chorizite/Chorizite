#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "EventListener.h"
#include <string>

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

RMLUI_CAPI Rml::EventListener *rml_CreateEventListener(::onProcessEvent onProcessEvent, ::onAttachEvent onAttachEvent, ::onDetachEvent onDetachEvent) {
    Rml::Log::Message(Rml::Log::Type::LT_DEBUG, "rml_CreateEventListener");
    return new EventListenerProxy(onProcessEvent, onAttachEvent, onDetachEvent);
}

RMLUI_CAPI void rml_ReleaseEventListener(Rml::EventListener *eventListener) {
    delete eventListener;
}

RMLUI_CAPI void rml_RemoveContext(const char *name) {
    Rml::RemoveContext(name);
}

RMLUI_CAPI int rml_Test(const char *name) {
    return 123;
}
