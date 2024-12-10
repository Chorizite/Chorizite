#include "RmlNative.h"
#include "RmlUi/Core/SystemInterface.h"
#include <iostream>
#include <string>

typedef double(*onGetElapsedTime)();
typedef const char *(*onTranslateString)(int *changeCount, const char *input);
typedef bool(*onLogMessage)(Rml::Log::Type type, const char *message);
typedef char*(*onJoinPath)(const char *document_path, const char *path);
typedef bool(*onSetMouseCursor)(const char *message);
typedef void(*onSetClipboardText)(const char *message);
typedef const char* (*onGetClipboardText)();
typedef void(*onActivateKeyboard)(float caret_x, float caret_y, float line_height);
typedef void(*onDeactivateKeyboard)();

class SystemInterface : Rml::SystemInterface {
private:
    ::onGetElapsedTime m_onGetElapsedTime;
    ::onTranslateString m_onTranslateString;
    ::onLogMessage m_onLogMessage;
    ::onJoinPath m_onJoinPath;
    ::onSetMouseCursor m_onSetMouseCursor;
    ::onSetClipboardText m_onSetClipboardText;
    ::onGetClipboardText m_onGetClipboardText;
    ::onActivateKeyboard m_onActivateKeyboard;
    ::onDeactivateKeyboard m_onDeactivateKeyboard;

public:
    explicit SystemInterface(::onGetElapsedTime onGetElapsedTime, ::onTranslateString onTranslateString,
                             ::onLogMessage onLogMessage, ::onJoinPath onJoinPath, ::onSetMouseCursor onSetMouseCursor,
                             ::onSetClipboardText onSetClipboardText, ::onGetClipboardText onGetClipboardText,
                             ::onActivateKeyboard onActivateKeyboard, ::onDeactivateKeyboard onDeactivateKeyboard) {
        m_onGetElapsedTime = onGetElapsedTime;
        m_onTranslateString = onTranslateString;
        m_onLogMessage = onLogMessage;
        m_onJoinPath = onJoinPath;
        m_onSetMouseCursor = onSetMouseCursor;
        m_onSetClipboardText = onSetClipboardText;
        m_onGetClipboardText = onGetClipboardText;
        m_onActivateKeyboard = onActivateKeyboard;
        m_onDeactivateKeyboard = onDeactivateKeyboard;
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
        (*m_onSetClipboardText)(text.c_str());
    }

    void GetClipboardText(Rml::String &text) override {
        text = (*m_onGetClipboardText)();
    }

    void ActivateKeyboard(Rml::Vector2f caret_position, float line_height) override {
        (*m_onActivateKeyboard)(caret_position.x, caret_position.y, line_height);
    }

    void DeactivateKeyboard() override {
        (*m_onDeactivateKeyboard)();
    }
};

RMLUI_CAPI void *rml_SystemInterface_New(::onGetElapsedTime onGetElapsedTime, ::onTranslateString onTranslateString,
                                         ::onLogMessage onLogMessage, ::onJoinPath onJoinPath, ::onSetMouseCursor onSetMouseCursor,
                                         ::onSetClipboardText onSetClipboardText, ::onGetClipboardText onGetClipboardText,
                                         ::onActivateKeyboard onActivateKeyboard, ::onDeactivateKeyboard onDeactivateKeyboard) {
    return new SystemInterface(onGetElapsedTime, onTranslateString, onLogMessage, onJoinPath, onSetMouseCursor,
            onSetClipboardText, onGetClipboardText, onActivateKeyboard, onDeactivateKeyboard);
}