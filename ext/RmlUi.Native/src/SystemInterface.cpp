#include "RmlNative.h"
#include "RmlUi/Core/SystemInterface.h"
#include <iostream>
#include <string>

typedef double(*onGetElapsedTime)();

typedef const char *(*onTranslateString)(int *changeCount, const char *input);

typedef bool(*onLogMessage)(Rml::Log::Type type, const char *message);

typedef char*(*onJoinPath)(const char *document_path, const char *path);

typedef bool(*onSetMouseCursor)(const char *message);

class SystemInterface : Rml::SystemInterface {
private:
    ::onGetElapsedTime m_onGetElapsedTime;
    ::onTranslateString m_onTranslateString;
    ::onLogMessage m_onLogMessage;
    ::onJoinPath m_onJoinPath;
    ::onSetMouseCursor m_onSetMouseCursor;

public:
    explicit SystemInterface(::onGetElapsedTime onGetElapsedTime, ::onTranslateString onTranslateString,
                             ::onLogMessage onLogMessage, ::onJoinPath onJoinPath, ::onSetMouseCursor onSetMouseCursor) {
        m_onGetElapsedTime = onGetElapsedTime;
        m_onTranslateString = onTranslateString;
        m_onLogMessage = onLogMessage;
        m_onJoinPath = onJoinPath;
        m_onSetMouseCursor = onSetMouseCursor;
    }

    double GetElapsedTime() override {
        return (*m_onGetElapsedTime)();
    }

    int TranslateString(Rml::String &translated, const Rml::String &input) override {
        int changeCount = 0;
        //translated = (*m_onTranslateString)(&changeCount, input.c_str());
        translated = input;

        return changeCount;
    }

    bool LogMessage(Rml::Log::Type type, const Rml::String &message) override {
        return (*m_onLogMessage)(type, message.c_str());
    }

    void JoinPath(Rml::String& translated_path, const Rml::String& document_path, const Rml::String& path) {
        translated_path = (*m_onJoinPath)(document_path.c_str(), path.c_str());
    }

    void SetMouseCursor(const Rml::String &cursor_name) override {
        (*m_onSetMouseCursor)(cursor_name.c_str());
    }

    void SetClipboardText(const Rml::String &text) override {
    }

    void GetClipboardText(Rml::String &text) override {
    }

    void ActivateKeyboard(Rml::Vector2f caret_position, float line_height) override {
    }

    void DeactivateKeyboard() override {
    }
};

RMLUI_CAPI void *rml_SystemInterface_New(::onGetElapsedTime onGetElapsedTime, ::onTranslateString onTranslateString,
                                         ::onLogMessage onLogMessage, ::onJoinPath onJoinPath, ::onSetMouseCursor onSetMouseCursor) {
    return new SystemInterface(onGetElapsedTime, onTranslateString, onLogMessage, onJoinPath, onSetMouseCursor);
}