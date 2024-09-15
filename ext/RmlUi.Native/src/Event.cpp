#include "RmlNative.h"
#include "RmlUi/Core/ElementDocument.h"
#include "Util.h"

RMLUI_CAPI Rml::EventId rml_Event_GetId(Rml::Event *ev) {
    return ev->GetId();
}

RMLUI_CAPI Rml::EventPhase rml_Event_GetPhase(Rml::Event *ev) {
    return ev->GetPhase();
}

RMLUI_CAPI const char *rml_Event_GetCurrentElement(Rml::Event *ev, Rml::Element **element) {
    *element = ev->GetCurrentElement();

    return rmlui_type_name(**element);
}

RMLUI_CAPI const char *rml_Event_GetTargetElement(Rml::Event *ev, Rml::Element **element) {
    *element = ev->GetTargetElement();

    return rmlui_type_name(**element);
}

RMLUI_CAPI void rml_Event_StopPropagation(Rml::Event *ev) {
    ev->StopPropagation();
}

RMLUI_CAPI void rml_Event_StopImmediatePropagation(Rml::Event *ev) {
    ev->StopImmediatePropagation();
}

RMLUI_CAPI bool rml_Event_IsInterruptible(Rml::Event *ev) {
    return ev->IsInterruptible();
}

RMLUI_CAPI bool rml_Event_IsPropagating(Rml::Event *ev) {
    return ev->IsPropagating();
}

RMLUI_CAPI bool rml_Event_IsImmediatePropagating(Rml::Event *ev) {
    return ev->IsImmediatePropagating();
}
