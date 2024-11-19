#include "RmlNative.h"
#include "RmlUi/Core.h"
#include "RmlUi/Core/Types.h"
#include "Util.h"

RMLUI_CAPI const char *rml_Dictionary_GetString(Rml::Dictionary *attributes, const char *prop, const char *defaultValue) {
	Rml::String result = Rml::String(defaultValue);
	auto it = attributes->find(prop);
	
  if (it != attributes->end()) {
		it->second.GetInto(result);
  }

	return _strdup(result.c_str());
}