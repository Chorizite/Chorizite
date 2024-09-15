#include "RmlNative.h"
#include "RmlUi/Core/FileInterface.h"
#include <iostream>
#include <string>
#include <cstdlib>

typedef Rml::FileHandle(*onOpen)(const char* path);
typedef void(*onClose)(Rml::FileHandle file);
typedef const char* (*onLoadFile)(const char* path);
typedef size_t(*onRead)(uint8_t* buffer, size_t size, Rml::FileHandle file);
typedef bool(*onSeek)(Rml::FileHandle file, long offset, int origin);
typedef size_t(*onTell)(Rml::FileHandle file);
typedef size_t(*onLength)(Rml::FileHandle file);

class FileInterface : public Rml::FileInterface {
private:
	::onOpen m_onOpen;
	::onClose m_onClose;
	::onLoadFile m_onLoadFile;
	::onRead m_onRead;
	::onSeek m_onSeek;
	::onTell m_onTell;
	::onLength m_onLength;

public:
	explicit FileInterface(
		::onOpen onOpen,
		::onClose onClose,
		::onLoadFile onLoadFile,
		::onRead onRead,
		::onSeek onSeek,
		::onTell onTell,
		::onLength onLength
	) {
		m_onOpen = onOpen;
		m_onClose = onClose;
		m_onLoadFile = onLoadFile;
		m_onRead = onRead;
		m_onSeek = onSeek;
		m_onTell = onTell;
		m_onLength = onLength;
	}

	Rml::FileHandle Open(const Rml::String& path) override {
		return (*m_onOpen)(path.c_str());
	}

	void Close(Rml::FileHandle file) override {
		(*m_onClose)(file);
	}

	size_t Read(void* buffer, size_t size, Rml::FileHandle file) override {
		uint8_t* bytes = static_cast<uint8_t*>(std::malloc(sizeof(uint8_t) * size));
		size_t length = (*m_onRead)(bytes, size, file);

		// shut up I know
		memcpy(buffer, bytes, length);

		return length;
	}

	bool Seek(Rml::FileHandle file, long offset, int origin) override {
		return (*m_onSeek)(file, offset, origin);
	}

	size_t Tell(Rml::FileHandle file) override {
		return (*m_onTell)(file);
	}

	size_t Length(Rml::FileHandle file) override {
		return (*m_onLength)(file);
	}

	bool LoadFile(const Rml::String& path, Rml::String& out_data) override {
		out_data = (*m_onLoadFile)(path.c_str());
		return (out_data != "");
	}
};

RMLUI_CAPI void* rml_FileInterface_New(
	::onOpen onOpen,
	::onClose onClose,
	::onLoadFile onLoadFile,
	::onRead onRead,
	::onSeek onSeek,
	::onTell onTell,
	::onLength onLength
) {
	return new FileInterface(
		onOpen,
		onClose,
		onLoadFile,
		onRead,
		onSeek,
		onTell,
		onLength
	);
}
