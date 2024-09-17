#include "RmlNative.h"
#include "RmlUi/Core/Plugin.h"
#include "RmlUi/Core/ElementDocument.h"
#include "RmlUi/Core/Context.h"
#include <iostream>
#include <string>

typedef void(*onInitialise)();
typedef void(*onShutdown)();
typedef void(*onDocumentOpen)(Rml::Context* context, const char *document_path);
typedef void(*onDocumentLoad)(Rml::ElementDocument* document);
typedef void(*onDocumentUnload)(Rml::ElementDocument* document);
typedef void(*onContextCreate)(Rml::Context* context);
typedef void(*onContextDestroy)(Rml::Context* context);
typedef void(*onElementCreate)(Rml::Element* element);
typedef void(*onElementDestroy)(Rml::Element* element);

class Plugin : Rml::Plugin {
private:
    ::onInitialise m_onInitialise;
    ::onShutdown m_onShutdown;
    ::onDocumentOpen m_onDocumentOpen;
    ::onDocumentLoad m_onDocumentLoad;
    ::onDocumentUnload m_onDocumentUnload;
    ::onContextCreate m_onContextCreate;
    ::onContextDestroy m_onContextDestroy;
    ::onElementCreate m_onElementCreate;
    ::onElementDestroy m_onElementDestroy;

public:
    explicit Plugin(::onInitialise onInitialise,
              ::onShutdown onShutdown,
              ::onDocumentOpen onDocumentOpen,
              ::onDocumentLoad onDocumentLoad,
              ::onDocumentUnload onDocumentUnload,
              ::onContextCreate onContextCreate,
              ::onContextDestroy onContextDestroy,
              ::onElementCreate onElementCreate,
              ::onElementDestroy onElementDestroy) {
        m_onInitialise = onInitialise;
        m_onShutdown = onShutdown;
        m_onDocumentOpen = onDocumentOpen;
        m_onDocumentLoad = onDocumentLoad;
        m_onDocumentUnload = onDocumentUnload;
        m_onContextCreate = onContextCreate;
        m_onContextDestroy = onContextDestroy;
        m_onElementCreate = onElementCreate;
        m_onElementDestroy = onElementDestroy;
    }

    void OnInitialise() override {
      (*m_onInitialise)();
    }

    void OnShutdown() override {
      (*m_onShutdown)();
    }

    void OnDocumentOpen(Rml::Context* context, const Rml::String& document_path) override {
      (*m_onDocumentOpen)(context, document_path.c_str());
    }

    void OnDocumentLoad(Rml::ElementDocument* document) override {
      (*m_onDocumentLoad)(document);
    }

    void OnDocumentUnload(Rml::ElementDocument* document) override {
      (*m_onDocumentUnload)(document);
    }

    void OnContextCreate(Rml::Context* context) override {
      (*m_onContextCreate)(context);
    }

    void OnContextDestroy(Rml::Context* context) override {
      (*m_onContextDestroy)(context);
    }

    void OnElementCreate(Rml::Element* element) override {
      (*m_onElementCreate)(element);
    }

    void OnElementDestroy(Rml::Element* element) override {
      //(*m_onElementDestroy)(element);
    }
};

RMLUI_CAPI void *rml_Plugin_New(::onInitialise onInitialise,
              ::onShutdown onShutdown,
              ::onDocumentOpen onDocumentOpen,
              ::onDocumentLoad onDocumentLoad,
              ::onDocumentUnload onDocumentUnload,
              ::onContextCreate onContextCreate,
              ::onContextDestroy onContextDestroy,
              ::onElementCreate onElementCreate,
              ::onElementDestroy onElementDestroy) {
    return new Plugin(onInitialise, onShutdown, onDocumentOpen, onDocumentLoad, onDocumentUnload, onContextCreate, onContextDestroy, onElementCreate, onElementDestroy);
}