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

RMLUI_CAPI void rml_ElementDocument_PullToFront(Rml::ElementDocument* document) {
    document->PullToFront();
}

RMLUI_CAPI void rml_ElementDocument_SetTitle(Rml::ElementDocument* document, const char* title) {
    document->SetTitle(title);
}

RMLUI_CAPI const char* rml_ElementDocument_GetTitle(Rml::ElementDocument* document) {
    return strdup(document->GetTitle().c_str());
}

RMLUI_CAPI const char* rml_ElementDocument_GetSourceURL(Rml::ElementDocument* document) {
    return strdup(document->GetSourceURL().c_str());
}

RMLUI_CAPI Rml::ElementPtr* rml_ElementDocument_CreateElement(Rml::ElementDocument* document, const char* name) {
    return &document->CreateElement(name);
}

RMLUI_CAPI Rml::Element* rml_ElementDocument_CreateTextNode(Rml::ElementDocument* document, const char* text) {
    return document->CreateTextNode(text).get();
}

RMLUI_CAPI void rml_ElementDocument_AddStyleSheetContainer(Rml::ElementDocument* document, Rml::StyleSheetContainer* container) {
    auto sheet_container = document->GetStyleSheetContainer()->CombineStyleSheetContainer(*container);
    document->SetStyleSheetContainer(sheet_container);
}

RMLUI_CAPI void rml_ElementDocument_Close(Rml::ElementDocument* document) {
    document->Close();
}

typedef void(*onLoadInlineScript)(const char *context, const char *source_path, int source_line);
typedef void(*onLoadExternalScript)(const char *source_path);

class ElementDocumentCustom : Rml::ElementDocument {
private:
    ::onLoadInlineScript m_onLoadInlineScript;
    ::onLoadExternalScript m_onLoadExternalScript;

public:
    explicit ElementDocumentCustom(const Rml::String& tag, ::onLoadInlineScript onLoadInlineScript, ::onLoadExternalScript onLoadExternalScript) : ElementDocument(tag) {
        m_onLoadInlineScript = onLoadInlineScript;
        m_onLoadExternalScript = onLoadExternalScript;
    }

    void LoadInlineScript(const Rml::String& context, const Rml::String& source_path, int source_line) override {
        if (m_onLoadInlineScript != NULL) {
            (*m_onLoadInlineScript)(context.c_str(), source_path.c_str(), source_line);
        }
    }

    void LoadExternalScript(const Rml::String& source_path) override {
        if (m_onLoadExternalScript != NULL) {
            (*m_onLoadExternalScript)(source_path.c_str());
        }
    }
};

static Rml::Pool<ElementDocumentCustom> pool_element(200, true);

RMLUI_CAPI void *rml_ElementDocument_New(::onLoadInlineScript onLoadInlineScript, ::onLoadExternalScript onLoadExternalScript) {
    ElementDocumentCustom* ptr = pool_element.AllocateAndConstruct("body", onLoadInlineScript, onLoadExternalScript);
    return ptr;
}

RMLUI_CAPI void rml_ElementDocument_Free(ElementDocumentCustom *element) {
	pool_element.DestroyAndDeallocate(element);
}