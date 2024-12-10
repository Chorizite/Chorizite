#include "RmlNative.h"
#include "RmlUi/Core/EventInstancer.h"
#include "RmlUi/Core/Event.h"
#include "RmlUi/Core/Factory.h"
#include <iostream>
#include <string>
#include "Pool.h"

typedef void(*onInstanceEvent)(Rml::Element* target, const char* element_type, Rml::EventId id, const char* name, const Rml::Dictionary& parameters, bool interruptible);

class MyEventInstancer : Rml::EventInstancer {
private:
    ::onInstanceEvent m_onInstanceEvent;

public:
    explicit MyEventInstancer(::onInstanceEvent onInstanceEvent) {
        m_onInstanceEvent = onInstanceEvent;
    }

    Rml::EventPtr InstanceEvent(Rml::Element* target, Rml::EventId id, const Rml::String& type, const Rml::Dictionary& parameters, bool interruptible) override {
      (*m_onInstanceEvent)(target, rmlui_type_name(target), id, type.c_str(), parameters, interruptible);
      
      return Rml::EventPtr(new Rml::Event(target, id, type, parameters, interruptible));
    }

    void ReleaseEvent(Rml::Event* event) override {
      delete event;
    }
    
    void Release() override {
      delete this;
    }
};

static Rml::Pool<MyEventInstancer> pool_element(5, true);

RMLUI_CAPI MyEventInstancer* rml_EventInstancer_New(::onInstanceEvent onInstanceEvent) {
    MyEventInstancer* instancer = pool_element.AllocateAndConstruct(onInstanceEvent);
    Rml::Factory::RegisterEventInstancer((Rml::EventInstancer*)instancer);

    return instancer;
}

RMLUI_CAPI void rml_EventInstancer_Free(MyEventInstancer *instancer) {
	pool_element.DestroyAndDeallocate(instancer);
}