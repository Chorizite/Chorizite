#include <Buffer.h>
#include <RmlNative.h>

#include <cstdlib>

RMLUI_CAPI cs_buffer_t cs_buffer_new(size_t size) {
	cs_buffer_t buffer;
	if (size > 0) {
		buffer.size = static_cast<int64_t>(size);
		buffer.data = static_cast<uint8_t*>(std::malloc(sizeof(uint8_t) * size));
	}
	else {
		buffer.size = 0;
		buffer.data = nullptr;
	}
	return buffer;
}

RMLUI_CAPI void cs_buffer_free(cs_buffer_t* buffer) {
	if (buffer->data) {
		std::free(buffer->data);
		buffer->data = nullptr;
	}
	buffer->size = 0;
}