#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/ElementInstancer.h"
#include "Util.h"

typedef Rml::Element*(*instanceElement)(Rml::Element *parent, const char *tag, const Rml::XMLAttributes &attributes);
typedef void(*releaseElement)(Rml::Element *element);


class ElementInstancer : public Rml::ElementInstancer {
private:
    ::instanceElement m_instanceElement;
    ::releaseElement m_releaseElement;

public:
    explicit ElementInstancer(::instanceElement instanceElement, ::releaseElement releaseElement) {
        m_instanceElement = instanceElement;
        m_releaseElement = releaseElement;
    }

	  Rml::ElementPtr InstanceElement(Rml::Element* parent, const Rml::String& tag, const Rml::XMLAttributes& attributes) override {
      return Rml::ElementPtr((*m_instanceElement)(parent, tag.c_str(), attributes));
    }

	  void ReleaseElement(Rml::Element* element) override {
      (*m_releaseElement)(element);
    }
};

RMLUI_CAPI void *rml_ElementInstancer_New(char *tag, ::instanceElement instanceElement, ::releaseElement releaseElement) {
    auto instancer = new ElementInstancer(instanceElement, releaseElement);
    Rml::Factory::RegisterElementInstancer(tag, instancer);

    return instancer;
}
