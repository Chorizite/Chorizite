#include "RmlNative.h"
#include <RmlUi/Debugger.h>

RMLUI_CAPI void rml_Debugger_Initialise(Rml::Context* context) {
	Rml::Debugger::Initialise(context);
}

RMLUI_CAPI void rml_Debugger_Shutdown() {
	Rml::Debugger::Shutdown();
}

RMLUI_CAPI void rml_Debugger_SetContext(Rml::Context* context) {
	Rml::Debugger::SetContext(context);
}

RMLUI_CAPI void rml_Debugger_SetVisible(bool visible) {
	Rml::Debugger::SetVisible(visible);
}

RMLUI_CAPI bool rml_Debugger_IsVisible() {
	return Rml::Debugger::IsVisible();
}
