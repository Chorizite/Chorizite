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

RMLUI_CAPI const char *rml_Element_GetElementTypeName(Rml::Element *element) {
    return rmlui_type_name(*element);
}

RMLUI_CAPI const char *rml_Element_GetOwnerDocument(Rml::Element *element, Rml::Element **foundElement) {
    *foundElement = element->GetOwnerDocument();

    return rmlui_type_name(**foundElement);
}

RMLUI_CAPI const char* rml_Element_GetInnerRml(Rml::Element *element) {
    return strdup(element->GetInnerRML().c_str());
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

RMLUI_CAPI float rml_Element_GetAbsoluteLeft(Rml::Element *element) {
    return element->GetAbsoluteLeft();
}

RMLUI_CAPI float rml_Element_GetAbsoluteTop(Rml::Element *element) {
    return element->GetAbsoluteTop();
}

RMLUI_CAPI void rml_Element_SetAttributeString(Rml::Element *element, const char *attr, const char *value) {
    element->SetAttribute(attr, value);
}

RMLUI_CAPI const char* rml_Element_GetAttributeString(Rml::Element *element, const char *attr, const char *default_value) {
    return _strdup(element->GetAttribute<Rml::String>(attr, default_value).c_str());
}

RMLUI_CAPI void rml_Element_SetProperty(Rml::Element *element, const char *name, const char *value) {
    element->SetProperty(name, value);
}

RMLUI_CAPI const Rml::Property* rml_Element_GetProperty(Rml::Element *element, const char *name) {
    return element->GetLocalProperty(name);
}

RMLUI_CAPI const Rml::Property* rml_Element_GetPropertyById(Rml::Element *element, Rml::PropertyId property_id) {
    return element->GetLocalProperty(property_id);
}

RMLUI_CAPI const char* rml_Element_GetPropertyString(Rml::Element *element, const char *name) {
    return _strdup(element->GetProperty(name)->Get<Rml::String>().c_str());
}

RMLUI_CAPI Rml::Element* rml_Element_GetChild(Rml::Element *element, int index) {
    return element->GetChild(index);
}

RMLUI_CAPI int rml_Element_GetNumChildren(Rml::Element *element, bool include_non_dom_elements) {
    return element->GetNumChildren(include_non_dom_elements);
}

RMLUI_CAPI float rml_Element_GetClientHeight(Rml::Element *element) {
    return element->GetClientHeight();
}

RMLUI_CAPI bool rml_Element_IsClassSet(Rml::Element *element, const char* class_name) {
    return element->IsClassSet(class_name);
}

RMLUI_CAPI void rml_Element_SetClass(Rml::Element *element, const char* class_name, bool activate) {
    element->SetClass(class_name, activate);
}

RMLUI_CAPI float rml_Element_GetClientLeft(Rml::Element *element) {
    return element->GetClientLeft();
}

RMLUI_CAPI float rml_Element_GetClientTop(Rml::Element *element) {
    return element->GetClientTop();
}

RMLUI_CAPI float rml_Element_GetClientWidth(Rml::Element *element) {
    return element->GetClientWidth();
}

RMLUI_CAPI Rml::Element* rml_Element_GetFirstChild(Rml::Element *element) {
    return element->GetFirstChild();
}

RMLUI_CAPI const char* rml_Element_GetId(Rml::Element *element) {
    return element->GetId().c_str();
}

RMLUI_CAPI void rml_Element_SetId(Rml::Element *element, const char* id) {
    element->SetId(id);
}

RMLUI_CAPI Rml::Element* rml_Element_GetLastChild(Rml::Element *element) {
    return element->GetLastChild();
}

RMLUI_CAPI Rml::Element* rml_Element_GetNextSibling(Rml::Element *element) {
    return element->GetNextSibling();
}

RMLUI_CAPI float rml_Element_GetOffsetHeight(Rml::Element *element) {
    return element->GetOffsetHeight();
}

RMLUI_CAPI float rml_Element_GetOffsetLeft(Rml::Element *element) {
    return element->GetOffsetLeft();
}

RMLUI_CAPI Rml::Element* rml_Element_GetOffsetParent(Rml::Element *element) {
    return element->GetOffsetParent();
}

RMLUI_CAPI float rml_Element_GetOffsetWidth(Rml::Element *element) {
    return element->GetOffsetWidth();
}

RMLUI_CAPI Rml::Element* rml_Element_GetParentNode(Rml::Element *element) {
    return element->GetParentNode();
}

RMLUI_CAPI void rml_Element_ReplaceChild(Rml::Element *element, Rml::Element *inserted_element, Rml::Element *replaced_element) {
    element->ReplaceChild(inserted_element->GetParentNode()->RemoveChild(inserted_element), replaced_element);
}

RMLUI_CAPI Rml::Element* rml_Element_GetPreviousSibling(Rml::Element *element) {
    return element->GetPreviousSibling();
}

RMLUI_CAPI float rml_Element_GetScrollHeight(Rml::Element *element) {
    return element->GetScrollHeight();
}

RMLUI_CAPI float rml_Element_GetScrollLeft(Rml::Element *element) {
    return element->GetScrollLeft();
}

RMLUI_CAPI float rml_Element_GetScrollTop(Rml::Element *element) {
    return element->GetScrollTop();
}

RMLUI_CAPI float rml_Element_GetScrollWidth(Rml::Element *element) {
    return element->GetScrollWidth();
}

RMLUI_CAPI Rml::Element* rml_Element_AppendChild(Rml::Element *element, Rml::Element *element_to_append, bool add_to_dom) {
    return element->AppendChild(element_to_append->GetParentNode()->RemoveChild(element_to_append), add_to_dom);
}

RMLUI_CAPI Rml::Element* rml_Element_AppendChildTag(Rml::Element *element, const char* tagName, bool add_to_dom) {
    return element->AppendChild(element->GetOwnerDocument()->CreateElement(tagName), add_to_dom);
}

RMLUI_CAPI Rml::Element* rml_Element_Closest(Rml::Element *element, const char* selectors) {
    return element->Closest(selectors);
}

RMLUI_CAPI bool rml_Element_DispatchEvent(Rml::Element *element, const char* event_id, Rml::Dictionary& parameters, bool interruptible, bool bubbles) {
    return element->DispatchEvent(event_id, parameters, interruptible, bubbles);
}

RMLUI_CAPI bool rml_Element_HasAttribute(Rml::Element *element, const char* attr) {
	return element->HasAttribute(attr);
}

RMLUI_CAPI bool rml_Element_HasChildNodes(Rml::Element *element) {
	return element->HasChildNodes();
}

RMLUI_CAPI bool rml_Element_HasClass(Rml::Element *element, const char* class_name) {
	return element->IsClassSet(class_name);
}

RMLUI_CAPI bool rml_Element_InsertBefore(Rml::Element *element, Rml::Element *element_to_add, Rml::Element *adjacent_element) {
	return element->InsertBefore(Rml::ElementPtr(element_to_add), adjacent_element);
}

RMLUI_CAPI Rml::Element* rml_Element_QuerySelector(Rml::Element *element, const char* selector) {
	return element->QuerySelector(selector);
}

/*
RMLUI_CAPI Rml::ElementList* rml_Element_GetElementsByTagName(Rml::Element *element, const char* tag) {
	Rml::ElementList list;
	element->GetElementsByTagName(list, tag);
    return &list;
}

RMLUI_CAPI Rml::ElementList* rml_Element_GetElementsByClassName(Rml::Element *element, const char* class_name) {
	Rml::ElementList list;
	element->GetElementsByClassName(list, class_name);
    return &list;
}

RMLUI_CAPI Rml::ElementList* rml_Element_QuerySelectorAll(Rml::Element *element, const char* selector) {
	Rml::ElementList list;
	element->QuerySelectorAll(list, selector);
    return &list;
}
*/

RMLUI_CAPI bool rml_Element_Matches(Rml::Element *element, const char* selector) {
	return element->Matches(selector);
}

RMLUI_CAPI void rml_Element_RemoveAttribute(Rml::Element *element, const char* attr) {
	element->RemoveAttribute(attr);
}
RMLUI_CAPI void rml_Element_ScrollIntoView(Rml::Element *element) {
	element->ScrollIntoView();
}

RMLUI_CAPI void rml_Element_ScrollTo(Rml::Element *element, float x, float y, Rml::ScrollBehavior behavior) {
	element->ScrollTo(Rml::Vector2f(x, y), behavior);
}

RMLUI_CAPI const Rml::Box* rml_Element_GetBox(Rml::Element *element) {
    return &(element->GetBox());
}

RMLUI_CAPI Rml::RenderManager* rml_Element_GetRenderManager(Rml::Element *element) {
	return element->GetRenderManager();
}
