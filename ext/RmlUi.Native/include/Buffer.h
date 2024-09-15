#pragma once

#include "RmlNative.h"
#include <cstdint>

#ifdef __cplusplus
extern "C" {
#endif

	typedef struct {
		int64_t size;
		uint8_t* data;
	} cs_buffer_t;

#define CS_BUFFER_INVALID (cs_buffer_t{.size = -1, .data = NULL})

#ifdef __cplusplus
} // extern "C"
#endif

RMLUI_CAPI cs_buffer_t cs_buffer_new(size_t size);
RMLUI_CAPI void cs_buffer_free(cs_buffer_t* buffer);
