#pragma once

#include <iostream>
#include "Util.h"
#include "RmlUi/Core/EventListener.h"

typedef void(*onProcessEvent)(Rml::Event &event);

typedef void(*onAttachEvent)(Rml::Element *element, const char *elementType);

typedef void(*onDetachEvent)(Rml::Element *element, const char *elementType);

class EventListenerProxy : public Rml::EventListener {
private:
    ::onProcessEvent m_onProcessEvent;
    ::onAttachEvent m_onAttachEvent;
    ::onDetachEvent m_onDetachEvent;

public:
    explicit EventListenerProxy(::onProcessEvent onProcessEvent, ::onAttachEvent onAttachEvent,
                                ::onDetachEvent onDetachEvent) {
        m_onProcessEvent = onProcessEvent;
        m_onAttachEvent = onAttachEvent;
        m_onDetachEvent = onDetachEvent;
    }

    void ProcessEvent(Rml::Event &event) override {
        (*m_onProcessEvent)(event);
    }

    void OnAttach(Rml::Element *element) override {
        (*m_onAttachEvent)(element, rmlui_type_name(*element));
    }

    void OnDetach(Rml::Element *element) override {
        (*m_onDetachEvent)(element, rmlui_type_name(*element));
    }
};
