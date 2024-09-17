#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/Element.h"
#include "Util.h"
#include "Pool.h"

typedef void(*onRender)();

class ElementCustom : Rml::Element {
private:
    ::onRender m_onRender;

public:
    explicit ElementCustom(const Rml::String& tag, ::onRender onRender) : Element(tag) {
        m_onRender = onRender;
    }

    void OnRender() override {
        if (m_onRender != NULL) {
            (*m_onRender)();
        }
        else {
            Rml::Element::OnRender();
        }
    }
};

static Rml::Pool<ElementCustom> pool_element(200, true);

RMLUI_CAPI void *rml_ElementCustom_New(char *tag, ::onRender onRender) {
    ElementCustom* ptr = pool_element.AllocateAndConstruct(tag, onRender);
    return ptr;
}

RMLUI_CAPI void rml_ElementCustom_Free(ElementCustom *element) {
	pool_element.DestroyAndDeallocate(element);
}
