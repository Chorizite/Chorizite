#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/Types.h"
#include "Util.h"

RMLUI_CAPI Rml::Dictionary* rml_Dictionary_Create() {
  return new Rml::Dictionary();
}

RMLUI_CAPI void rml_Dictionary_Free(Rml::Dictionary* dict) {
  delete dict;
}

RMLUI_CAPI int rml_Dictionary_Size(Rml::Dictionary* dict) {
  return dict->size();
}

RMLUI_CAPI const char** rml_Dictionary_GetAllKeys(Rml::Dictionary* dict, int* outKeyCount) {
    // Ensure we use a pointer for outKeyCount to match C# ref semantics
    if (dict == nullptr || outKeyCount == nullptr) {
        if (outKeyCount) *outKeyCount = 0;
        return nullptr;
    }
    
    *outKeyCount = static_cast<int>(dict->size());
   
    if (*outKeyCount == 0) {
        return nullptr;
    }
    
    const char** keys = nullptr;
    
    try {
        keys = new const char*[*outKeyCount]();  // Zero-initialize
        
        size_t index = 0;
        for (const auto& item : *dict) {
            // Allocate and copy each key
            keys[index] = strdup(item.first.c_str());
            
            // Optional: additional safety check
            if (keys[index] == nullptr) {
                throw std::bad_alloc();
            }
            
            index++;
        }
    }
    catch (...) {
        // Cleanup in case of allocation failure
        if (keys != nullptr) {
            for (int i = 0; i < *outKeyCount; i++) {
                if (keys[i] != nullptr) {
                    free(const_cast<char*>(keys[i]));
                }
            }
            delete[] keys;
        }
       
        *outKeyCount = 0;
        return nullptr;
    }
    
    return keys;
}

RMLUI_CAPI void rml_Dictionary_FreeKeys(const char** keys, int keyCount) {
    if (keys == nullptr) return;

    // Use free() to match strdup()
    for (int i = 0; i < keyCount; ++i) {
        free(const_cast<char*>(keys[i]));
    }
    
    delete[] keys;
}

RMLUI_CAPI void rml_Dictionary_Insert(Rml::Dictionary* dict, const char* prop, Rml::Variant* value) {
    (*dict)[prop] = *value;
}

RMLUI_CAPI void rml_Dictionary_Remove(Rml::Dictionary* dict, const char* prop) {
    dict->erase(prop);
}

RMLUI_CAPI Rml::Variant* rml_Dictionary_Get(Rml::Dictionary *dict, const char *prop) {
	return &(*dict)[prop];
}