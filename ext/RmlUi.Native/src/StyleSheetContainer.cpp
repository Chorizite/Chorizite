#include "RmlNative.h"
#include "StreamFile.h"
#include "Util.h"
#include <iostream>

RMLUI_CAPI void *rml_StyleSheetContainer_New() {
    return new Rml::StyleSheetContainer();
}

RMLUI_CAPI void rml_StyleSheetContainer_Free(Rml::StyleSheetContainer* container) {
    delete container;
}

RMLUI_CAPI bool rml_StyleSheetContainer_LoadStyleSheetContainer(Rml::StyleSheetContainer *container, const char *file_name) {
	  auto file_stream = Rml::MakeUnique<Rml::StreamFile>();
	  file_stream->Open(file_name);
    return container->LoadStyleSheetContainer(file_stream.get(), 1);
}