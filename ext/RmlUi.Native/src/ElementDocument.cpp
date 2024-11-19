#include "RmlNative.h"
#include "RmlUi/Core/ElementDocument.h"
#include "RmlUi/Core/StyleSheet.h"
#include "RmlUi/Core/StyleSheetContainer.h"
#include "RmlUi/Core/StyleSheetTypes.h"
#include "Pool.h"

RMLUI_CAPI void rml_ElementDocument_Show(Rml::ElementDocument* document, Rml::ModalFlag modal_flag = Rml::ModalFlag::None, Rml::FocusFlag focus_flag = Rml::FocusFlag::Auto) {
    document->Show(modal_flag, focus_flag);
}

RMLUI_CAPI void rml_ElementDocument_Hide(Rml::ElementDocument* document) {
    document->Hide();
}

RMLUI_CAPI void rml_ElementDocument_AddStyleSheetContainer(Rml::ElementDocument* document, Rml::StyleSheetContainer* container) {
    auto sheet_container = document->GetStyleSheetContainer()->CombineStyleSheetContainer(*container);
    document->SetStyleSheetContainer(sheet_container);
}

RMLUI_CAPI void rml_ElementDocument_Close(Rml::ElementDocument* document) {
    document->Close();
}

typedef void(*onLoadInlineScript)(const char *context, const char *source_path, int source_line);

class ElementDocumentCustom : Rml::ElementDocument {
private:
    ::onLoadInlineScript m_onLoadInlineScript;

public:
    explicit ElementDocumentCustom(const Rml::String& tag, ::onLoadInlineScript onLoadInlineScript) : ElementDocument(tag) {
        m_onLoadInlineScript = onLoadInlineScript;
    }

    void LoadInlineScript(const Rml::String& context, const Rml::String& source_path, int source_line) override {
        if (m_onLoadInlineScript != NULL) {
            (*m_onLoadInlineScript)(context.c_str(), source_path.c_str(), source_line);
        }
    }
};

static Rml::Pool<ElementDocumentCustom> pool_element(200, true);

RMLUI_CAPI void *rml_ElementDocument_New(::onLoadInlineScript onLoadInlineScript) {
    ElementDocumentCustom* ptr = pool_element.AllocateAndConstruct("body", onLoadInlineScript);
    return ptr;
}

RMLUI_CAPI void rml_ElementDocument_Free(ElementDocumentCustom *element) {
	pool_element.DestroyAndDeallocate(element);
}