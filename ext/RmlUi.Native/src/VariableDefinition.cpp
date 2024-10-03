#include "RmlNative.h"
#include "RmlUi/Core/DataVariable.h"
#include <string>

typedef bool(*onGet)(void* ptr, Rml::Variant*& variant);
typedef bool(*onSet)(void* ptr, const Rml::Variant& variant);
typedef int(*onSize)(void* ptr);
typedef Rml::DataVariable*(*onChild)(void* ptr, const char* name, int offset);

class VariableDefinition : Rml::VariableDefinition {
private:
    ::onGet m_onGet;
    ::onSet m_onSet;
    ::onSize m_onSize;
    ::onChild m_onChild;

public:
    explicit VariableDefinition(Rml::DataVariableType type, ::onGet onGet, ::onSet onSet, ::onSize onSize, ::onChild onChild) : Rml::VariableDefinition(type) {
        m_onGet = onGet;
        m_onSet = onSet;
        m_onSize = onSize;
        m_onChild = onChild;
    }

    bool Get(void* ptr, Rml::Variant& variant) override {
      Rml::Variant* variant_ptr = &variant;
      auto res = (*m_onGet)(ptr, variant_ptr);
      variant = *variant_ptr;
      return res;
    }

    bool Set(void* ptr, const Rml::Variant& variant) override {
        return (*m_onSet)(ptr, variant);
    }

    int Size(void* ptr) override {
        return (*m_onSize)(ptr);
    }

    Rml::DataVariable Child(void* ptr, const Rml::DataAddressEntry& address) override {
        return *(*m_onChild)(ptr, address.name.c_str(), address.index);
    }
};

RMLUI_CAPI void *rml_VariableDefinition_New(Rml::DataVariableType type, ::onGet onGet, ::onSet onSet, ::onSize onSize, ::onChild onChild) {
    return new VariableDefinition(type, onGet, onSet, onSize, onChild);
}

RMLUI_CAPI void rml_VariableDefinition_Free(VariableDefinition* definition) {
    delete definition;
}