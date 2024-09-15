#include "RmlNative.h"
#include "RmlUi/Core/Element.h"
#include "Util.h"

RMLUI_CAPI const char *rml_Element_GetTagName(Rml::Element *element) {
    return element->GetTagName().c_str();
}

RMLUI_CAPI void
rml_Element_AddEventListener(Rml::Element *element, const char *event, Rml::EventListener *eventListener,
                             bool inCapturePhase) {
    element->AddEventListener(event, eventListener, inCapturePhase);
}

RMLUI_CAPI void
rml_Element_RemoveEventListener(Rml::Element *element, const char *event, Rml::EventListener *eventListener,
                                bool inCapturePhase) {
    element->RemoveEventListener(event, eventListener, inCapturePhase);
}

RMLUI_CAPI const char *rml_Element_GetElementByID(Rml::Element *element, const char *id, Rml::Element **foundElement) {
    *foundElement = element->GetElementById(id);

    if (*foundElement) {
        return rmlui_type_name(**foundElement);
    }

    return nullptr;
}

RMLUI_CAPI const char *rml_Element_GetOwnerDocument(Rml::Element *element, Rml::Element **foundElement) {
    *foundElement = element->GetOwnerDocument();

    return rmlui_type_name(**foundElement);
}

RMLUI_CAPI void rml_Element_SetInnerRml(Rml::Element *element, const char* rml) {
    element->SetInnerRML(rml);
}

RMLUI_CAPI void rml_Element_Focus(Rml::Element *element) {
    element->Focus();
}

RMLUI_CAPI void rml_Element_Blur(Rml::Element *element) {
    element->Blur();
}

RMLUI_CAPI void rml_Element_Click(Rml::Element *element) {
    element->Click();
}

RMLUI_CAPI float rml_Element_GetOffsetTop(Rml::Element *element) {
    return element->GetOffsetTop();
}

RMLUI_CAPI const Rml::Box* rml_Element_GetBox(Rml::Element *element) {
    if (element) {
        return &(element->GetBox());
    }
    return nullptr;
}