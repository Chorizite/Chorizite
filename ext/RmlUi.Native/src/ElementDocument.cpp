#include "RmlNative.h"
#include "RmlUi/Core/ElementDocument.h"
#include "RmlUi/Core/StyleSheet.h"
#include "RmlUi/Core/StyleSheetContainer.h"
#include "RmlUi/Core/StyleSheetTypes.h"

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