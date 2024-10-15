using System;
using System.CodeDom;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AcClient {
    public unsafe partial struct AC1Legacy {
        public unsafe struct PStringBase<T> where T : unmanaged {
            // Struct:
            public PSRefBuffer<T>* m_buffer;

            public override string ToString() {
                if (m_buffer == null || m_buffer->m_len == 0) { return "null"; }
                if (typeof(T) == typeof(UInt16)) return new string((char*)m_buffer->m_data, 0, m_buffer->m_len - 1);
                return new string((sbyte*)m_buffer->m_data, 0, m_buffer->m_len - 1);
            }

            public static implicit operator PStringBase<T>(string inStr) {
                PStringBase<T> ret;
                if (typeof(T) == typeof(UInt16)) {
                    ret.m_buffer = *s_NullBuffer_w;
                    UInt16[] buf = new UInt16[inStr.Length];
                    for (int i = 0; i < inStr.Length; i++) {
                        buf[i] = inStr[i];
                    }
                    __Ctor_16((AC1Legacy.PStringBase<UInt16>*)&ret, buf);
                    return ret;

                }
                ret.m_buffer = *s_NullBuffer;

                __Ctor_((AC1Legacy.PStringBase<Char>*)&ret, inStr.ToCharArray());
                return ret;
            }

            public static implicit operator PStringBase<T>(int v) {
                PStringBase<T> ret;
                if (typeof(T) == typeof(UInt16)) {
                    throw new NotImplementedException();
                }
                ret.m_buffer = *s_NullBuffer;

                __Ctor((AC1Legacy.PStringBase<Char>*)&ret, v);
                return ret;
            }

            //public static implicit operator PStringBase<T>(PStringBase<char> v) {
            //    PStringBase<T> ret;
            //    if (typeof(T) == typeof(UInt16)) {
            //        throw new NotImplementedException();
            //    }
            //    ret.m_buffer = *s_NullBuffer;

            //    __Ctor__((AC1Legacy.PStringBase<Char>*)&ret, &v);
            //    return ret;
            //}

            // AC1Legacy::PStringBase<unsigned short>.PStringBase<unsigned short>:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.PStringBase<UInt16>*, UInt16[], void> __Ctor_16 = (delegate* unmanaged[Thiscall]<AC1Legacy.PStringBase<UInt16>*, UInt16[], void>)0x005444D0; // .text:00543910 ; void __thiscall AC1Legacy::PStringBase<unsigned short>::PStringBase<unsigned short>(AC1Legacy::PStringBase<unsigned short> *this, const unsigned __int16 *str) .text:00543910 ??0?$PStringBase@G@AC1Legacy@@QAE@PBG@Z

            // AC1Legacy::PStringBase<Char>.PStringBase<Char>:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.PStringBase<Char>*, char[], void> __Ctor_ = (delegate* unmanaged[Thiscall]<AC1Legacy.PStringBase<Char>*, char[], void>)0x0048C3E0; // .text:0048C100 ; void __thiscall AC1Legacy::PStringBase<Char>::PStringBase<Char>(AC1Legacy::PStringBase<Char> *this, const Char *str) .text:0048C100 ??0?$PStringBase@D@AC1Legacy@@QAE@PBD@Z

            // AC1Legacy::PStringBase<Char>.PStringBase<Char>:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.PStringBase<Char>*, Int32, void> __Ctor = (delegate* unmanaged[Thiscall]<AC1Legacy.PStringBase<Char>*, Int32, void>)0x004ADBA0; // .text:004AD820 ; void __thiscall AC1Legacy::PStringBase<Char>::PStringBase<Char>(AC1Legacy::PStringBase<Char> *this, Int32 i_Int32) .text:004AD820 ??0?$PStringBase@D@AC1Legacy@@QAE@J@Z


            // AC1Legacy.PStringBase.operator_equals<char>:
            public AC1Legacy.PStringBase<char>* operator_equals(int i_int32) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, int, AC1Legacy.PStringBase<char>*>)0x004AD9C0)(ref this, i_int32); // .text:004AD640 ; AC1Legacy.PStringBase<char> *__thiscall AC1Legacy.PStringBase<char>::operator=(AC1Legacy.PStringBase<char> *this, int i_int32) .text:004AD640 ??4?$PStringBase@D@AC1Legacy@@QAEAAV01@J@Z

            // AC1Legacy.PStringBase.operator_equals<unsigned short>:
            public AC1Legacy.PStringBase<UInt16>* operator_equals(AC1Legacy.PStringBase<UInt16>* rhs) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<UInt16>*, AC1Legacy.PStringBase<UInt16>*>)0x0048A0A0)(ref this, rhs); // .text:00489D70 ; AC1Legacy.PStringBase<unsigned short> *__thiscall AC1Legacy.PStringBase<unsigned short>::operator=(AC1Legacy.PStringBase<unsigned short> *this, AC1Legacy.PStringBase<unsigned short> *rhs) .text:00489D70 ??4?$PStringBase@G@AC1Legacy@@QAEAAV01@ABV01@@Z

            // AC1Legacy.PStringBase.operator_is_equal<char>:
            public Byte operator_is_equal(AC1Legacy.PStringBase<char>* rhs) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<char>*, Byte>)0x004AB9D0)(ref this, rhs); // .text:004AB650 ; bool __thiscall AC1Legacy.PStringBase<char>::operator==(AC1Legacy.PStringBase<char> *this, AC1Legacy.PStringBase<char> *rhs) .text:004AB650 ??8?$PStringBase@D@AC1Legacy@@QBE_NABV01@@Z

            // AC1Legacy.PStringBase.operator_not_equal<char>:
            public Byte operator_not_equal(AC1Legacy.PStringBase<char>* rhs) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<char>*, Byte>)0x004ABA30)(ref this, rhs); // .text:004AB6B0 ; bool __thiscall AC1Legacy.PStringBase<char>::operator!=(AC1Legacy.PStringBase<char> *this, AC1Legacy.PStringBase<char> *rhs) .text:004AB6B0 ??9?$PStringBase@D@AC1Legacy@@QBE_NABV01@@Z

            // AC1Legacy.PStringBase.operator_plus<char>:
            public AC1Legacy.PStringBase<char>* operator_plus(AC1Legacy.PStringBase<char>* result, AC1Legacy.PStringBase<char>* rhs) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*>)0x004A2B90)(ref this, result, rhs); // .text:004A2860 ; AC1Legacy.PStringBase<char> *__thiscall AC1Legacy.PStringBase<char>::operator+(AC1Legacy.PStringBase<char> *this, AC1Legacy.PStringBase<char> *result, AC1Legacy.PStringBase<char> *rhs) .text:004A2860 ??H?$PStringBase@D@AC1Legacy@@QBE?AV01@ABV01@@Z

            // AC1Legacy.PStringBase.operator_plus_equals<char>:
            public AC1Legacy.PStringBase<char>* operator_plus_equals(AC1Legacy.PStringBase<char>* rhs) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*>)0x004914F0)(ref this, rhs); // .text:00491210 ; AC1Legacy.PStringBase<char> *__thiscall AC1Legacy.PStringBase<char>::operator+=(AC1Legacy.PStringBase<char> *this, AC1Legacy.PStringBase<char> *rhs) .text:00491210 ??Y?$PStringBase@D@AC1Legacy@@QAEAAV01@ABV01@@Z

            // AC1Legacy.PStringBase.GetPackSize<char>:
            public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, UInt32>)0x004FD1F0)(ref this); // .text:004FC650 ; unsigned int __thiscall AC1Legacy.PStringBase<char>::GetPackSize(AC1Legacy.PStringBase<char> *this) .text:004FC650 ?GetPackSize@?$PStringBase@D@AC1Legacy@@QBEIXZ

            // AC1Legacy.PStringBase.InsertCommas<char>:
            // public Byte InsertCommas() => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, Byte>)0xDEADBEEF)(ref this); // .text:004AC500 ; bool __thiscall AC1Legacy.PStringBase<char>::InsertCommas(AC1Legacy.PStringBase<char> *this) .text:004AC500 ?InsertCommas@?$PStringBase@D@AC1Legacy@@IAE_NXZ

            // AC1Legacy.PStringBase.Pack<char>:
            public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, void**, UInt32, UInt32>)0x004FD290)(ref this, addr, size); // .text:004FC6F0 ; unsigned int __thiscall AC1Legacy.PStringBase<char>::Pack(AC1Legacy.PStringBase<char> *this, void **addr, unsigned int size) .text:004FC6F0 ?Pack@?$PStringBase@D@AC1Legacy@@QBEIAAPAXI@Z

            // AC1Legacy.PStringBase.UnPack<char>:
            public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, void**, UInt32, int>)0x004FD460)(ref this, addr, size); // .text:004FC8C0 ; int __thiscall AC1Legacy.PStringBase<char>::UnPack(AC1Legacy.PStringBase<char> *this, void **addr, unsigned int size) .text:004FC8C0 ?UnPack@?$PStringBase@D@AC1Legacy@@QAEHAAPAXI@Z

            // AC1Legacy.PStringBase.allocate_ref_buffer<char>:
            public void allocate_ref_buffer(UInt32 len) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, UInt32, void>)0x00403560)(ref this, len); // .text:00403380 ; void __thiscall AC1Legacy.PStringBase<char>::allocate_ref_buffer(AC1Legacy.PStringBase<char> *this, unsigned int len) .text:00403380 ?allocate_ref_buffer@?$PStringBase@D@AC1Legacy@@IAEXI@Z

            // AC1Legacy.PStringBase.allocate_ref_buffer<unsigned short>:
            public void allocate_ref_buffer<UInt16>(UInt32 len) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, UInt32, void>)0x00543680)(ref this, len); // .text:00542AA0 ; void __thiscall AC1Legacy.PStringBase<unsigned short>::allocate_ref_buffer(AC1Legacy.PStringBase<unsigned short> *this, unsigned int len) .text:00542AA0 ?allocate_ref_buffer@?$PStringBase@G@AC1Legacy@@IAEXI@Z

            // AC1Legacy.PStringBase.append_int32<char>:
            // public void append_int32(int num) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, int, void>)0xDEADBEEF)(ref this, num); // .text:004AC490 ; void __thiscall AC1Legacy.PStringBase<char>::append_int32(AC1Legacy.PStringBase<char> *this, int num) .text:004AC490 ?append_int32@?$PStringBase@D@AC1Legacy@@QAEXJ@Z

            // AC1Legacy.PStringBase.append_n_chars<char>:
            public void append_n_chars(char* str, UInt32 count) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, char*, UInt32, void>)0x004910C0)(ref this, str, count); // .text:00490DE0 ; void __thiscall AC1Legacy.PStringBase<char>::append_n_chars(AC1Legacy.PStringBase<char> *this, const char *str, unsigned int count) .text:00490DE0 ?append_n_chars@?$PStringBase@D@AC1Legacy@@QAEXPBDI@Z

            // AC1Legacy.PStringBase.break_reference<char>:
            public void break_reference() => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, void>)0x00411870)(ref this); // .text:00411510 ; void __thiscall AC1Legacy.PStringBase<char>::break_reference(AC1Legacy.PStringBase<char> *this) .text:00411510 ?break_reference@?$PStringBase@D@AC1Legacy@@IAEXXZ

            // AC1Legacy.PStringBase.clear<char>:
            public void clear() => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, void>)0x004AB990)(ref this); // .text:004AB610 ; void __thiscall AC1Legacy.PStringBase<char>::clear(AC1Legacy.PStringBase<char> *this) .text:004AB610 ?clear@?$PStringBase@D@AC1Legacy@@QAEXXZ

            // AC1Legacy.PStringBase.cmp<char>:
            public int cmp(AC1Legacy.PStringBase<char>* rhs, int case_sensitive) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<char>*, int, int>)0x004ABA90)(ref this, rhs, case_sensitive); // .text:004AB710 ; int __thiscall AC1Legacy.PStringBase<char>::cmp(AC1Legacy.PStringBase<char> *this, AC1Legacy.PStringBase<char> *rhs, int case_sensitive) .text:004AB710 ?cmp@?$PStringBase@D@AC1Legacy@@QBEJABV12@H@Z

            // AC1Legacy.PStringBase.compute_hash<char>:
            public UInt32 compute_hash() => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, UInt32>)0x004FE440)(ref this); // .text:004FD8A0 ; unsigned int __thiscall AC1Legacy.PStringBase<char>::compute_hash(AC1Legacy.PStringBase<char> *this) .text:004FD8A0 ?compute_hash@?$PStringBase@D@AC1Legacy@@IBEKXZ

            // AC1Legacy.PStringBase.convert<char>:
            // public Byte convert(int i_int32, int comma) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, int, int, Byte>)0xDEADBEEF)(ref this, i_int32, comma); // .text:004AD5D0 ; bool __thiscall AC1Legacy.PStringBase<char>::convert(AC1Legacy.PStringBase<char> *this, int i_int32, int comma) .text:004AD5D0 ?convert@?$PStringBase@D@AC1Legacy@@QAE_NJH@Z

            // AC1Legacy.PStringBase.eq<char>:
            public Byte eq(AC1Legacy.PStringBase<char>* rhs, int case_sensitive) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<char>*, int, Byte>)0x004AC350)(ref this, rhs, case_sensitive); // .text:004ABFD0 ; bool __thiscall AC1Legacy.PStringBase<char>::eq(AC1Legacy.PStringBase<char> *this, AC1Legacy.PStringBase<char> *rhs, int case_sensitive) .text:004ABFD0 ?eq@?$PStringBase@D@AC1Legacy@@QBE_NABV12@H@Z

            // AC1Legacy.PStringBase.find_substring<char>:
            public int find_substring(AC1Legacy.PStringBase<char>* str) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<char>*, int>)0x00542EA0)(ref this, str); // .text:005422C0 ; int __thiscall AC1Legacy.PStringBase<char>::find_substring(AC1Legacy.PStringBase<char> *this, AC1Legacy.PStringBase<char> *str) .text:005422C0 ?find_substring@?$PStringBase@D@AC1Legacy@@QBEJABV12@@Z

            // AC1Legacy.PStringBase.replace<char>:
            public int replace(AC1Legacy.PStringBase<char>* search, AC1Legacy.PStringBase<char>* str) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*, int>)0x00566D10)(ref this, search, str); // .text:00565F70 ; int __thiscall AC1Legacy.PStringBase<char>::replace(AC1Legacy.PStringBase<char> *this, AC1Legacy.PStringBase<char> *search, AC1Legacy.PStringBase<char> *str) .text:00565F70 ?replace@?$PStringBase@D@AC1Legacy@@QAEJABV12@0@Z

            // AC1Legacy.PStringBase.set<char>:
            public void set(char* str) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, char*, void>)0x004034C0)(ref this, str); // .text:004032E0 ; void __thiscall AC1Legacy.PStringBase<char>::set(AC1Legacy.PStringBase<char> *this, const char *str) .text:004032E0 ?set@?$PStringBase@D@AC1Legacy@@QAEXPBD@Z

            // AC1Legacy.PStringBase.set<unsigned short>:
            public void set(UInt16* str) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, UInt16*, void>)0x0055F580)(ref this, str); // .text:0055E810 ; void __thiscall AC1Legacy.PStringBase<unsigned short>::set(AC1Legacy.PStringBase<unsigned short> *this, const unsigned __int16 *str) .text:0055E810 ?set@?$PStringBase@G@AC1Legacy@@QAEXPBG@Z

            // AC1Legacy.PStringBase.sprintf:
            // (ERR) .text:00487620 ; int __cdecl AC1Legacy.PStringBase<char>::sprintf(int, char *Format, char ArgList) .text:00487620 ?sprintf@?$PStringBase@D@AC1Legacy@@QAAJPBDZZ

            // AC1Legacy.PStringBase.substring<char>:
            public AC1Legacy.PStringBase<char>* substring(AC1Legacy.PStringBase<char>* result, UInt32 first, UInt32 last) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<char>*, UInt32, UInt32, AC1Legacy.PStringBase<char>*>)0x005AA260)(ref this, result, first, last); // .text:005A91B0 ; AC1Legacy.PStringBase<char> *__thiscall AC1Legacy.PStringBase<char>::substring(AC1Legacy.PStringBase<char> *this, AC1Legacy.PStringBase<char> *result, unsigned int first, unsigned int last) .text:005A91B0 ?substring@?$PStringBase@D@AC1Legacy@@QBE?AV12@KK@Z

            // AC1Legacy.PStringBase.to_spstring<unsigned short>:
            public AC1Legacy.PStringBase<char>* to_spstring(AC1Legacy.PStringBase<char>* result, UInt16 i_targetCodePage) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<char>*, UInt16, AC1Legacy.PStringBase<char>*>)0x00546290)(ref this, result, i_targetCodePage); // .text:005456D0 ; AC1Legacy.PStringBase<char> *__thiscall AC1Legacy.PStringBase<unsigned short>::to_spstring(AC1Legacy.PStringBase<unsigned short> *this, AC1Legacy.PStringBase<char> *result, const unsigned __int16 i_targetCodePage) .text:005456D0 ?to_spstring@?$PStringBase@G@AC1Legacy@@QBE?AV?$PStringBase@D@2@G@Z

            // AC1Legacy.PStringBase.to_wpstring<char>:
            public AC1Legacy.PStringBase<UInt16>* to_wpstring(AC1Legacy.PStringBase<UInt16>* result, UInt16 i_sourceCodePage) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, AC1Legacy.PStringBase<UInt16>*, UInt16, AC1Legacy.PStringBase<UInt16>*>)0x005571C0)(ref this, result, i_sourceCodePage); // .text:00556580 ; AC1Legacy.PStringBase<unsigned short> *__thiscall AC1Legacy.PStringBase<char>::to_wpstring(AC1Legacy.PStringBase<char> *this, AC1Legacy.PStringBase<unsigned short> *result, const unsigned __int16 i_sourceCodePage) .text:00556580 ?to_wpstring@?$PStringBase@D@AC1Legacy@@QBE?AV?$PStringBase@G@2@G@Z

            // AC1Legacy.PStringBase.trim<char>:
            public void trim(int pre, int post, AC1Legacy.PStringBase<char> filter) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, int, int, AC1Legacy.PStringBase<char>, void>)0x0056F9A0)(ref this, pre, post, filter); // .text:0056EBF0 ; void __thiscall AC1Legacy.PStringBase<char>::trim(AC1Legacy.PStringBase<char> *this, int pre, int post, AC1Legacy.PStringBase<char> filter) .text:0056EBF0 ?trim@?$PStringBase@D@AC1Legacy@@QAEXHHV12@@Z

            // AC1Legacy.PStringBase.vsprintf<char>:
            public int vsprintf(char* fmt, char* args) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, char*, char*, int>)0x00487480)(ref this, fmt, args); // .text:004870C0 ; int __thiscall AC1Legacy.PStringBase<char>::vsprintf(AC1Legacy.PStringBase<char> *this, const char *fmt, char *args) .text:004870C0 ?vsprintf@?$PStringBase@D@AC1Legacy@@QAEJPBDPAD@Z

            // AC1Legacy.PStringBase.vsprintf<unsigned short>:
            // public int vsprintf(UInt16* fmt, char* args) => ((delegate* unmanaged[Thiscall]<ref AC1Legacy.PStringBase<T>, UInt16*, char*, int>)0xDEADBEEF)(ref this, fmt, args); // .text:00556430 ; int __thiscall AC1Legacy.PStringBase<unsigned short>::vsprintf(AC1Legacy.PStringBase<unsigned short> *this, const unsigned __int16 *fmt, char *args) .text:00556430 ?vsprintf@?$PStringBase@G@AC1Legacy@@QAEJPBGPAD@Z

            // -- No References found

            // Globals:
            public static AC1Legacy.PSRefBuffer<T>** s_NullBuffer = (AC1Legacy.PSRefBuffer<T>**)0x008EF11C; // .data:008EE10C ; AC1Legacy::PSRefBuffer<Char> *AC1Legacy.PStringBase<Char>::s_NullBuffer .data:008EE10C ?s_NullBuffer@?$PStringBase@D@AC1Legacy@@1PAV?$PSRefBuffer@D@2@A
            public static AC1Legacy.PStringBase<Char>* null_string = (AC1Legacy.PStringBase<Char>*)0x008EF120; // .data:008EE110 ; AC1Legacy.PStringBase<Char> AC1Legacy.PStringBase<Char>::null_string .data:008EE110 ?null_string@?$PStringBase@D@AC1Legacy@@2V12@B
            public static AC1Legacy.PStringBase<Char>* whitespace_string = (AC1Legacy.PStringBase<Char>*)0x008EF124; // .data:008EE114 ; AC1Legacy.PStringBase<Char> AC1Legacy.PStringBase<Char>::whitespace_string .data:008EE114 ?whitespace_string@?$PStringBase@D@AC1Legacy@@2V12@B
            public static AC1Legacy.PSRefBuffer<T>** s_NullBuffer_w = (AC1Legacy.PSRefBuffer<T>**)0x008EF12C; // .data:008EE11C ; AC1Legacy::PSRefBuffer<unsigned short> *AC1Legacy.PStringBase<unsigned short>::s_NullBuffer .data:008EE11C ?s_NullBuffer@?$PStringBase@G@AC1Legacy@@1PAV?$PSRefBuffer@G@2@A
            public static AC1Legacy.PStringBase<UInt16>* null_string_w = (AC1Legacy.PStringBase<UInt16>*)0x008EF130; // .data:008EE120 ; AC1Legacy.PStringBase<unsigned short> AC1Legacy.PStringBase<unsigned short>::null_string .data:008EE120 ?null_string@?$PStringBase@G@AC1Legacy@@2V12@B
            public static AC1Legacy.PStringBase<UInt16>* whitespace_string_w = (AC1Legacy.PStringBase<UInt16>*)0x008EF134; // .data:008EE124 ; AC1Legacy.PStringBase<unsigned short> AC1Legacy.PStringBase<unsigned short>::whitespace_string .data:008EE124 ?whitespace_string@?$PStringBase@G@AC1Legacy@@2V12@B

        }
        public unsafe struct PSRefBuffer<T> where T : unmanaged {
            // Struct:
            public Turbine_RefCount _ref;
            public Int32 m_len;
            public UInt32 m_size;
            public UInt32 m_hash;
            public fixed Int32 m_data[128];
        }
        public unsafe struct CaseInsensitiveStringBase<T> {
            // Struct:
            public T str;
            public override string ToString() => str.ToString();
            // CaseInsensitiveStringBase<PStringBase<Char>>.case_insensitive_hash:
            // public static delegate* unmanaged[Thiscall]<CaseInsensitiveStringBase<PStringBase<Char>>*, UInt32> case_insensitive_hash = (delegate* unmanaged[Thiscall]<CaseInsensitiveStringBase<PStringBase<Char>>*, UInt32>)0xDEADBEEF; // .text:0041A710 ; UInt32 __thiscall CaseInsensitiveStringBase<PStringBase<Char>>::case_insensitive_hash(CaseInsensitiveStringBase<PStringBase<Char> > *this) .text:0041A710 ?case_insensitive_hash@?$CaseInsensitiveStringBase@V?$PStringBase@D@@@@QBEKXZ

        }






    }




    public unsafe struct PStringBase<T> where T : unmanaged {
        // Struct:
        public PSRefBufferCharData<T>* m_charbuffer;
        public override string ToString() {
            int len = 0;
            if (typeof(T) == typeof(UInt16)) {
                for (int i = 0; ((char*)m_charbuffer->m_data)[i] != 0; i++) len++;
                return new string((char*)m_charbuffer, 0, len);
            }
            for (int i = 0; ((sbyte*)m_charbuffer->m_data)[i] != 0; i++) len++;
            return new string((sbyte*)m_charbuffer, 0, len);
        }

        // Functions:

        // PStringBase.operator_equals<unsigned short>:
        public PStringBase<UInt16>* operator_equals(UInt16* rhs) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt16*, PStringBase<UInt16>*>)0x00402070)(ref this, rhs); // .text:00401A50 ; PStringBase<unsigned short> *__thiscall PStringBase<unsigned short>::operator=(PStringBase<unsigned short> *this, const unsigned __int16 *rhs) .text:00401A50 ??4?$PStringBase@G@@QAEAAV0@ABV0@@Z

        // PStringBase.operator_is_equal<char>:
        public Byte operator_is_equal(PStringBase<char>* rhs) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, Byte>)0x00401920)(ref this, rhs); // .text:00401910 ; bool __thiscall PStringBase<char>::operator==(PStringBase<char> *this, PStringBase<char> *rhs) .text:00401910 ??8?$PStringBase@D@@QBE_NABV0@@Z

        // PStringBase.operator_is_equal<unsigned short>:
        public Byte operator_is_equal(PStringBase<UInt16>* rhs) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<UInt16>*, Byte>)0x0042C8C0)(ref this, rhs); // .text:0042C660 ; bool __thiscall PStringBase<unsigned short>::operator==(PStringBase<unsigned short> *this, PStringBase<unsigned short> *rhs) .text:0042C660 ??8?$PStringBase@G@@QBE_NABV0@@Z

        // PStringBase.operator_not_equal<char>:
        public Byte operator_not_equal(PStringBase<char>* rhs) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, Byte>)0x00426520)(ref this, rhs); // .text:00426240 ; bool __thiscall PStringBase<char>::operator!=(PStringBase<char> *this, PStringBase<char> *rhs) .text:00426240 ??9?$PStringBase@D@@QBE_NABV0@@Z

        // PStringBase.operator_not_equal<unsigned short>:
        public Byte operator_not_equal(PStringBase<UInt16>* rhs) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<UInt16>*, Byte>)0x00494E10)(ref this, rhs); // .text:00494B30 ; bool __thiscall PStringBase<unsigned short>::operator!=(PStringBase<unsigned short> *this, PStringBase<unsigned short> *rhs) .text:00494B30 ??9?$PStringBase@G@@QBE_NABV0@@Z

        // PStringBase.operator_bracket<unsigned short>:
        public UInt16* operator_bracket(UInt32 index) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32, UInt16*>)0x004075C0)(ref this, index); // .text:00407310 ; const unsigned __int16 *__thiscall PStringBase<unsigned short>::operator[](PStringBase<unsigned short> *this, unsigned int index) .text:00407310 ??A?$PStringBase@G@@QBEABGK@Z

        // PStringBase.operator_plus<char>:
        public PStringBase<char>* operator_plus(PStringBase<char>* result, PStringBase<char>* rhs) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, PStringBase<char>*, PStringBase<char>*>)0x0040BBC0)(ref this, result, rhs); // .text:0040B860 ; PStringBase<char> *__thiscall PStringBase<char>::operator+(PStringBase<char> *this, PStringBase<char> *result, PStringBase<char> *rhs) .text:0040B860 ??H?$PStringBase@D@@QBE?AV0@ABV0@@Z

        // PStringBase.operator_plus<unsigned short>:
        public PStringBase<UInt16>* operator_plus(PStringBase<UInt16>* result, PStringBase<UInt16>* rhs) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<UInt16>*, PStringBase<UInt16>*, PStringBase<UInt16>*>)0x004086C0)(ref this, result, rhs); // .text:00408410 ; PStringBase<unsigned short> *__thiscall PStringBase<unsigned short>::operator+(PStringBase<unsigned short> *this, PStringBase<unsigned short> *result, PStringBase<unsigned short> *rhs) .text:00408410 ??H?$PStringBase@G@@QBE?AV0@ABV0@@Z

        // PStringBase.operator_plus_equals<char>:
        public PStringBase<char>* operator_plus_equals(PStringBase<char>* rhs) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, PStringBase<char>*>)0x004087D0)(ref this, rhs); // .text:00408520 ; PStringBase<char> *__thiscall PStringBase<char>::operator+=(PStringBase<char> *this, PStringBase<char> *rhs) .text:00408520 ??Y?$PStringBase@D@@QAEAAV0@ABV0@@Z

        // PStringBase.operator_plus_equals<unsigned short>:
        public PStringBase<UInt16>* operator_plus_equals(PStringBase<UInt16>* rhs) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<UInt16>*, PStringBase<UInt16>*>)0x00408800)(ref this, rhs); // .text:00408550 ; PStringBase<unsigned short> *__thiscall PStringBase<unsigned short>::operator+=(PStringBase<unsigned short> *this, PStringBase<unsigned short> *rhs) .text:00408550 ??Y?$PStringBase@G@@QAEAAV0@ABV0@@Z

        // PStringBase.Serialize<char>:
        public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, Archive*, void>)0x00402400)(ref this, io_archive); // .text:00402260 ; void __thiscall PStringBase<char>::Serialize(PStringBase<char> *this, Archive *io_archive) .text:00402260 ?Serialize@?$PStringBase@D@@QAEXAAVArchive@@@Z

        // PStringBase.Serialize<unsigned short>:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:004223B0 ; void __thiscall PStringBase<unsigned short>::Serialize(PStringBase<unsigned short> *this, Archive *io_archive) .text:004223B0 ?Serialize@?$PStringBase@G@@QAEXAAVArchive@@@Z

        // PStringBase.SetAtIndex<char>:
        public void SetAtIndex(UInt32 nIndex, char zCharacter) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32, char, void>)0x00408770)(ref this, nIndex, zCharacter); // .text:004084C0 ; void __thiscall PStringBase<char>::SetAtIndex(PStringBase<char> *this, unsigned int nIndex, const char zCharacter) .text:004084C0 ?SetAtIndex@?$PStringBase@D@@QAEXKD@Z

        // PStringBase.SetAtIndex<unsigned short>:
        public void SetAtIndex<UInt16>(UInt32 nIndex, UInt16 zCharacter) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32, UInt16, void>)0x004089F0)(ref this, nIndex, zCharacter); // .text:00408740 ; void __thiscall PStringBase<unsigned short>::SetAtIndex(PStringBase<unsigned short> *this, unsigned int nIndex, const unsigned __int16 zCharacter) .text:00408740 ?SetAtIndex@?$PStringBase@G@@QAEXKG@Z

        // PStringBase.allocate<char>:
        public Byte allocate(UInt32 num_chars) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32, Byte>)0x00408D90)(ref this, num_chars); // .text:00408AE0 ; bool __thiscall PStringBase<char>::allocate(PStringBase<char> *this, unsigned int num_chars) .text:00408AE0 ?allocate@?$PStringBase@D@@QAE_NI@Z

        // PStringBase.allocate<unsigned short>:
        public Byte allocate<UInt16>(UInt32 num_chars) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32, Byte>)0x00408EC0)(ref this, num_chars); // .text:00408C10 ; bool __thiscall PStringBase<unsigned short>::allocate(PStringBase<unsigned short> *this, unsigned int num_chars) .text:00408C10 ?allocate@?$PStringBase@G@@QAE_NI@Z

        // PStringBase.allocate_ref_buffer<char>:
        public Byte allocate_ref_buffer(UInt32 len) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32, Byte>)0x00401280)(ref this, len); // .text:004012C0 ; bool __thiscall PStringBase<char>::allocate_ref_buffer(PStringBase<char> *this, unsigned int len) .text:004012C0 ?allocate_ref_buffer@?$PStringBase@D@@IAE_NI@Z

        // PStringBase.allocate_ref_buffer<unsigned short>:
        public Byte allocate_ref_buffer<UInt16>(UInt32 len) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32, Byte>)0x004022D0)(ref this, len); // .text:00402130 ; bool __thiscall PStringBase<unsigned short>::allocate_ref_buffer(PStringBase<unsigned short> *this, unsigned int len) .text:00402130 ?allocate_ref_buffer@?$PStringBase@G@@IAE_NI@Z

        // PStringBase.append_int32<unsigned short>:
        public void append_int32(int num) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, int, void>)0x0047B520)(ref this, num); // .text:0047B160 ; void __thiscall PStringBase<unsigned short>::append_int32(PStringBase<unsigned short> *this, int num) .text:0047B160 ?append_int32@?$PStringBase@G@@QAEXJ@Z

        // PStringBase.append_n_chars<char>:
        public void append_n_chars(char* str, UInt32 count) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, char*, UInt32, void>)0x00404EF0)(ref this, str, count); // .text:00404CF0 ; void __thiscall PStringBase<char>::append_n_chars(PStringBase<char> *this, const char *str, unsigned int count) .text:00404CF0 ?append_n_chars@?$PStringBase@D@@QAEXPBDI@Z

        // PStringBase.append_n_chars<unsigned short>:
        public void append_n_chars(UInt16* str, UInt32 count) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt16*, UInt32, void>)0x00402490)(ref this, str, count); // .text:004022F0 ; void __thiscall PStringBase<unsigned short>::append_n_chars(PStringBase<unsigned short> *this, const unsigned __int16 *str, unsigned int count) .text:004022F0 ?append_n_chars@?$PStringBase@G@@QAEXPBGI@Z

        // PStringBase.append_string<char>:
        public void append_string(PStringBase<char>* str) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, void>)0x004064E0)(ref this, str); // .text:004061E0 ; void __thiscall PStringBase<char>::append_string(PStringBase<char> *this, PStringBase<char> *str) .text:004061E0 ?append_string@?$PStringBase@D@@QAEXABV1@@Z

        // PStringBase.append_string<unsigned short>:
        public void append_string(PStringBase<UInt16>* str) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<UInt16>*, void>)0x00402790)(ref this, str); // .text:004025F0 ; void __thiscall PStringBase<unsigned short>::append_string(PStringBase<unsigned short> *this, PStringBase<unsigned short> *str) .text:004025F0 ?append_string@?$PStringBase@G@@QAEXABV1@@Z

        // PStringBase.append_string<unsigned short>:
        public void append_string(UInt16* str) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt16*, void>)0x0040B8F0)(ref this, str); // .text:0040B590 ; void __thiscall PStringBase<unsigned short>::append_string(PStringBase<unsigned short> *this, const unsigned __int16 *str) .text:0040B590 ?append_string@?$PStringBase@G@@QAEXPBG@Z

        // PStringBase.append_uint32<char>:
        public void append_uint32(UInt32 num) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32, void>)0x0040F110)(ref this, num); // .text:0040EDB0 ; void __thiscall PStringBase<char>::append_uint32(PStringBase<char> *this, unsigned int num) .text:0040EDB0 ?append_uint32@?$PStringBase@D@@QAEXK@Z

        // PStringBase.append_uint32<unsigned short>:
        // public void append_uint32(UInt32 num) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32, void>)0xDEADBEEF)(ref this, num); // .text:004823E0 ; void __thiscall PStringBase<unsigned short>::append_uint32(PStringBase<unsigned short> *this, unsigned int num) .text:004823E0 ?append_uint32@?$PStringBase@G@@QAEXK@Z

        // PStringBase.break_reference<char>:
        public void break_reference() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, void>)0x004080C0)(ref this); // .text:00407EB0 ; void __thiscall PStringBase<char>::break_reference(PStringBase<char> *this) .text:00407EB0 ?break_reference@?$PStringBase@D@@IAEXXZ

        // PStringBase.break_reference<unsigned short>:
        public void break_reference<UInt16>() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, void>)0x00408390)(ref this); // .text:004080E0 ; void __thiscall PStringBase<unsigned short>::break_reference(PStringBase<unsigned short> *this) .text:004080E0 ?break_reference@?$PStringBase@G@@IAEXXZ

        // PStringBase.clear<char>:
        public void clear() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, void>)0x00404CD0)(ref this); // .text:00404AD0 ; void __thiscall PStringBase<char>::clear(PStringBase<char> *this) .text:00404AD0 ?clear@?$PStringBase@D@@QAEXXZ

        // PStringBase.clear<unsigned short>:
        public void clear<UInt16>() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, void>)0x0040B220)(ref this); // .text:0040AEC0 ; void __thiscall PStringBase<unsigned short>::clear(PStringBase<unsigned short> *this) .text:0040AEC0 ?clear@?$PStringBase@G@@QAEXXZ

        // PStringBase.cmp<char>:
        public int cmp(PStringBase<char>* rhs, Byte case_sensitive) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, Byte, int>)0x00404B40)(ref this, rhs, case_sensitive); // .text:00404940 ; int __thiscall PStringBase<char>::cmp(PStringBase<char> *this, PStringBase<char> *rhs, bool case_sensitive) .text:00404940 ?cmp@?$PStringBase@D@@QBEJABV1@_N@Z

        // PStringBase.eq<char>:
        public Byte eq(PStringBase<char>* rhs, Byte case_sensitive) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, Byte, Byte>)0x00404D20)(ref this, rhs, case_sensitive); // .text:00404B20 ; bool __thiscall PStringBase<char>::eq(PStringBase<char> *this, PStringBase<char> *rhs, bool case_sensitive) .text:00404B20 ?eq@?$PStringBase@D@@QBE_NABV1@_N@Z

        // PStringBase.find_substring<char>:
        public int find_substring(PStringBase<char>* str) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, int>)0x00404D40)(ref this, str); // .text:00404B40 ; int __thiscall PStringBase<char>::find_substring(PStringBase<char> *this, PStringBase<char> *str) .text:00404B40 ?find_substring@?$PStringBase@D@@QBEJABV1@@Z

        // PStringBase.hash<char>:
        public UInt32 hash() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32>)0x004134B0)(ref this); // .text:004131A0 ; unsigned int __thiscall PStringBase<char>::hash(PStringBase<char> *this) .text:004131A0 ?hash@?$PStringBase@D@@QBEKXZ

        // PStringBase.replace<char>:
        public int replace(PStringBase<char>* search, PStringBase<char>* str) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, PStringBase<char>*, int>)0x004053A0)(ref this, search, str); // .text:004050A0 ; int __thiscall PStringBase<char>::replace(PStringBase<char> *this, PStringBase<char> *search, PStringBase<char> *str) .text:004050A0 ?replace@?$PStringBase@D@@QAEJABV1@0@Z

        // PStringBase.replace<unsigned short>:
        public int replace(PStringBase<UInt16>* search, PStringBase<UInt16>* str) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<UInt16>*, PStringBase<UInt16>*, int>)0x0040D870)(ref this, search, str); // .text:0040D510 ; int __thiscall PStringBase<unsigned short>::replace(PStringBase<unsigned short> *this, PStringBase<unsigned short> *search, PStringBase<unsigned short> *str) .text:0040D510 ?replace@?$PStringBase@G@@QAEJABV1@0@Z

        // PStringBase.set<char>:
        public void set(PStringBase<char>* str) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, void>)0x00401700)(ref this, str); // .text:004016F0 ; void __thiscall PStringBase<char>::set(PStringBase<char> *this, PStringBase<char> *str) .text:004016F0 ?set@?$PStringBase@D@@QAEXABV1@@Z

        // PStringBase.set<char>:
        public void set(char* str) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, char*, void>)0x00405000)(ref this, str); // .text:00404E00 ; void __thiscall PStringBase<char>::set(PStringBase<char> *this, const char *str) .text:00404E00 ?set@?$PStringBase@D@@QAEXPBD@Z

        // PStringBase.set<unsigned short>:
        public void set(UInt16* str) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt16*, void>)0x00407E40)(ref this, str); // .text:00407B90 ; void __thiscall PStringBase<unsigned short>::set(PStringBase<unsigned short> *this, const unsigned __int16 *str) .text:00407B90 ?set@?$PStringBase@G@@QAEXPBG@Z

        // PStringBase.sprintf:
        // (ERR) .text:00402710 ; int __cdecl PStringBase<char>::sprintf(int, char *Format, char ArgList) .text:00402710 ?sprintf@?$PStringBase@D@@QAAJPBDZZ

        // PStringBase.sprintf:
        // (ERR) .text:004027B0 ; int __cdecl PStringBase<unsigned short>::sprintf(int, wchar_t *Format, char ArgList) .text:004027B0 ?sprintf@?$PStringBase@G@@QAAJPBGZZ

        // PStringBase.sprintf_append:
        // (ERR) .text:00406500 ; int __cdecl PStringBase<char>::sprintf_append(int, char *Format, char ArgList) .text:00406500 ?sprintf_append@?$PStringBase@D@@QAAJPBDZZ

        // PStringBase.sprintf_append:
        // (ERR) .text:004300A0 ; int __cdecl PStringBase<unsigned short>::sprintf_append(int, wchar_t *Format, char ArgList) .text:004300A0 ?sprintf_append@?$PStringBase@G@@QAAJPBGZZ

        // PStringBase.substring<char>:
        public PStringBase<char>* substring(PStringBase<char>* result, UInt32 first, UInt32 last) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, UInt32, UInt32, PStringBase<char>*>)0x00404F80)(ref this, result, first, last); // .text:00404D80 ; PStringBase<char> *__thiscall PStringBase<char>::substring(PStringBase<char> *this, PStringBase<char> *result, unsigned int first, unsigned int last) .text:00404D80 ?substring@?$PStringBase@D@@QBE?AV1@KK@Z

        // PStringBase.substring<unsigned short>:
        // public PStringBase<UInt16>* substring(PStringBase<UInt16>* result, UInt32 first, UInt32 last) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<UInt16>*, UInt32, UInt32, PStringBase<UInt16>*>)0xDEADBEEF)(ref this, result, first, last); // .text:004F3FE0 ; PStringBase<unsigned short> *__thiscall PStringBase<unsigned short>::substring(PStringBase<unsigned short> *this, PStringBase<unsigned short> *result, unsigned int first, unsigned int last) .text:004F3FE0 ?substring@?$PStringBase@G@@QBE?AV1@KK@Z

        // PStringBase.to_float<unsigned short>:
        // public Single to_float() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, Single>)0xDEADBEEF)(ref this); // .text:00482110 ; float __thiscall PStringBase<unsigned short>::to_float(PStringBase<unsigned short> *this) .text:00482110 ?to_float@?$PStringBase@G@@QBEMXZ

        // PStringBase.to_int32<char>:
        public int to_int32() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, int>)0x00429A50)(ref this); // .text:004297B0 ; int __thiscall PStringBase<char>::to_int32(PStringBase<char> *this) .text:004297B0 ?to_int32@?$PStringBase@D@@QBEJXZ

        // PStringBase.to_int32<unsigned short>:
        // public int to_int32() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, int>)0xDEADBEEF)(ref this); // .text:00489B90 ; int __thiscall PStringBase<unsigned short>::to_int32(PStringBase<unsigned short> *this) .text:00489B90 ?to_int32@?$PStringBase@G@@QBEJXZ

        // PStringBase.to_spstring<unsigned short>:
        public PStringBase<char>* to_spstring(PStringBase<char>* result, UInt16 i_targetCodePage) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<char>*, UInt16, PStringBase<char>*>)0x00408FD0)(ref this, result, i_targetCodePage); // .text:00408D20 ; PStringBase<char> *__thiscall PStringBase<unsigned short>::to_spstring(PStringBase<unsigned short> *this, PStringBase<char> *result, const unsigned __int16 i_targetCodePage) .text:00408D20 ?to_spstring@?$PStringBase@G@@QBE?AV?$PStringBase@D@@G@Z

        // PStringBase.to_uint32<char>:
        public UInt32 to_uint32() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32>)0x00404D70)(ref this); // .text:00404B70 ; unsigned int __thiscall PStringBase<char>::to_uint32(PStringBase<char> *this) .text:00404B70 ?to_uint32@?$PStringBase@D@@QBEKXZ

        // PStringBase.to_uint32<unsigned short>:
        public UInt32 to_uint32<UInt16>() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt32>)0x00478B80)(ref this); // .text:00478780 ; unsigned int __thiscall PStringBase<unsigned short>::to_uint32(PStringBase<unsigned short> *this) .text:00478780 ?to_uint32@?$PStringBase@G@@QBEKXZ

        // PStringBase.to_wpstring<char>:
        public PStringBase<UInt16>* to_wpstring(PStringBase<UInt16>* result, UInt16 i_sourceCodePage) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, PStringBase<UInt16>*, UInt16, PStringBase<UInt16>*>)0x00403350)(ref this, result, i_sourceCodePage); // .text:00403170 ; PStringBase<unsigned short> *__thiscall PStringBase<char>::to_wpstring(PStringBase<char> *this, PStringBase<unsigned short> *result, const unsigned __int16 i_sourceCodePage) .text:00403170 ?to_wpstring@?$PStringBase@D@@QBE?AV?$PStringBase@G@@G@Z

        // PStringBase.tolower<char>:
        // public void tolower() => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, void>)0xDEADBEEF)(ref this); // .text:0041C8A0 ; void __thiscall PStringBase<char>::tolower(PStringBase<char> *this) .text:0041C8A0 ?tolower@?$PStringBase@D@@QAEXXZ

        // PStringBase.trim<char>:
        public void trim(Byte pre, Byte post, PStringBase<char> filter) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, Byte, Byte, PStringBase<char>, void>)0x00435720)(ref this, pre, post, filter); // .text:00435420 ; void __thiscall PStringBase<char>::trim(PStringBase<char> *this, bool pre, bool post, PStringBase<char> filter) .text:00435420 ?trim@?$PStringBase@D@@QAEX_N0V1@@Z

        // PStringBase.trim<unsigned short>:
        // public void trim(Byte pre, Byte post, PStringBase<UInt16> filter) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, Byte, Byte, PStringBase<UInt16>, void>)0xDEADBEEF)(ref this, pre, post, filter); // .text:004D5C60 ; void __thiscall PStringBase<unsigned short>::trim(PStringBase<unsigned short> *this, bool pre, bool post, PStringBase<unsigned short> filter) .text:004D5C60 ?trim@?$PStringBase@G@@QAEX_N0V1@@Z

        // PStringBase.vsprintf<char>:
        public int vsprintf(char* fmt, char* args) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, char*, char*, int>)0x00402390)(ref this, fmt, args); // .text:004021F0 ; int __thiscall PStringBase<char>::vsprintf(PStringBase<char> *this, const char *fmt, char *args) .text:004021F0 ?vsprintf@?$PStringBase@D@@QAEJPBDPAD@Z

        // PStringBase.vsprintf<unsigned short>:
        public int vsprintf(UInt16* fmt, char* args) => ((delegate* unmanaged[Thiscall]<ref PStringBase<T>, UInt16*, char*, int>)0x00402520)(ref this, fmt, args); // .text:00402380 ; int __thiscall PStringBase<unsigned short>::vsprintf(PStringBase<unsigned short> *this, const unsigned __int16 *fmt, char *args) .text:00402380 ?vsprintf@?$PStringBase@G@@QAEJPBGPAD@Z

        // Globals:
        public static PSRefBufferCharData<UInt16>** s_NullBuffer_w = (PSRefBufferCharData<UInt16>**)0x00818340; // .data:00817340 ; PSRefBufferCharData<unsigned short> *PStringBase<unsigned short>::s_NullBuffer .data:00817340 ?s_NullBuffer@?$PStringBase@G@@0PAV?$PSRefBufferCharData@G@@A
        public static PStringBase<char>* s_NullBuffer = (PStringBase<char>*)0x00818344; // .data:00817344 ; PStringBase<char> PStringBase<char>::s_NullBuffer .data:00817344 ?s_NullBuffer@?$PStringBase@D@@0PAV?$PSRefBufferCharData@D@@A
        public static PStringBase<char>* null_string = (PStringBase<char>*)0x008183B4; // .data:008173B4 ; PStringBase<char> PStringBase<char>::null_string .data:008173B4 ?null_string@?$PStringBase@D@@2V1@B
                                                                                       // public static PStringBase<char>* whitespace_string = (PStringBase<char>*)0xDEADBEEF; // .data:00836748 ; PStringBase<char> PStringBase<char>::whitespace_string .data:00836748 ?whitespace_string@?$PStringBase@D@@2V1@B
        public static PStringBase<UInt16>* null_string_w = (PStringBase<UInt16>*)0x0083774C; // .data:0083674C ; PStringBase<unsigned short> PStringBase<unsigned short>::null_string .data:0083674C ?null_string@?$PStringBase@G@@2V1@B
        public static PStringBase<UInt16>* whitespace_string_w = (PStringBase<UInt16>*)0x00837750; // .data:00836750 ; PStringBase<unsigned short> PStringBase<unsigned short>::whitespace_string .data:00836750 ?whitespace_string@?$PStringBase@G@@2V1@B
    }


    public unsafe struct PSRefBufferCharData<T> where T : unmanaged {
        // Struct:
        public fixed Int32 m_data[256];
    }
    public unsafe struct CaseInsensitiveStringBase<T> {
        // Struct:
        public T str;
        public override string ToString() => str.ToString();

        // Functions:

        // CaseInsensitiveStringBase.case_insensitive_hash:
        public UInt32 case_insensitive_hash<UInt16>() => ((delegate* unmanaged[Thiscall]<ref CaseInsensitiveStringBase<T>, UInt32>)0x00407680)(ref this); // .text:004073D0 ; unsigned int __thiscall CaseInsensitiveStringBase<PStringBase<unsigned short>>::case_insensitive_hash(CaseInsensitiveStringBase<PStringBase<unsigned short> > *this) .text:004073D0 ?case_insensitive_hash@?$CaseInsensitiveStringBase@V?$PStringBase@G@@@@QBEKXZ

        // CaseInsensitiveStringBase.case_insensitive_hash:
        public UInt32 case_insensitive_hash() => ((delegate* unmanaged[Thiscall]<ref CaseInsensitiveStringBase<T>, UInt32>)0x0041AA50)(ref this); // .text:0041A710 ; unsigned int __thiscall CaseInsensitiveStringBase<PStringBase<char>>::case_insensitive_hash(CaseInsensitiveStringBase<PStringBase<char> > *this) .text:0041A710 ?case_insensitive_hash@?$CaseInsensitiveStringBase@V?$PStringBase@D@@@@QBEKXZ
    }










    public struct TheseWork {
        public unsafe struct PStringBase<T> where T : unmanaged {
            // Struct:
            public PSRefBufferCharData<T>* m_Charbuffer;
            //public override string ToString() => $"{Marshal.PtrToStringAnsi((IntPtr)(m_Charbuffer->m_data))}";

            public override string ToString() {
                if (m_Charbuffer == null || m_Charbuffer->m_data[0] == 0) { return "null"; }
                if (typeof(T) == typeof(UInt16)) return new string((char*)m_Charbuffer->m_data);
                return new string((sbyte*)m_Charbuffer->m_data);
            }

            // Functions:

            // PStringBase<Char>.operator==:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, Byte> operator_isequal = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, Byte>)0x00401920; // .text:00401910 ; bool __thiscall PStringBase<Char>::operator==(PStringBase<Char> *this, PStringBase<Char> *rhs) .text:00401910 ??8?$PStringBase@D@@QBE_NABV0@@Z

            // PStringBase<Char>.trim:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, Byte, Byte, PStringBase<Char>> trim = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, Byte, Byte, PStringBase<Char>>)0x00435720; // .text:00435420 ; void __thiscall PStringBase<Char>::trim(PStringBase<Char> *this, bool pre, bool post, PStringBase<Char> filter) .text:00435420 ?trim@?$PStringBase@D@@QAEX_N0V1@@Z

            // PStringBase<Char>.__Ctor:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, _WidthConvert, PStringBase<UInt16>*> __Ctor = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, _WidthConvert, PStringBase<UInt16>*>)0x0048CAD0; // .text:0048C7F0 ; void __thiscall PStringBase<Char>::PStringBase<Char>(PStringBase<Char> *this, _WidthConvert __formal, PStringBase<UInt16> *str) .text:0048C7F0 ??0?$PStringBase@D@@QAE@W4_WidthConvert@@ABV?$PStringBase@G@@@Z

            // PStringBase<Char>.__Ctor:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*> __Ctor__ = (delegate* unmanaged[Thiscall]<PStringBase<Char>*>)0x00401A40; // .text:00401A30 ; void __thiscall PStringBase<Char>::PStringBase<Char>(PStringBase<Char> *this) .text:00401A30 ??0?$PStringBase@D@@QAE@XZ

            // PStringBase<Char>.vsprInt32f:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, Char*, Char*, Int32> vsprInt32f = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, Char*, Char*, Int32>)0x00402390; // .text:004021F0 ; Int32 __thiscall PStringBase<Char>::vsprInt32f(PStringBase<Char> *this, const Char *fmt, Char *args) .text:004021F0 ?vsprInt32f@?$PStringBase@D@@QAEJPBDPAD@Z

            // PStringBase<Char>.operator+:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, PStringBase<Char>*, PStringBase<Char>*> operator_plus = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, PStringBase<Char>*, PStringBase<Char>*>)0x0040BBC0; // .text:0040B860 ; PStringBase<Char> *__thiscall PStringBase<Char>::operator+(PStringBase<Char> *this, PStringBase<Char> *result, PStringBase<Char> *rhs) .text:0040B860 ??H?$PStringBase@D@@QBE?AV0@ABV0@@Z

            // PStringBase<Char>.hash:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32> hash = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32>)0x004134B0; // .text:004131A0 ; UInt32 __thiscall PStringBase<Char>::hash(PStringBase<Char> *this) .text:004131A0 ?hash@?$PStringBase@D@@QBEKXZ

            // PStringBase<Char>.to_Int32:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, Int32> to_Int32 = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, Int32>)0x00429A50; // .text:004297B0 ; Int32 __thiscall PStringBase<Char>::to_Int32(PStringBase<Char> *this) .text:004297B0 ?to_Int32@?$PStringBase@D@@QBEJXZ

            // PStringBase<Char>.sprInt32f_append:
            // (ERR) .text:00406500 ; Int32 __cdecl PStringBase<Char>::sprInt32f_append(Int32, Char *Format, Char ArgList) .text:00406500 ?sprInt32f_append@?$PStringBase@D@@QAAJPBDZZ

            // PStringBase<Char>.__Ctor:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, Char*> __Ctor___ = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, Char*>)0x00401340; // .text:00401380 ; void __thiscall PStringBase<Char>::PStringBase<Char>(PStringBase<Char> *this, const Char *str) .text:00401380 ??0?$PStringBase@D@@QAE@PBD@Z

            // PStringBase<Char>.Serialize:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, Archive*> Serialize = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, Archive*>)0x00402400; // .text:00402260 ; void __thiscall PStringBase<Char>::Serialize(PStringBase<Char> *this, Archive *io_archive) .text:00402260 ?Serialize@?$PStringBase@D@@QAEXAAVArchive@@@Z

            // PStringBase<Char>.append_n_Chars:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, Char*, UInt32> append_n_Chars = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, Char*, UInt32>)0x00404EF0; // .text:00404CF0 ; void __thiscall PStringBase<Char>::append_n_Chars(PStringBase<Char> *this, const Char *str, UInt32 count) .text:00404CF0 ?append_n_Chars@?$PStringBase@D@@QAEXPBDI@Z

            // PStringBase<Char>.substring:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, UInt32, UInt32, PStringBase<Char>*> substring = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, UInt32, UInt32, PStringBase<Char>*>)0x00404F80; // .text:00404D80 ; PStringBase<Char> *__thiscall PStringBase<Char>::substring(PStringBase<Char> *this, PStringBase<Char> *result, UInt32 first, UInt32 last) .text:00404D80 ?substring@?$PStringBase@D@@QBE?AV1@KK@Z

            // PStringBase<Char>.SetAtIndex:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32, Char> SetAtIndex = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32, Char>)0x00408770; // .text:004084C0 ; void __thiscall PStringBase<Char>::SetAtIndex(PStringBase<Char> *this, UInt32 nIndex, const Char zCharacter) .text:004084C0 ?SetAtIndex@?$PStringBase@D@@QAEXKD@Z

            // PStringBase<Char>.to_wpstring:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<UInt16>*, UInt16, PStringBase<UInt16>*> to_wpstring = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<UInt16>*, UInt16, PStringBase<UInt16>*>)0x00403350; // .text:00403170 ; PStringBase<UInt16> *__thiscall PStringBase<Char>::to_wpstring(PStringBase<Char> *this, PStringBase<UInt16> *result, const U__Int3216 i_sourceCodePage) .text:00403170 ?to_wpstring@?$PStringBase@D@@QBE?AV?$PStringBase@G@@G@Z

            // PStringBase<Char>.cmp:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, Byte, Int32> cmp = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, Byte, Int32>)0x00404B40; // .text:00404940 ; Int32 __thiscall PStringBase<Char>::cmp(PStringBase<Char> *this, PStringBase<Char> *rhs, bool case_sensitive) .text:00404940 ?cmp@?$PStringBase@D@@QBEJABV1@_N@Z

            // PStringBase<Char>.break_reference:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*> break_reference = (delegate* unmanaged[Thiscall]<PStringBase<Char>*>)0x004080C0; // .text:00407EB0 ; void __thiscall PStringBase<Char>::break_reference(PStringBase<Char> *this) .text:00407EB0 ?break_reference@?$PStringBase@D@@IAEXXZ

            // PStringBase<Char>.__Ctor:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, Char> __Ctor_ = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, Char>)0x0040B870; // .text:0040B510 ; void __thiscall PStringBase<Char>::PStringBase<Char>(PStringBase<Char> *this, Char c) .text:0040B510 ??0?$PStringBase@D@@QAE@D@Z

            // PStringBase<Char>.allocate:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32, Byte> allocate = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32, Byte>)0x00408D90; // .text:00408AE0 ; bool __thiscall PStringBase<Char>::allocate(PStringBase<Char> *this, UInt32 num_Chars) .text:00408AE0 ?allocate@?$PStringBase@D@@QAE_NI@Z

            // PStringBase<Char>.append_UInt32:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32> append_UInt32 = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32>)0x0040F110; // .text:0040EDB0 ; void __thiscall PStringBase<Char>::append_UInt32(PStringBase<Char> *this, UInt32 num) .text:0040EDB0 ?append_UInt32@?$PStringBase@D@@QAEXK@Z

            // PStringBase<Char>.tolower:
            // public static delegate* unmanaged[Thiscall]<PStringBase<Char>*> tolower = (delegate* unmanaged[Thiscall]<PStringBase<Char>*>)0xDEADBEEF; // .text:0041C8A0 ; void __thiscall PStringBase<Char>::tolower(PStringBase<Char> *this) .text:0041C8A0 ?tolower@?$PStringBase@D@@QAEXXZ

            // PStringBase<Char>.__Dtor:
            public static delegate* unmanaged[Thiscall]<CaseInsensitiveStringBase<PStringBase<Char>>*> __Dtor = (delegate* unmanaged[Thiscall]<CaseInsensitiveStringBase<PStringBase<Char>>*>)0x004011B0; // .text:004011B0 ; void __thiscall PStringBase<Char>::~PStringBase<Char>(CaseInsensitiveStringBase<PStringBase<Char> > *this) .text:004011B0 ??1?$PStringBase@D@@QAE@XZ

            // PStringBase<Char>.set:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*> set = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*>)0x00401700; // .text:004016F0 ; void __thiscall PStringBase<Char>::set(PStringBase<Char> *this, PStringBase<Char> *str) .text:004016F0 ?set@?$PStringBase@D@@QAEXABV1@@Z

            // PStringBase<Char>.eq:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, Byte, Byte> eq = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, Byte, Byte>)0x00404D20; // .text:00404B20 ; bool __thiscall PStringBase<Char>::eq(PStringBase<Char> *this, PStringBase<Char> *rhs, bool case_sensitive) .text:00404B20 ?eq@?$PStringBase@D@@QBE_NABV1@_N@Z

            // PStringBase<Char>.to_UInt32:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32> to_UInt32 = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32>)0x00404D70; // .text:00404B70 ; UInt32 __thiscall PStringBase<Char>::to_UInt32(PStringBase<Char> *this) .text:00404B70 ?to_UInt32@?$PStringBase@D@@QBEKXZ

            // PStringBase<Char>.append_string:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*> append_string = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*>)0x004064E0; // .text:004061E0 ; void __thiscall PStringBase<Char>::append_string(PStringBase<Char> *this, PStringBase<Char> *str) .text:004061E0 ?append_string@?$PStringBase@D@@QAEXABV1@@Z

            // PStringBase<Char>.operator<:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, Byte> operator_lessthan = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, Byte>)0x0042FB60; // .text:0042F940 ; bool __thiscall PStringBase<Char>::operator<(PStringBase<Char> *this, PStringBase<Char> *rhs) .text:0042F940 ??M?$PStringBase@D@@QBE_NABV0@@Z

            // PStringBase<Char>.operator!=:
            // public static delegate* unmanaged[Thiscall]<PStringBase<Char>*,PStringBase<Char>*, Byte> operator!= = (delegate* unmanaged[Thiscall]<PStringBase<Char>*,PStringBase<Char>*, Byte>)0xDEADBEEF; // .text:00426240 ; bool __thiscall PStringBase<Char>::operator!=(PStringBase<Char> *this, PStringBase<Char> *rhs) .text:00426240 ??9?$PStringBase@D@@QBE_NABV0@@Z

            // PStringBase<Char>.sprInt32f:
            // (ERR) .text:00402710 ; Int32 __cdecl PStringBase<Char>::sprInt32f(Int32, Char *Format, Char ArgList) .text:00402710 ?sprInt32f@?$PStringBase@D@@QAAJPBDZZ

            // PStringBase<Char>.PStringBase<Char>:
            // (ERR) .text:00408670 ; Int32 __cdecl PStringBase<Char>::PStringBase<Char>(Int32, Int32, Char *Format, Char ArgList) .text:00408670 ??0?$PStringBase@D@@QAA@W4_Formatted@@PBDZZ

            // PStringBase<Char>.allocate_ref_buffer:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32, Byte> allocate_ref_buffer = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32, Byte>)0x00401280; // .text:004012C0 ; bool __thiscall PStringBase<Char>::allocate_ref_buffer(PStringBase<Char> *this, UInt32 len) .text:004012C0 ?allocate_ref_buffer@?$PStringBase@D@@IAE_NI@Z

            // PStringBase<Char>.clear:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*> clear = (delegate* unmanaged[Thiscall]<PStringBase<Char>*>)0x00404CD0; // .text:00404AD0 ; void __thiscall PStringBase<Char>::clear(PStringBase<Char> *this) .text:00404AD0 ?clear@?$PStringBase@D@@QAEXXZ

            // PStringBase<Char>.find_substring:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, Int32> find_substring = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, Int32>)0x00404D40; // .text:00404B40 ; Int32 __thiscall PStringBase<Char>::find_substring(PStringBase<Char> *this, PStringBase<Char> *str) .text:00404B40 ?find_substring@?$PStringBase@D@@QBEJABV1@@Z

            // PStringBase<Char>.replace:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, PStringBase<Char>*, Int32> replace = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, PStringBase<Char>*, Int32>)0x004053A0; // .text:004050A0 ; Int32 __thiscall PStringBase<Char>::replace(PStringBase<Char> *this, PStringBase<Char> *search, PStringBase<Char> *str) .text:004050A0 ?replace@?$PStringBase@D@@QAEJABV1@0@Z

            // PStringBase<Char>.operator+=:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, PStringBase<Char>*> operator_plus_equals = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, PStringBase<Char>*, PStringBase<Char>*>)0x004087D0; // .text:00408520 ; PStringBase<Char> *__thiscall PStringBase<Char>::operator+=(PStringBase<Char> *this, PStringBase<Char> *rhs) .text:00408520 ??Y?$PStringBase@D@@QAEAAV0@ABV0@@Z

            // PStringBase<Char>.set:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, Char*> set_ = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, Char*>)0x00405000; // .text:00404E00 ; void __thiscall PStringBase<Char>::set(PStringBase<Char> *this, const Char *str) .text:00404E00 ?set@?$PStringBase@D@@QAEXPBD@Z

            // Globals:
            public static PStringBase<Char>* s_NullBuffer = (PStringBase<Char>*)0x00818344; // .data:00817344 ; PStringBase<Char> PStringBase<Char>::s_NullBuffer .data:00817344 ?s_NullBuffer@?$PStringBase@D@@0PAV?$PSRefBufferCharData@D@@A
            public static PStringBase<Char>* null_string = (PStringBase<Char>*)0x008183B4; // .data:008173B4 ; PStringBase<Char> PStringBase<Char>::null_string .data:008173B4 ?null_string@?$PStringBase@D@@2V1@B
                                                                                           // public static PStringBase<Char>* whitespace_string = (PStringBase<Char>*)0xDEADBEEF; // .data:00836748 ; PStringBase<Char> PStringBase<Char>::whitespace_string .data:00836748 ?whitespace_string@?$PStringBase@D@@2V1@B
        }





        public unsafe struct PStringBase_UInt16 {
            // Struct:
            public PSRefBufferCharData<UInt16>* m_Charbuffer;
            public override string ToString() => $"{Marshal.PtrToStringAuto((IntPtr)(m_Charbuffer->m_data))}";


            // Functions:

            // PStringBase<UInt16>.clear:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*> clear = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*>)0x0040B220; // .text:0040AEC0 ; void __thiscall PStringBase<UInt16>::clear(PStringBase<UInt16> *this) .text:0040AEC0 ?clear@?$PStringBase@G@@QAEXXZ

            // PStringBase<UInt16>.to_UInt32:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt32> to_UInt32 = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt32>)0x00478B80; // .text:00478780 ; UInt32 __thiscall PStringBase<UInt16>::to_UInt32(PStringBase<UInt16> *this) .text:00478780 ?to_UInt32@?$PStringBase@G@@QBEKXZ

            // PStringBase<UInt16>.trim:
            // public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,Byte,Byte,PStringBase<UInt16>> trim = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,Byte,Byte,PStringBase<UInt16>>)0xDEADBEEF; // .text:004D5C60 ; void __thiscall PStringBase<UInt16>::trim(PStringBase<UInt16> *this, bool pre, bool post, PStringBase<UInt16> filter) .text:004D5C60 ?trim@?$PStringBase@G@@QAEX_N0V1@@Z

            // PStringBase<UInt16>.PStringBase<UInt16>:
            // (ERR) .text:00480980 ; Int32 __cdecl PStringBase<UInt16>::PStringBase<UInt16>(Int32, Int32, wChar_t *Format, Char ArgList) .text:00480980 ??0?$PStringBase@G@@QAA@W4_Formatted@@PBGZZ

            // PStringBase<UInt16>.append_n_Chars:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*, UInt32> append_n_Chars = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*, UInt32>)0x00402490; // .text:004022F0 ; void __thiscall PStringBase<UInt16>::append_n_Chars(PStringBase<UInt16> *this, const U__Int3216 *str, UInt32 count) .text:004022F0 ?append_n_Chars@?$PStringBase@G@@QAEXPBGI@Z

            // PStringBase<UInt16>.__vecDelDtor:
            public static delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<PStringBase<Char>*, UInt32, void*>)0x00407920; // .text:00407540 ; void *__thiscall PStringBase<UInt16>::`vector deleting destructor'(PStringBase<Char> *this, UInt32) .text:00407540 ??_E?$PStringBase@G@@QAEPAXI@Z

            // PStringBase<UInt16>.break_reference:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*> break_reference = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*>)0x00408390; // .text:004080E0 ; void __thiscall PStringBase<UInt16>::break_reference(PStringBase<UInt16> *this) .text:004080E0 ?break_reference@?$PStringBase@G@@IAEXXZ

            // PStringBase<UInt16>.append_Int32:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, Int32> append_Int32 = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, Int32>)0x0047B520; // .text:0047B160 ; void __thiscall PStringBase<UInt16>::append_Int32(PStringBase<UInt16> *this, Int32 num) .text:0047B160 ?append_Int32@?$PStringBase@G@@QAEXJ@Z

            // PStringBase<UInt16>.append_UInt32:
            // public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,UInt32> append_UInt32 = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,UInt32>)0xDEADBEEF; // .text:004823E0 ; void __thiscall PStringBase<UInt16>::append_UInt32(PStringBase<UInt16> *this, UInt32 num) .text:004823E0 ?append_UInt32@?$PStringBase@G@@QAEXK@Z

            // PStringBase<UInt16>.__Ctor:
            // public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,_WidthConvert,PStringBase<Char>*> __Ctor = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,_WidthConvert,PStringBase<Char>*>)0xDEADBEEF; // .text:004A1E40 ; void __thiscall PStringBase<UInt16>::PStringBase<UInt16>(PStringBase<UInt16> *this, _WidthConvert __formal, PStringBase<Char> *str) .text:004A1E40 ??0?$PStringBase@G@@QAE@W4_WidthConvert@@ABV?$PStringBase@D@@@Z

            // PStringBase<UInt16>.operator+:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<UInt16>*, PStringBase<UInt16>*, PStringBase<UInt16>*> operator_plus = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<UInt16>*, PStringBase<UInt16>*, PStringBase<UInt16>*>)0x004086C0; // .text:00408410 ; PStringBase<UInt16> *__thiscall PStringBase<UInt16>::operator+(PStringBase<UInt16> *this, PStringBase<UInt16> *result, PStringBase<UInt16> *rhs) .text:00408410 ??H?$PStringBase@G@@QBE?AV0@ABV0@@Z

            // PStringBase<UInt16>.SetAtIndex:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt32, UInt16> SetAtIndex = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt32, UInt16>)0x004089F0; // .text:00408740 ; void __thiscall PStringBase<UInt16>::SetAtIndex(PStringBase<UInt16> *this, UInt32 nIndex, const U__Int3216 zCharacter) .text:00408740 ?SetAtIndex@?$PStringBase@G@@QAEXKG@Z

            // PStringBase<UInt16>.__Ctor:
            public static delegate* unmanaged[Thiscall]<CaseInsensitiveStringBase<PStringBase<Char>>*, PStringBase<Char>*> __Ctor = (delegate* unmanaged[Thiscall]<CaseInsensitiveStringBase<PStringBase<Char>>*, PStringBase<Char>*>)0x0041AB80; // .text:0041A840 ; void __thiscall PStringBase<UInt16>::PStringBase<UInt16>(CaseInsensitiveStringBase<PStringBase<Char> > *this, PStringBase<Char> *from) .text:0041A840 ??0?$PStringBase@G@@QAE@ABV0@@Z

            // PStringBase<UInt16>.to_Single:
            // public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, Single> to_Single = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, Single>)0xDEADBEEF; // .text:00482110 ; Single __thiscall PStringBase<UInt16>::to_Single(PStringBase<UInt16> *this) .text:00482110 ?to_Single@?$PStringBase@G@@QBEMXZ

            // PStringBase<UInt16>.append_string:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<UInt16>*> append_string = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<UInt16>*>)0x00402790; // .text:004025F0 ; void __thiscall PStringBase<UInt16>::append_string(PStringBase<UInt16> *this, PStringBase<UInt16> *str) .text:004025F0 ?append_string@?$PStringBase@G@@QAEXABV1@@Z

            // PStringBase<UInt16>.Serialize:
            // public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,Archive*> Serialize = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,Archive*>)0xDEADBEEF; // .text:004223B0 ; void __thiscall PStringBase<UInt16>::Serialize(PStringBase<UInt16> *this, Archive *io_archive) .text:004223B0 ?Serialize@?$PStringBase@G@@QAEXAAVArchive@@@Z

            // PStringBase<UInt16>.operator==:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<UInt16>*, Byte> operator_isequal = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<UInt16>*, Byte>)0x0042C8C0; // .text:0042C660 ; bool __thiscall PStringBase<UInt16>::operator==(PStringBase<UInt16> *this, PStringBase<UInt16> *rhs) .text:0042C660 ??8?$PStringBase@G@@QBE_NABV0@@Z

            // PStringBase<UInt16>.allocate:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt32, Byte> allocate = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt32, Byte>)0x00408EC0; // .text:00408C10 ; bool __thiscall PStringBase<UInt16>::allocate(PStringBase<UInt16> *this, UInt32 num_Chars) .text:00408C10 ?allocate@?$PStringBase@G@@QAE_NI@Z

            // PStringBase<UInt16>.substring:
            // public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,PStringBase<UInt16>*,UInt32,UInt32, PStringBase<UInt16>*> substring = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,PStringBase<UInt16>*,UInt32,UInt32, PStringBase<UInt16>*>)0xDEADBEEF; // .text:004F3FE0 ; PStringBase<UInt16> *__thiscall PStringBase<UInt16>::substring(PStringBase<UInt16> *this, PStringBase<UInt16> *result, UInt32 first, UInt32 last) .text:004F3FE0 ?substring@?$PStringBase@G@@QBE?AV1@KK@Z

            // PStringBase<UInt16>.sprInt32f:
            // (ERR) .text:004027B0 ; Int32 __cdecl PStringBase<UInt16>::sprInt32f(Int32, wChar_t *Format, Char ArgList) .text:004027B0 ?sprInt32f@?$PStringBase@G@@QAAJPBGZZ

            // PStringBase<UInt16>.operator=:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*, PStringBase<UInt16>*> operator_equals = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*, PStringBase<UInt16>*>)0x00402070; // .text:00401A50 ; PStringBase<UInt16> *__thiscall PStringBase<UInt16>::operator=(PStringBase<UInt16> *this, const U__Int3216 *rhs) .text:00401A50 ??4?$PStringBase@G@@QAEAAV0@ABV0@@Z

            // PStringBase<UInt16>.allocate_ref_buffer:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt32, Byte> allocate_ref_buffer = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt32, Byte>)0x004022D0; // .text:00402130 ; bool __thiscall PStringBase<UInt16>::allocate_ref_buffer(PStringBase<UInt16> *this, UInt32 len) .text:00402130 ?allocate_ref_buffer@?$PStringBase@G@@IAE_NI@Z

            // PStringBase<UInt16>.operator[]:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt32, UInt16*> operator_brackets = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt32, UInt16*>)0x004075C0; // .text:00407310 ; const U__Int3216 *__thiscall PStringBase<UInt16>::operator[](PStringBase<UInt16> *this, UInt32 index) .text:00407310 ??A?$PStringBase@G@@QBEABGK@Z

            // PStringBase<UInt16>.set:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*> set = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*>)0x00407E40; // .text:00407B90 ; void __thiscall PStringBase<UInt16>::set(PStringBase<UInt16> *this, const U__Int3216 *str) .text:00407B90 ?set@?$PStringBase@G@@QAEXPBG@Z

            // PStringBase<UInt16>.append_string:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*> append_string_ = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*>)0x0040B8F0; // .text:0040B590 ; void __thiscall PStringBase<UInt16>::append_string(PStringBase<UInt16> *this, const U__Int3216 *str) .text:0040B590 ?append_string@?$PStringBase@G@@QAEXPBG@Z

            // PStringBase<UInt16>.to_Int32:
            // public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, Int32> to_Int32 = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, Int32>)0xDEADBEEF; // .text:00489B90 ; Int32 __thiscall PStringBase<UInt16>::to_Int32(PStringBase<UInt16> *this) .text:00489B90 ?to_Int32@?$PStringBase@G@@QBEJXZ

            // PStringBase<UInt16>.__Ctor:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*> __Ctor_ = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*>)0x00401A60; // .text:00401AA0 ; void __thiscall PStringBase<UInt16>::PStringBase<UInt16>(PStringBase<UInt16> *this) .text:00401AA0 ??0?$PStringBase@G@@QAE@XZ

            // PStringBase<UInt16>.vsprInt32f:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*, Char*, Int32> vsprInt32f = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*, Char*, Int32>)0x00402520; // .text:00402380 ; Int32 __thiscall PStringBase<UInt16>::vsprInt32f(PStringBase<UInt16> *this, const U__Int3216 *fmt, Char *args) .text:00402380 ?vsprInt32f@?$PStringBase@G@@QAEJPBGPAD@Z

            // PStringBase<UInt16>.__Ctor:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*> __Ctor__ = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, UInt16*>)0x00402730; // .text:00402590 ; void __thiscall PStringBase<UInt16>::PStringBase<UInt16>(PStringBase<UInt16> *this, const U__Int3216 *str) .text:00402590 ??0?$PStringBase@G@@QAE@PBG@Z

            // PStringBase<UInt16>.to_spstring:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<Char>*, UInt16, PStringBase<Char>*> to_spstring = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<Char>*, UInt16, PStringBase<Char>*>)0x00408FD0; // .text:00408D20 ; PStringBase<Char> *__thiscall PStringBase<UInt16>::to_spstring(PStringBase<UInt16> *this, PStringBase<Char> *result, const U__Int3216 i_targetCodePage) .text:00408D20 ?to_spstring@?$PStringBase@G@@QBE?AV?$PStringBase@D@@G@Z

            // PStringBase<UInt16>.sprInt32f_append:
            // (ERR) .text:004300A0 ; Int32 __cdecl PStringBase<UInt16>::sprInt32f_append(Int32, wChar_t *Format, Char ArgList) .text:004300A0 ?sprInt32f_append@?$PStringBase@G@@QAAJPBGZZ

            // PStringBase<UInt16>.__Ctor:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, _WidthConvert, Char*> __Ctor___ = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, _WidthConvert, Char*>)0x00404A40; // .text:00404840 ; void __thiscall PStringBase<UInt16>::PStringBase<UInt16>(PStringBase<UInt16> *this, _WidthConvert __formal, const Char *str) .text:00404840 ??0?$PStringBase@G@@QAE@W4_WidthConvert@@PBD@Z

            // PStringBase<UInt16>.operator+=:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<UInt16>*, PStringBase<UInt16>*> operator_plus_equals = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<UInt16>*, PStringBase<UInt16>*>)0x00408800; // .text:00408550 ; PStringBase<UInt16> *__thiscall PStringBase<UInt16>::operator+=(PStringBase<UInt16> *this, PStringBase<UInt16> *rhs) .text:00408550 ??Y?$PStringBase@G@@QAEAAV0@ABV0@@Z

            // PStringBase<UInt16>.replace:
            public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<UInt16>*, PStringBase<UInt16>*, Int32> replace = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*, PStringBase<UInt16>*, PStringBase<UInt16>*, Int32>)0x0040D870; // .text:0040D510 ; Int32 __thiscall PStringBase<UInt16>::replace(PStringBase<UInt16> *this, PStringBase<UInt16> *search, PStringBase<UInt16> *str) .text:0040D510 ?replace@?$PStringBase@G@@QAEJABV1@0@Z

            // PStringBase<UInt16>.operator!=:
            // public static delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,PStringBase<UInt16>*, Byte> operator!= = (delegate* unmanaged[Thiscall]<PStringBase<UInt16>*,PStringBase<UInt16>*, Byte>)0xDEADBEEF; // .text:00494B30 ; bool __thiscall PStringBase<UInt16>::operator!=(PStringBase<UInt16> *this, PStringBase<UInt16> *rhs) .text:00494B30 ??9?$PStringBase@G@@QBE_NABV0@@Z

            // Globals:
            public static PStringBase<UInt16>* null_string = (PStringBase<UInt16>*)0x0083774C; // .data:0083674C ; PStringBase<UInt16> PStringBase<UInt16>::null_string .data:0083674C ?null_string@?$PStringBase@G@@2V1@B
            public static PStringBase<UInt16>* whitespace_string = (PStringBase<UInt16>*)0x00837750; // .data:00836750 ; PStringBase<UInt16> PStringBase<UInt16>::whitespace_string .data:00836750 ?whitespace_string@?$PStringBase@G@@2V1@B
            public static PSRefBufferCharData<UInt16>** s_NullBuffer = (PSRefBufferCharData<UInt16>**)0x00818340; // .data:00817340 ; PSRefBufferCharData<UInt16> *PStringBase<UInt16>::s_NullBuffer .data:00817340 ?s_NullBuffer@?$PStringBase@G@@0PAV?$PSRefBufferCharData@G@@A
        }





        public unsafe struct PSRefBufferCharData<T> where T : unmanaged {
            // Struct:
            public fixed Int32 m_data[256];
        }
        public unsafe struct CaseInsensitiveStringBase<T> {
            // Struct:
            public T str;
            public override string ToString() => str.ToString();

            // Functions:

            // CaseInsensitiveStringBase.case_insensitive_hash:
            public UInt32 case_insensitive_hash<UInt16>() => ((delegate* unmanaged[Thiscall]<ref CaseInsensitiveStringBase<T>, UInt32>)0x00407680)(ref this); // .text:004073D0 ; unsigned int __thiscall CaseInsensitiveStringBase<PStringBase<unsigned short>>::case_insensitive_hash(CaseInsensitiveStringBase<PStringBase<unsigned short> > *this) .text:004073D0 ?case_insensitive_hash@?$CaseInsensitiveStringBase@V?$PStringBase@G@@@@QBEKXZ

            // CaseInsensitiveStringBase.case_insensitive_hash:
            public UInt32 case_insensitive_hash() => ((delegate* unmanaged[Thiscall]<ref CaseInsensitiveStringBase<T>, UInt32>)0x0041AA50)(ref this); // .text:0041A710 ; unsigned int __thiscall CaseInsensitiveStringBase<PStringBase<char>>::case_insensitive_hash(CaseInsensitiveStringBase<PStringBase<char> > *this) .text:0041A710 ?case_insensitive_hash@?$CaseInsensitiveStringBase@V?$PStringBase@D@@@@QBEKXZ
        }

    }
}