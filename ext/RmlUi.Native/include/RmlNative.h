#pragma once

struct FakeStruct {
  public:
    int FakeField;
};

#if defined(_MSC_VER)
#    define _RMLUI_EXPORT __declspec(dllexport)
#elif defined(__GNUC__)
#    define _RMLUI_EXPORT __attribute__((visibility("default")))
#else
#    define _RMLUI_EXPORT
#    pragma warning "Unknown dynamic link import/export semantics."
#endif

#ifdef __cplusplus
#    define _RMLUI_EXTERN extern "C"
#else
#    define _RMLUI_EXTERN extern
#endif

#define RMLUI_CAPI _RMLUI_EXTERN _RMLUI_EXPORT