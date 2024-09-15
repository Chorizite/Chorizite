#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/Box.h"
#include "EventListener.h"

struct V2F {
    float X;
    float Y;
};

RMLUI_CAPI V2F* rml_Box_GetPosition(Rml::Box* box, Rml::BoxArea area) {
    auto pos = box->GetPosition(area);
    auto v = new V2F();
    v->X = pos.x;
    v->Y = pos.y;
    return v;
}

RMLUI_CAPI V2F* rml_Box_GetSize(Rml::Box* box) {
    auto pos = box->GetSize();
    auto v = new V2F();
    v->X = pos.x;
    v->Y = pos.y;
    return v;
}

RMLUI_CAPI V2F* rml_Box_GetSizeBoxArea(Rml::Box* box, Rml::BoxArea area) {
    auto pos = box->GetSize(area);
    auto v = new V2F();
    v->X = pos.x;
    v->Y = pos.y;
    return v;
}