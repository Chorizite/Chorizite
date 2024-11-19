#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/EventInstancer.h"
#include "Util.h"
#include "Pool.h"

typedef Rml::EventListener* (*instanceEventListener)(const char* value, Rml::Element *element);


class EventListenerInstancer : public Rml::EventListenerInstancer {
private:
    ::instanceEventListener m_instanceEventListener;

public:
    explicit EventListenerInstancer(::instanceEventListener instanceEventListener) {
        m_instanceEventListener = instanceEventListener;
    }

	Rml::EventListener* InstanceEventListener(const Rml::String& value, Rml::Element* element) override {
      return (*m_instanceEventListener)(value.c_str(), element);
    }
};

static Rml::Pool<EventListenerInstancer> pool_element(200, true);

RMLUI_CAPI EventListenerInstancer* rml_EventListenerInstancer_New(::instanceEventListener instanceEventListener) {
    EventListenerInstancer* instancer = pool_element.AllocateAndConstruct(instanceEventListener);
    Rml::Factory::RegisterEventListenerInstancer(instancer);

    return instancer;
}

RMLUI_CAPI void rml_EventListenerInstancer_Free(EventListenerInstancer *instancer) {
	pool_element.DestroyAndDeallocate(instancer);
}