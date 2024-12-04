using System;

namespace AcClient {
    // This is the home for all of the "fundamental" pieces.
    public unsafe struct EnumPropertyValue {
        public BasePropertyValue basePropertyValue;
        public uint m_value;

        public  byte GetValueAsString(BasePropertyDesc* desc, PStringBase<byte>* name, byte format) {
            return ((delegate* unmanaged[Thiscall]<ref EnumPropertyValue, BasePropertyDesc*, PStringBase<byte>*, byte, byte>)0x0042B860)(ref this, desc, name, format);
        }
    }
    public unsafe struct BoolPropertyValue {
        public BasePropertyValue basePropertyValue;
        public bool m_value;

        public byte InqBool(byte* val) {
            return ((delegate* unmanaged[Thiscall]<ref BoolPropertyValue, byte*, byte>)0x00423AF0)(ref this, val);
        }
    }
    public unsafe struct LongIntegerPropertyValue {
        public BasePropertyValue basePropertyValue;
        public long m_value;
    }
    public unsafe struct IntegerPropertyValue {
        public BasePropertyValue basePropertyValue;
        public int m_value;
    }
    public unsafe struct DataFilePropertyValue {
        public BasePropertyValue basePropertyValue;
        public uint m_value;
    }
    public unsafe struct ArrayPropertyValue {
        public BasePropertyValue basePropertyValue;
        public SmartArray<BaseProperty> m_value;
    }
    public unsafe struct StringInfoPropertyValue {
        public BasePropertyValue basePropertyValue;
        public StringInfo m_value;
    }

    public unsafe struct _Vtbl {
        public static delegate* unmanaged[Thiscall]<Int32*, UInt32, void*> __vecDelDtor; //   void *(__thiscall *__vecDelDtor)(PackObj *this, UInt32);
    };

    public unsafe struct Plane {
        public Vector3 N;
        public Single d;
        public override string ToString() => $"{N} d:{d:n5}";
    };

    public unsafe struct Box2D {
        public Int32 m_x0;
        public Int32 m_y0;
        public Int32 m_x1;
        public Int32 m_y1;
        public override string ToString() => $"[{m_x0},{m_y0},{m_x1},{m_y1}]";
    };

    public unsafe struct CSphere {
        public Vector3 center;
        public Single radius;
        public override string ToString() => $"{center} radius:{radius:n5}";
    };

    public unsafe struct BBox {
        public Vector3 m_vMin;
        public Vector3 m_vMax;
        public override string ToString() => $"m_vMin:({m_vMin}),m_vMax:({m_vMax})";
    };
    //todo
    public unsafe struct CVertexArray {
        public void* vertex_memory;
        public BBox bbox;
        public VertexType vertex_type;
        public UInt32 num_vertices;
        public CVertex* vertices;
        public override string ToString() => $"bbox:(BBox){bbox}, vertex_type:(VertexType){vertex_type}, num_vertices:{num_vertices} vertices->(CVertex*)0x{(Int32)vertices}";
    };

    public unsafe struct Vec2D {
        public Single x;
        public Single y;
        public override string ToString() => $"x:{x:n5},y:{y:n5}";
    };
    public unsafe struct QualifiedDataID {
        public UInt32 Type;
        public UInt32 ID;  // IDClass<_tagDataID,32,0>
        public override string ToString() => $"Type:{Type:X8},ID:{ID:X8}";
    };

    public unsafe struct _iobuf {
        public Char* _ptr;
        public Int32 _cnt;
        public Char* _base;
        public Int32 _flag;
        public Int32 _file;
        public Int32 _Charbuf;
        public Int32 _bufsiz;
        public Char* _tmpfname;
    };
    public unsafe struct tagRECT {
        public UInt32 left;
        public UInt32 top;
        public UInt32 right;
        public UInt32 bottom;
        public override string ToString() => $"left:{left},top:{top},right:{right},bottom:{bottom}";
    };
    public unsafe struct tagPOINT {
        public Int32 x;
        public Int32 y;
        public override string ToString() => $"x:{x},y:{y}";
    };
    public unsafe struct CCylSphere {
        public Vector3 low_pt;
        public Single height;
        public Single radius;
        public override string ToString() => $"{low_pt} height:{height:n5} radius:{radius:n5}";
    };
    public unsafe struct RGBColor {
        public Single r;
        public Single g;
        public Single b;
        public override string ToString() => $"r:{r:n5},g:{g:n5},b:{b:n5}";
    };
    //todo
    public unsafe struct CTriangleStrip {
        public UInt32 num_indices;
        public UInt16* indices;
        public override string ToString() => $"num_indices:{num_indices}, indices->(UInt16*)0x{(Int32)indices}";
    };
    public unsafe struct CVec2Duv {
        public Single u;
        public Single v;
        public override string ToString() => $"u:{u:n5},v:{v:n5}";
    };
    public unsafe struct CPolygon {
        public CVertex** vertices;
        public UInt16* vertex_ids;
        public Vec2Dscreen** screen;
        public Int16 poly_id;
        public byte num_pts;
        public byte stippling;
        public Int32 sides_type;
        public byte* pos_uv_indices;
        public byte* neg_uv_indices;
        public UInt16 pos_surface;
        public UInt16 neg_surface;
        public Plane plane;
        public override string ToString() => $"vertices:->(CVertex**)0x{(Int32)vertices:X8}, vertex_ids:->(UInt16*)0x{(Int32)vertex_ids:X8}, screen:->(Vec2Dscreen**)0x{(Int32)screen:X8}, poly_id:{poly_id}, num_pts:{num_pts}, stippling:{stippling}, sides_type:{sides_type}, pos_uv_indices:->(Char*)0x{(Int32)pos_uv_indices:X8}, neg_uv_indices:->(Char*)0x{(Int32)neg_uv_indices:X8}, pos_surface:{pos_surface:X4}, neg_surface:{neg_surface:X4}, plane(Plane):{plane}";

    };
    public unsafe struct Vec2Dscreen {
        public AC1Legacy.Vector3 vertex_w;
        public Single w;
        public override string ToString() => $"vertex_w:{vertex_w}, w:{w:n5}";

    };
    public unsafe struct CVertex {
        public Single x;
        public Single y;
        public Single z;
        public UInt32 reserve4;
        public UInt32 reserve5;
        public UInt32 reserve6;
        public UInt32 reserve7;
        public UInt32 reserve8;
        public override string ToString() => $"x:{x:n5},y:{y:n5},z:{z:n5}, reserve4:{reserve4:X8}, reserve5:{reserve5:X8}, reserve6:{reserve6:X8}, reserve7:{reserve7:X8}, reserve8:{reserve8:X8}";
    };
    public unsafe struct _D3DCOLORVALUE {
        public Single r;
        public Single g;
        public Single b;
        public Single a;
        public override string ToString() => $"r:{r:n5}, g:{g:n5}, b:{b:n5}, a:{a:n5}";

    };
    public unsafe struct _D3DMATERIAL9 {
        public _D3DCOLORVALUE Diffuse;
        public _D3DCOLORVALUE Ambient;
        public _D3DCOLORVALUE Specular;
        public _D3DCOLORVALUE Emissive;
        public Single Power;
        public override string ToString() => $"Diffuse(_D3DCOLORVALUE):{Diffuse}, Ambient(_D3DCOLORVALUE):{Ambient}, Specular(_D3DCOLORVALUE):{Specular}, Emissive(_D3DCOLORVALUE):{Emissive}, Power:{Power:n5}";

    };

    public unsafe struct RGBAColor {
        public Single r;
        public Single g;
        public Single b;
        public Single a;
    };

    public unsafe struct _GUID {
        public UInt32 Data1;
        public UInt16 Data2;
        public UInt16 Data3;
        public fixed Byte Data4[8];
        public override string ToString() => $"{Data1:x8}-{Data2:x4}-{Data3:x4}-{Data4[0]:x2}{Data4[1]:x2}-{Data4[2]:x2}{Data4[3]:x2}{Data4[4]:x2}{Data4[5]:x2}{Data4[6]:x2}{Data4[7]:x2}";
    };

    public unsafe struct Turbine_GUID {
        public UInt32 m_data1;
        public UInt16 m_data2;
        public UInt16 m_data3;
        public fixed Char m_data4[8];
        public override string ToString() => $"{m_data1:x8}-{m_data2:x4}-{m_data3:x4}-{m_data4[0]:x2}{m_data4[1]:x2}-{m_data4[2]:x2}{m_data4[3]:x2}{m_data4[4]:x2}{m_data4[5]:x2}{m_data4[6]:x2}{m_data4[7]:x2}";
    };

    public unsafe struct TResult {
        public UInt32 m_val;
        public override string ToString() => $"m_val:{m_val:X8}";
    };
    public unsafe struct Position {
        public PackObj packObj;
        public UInt32 objcell_id;
        public Frame frame;
        public override string ToString() => $"0x{objcell_id:X8} {frame}";
    };
    public unsafe struct Frame {
        public Single qw;
        public Single qx;
        public Single qy;
        public Single qz;
        public fixed Single m_fl2gv[9];
        public Vector3 m_fOrigin;
        public override string ToString() => $"{m_fOrigin} [{qw:n5} {qx:n5} {qy:n5} {qz:n5}]";
        // Enums:
        public enum FrameInitializationEnum : UInt32 {
            FRAME_NO_INITIALIZATION = 0x0,
        };

        // Functions:

        // Frame.set_rotate:
        public void set_rotate(Single new_qw, Single new_qx, Single new_qy, Single new_qz) => ((delegate* unmanaged[Thiscall]<ref Frame, Single, Single, Single, Single, void>)0x00535DC0)(ref this, new_qw, new_qx, new_qy, new_qz); // .text:00535080 ; void __thiscall Frame::set_rotate(Frame *this, float new_qw, float new_qx, float new_qy, float new_qz) .text:00535080 ?set_rotate@Frame@@QAEXMMMM@Z

        // Frame.is_equal:
        public int is_equal(Frame* rhs) => ((delegate* unmanaged[Thiscall]<ref Frame, Frame*, int>)0x00424E90)(ref this, rhs); // .text:00424C30 ; int __thiscall Frame::is_equal(Frame *this, Frame *rhs) .text:00424C30 ?is_equal@Frame@@QBEHABV1@@Z

        // Frame.globaltolocal:
        public AC1Legacy.Vector3* globaltolocal(AC1Legacy.Vector3* result, AC1Legacy.Vector3* _in) => ((delegate* unmanaged[Thiscall]<ref Frame, AC1Legacy.Vector3*, AC1Legacy.Vector3*, AC1Legacy.Vector3*>)0x004526C0)(ref this, result, _in); // .text:00452680 ; Vector3 *__thiscall Frame::globaltolocal(Frame *this, Vector3 *result, Vector3 *in) .text:00452680 ?globaltolocal@Frame@@QBE?AVVector3@AC1Legacy@@ABV23@@Z

        // Frame.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Frame, void**, UInt32, UInt32>)0x00535E70)(ref this, addr, size); // .text:00535130 ; unsigned int __thiscall Frame::Pack(Frame *this, void **addr, unsigned int size) .text:00535130 ?Pack@Frame@@QAEIAAPAXI@Z

        // Frame.rotate:
        public void rotate(AC1Legacy.Vector3* w) => ((delegate* unmanaged[Thiscall]<ref Frame, AC1Legacy.Vector3*, void>)0x004525F0)(ref this, w); // .text:004525B0 ; void __thiscall Frame::rotate(Frame *this, Vector3 *w) .text:004525B0 ?rotate@Frame@@QAEXABVVector3@AC1Legacy@@@Z

        // Frame.combine:
        public void combine(Frame* _f1, AFrame* _f2, AC1Legacy.Vector3* scale) => ((delegate* unmanaged[Thiscall]<ref Frame, Frame*, AFrame*, AC1Legacy.Vector3*, void>)0x00519B00)(ref this, _f1, _f2, scale); // .text:00518FD0 ; void __thiscall Frame::combine(Frame *this, Frame *_f1, AFrame *_f2, Vector3 *scale) .text:00518FD0 ?combine@Frame@@QAEXABV1@ABVAFrame@@ABVVector3@AC1Legacy@@@Z

        // Frame.grotate:
        public void grotate(AC1Legacy.Vector3* w) => ((delegate* unmanaged[Thiscall]<ref Frame, AC1Legacy.Vector3*, void>)0x005364E0)(ref this, w); // .text:005357A0 ; void __thiscall Frame::grotate(Frame *this, Vector3 *w) .text:005357A0 ?grotate@Frame@@QAEXABVVector3@AC1Legacy@@@Z

        // Frame.euler_set_rotate:
        public void euler_set_rotate(Single x, Single y, Single z, int _order) => ((delegate* unmanaged[Thiscall]<ref Frame, Single, Single, Single, int, void>)0x00536930)(ref this, x, y, z, _order); // .text:00535BF0 ; void __thiscall Frame::euler_set_rotate(Frame *this, float x, float y, float z, int _order) .text:00535BF0 ?euler_set_rotate@Frame@@QAEXMMMH@Z

        // Frame.set_heading:
        public void set_heading(Single degrees) => ((delegate* unmanaged[Thiscall]<ref Frame, Single, void>)0x00536B80)(ref this, degrees); // .text:00535E40 ; void __thiscall Frame::set_heading(Frame *this, float degrees) .text:00535E40 ?set_heading@Frame@@QAEXM@Z

        // Frame.globaltolocalvec:
        // public AC1Legacy.Vector3* globaltolocalvec(AC1Legacy.Vector3* result, AC1Legacy.Vector3* in) => ((delegate* unmanaged[Thiscall]<ref Frame, AC1Legacy.Vector3*, AC1Legacy.Vector3*, AC1Legacy.Vector3*>)0xDEADBEEF)(ref this, result, in); // .text:00452550 ; Vector3 *__thiscall Frame::globaltolocalvec(Frame *this, Vector3 *result, Vector3 *in) .text:00452550 ?globaltolocalvec@Frame@@QBE?AVVector3@AC1Legacy@@ABV23@@Z

        // Frame.combine:
        public void combine(Frame* _f1, AFrame* _f2) => ((delegate* unmanaged[Thiscall]<ref Frame, Frame*, AFrame*, void>)0x00525D80)(ref this, _f1, _f2); // .text:00525180 ; void __thiscall Frame::combine(Frame *this, Frame *_f1, AFrame *_f2) .text:00525180 ?combine@Frame@@QAEXABV1@ABVAFrame@@@Z

        // Frame.IsValid:
        public int IsValid() => ((delegate* unmanaged[Thiscall]<ref Frame, int>)0x00535C10)(ref this); // .text:00534ED0 ; int __thiscall Frame::IsValid(Frame *this) .text:00534ED0 ?IsValid@Frame@@QBEHXZ

        // Frame.get_vector_heading:
        public AC1Legacy.Vector3* get_vector_heading(AC1Legacy.Vector3* result) => ((delegate* unmanaged[Thiscall]<ref Frame, AC1Legacy.Vector3*, AC1Legacy.Vector3*>)0x00536460)(ref this, result); // .text:00535720 ; Vector3 *__thiscall Frame::get_vector_heading(Frame *this, Vector3 *result) .text:00535720 ?get_vector_heading@Frame@@QBE?AVVector3@AC1Legacy@@XZ

        // Frame.is_quaternion_equal:
        public int is_quaternion_equal(Frame* rhs) => ((delegate* unmanaged[Thiscall]<ref Frame, Frame*, int>)0x00424ED0)(ref this, rhs); // .text:00424C70 ; int __thiscall Frame::is_quaternion_equal(Frame *this, Frame *rhs) .text:00424C70 ?is_quaternion_equal@Frame@@QBEHABV1@@Z

        // Frame.close_rotation:
        public int close_rotation(Frame* f1, Frame* f2, Single epsilon) => ((delegate* unmanaged[Cdecl]<Frame*, Frame*, Single, int>)0x00455E90)(f1, f2, epsilon); // .text:00455D70 ; int __cdecl Frame::close_rotation(Frame *f1, Frame *f2, const float epsilon) .text:00455D70 ?close_rotation@Frame@@SAHABV1@0M@Z

        // Frame.interpolate_origin:
        public void interpolate_origin(Frame* from, Frame* to, Single t) => ((delegate* unmanaged[Thiscall]<ref Frame, Frame*, Frame*, Single, void>)0x00536030)(ref this, from, to, t); // .text:005352F0 ; void __thiscall Frame::interpolate_origin(Frame *this, Frame *from, Frame *to, float t) .text:005352F0 ?interpolate_origin@Frame@@QAEXABV1@0M@Z

        // Frame.subtract2:
        public void subtract2(Frame* _f1, Frame* _f2) => ((delegate* unmanaged[Thiscall]<ref Frame, Frame*, Frame*, void>)0x00536390)(ref this, _f1, _f2); // .text:00535650 ; void __thiscall Frame::subtract2(Frame *this, Frame *_f1, Frame *_f2) .text:00535650 ?subtract2@Frame@@QAEXABV1@0@Z

        // Frame.localtoglobal:
        public AC1Legacy.Vector3* localtoglobal(AC1Legacy.Vector3* result, AC1Legacy.Vector3* _in) => ((delegate* unmanaged[Thiscall]<ref Frame, AC1Legacy.Vector3*, AC1Legacy.Vector3*, AC1Legacy.Vector3*>)0x00452660)(ref this, result, _in); // .text:00452620 ; Vector3 *__thiscall Frame::localtoglobal(Frame *this, Vector3 *result, Vector3 *in) .text:00452620 ?localtoglobal@Frame@@QBE?AVVector3@AC1Legacy@@ABV23@@Z

        // Frame.combine:
        public void combine(Frame* _f1, Frame* _f2) => ((delegate* unmanaged[Thiscall]<ref Frame, Frame*, Frame*, void>)0x00512DE0)(ref this, _f1, _f2); // .text:005122E0 ; void __thiscall Frame::combine(Frame *this, Frame *_f1, Frame *_f2) .text:005122E0 ?combine@Frame@@QAEXABV1@0@Z

        // Frame.interpolate_rotation:
        public void interpolate_rotation(Frame* from, Frame* to, Single t) => ((delegate* unmanaged[Thiscall]<ref Frame, Frame*, Frame*, Single, void>)0x005360D0)(ref this, from, to, t); // .text:00535390 ; void __thiscall Frame::interpolate_rotation(Frame *this, Frame *from, Frame *to, float t) .text:00535390 ?interpolate_rotation@Frame@@QAEXABV1@0M@Z

        // Frame.set_vector_heading:
        public void set_vector_heading(AC1Legacy.Vector3* heading) => ((delegate* unmanaged[Thiscall]<ref Frame, AC1Legacy.Vector3*, void>)0x00536AF0)(ref this, heading); // .text:00535DB0 ; void __thiscall Frame::set_vector_heading(Frame *this, Vector3 *heading) .text:00535DB0 ?set_vector_heading@Frame@@QAEXABVVector3@AC1Legacy@@@Z

        // Frame.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Frame, void**, UInt32, int>)0x00535EE0)(ref this, addr, size); // .text:005351A0 ; int __thiscall Frame::UnPack(Frame *this, void **addr, unsigned int size) .text:005351A0 ?UnPack@Frame@@QAEHAAPAXI@Z

        // Frame.Serialize:
        public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref Frame, Archive*, void>)0x00535F70)(ref this, io_archive); // .text:00535230 ; void __thiscall Frame::Serialize(Frame *this, Archive *io_archive) .text:00535230 ?Serialize@Frame@@QAEXAAVArchive@@@Z

        // Frame.subtract1:
        public void subtract1(Frame* _f1, AFrame* _f2) => ((delegate* unmanaged[Thiscall]<ref Frame, Frame*, AFrame*, void>)0x00536260)(ref this, _f1, _f2); // .text:00535520 ; void __thiscall Frame::subtract1(Frame *this, Frame *_f1, AFrame *_f2) .text:00535520 ?subtract1@Frame@@QAEXABV1@ABVAFrame@@@Z

        // Frame.cache_quaternion:
        public void cache_quaternion() => ((delegate* unmanaged[Thiscall]<ref Frame, void>)0x00536610)(ref this); // .text:005358D0 ; void __thiscall Frame::cache_quaternion(Frame *this) .text:005358D0 ?cache_quaternion@Frame@@QAEXXZ

        // Frame.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Frame, void>)0x00424CE0)(ref this); // .text:00424A80 ; void __thiscall Frame::Frame(Frame *this) .text:00424A80 ??0Frame@@QAE@XZ

        // Frame.operator_equals:
        public Frame* operator_equals(Frame* a1) => ((delegate* unmanaged[Thiscall]<ref Frame, Frame*, Frame*>)0x00425F10)(ref this, a1); // .text:00425C30 ; public: class Frame & __thiscall Frame::operator=(class Frame const &) .text:00425C30 ??4Frame@@QAEAAV0@ABV0@@Z

        // Frame.cache:
        public void cache() => ((delegate* unmanaged[Thiscall]<ref Frame, void>)0x00535B30)(ref this); // .text:00534DF0 ; void __thiscall Frame::cache(Frame *this) .text:00534DF0 ?cache@Frame@@QAEXXZ

        // Frame.IsValidExceptForHeading:
        public int IsValidExceptForHeading() => ((delegate* unmanaged[Thiscall]<ref Frame, int>)0x00535D20)(ref this); // .text:00534FE0 ; int __thiscall Frame::IsValidExceptForHeading(Frame *this) .text:00534FE0 ?IsValidExceptForHeading@Frame@@QBEHXZ

        // Frame.localtoglobalvec:
        public AC1Legacy.Vector3* localtoglobalvec(AC1Legacy.Vector3* result, AC1Legacy.Vector3* _in) => ((delegate* unmanaged[Thiscall]<ref Frame, AC1Legacy.Vector3*, AC1Legacy.Vector3*, AC1Legacy.Vector3*>)0x00452530)(ref this, result, _in); // .text:004524F0 ; Vector3 *__thiscall Frame::localtoglobalvec(Frame *this, Vector3 *result, Vector3 *in) .text:004524F0 ?localtoglobalvec@Frame@@QBE?AVVector3@AC1Legacy@@ABV23@@Z

        // Frame.get_heading:
        public Single get_heading() => ((delegate* unmanaged[Thiscall]<ref Frame, Single>)0x005364A0)(ref this); // .text:00535760 ; float __thiscall Frame::get_heading(Frame *this) .text:00535760 ?get_heading@Frame@@QBEMXZ

        // Frame.rotate_around_axis_to_vector:
        public void rotate_around_axis_to_vector(int axis_num, AC1Legacy.Vector3* dir) => ((delegate* unmanaged[Thiscall]<ref Frame, int, AC1Legacy.Vector3*, void>)0x00536780)(ref this, axis_num, dir); // .text:00535A40 ; void __thiscall Frame::rotate_around_axis_to_vector(Frame *this, int axis_num, Vector3 *dir) .text:00535A40 ?rotate_around_axis_to_vector@Frame@@QAEXHABVVector3@AC1Legacy@@@Z

    };

    public unsafe struct Vector3 {
        // Struct:
        public Single x;
        public Single y;
        public Single z;
        public override string ToString() => $"x:{x:n5}, y:{y:n5}, z:{z:n5}";

        // Functions:

        // Vector3.operator_plus:
        public Vector3* operator_plus(Vector3* result, Vector3* _rhs) => ((delegate* unmanaged[Thiscall]<ref Vector3, Vector3*, Vector3*, Vector3*>)0x0043D8B0)(ref this, result, _rhs); // .text:0043D710 ; Vector3 *__thiscall Vector3::operator+(Vector3 *this, Vector3 *result, Vector3 *_rhs) .text:0043D710 ??HVector3@@QBE?AV0@ABV0@@Z

        // Vector3.operator_minus:
        public Vector3* operator_minus(Vector3* result, Vector3* _rhs) => ((delegate* unmanaged[Thiscall]<ref Vector3, Vector3*, Vector3*, Vector3*>)0x0043D8E0)(ref this, result, _rhs); // .text:0043D740 ; Vector3 *__thiscall Vector3::operator-(Vector3 *this, Vector3 *result, Vector3 *_rhs) .text:0043D740 ??GVector3@@QBE?AV0@ABV0@@Z

        // Vector3.operator_equals_divide:
        public void operator_equals_divide(Single _rhs) => ((delegate* unmanaged[Thiscall]<ref Vector3, Single, void>)0x00451AE0)(ref this, _rhs); // .text:00451AA0 ; void __thiscall Vector3::operator=/(Vector3 *this, const float _rhs) .text:00451AA0 ??_0Vector3@@QAEXM@Z

        // Vector3.ToFileNode:
        // public Byte ToFileNode(PFileNode* _pNode) => ((delegate* unmanaged[Thiscall]<ref Vector3, PFileNode*, Byte>)0xDEADBEEF)(ref this, _pNode); // .text:0065B6E0 ; bool __thiscall Vector3::ToFileNode(Vector3 *this, PFileNode *_pNode) .text:0065B6E0 ?ToFileNode@Vector3@@QBE_NPAVPFileNode@@@Z

        // Vector3.operator*:
        // (ERR) .text:0043D910 ; int __stdcall Vector3::operator*(int, float) .text:0043D910 ??DVector3@@QBE?AV0@M@Z

        // Vector3.Normalize:
        public void Normalize() => ((delegate* unmanaged[Thiscall]<ref Vector3, void>)0x0043E880)(ref this); // .text:0043E6E0 ; void __thiscall Vector3::Normalize(Vector3 *this) .text:0043E6E0 ?Normalize@Vector3@@QAEXXZ

        // Vector3.operator_divide:
        public Vector3* operator_divide(Vector3* result, Single _rhs) => ((delegate* unmanaged[Thiscall]<ref Vector3, Vector3*, Single, Vector3*>)0x00455F00)(ref this, result, _rhs); // .text:00455DE0 ; Vector3 *__thiscall Vector3::operator/(Vector3 *this, Vector3 *result, const float _rhs) .text:00455DE0 ??KVector3@@QBE?AV0@M@Z

        // Vector3.operator_not_equal:
        public Byte operator_not_equal(Vector3* _rhs) => ((delegate* unmanaged[Thiscall]<ref Vector3, Vector3*, Byte>)0x0045FAD0)(ref this, _rhs); // .text:0045F9F0 ; bool __thiscall Vector3::operator!=(Vector3 *this, Vector3 *_rhs) .text:0045F9F0 ??9Vector3@@QBE_NABV0@@Z

        // Vector3.FromFileNode:
        // public Byte FromFileNode(PFileNode* _pNode) => ((delegate* unmanaged[Thiscall]<ref Vector3, PFileNode*, Byte>)0xDEADBEEF)(ref this, _pNode); // .text:0065B750 ; bool __thiscall Vector3::FromFileNode(Vector3 *this, PFileNode *_pNode) .text:0065B750 ?FromFileNode@Vector3@@QAE_NPBVPFileNode@@@Z

        // Vector3.operator*=:
        // (ERR) .text:0043D890 ; int __stdcall Vector3::operator*=(float) .text:0043D890 ??XVector3@@QAEXM@Z
    }


    public unsafe struct Matrix4 {
        // Struct:
        public Single _11;
        public Single _12;
        public Single _13;
        public Single _14;
        public Single _21;
        public Single _22;
        public Single _23;
        public Single _24;
        public Single _31;
        public Single _32;
        public Single _33;
        public Single _34;
        public Single _41;
        public Single _42;
        public Single _43;
        public Single _44;
        public override string ToString() => $"_11:{_11:n5}, _12:{_12:n5}, _13:{_13:n5}, _14:{_14:n5}, _21:{_21:n5}, _22:{_22:n5}, _23:{_23:n5}, _24:{_24:n5}, _31:{_31:n5}, _32:{_32:n5}, _33:{_33:n5}, _34:{_34:n5}, _41:{_41:n5}, _42:{_42:n5}, _43:{_43:n5}, _44:{_44:n5}";

        // Functions:

        // Matrix4.Adjoint:
        // public void Adjoint(Matrix4* src) => ((delegate* unmanaged[Thiscall]<ref Matrix4, Matrix4*, void>)0xDEADBEEF)(ref this, src); // .text:0065D210 ; void __thiscall Matrix4::Adjoint(Matrix4 *this, Matrix4 *src) .text:0065D210 ?Adjoint@Matrix4@@QAEXABV1@@Z

        // Matrix4.AreEqual:
        // public static Byte AreEqual(Matrix4* _mA, Matrix4* _mB) => ((delegate* unmanaged[Cdecl]<Matrix4*, Matrix4*, Byte>)0xDEADBEEF)(_mA, _mB); // .text:0065D5A0 ; bool __cdecl Matrix4::AreEqual(Matrix4 *_mA, Matrix4 *_mB) .text:0065D5A0 ?AreEqual@Matrix4@@SA_NABV1@0@Z

        // Matrix4.CalcDeterminant:
        // public Single CalcDeterminant() => ((delegate* unmanaged[Thiscall]<ref Matrix4, Single>)0xDEADBEEF)(ref this); // .text:0065CE70 ; float __thiscall Matrix4::CalcDeterminant(Matrix4 *this) .text:0065CE70 ?CalcDeterminant@Matrix4@@QBEMXZ

        // Matrix4.Inverse:
        // public Single Inverse(Matrix4* src) => ((delegate* unmanaged[Thiscall]<ref Matrix4, Matrix4*, Single>)0xDEADBEEF)(ref this, src); // .text:0065D760 ; float __thiscall Matrix4::Inverse(Matrix4 *this, Matrix4 *src) .text:0065D760 ?Inverse@Matrix4@@QAEMABV1@@Z

        // Matrix4.Multiply_C:
        public void Multiply_C(Matrix4* a, Matrix4* b) => ((delegate* unmanaged[Thiscall]<ref Matrix4, Matrix4*, Matrix4*, void>)0x0043D9C0)(ref this, a, b); // .text:0043D820 ; void __thiscall Matrix4::Multiply_C(Matrix4 *this, Matrix4 *a, Matrix4 *b) .text:0043D820 ?Multiply_C@Matrix4@@QAEXABV1@0@Z

        // Matrix4.RotateX:
        // public void RotateX(Single radians) => ((delegate* unmanaged[Thiscall]<ref Matrix4, Single, void>)0xDEADBEEF)(ref this, radians); // .text:0065D0D0 ; void __thiscall Matrix4::RotateX(Matrix4 *this, float radians) .text:0065D0D0 ?RotateX@Matrix4@@QAEXM@Z

        // Matrix4.RotateY:
        // public void RotateY(Single radians) => ((delegate* unmanaged[Thiscall]<ref Matrix4, Single, void>)0xDEADBEEF)(ref this, radians); // .text:0065D120 ; void __thiscall Matrix4::RotateY(Matrix4 *this, float radians) .text:0065D120 ?RotateY@Matrix4@@QAEXM@Z

        // Matrix4.RotateZ:
        // public void RotateZ(Single radians) => ((delegate* unmanaged[Thiscall]<ref Matrix4, Single, void>)0xDEADBEEF)(ref this, radians); // .text:0065D170 ; void __thiscall Matrix4::RotateZ(Matrix4 *this, float radians) .text:0065D170 ?RotateZ@Matrix4@@QAEXM@Z

        // Matrix4.Scale:
        // public void Scale(Single x, Single y, Single z) => ((delegate* unmanaged[Thiscall]<ref Matrix4, Single, Single, Single, void>)0xDEADBEEF)(ref this, x, y, z); // .text:0065D1C0 ; void __thiscall Matrix4::Scale(Matrix4 *this, float x, float y, float z) .text:0065D1C0 ?Scale@Matrix4@@QAEXMMM@Z

        // Matrix4.TransformVector_C:
        public void TransformVector_C(Vector3* src, Vector3* dst) => ((delegate* unmanaged[Thiscall]<ref Matrix4, Vector3*, Vector3*, void>)0x0043D940)(ref this, src, dst); // .text:0043D7A0 ; void __thiscall Matrix4::TransformVector_C(Matrix4 *this, Vector3 *src, Vector3 *dst) .text:0043D7A0 ?TransformVector_C@Matrix4@@QBEXABVVector3@@AAV2@@Z

        // Matrix4.Translate3:
        // public void Translate3(Single x, Single y) => ((delegate* unmanaged[Thiscall]<ref Matrix4, Single, Single, void>)0xDEADBEEF)(ref this, x, y); // .text:0065D080 ; void __thiscall Matrix4::Translate3(Matrix4 *this, float x, float y) .text:0065D080 ?Translate3@Matrix4@@QAEXMM@Z

        // Matrix4.Translate:
        // public void Translate(Single x, Single y, Single z) => ((delegate* unmanaged[Thiscall]<ref Matrix4, Single, Single, Single, void>)0xDEADBEEF)(ref this, x, y, z); // .text:0065D030 ; void __thiscall Matrix4::Translate(Matrix4 *this, float x, float y, float z) .text:0065D030 ?Translate@Matrix4@@QAEXMMM@Z

        // Globals:
        // public static Matrix4* NULL_MATRIX4 = (Matrix4*)0xDEADBEEF; // .data:008F7650 ; Matrix4 Matrix4::NULL_MATRIX4 .data:008F7650 ?NULL_MATRIX4@Matrix4@@2V1@B
    }
    public unsafe struct Vector4 {
        // Struct:
        public Single x;
        public Single y;
        public Single z;
        public Single w;
        public override string ToString() => $"x:{x:n5}, y:{y:n5}, z:{z:n5}, w:{w:n5}";
    }


    public unsafe struct CTimestamp<T> where T : unmanaged {
        public T m_timestamp;
    }


    public unsafe struct LandDefs {
        public enum Rotation : UInt32 {
            ROT_0 = 0x0,
            ROT_90 = 0x1,
            ROT_180 = 0x2,
            ROT_270 = 0x3,
            FORCE_Rotation_32_BIT = 0x7FFFFFFF,
        };
        public enum PalType : UInt32 {
            SWTerrain = 0x0,
            SETerrain = 0x1,
            NETerrain = 0x2,
            NWTerrain = 0x3,
            Road = 0x4,
            FORCE_PalType_32_BIT = 0x7FFFFFFF,
        };
        public enum WaterType : UInt32 {
            NOT_WATER = 0x0,
            PARTIALLY_WATER = 0x1,
            ENTIRELY_WATER = 0x2,
            FORCE_WaterType_32_BIT = 0x7FFFFFFF,
        };
        public enum TerrainType : UInt32 {
            BarrenRock = 0x0,
            Grassland = 0x1,
            Ice = 0x2,
            LushGrass = 0x3,
            MarshSparseSwamp = 0x4,
            MudRichDirt = 0x5,
            ObsidianPlain = 0x6,
            PackedDirt = 0x7,
            PatchyDirt = 0x8,
            PatchyGrassland = 0x9,
            SandYellow = 0xA,
            SandGrey = 0xB,
            SandRockStrewn = 0xC,
            SedimentaryRock = 0xD,
            SemiBarrenRock = 0xE,
            Snow = 0xF,
            WaterRunning = 0x10,
            WaterStandingFresh = 0x11,
            WaterShallowSea = 0x12,
            WaterShallowStillSea = 0x13,
            WaterDeepSea = 0x14,
            Reserved21 = 0x15,
            Reserved22 = 0x16,
            Reserved23 = 0x17,
            Reserved24 = 0x18,
            Reserved25 = 0x19,
            Reserved26 = 0x1A,
            Reserved27 = 0x1B,
            Reserved28 = 0x1C,
            Reserved29 = 0x1D,
            Reserved30 = 0x1E,
            Reserved31 = 0x1F,
            RoadType = 0x20,
            FORCE_TerrainType_32_BIT = 0x7FFFFFFF,
        };
        public enum Direction : UInt32 {
            IN_VIEWER_BLOCK = 0x0,
            NORTH_OF_VIEWER = 0x1,
            SOUTH_OF_VIEWER = 0x2,
            EAST_OF_VIEWER = 0x3,
            WEST_OF_VIEWER = 0x4,
            NORTHWEST_OF_VIEWER = 0x5,
            SOUTHWEST_OF_VIEWER = 0x6,
            NORTHEAST_OF_VIEWER = 0x7,
            SOUTHEAST_OF_VIEWER = 0x8,
            UNKNOWN = 0x9,
            FORCE_Direction_32_BIT = 0x7FFFFFFF,
        };



    }

    public unsafe struct Timer {
        // Struct:

        // Functions:

        // Timer.GetTimerInstance:
        public static PreciseTimerInstance* GetTimerInstance() => ((delegate* unmanaged[Cdecl]<PreciseTimerInstance*>)0x0040FCA0)(); // .text:0040F9E0 ; PreciseTimerInstance *__cdecl Timer::GetTimerInstance() .text:0040F9E0 ?GetTimerInstance@Timer@@SAPAVPreciseTimerInstance@@XZ

        // Timer.Init:
        public static void Init() => ((delegate* unmanaged[Cdecl]<void>)0x0040FCD0)(); // .text:0040FA10 ; void __cdecl Timer::Init() .text:0040FA10 ?Init@Timer@@SAXXZ

        // Timer.compute_local_time:
        public static Double compute_local_time() => ((delegate* unmanaged[Cdecl]<Double>)0x0040FAD0)(); // .text:0040F810 ; long double __cdecl Timer::compute_local_time() .text:0040F810 ?compute_local_time@Timer@@SANXZ

        // Timer.compute_time:
        public static Double compute_time() => ((delegate* unmanaged[Cdecl]<Double>)0x0040FAA0)(); // .text:0040F7E0 ; long double __cdecl Timer::compute_time() .text:0040F7E0 ?compute_time@Timer@@SANXZ

        // Timer.get_real_time:
        public static int get_real_time() => ((delegate* unmanaged[Cdecl]<int>)0x0040FA90)(); // .text:0040F7D0 ; int __cdecl Timer::get_real_time() .text:0040F7D0 ?get_real_time@Timer@@SAJXZ

        // Timer.set_time:
        public static void set_time(Double* now) => ((delegate* unmanaged[Cdecl]<Double*, void>)0x0040FB00)(now); // .text:0040F840 ; void __cdecl Timer::set_time(const long double *now) .text:0040F840 ?set_time@Timer@@SAXABN@Z

        // Timer.update_time:
        public static void update_time() => ((delegate* unmanaged[Cdecl]<void>)0x0040FBD0)(); // .text:0040F910 ; void __cdecl Timer::update_time() .text:0040F910 ?update_time@Timer@@SAXXZ

        // Globals:
        public static PreciseTimerInstance* s_pcTimerInstance = *(PreciseTimerInstance**)0x008379A0; // .data:008369A0 ; PreciseTimerInstance *Timer::s_pcTimerInstance .data:008369A0 ?s_pcTimerInstance@Timer@@1PAVPreciseTimerInstance@@A
        public static Double* cur_time = (Double*)0x008379A8; // .data:008369A8 ; CICMDCommandStruct Timer::cur_time .data:008369A8 ?cur_time@Timer@@1NA
        public static Double* local_time = (Double*)0x008379B0; // .data:008369B0 ; long double Timer::local_time .data:008369B0 ?local_time@Timer@@1NA
        public static Byte* initialized_ = (Byte*)0x008379B8; // .data:008369B8 ; bool Timer::initialized_ .data:008369B8 ?initialized_@Timer@@1_NA
    }

    //public enum Motion___ { Forward = 0x45000005, Backward = 0x45000006, TurnRight = 0x6500000D, TurnLeft = 0x6500000E, StrafeRight = 0x6500000F, StrafeLeft = 0x65000010, Walk = 0x11112222 }
    public enum command : uint {
        Invalid = 0x80000000,
        HoldRun = 0x85000001,
        HoldSidestep = 0x85000002,
        Ready = 0x41000003,
        Stop = 0x40000004,
        WalkForward = 0x45000005,
        WalkBackwards = 0x45000006,
        RunForward = 0x44000007,
        Fallen = 0x40000008,
        Interpolating = 0x40000009,
        Hover = 0x4000000A,
        On = 0x4000000B,
        Off = 0x4000000C,
        TurnRight = 0x6500000D,
        TurnLeft = 0x6500000E,
        SideStepRight = 0x6500000F,
        SideStepLeft = 0x65000010,
        Dead = 0x40000011,
        Crouch = 0x41000012,
        Sitting = 0x41000013,
        Sleeping = 0x41000014,
        Falling = 0x40000015,
        Reload = 0x40000016,
        Unload = 0x40000017,
        Pickup = 0x40000018,
        StoreInBackpack = 0x40000019,
        Eat = 0x4000001A,
        Drink = 0x4000001B,
        Reading = 0x4000001C,
        JumpCharging = 0x4000001D,
        AimLevel = 0x4000001E,
        AimHigh15 = 0x4000001F,
        AimHigh30 = 0x40000020,
        AimHigh45 = 0x40000021,
        AimHigh60 = 0x40000022,
        AimHigh75 = 0x40000023,
        AimHigh90 = 0x40000024,
        AimLow15 = 0x40000025,
        AimLow30 = 0x40000026,
        AimLow45 = 0x40000027,
        AimLow60 = 0x40000028,
        AimLow75 = 0x40000029,
        AimLow90 = 0x4000002A,
        MagicBlast = 0x4000002B,
        MagicSelfHead = 0x4000002C,
        MagicSelfHeart = 0x4000002D,
        MagicBonus = 0x4000002E,
        MagicClap = 0x4000002F,
        MagicHarm = 0x40000030,
        MagicHeal = 0x40000031,
        MagicThrowMissile = 0x40000032,
        MagicRecoilMissile = 0x40000033,
        MagicPenalty = 0x40000034,
        MagicTransfer = 0x40000035,
        MagicVision = 0x40000036,
        MagicEnchantItem = 0x40000037,
        MagicPortal = 0x40000038,
        MagicPray = 0x40000039,
        StopTurning = 0x2000003A,
        Jump = 0x2500003B,
        HandCombat = 0x8000003C,
        NonCombat = 0x8000003D,
        SwordCombat = 0x8000003E,
        BowCombat = 0x8000003F,
        SwordShieldCombat = 0x80000040,
        CrossbowCombat = 0x80000041,
        UnusedCombat = 0x80000042,
        SlingCombat = 0x80000043,
        _2HandedSwordCombat = 0x80000044,
        _2HandedStaffCombat = 0x80000045,
        DualWieldCombat = 0x80000046,
        ThrownWeaponCombat = 0x80000047,
        Graze = 0x80000048,
        Magi = 0x80000049,
        Hop = 0x1000004A,
        Jumpup = 0x1000004B,
        Cheer = 0x1300004C,
        ChestBeat = 0x1000004D,
        TippedLeft = 0x1000004E,
        TippedRight = 0x1000004F,
        FallDown = 0x10000050,
        Twitch1 = 0x10000051,
        Twitch2 = 0x10000052,
        Twitch3 = 0x10000053,
        Twitch4 = 0x10000054,
        StaggerBackward = 0x10000055,
        StaggerForward = 0x10000056,
        Sanctuary = 0x10000057,
        ThrustMed = 0x10000058,
        ThrustLow = 0x10000059,
        ThrustHigh = 0x1000005A,
        SlashHigh = 0x1000005B,
        SlashMed = 0x1000005C,
        SlashLow = 0x1000005D,
        BackhandHigh = 0x1000005E,
        BackhandMed = 0x1000005F,
        BackhandLow = 0x10000060,
        Shoot = 0x10000061,
        AttackHigh1 = 0x10000062,
        AttackMed1 = 0x10000063,
        AttackLow1 = 0x10000064,
        AttackHigh2 = 0x10000065,
        AttackMed2 = 0x10000066,
        AttackLow2 = 0x10000067,
        AttackHigh3 = 0x10000068,
        AttackMed3 = 0x10000069,
        AttackLow3 = 0x1000006A,
        HeadThrow = 0x1000006B,
        FistSlam = 0x1000006C,
        BreatheFlame_ = 0x1000006D,
        SpinAttack = 0x1000006E,
        MagicPowerUp01 = 0x1000006F,
        MagicPowerUp02 = 0x10000070,
        MagicPowerUp03 = 0x10000071,
        MagicPowerUp04 = 0x10000072,
        MagicPowerUp05 = 0x10000073,
        MagicPowerUp06 = 0x10000074,
        MagicPowerUp07 = 0x10000075,
        MagicPowerUp08 = 0x10000076,
        MagicPowerUp09 = 0x10000077,
        MagicPowerUp10 = 0x10000078,
        ShakeFist = 0x13000079,
        Beckon = 0x1300007A,
        BeSeeingYou = 0x1300007B,
        BlowKiss = 0x1300007C,
        BowDeep = 0x1300007D,
        ClapHands = 0x1300007E,
        Cry = 0x1300007F,
        Laugh = 0x13000080,
        MimeEat = 0x13000081,
        MimeDrink = 0x13000082,
        Nod = 0x13000083,
        Point = 0x13000084,
        ShakeHead = 0x13000085,
        Shrug = 0x13000086,
        Wave = 0x13000087,
        Akimbo = 0x13000088,
        HeartyLaugh = 0x13000089,
        Salute = 0x1300008A,
        ScratchHead = 0x1300008B,
        SmackHead = 0x1300008C,
        TapFoot = 0x1300008D,
        WaveHigh = 0x1300008E,
        WaveLow = 0x1300008F,
        YawnStretch = 0x13000090,
        Cringe = 0x13000091,
        Kneel = 0x13000092,
        Plead = 0x13000093,
        Shiver = 0x13000094,
        Shoo = 0x13000095,
        Slouch = 0x13000096,
        Spit = 0x13000097,
        Surrender = 0x13000098,
        Woah = 0x13000099,
        Winded = 0x1300009A,
        YMCA = 0x1200009B,
        EnterGame = 0x1000009C,
        ExitGame = 0x1000009D,
        OnCreation = 0x1000009E,
        OnDestruction = 0x1000009F,
        EnterPortal = 0x100000A0,
        ExitPortal = 0x100000A1,
        Cancel = 0x080000A2,
        UseSelected = 0x090000A3,
        AutosortSelected = 0x090000A4,
        DropSelected = 0x090000A5,
        GiveSelected = 0x090000A6,
        SplitSelected = 0x090000A7,
        ExamineSelected = 0x090000A8,
        CreateShortcutToSelected = 0x080000A9,
        PreviousCompassItem = 0x090000AA,
        NextCompassItem = 0x090000AB,
        ClosestCompassItem = 0x090000AC,
        PreviousSelection = 0x090000AD,
        LastAttacker = 0x090000AE,
        PreviousFellow = 0x090000AF,
        NextFellow = 0x090000B0,
        ToggleCombat = 0x090000B1,
        HighAttack = 0x0D0000B2,
        MediumAttack = 0x0D0000B3,
        LowAttack = 0x0D0000B4,
        EnterChat = 0x080000B5,
        ToggleChat = 0x080000B6,
        SavePosition = 0x080000B7,
        OptionsPanel = 0x090000B8,
        ResetView = 0x090000B9,
        CameraLeftRotate = 0x0D0000BA,
        CameraRightRotate = 0x0D0000BB,
        CameraRaise = 0x0D0000BC,
        CameraLower = 0x0D0000BD,
        CameraCloser = 0x0D0000BE,
        CameraFarther = 0x0D0000BF,
        FloorView = 0x090000C0,
        MouseLook = 0x0C0000C1,
        PreviousItem = 0x090000C2,
        NextItem = 0x090000C3,
        ClosestItem = 0x090000C4,
        ShiftView = 0x0D0000C5,
        MapView = 0x090000C6,
        AutoRun = 0x090000C7,
        DecreasePowerSetting = 0x090000C8,
        IncreasePowerSetting = 0x090000C9,
        Pray = 0x130000CA,
        Mock = 0x130000CB,
        Teapot = 0x130000CC,
        SpecialAttack1 = 0x100000CD,
        SpecialAttack2 = 0x100000CE,
        SpecialAttack3 = 0x100000CF,
        MissileAttack1 = 0x100000D0,
        MissileAttack2 = 0x100000D1,
        MissileAttack3 = 0x100000D2,
        CastSpell = 0x400000D3,
        Flatulence = 0x120000D4,
        FirstPersonView = 0x090000D5,
        AllegiancePanel = 0x090000D6,
        FellowshipPanel = 0x090000D7,
        SpellbookPanel = 0x090000D8,
        SpellComponentsPanel = 0x090000D9,
        HousePanel = 0x090000DA,
        AttributesPanel = 0x090000DB,
        SkillsPanel = 0x090000DC,
        MapPanel = 0x090000DD,
        InventoryPanel = 0x090000DE,
        Demonet = 0x120000DF,
        UseMagicStaff = 0x400000E0,
        UseMagicWand = 0x400000E1,
        Blink = 0x100000E2,
        Bite = 0x100000E3,
        TwitchSubstate1 = 0x400000E4,
        TwitchSubstate2 = 0x400000E5,
        TwitchSubstate3 = 0x400000E6,
        CaptureScreenshotToFile = 0x090000E7,
        BowNoAmmo = 0x800000E8,
        CrossBowNoAmmo = 0x800000E9,
        ShakeFistState = 0x430000EA,
        PrayState = 0x430000EB,
        BowDeepState = 0x430000EC,
        ClapHandsState = 0x430000ED,
        CrossArmsState = 0x430000EE,
        ShiverState = 0x430000EF,
        PointState = 0x430000F0,
        WaveState = 0x430000F1,
        AkimboState = 0x430000F2,
        SaluteState = 0x430000F3,
        ScratchHeadState = 0x430000F4,
        TapFootState = 0x430000F5,
        LeanState = 0x430000F6,
        KneelState = 0x430000F7,
        PleadState = 0x430000F8,
        ATOYOT = 0x420000F9,
        SlouchState = 0x430000FA,
        SurrenderState = 0x430000FB,
        WoahState = 0x430000FC,
        WindedState = 0x430000FD,
        AutoCreateShortcuts = 0x090000FE,
        AutoRepeatAttacks = 0x090000FF,
        AutoTarget = 0x09000100,
        AdvancedCombatInterface = 0x09000101,
        IgnoreAllegianceRequests = 0x09000102,
        IgnoreFellowshipRequests = 0x09000103,
        InvertMouseLook = 0x09000104,
        LetPlayersGiveYouItems = 0x09000105,
        AutoTrackCombatTargets = 0x09000106,
        DisplayTooltips = 0x09000107,
        AttemptToDeceivePlayers = 0x09000108,
        RunAsDefaultMovement = 0x09000109,
        StayInChatModeAfterSend = 0x0900010A,
        RightClickToMouseLook = 0x0900010B,
        VividTargetIndicator = 0x0900010C,
        SelectSelf = 0x0900010D,
        SkillHealSelf = 0x1000010E,
        NextMonster = 0x0900010F,
        PreviousMonster = 0x09000110,
        ClosestMonster = 0x09000111,
        NextPlayer = 0x09000112,
        PreviousPlayer = 0x09000113,
        ClosestPlayer = 0x09000114,
        SnowAngelState = 0x43000115,
        WarmHands = 0x13000116,
        CurtseyState = 0x43000117,
        AFKState = 0x43000118,
        MeditateState = 0x43000119,
        TradePanel = 0x0900011A,
        LogOut = 0x1000011B,
        DoubleSlashLow = 0x1000011C,
        DoubleSlashMed = 0x1000011D,
        DoubleSlashHigh = 0x1000011E,
        TripleSlashLow = 0x1000011F,
        TripleSlashMed = 0x10000120,
        TripleSlashHigh = 0x10000121,
        DoubleThrustLow = 0x10000122,
        DoubleThrustMed = 0x10000123,
        DoubleThrustHigh = 0x10000124,
        TripleThrustLow = 0x10000125,
        TripleThrustMed = 0x10000126,
        TripleThrustHigh = 0x10000127,
        MagicPowerUp01Purple = 0x10000128,
        MagicPowerUp02Purple = 0x10000129,
        MagicPowerUp03Purple = 0x1000012A,
        MagicPowerUp04Purple = 0x1000012B,
        MagicPowerUp05Purple = 0x1000012C,
        MagicPowerUp06Purple = 0x1000012D,
        MagicPowerUp07Purple = 0x1000012E,
        MagicPowerUp08Purple = 0x1000012F,
        MagicPowerUp09Purple = 0x10000130,
        MagicPowerUp10Purple = 0x10000131,
        Helper = 0x13000132,
        Pickup5 = 0x40000133,
        Pickup10 = 0x40000134,
        Pickup15 = 0x40000135,
        Pickup20 = 0x40000136,
        HouseRecall = 0x10000137,
        AtlatlCombat = 0x80000138,
        ThrownShieldCombat = 0x80000139,
        SitState = 0x4300013A,
        SitCrossleggedState = 0x4300013B,
        SitBackState = 0x4300013C,
        PointLeftState = 0x4300013D,
        PointRightState = 0x4300013E,
        TalktotheHandState = 0x4300013F,
        PointDownState = 0x43000140,
        DrudgeDanceState = 0x43000141,
        PossumState = 0x43000142,
        ReadState = 0x43000143,
        ThinkerState = 0x43000144,
        HaveASeatState = 0x43000145,
        AtEaseState = 0x43000146,
        NudgeLeft = 0x13000147,
        NudgeRight = 0x13000148,
        PointLeft = 0x13000149,
        PointRight = 0x1300014A,
        PointDown = 0x1300014B,
        Knock = 0x1300014C,
        ScanHorizon = 0x1300014D,
        DrudgeDance = 0x1300014E,
        HaveASeat = 0x1300014F,
        LifestoneRecall = 0x10000150,
        CharacterOptionsPanel = 0x09000151,
        SoundAndGraphicsPanel = 0x09000152,
        HelpfulSpellsPanel = 0x09000153,
        HarmfulSpellsPanel = 0x09000154,
        CharacterInformationPanel = 0x09000155,
        LinkStatusPanel = 0x09000156,
        VitaePanel = 0x09000157,
        ShareFellowshipXP = 0x09000158,
        ShareFellowshipLoot = 0x09000159,
        AcceptCorpseLooting = 0x0900015A,
        IgnoreTradeRequests = 0x0900015B,
        DisableWeather = 0x0900015C,
        DisableHouseEffect = 0x0900015D,
        SideBySideVitals = 0x0900015E,
        ShowRadarCoordinates = 0x0900015F,
        ShowSpellDurations = 0x09000160,
        MuteOnLosingFocus = 0x09000161,
        Fishing = 0x10000162,
        MarketplaceRecall = 0x10000163,
        EnterPKLite = 0x10000164,
        AllegianceChat = 0x09000165,
        AutomaticallyAcceptFellowshipRequests = 0x09000166,
        Reply = 0x09000167,
        MonarchReply = 0x09000168,
        PatronReply = 0x09000169,
        ToggleCraftingChanceOfSuccessDialog = 0x0900016A,
        UseClosestUnopenedCorpse = 0x0900016B,
        UseNextUnopenedCorpse = 0x0900016C,
        IssueSlashCommand = 0x0900016D,
        AllegianceHometownRecall = 0x1000016E,
        PKArenaRecall = 0x1000016F,
        OffhandSlashHigh = 0x10000170,
        OffhandSlashMed = 0x10000171,
        OffhandSlashLow = 0x10000172,
        OffhandThrustHigh = 0x10000173,
        OffhandThrustMed = 0x10000174,
        OffhandThrustLow = 0x10000175,
        OffhandDoubleSlashLow = 0x10000176,
        OffhandDoubleSlashMed = 0x10000177,
        OffhandDoubleSlashHigh = 0x10000178,
        OffhandTripleSlashLow = 0x10000179,
        OffhandTripleSlashMed = 0x1000017A,
        OffhandTripleSlashHigh = 0x1000017B,
        OffhandDoubleThrustLow = 0x1000017C,
        OffhandDoubleThrustMed = 0x1000017D,
        OffhandDoubleThrustHigh = 0x1000017E,
        OffhandTripleThrustLow = 0x1000017F,
        OffhandTripleThrustMed = 0x10000180,
        OffhandTripleThrustHigh = 0x10000181,
        OffhandKick = 0x10000182,
        AttackHigh4 = 0x10000183,
        AttackMed4 = 0x10000184,
        AttackLow4 = 0x10000185,
        AttackHigh5 = 0x10000186,
        AttackMed5 = 0x10000187,
        AttackLow5 = 0x10000188,
        AttackHigh6 = 0x10000189,
        AttackMed6 = 0x1000018A,
        AttackLow6 = 0x1000018B,
        PunchFastHigh = 0x1000018C,
        PunchFastMed = 0x1000018D,
        PunchFastLow = 0x1000018E,
        PunchSlowHigh = 0x1000018F,
        PunchSlowMed = 0x10000190,
        PunchSlowLow = 0x10000191,
        OffhandPunchFastHigh = 0x10000192,
        OffhandPunchFastMed = 0x10000193,
        OffhandPunchFastLow = 0x10000194,
        OffhandPunchSlowHigh = 0x10000195,
        OffhandPunchSlowMed = 0x10000196,
        OffhandPunchSlowLow = 0x10000197,
    }


    public enum UIMode : int {
        None = 0,
        IntroUI = 0x10000001,
        DisconnectedUI = 0x10000002,
        DataPatchUI = 0x10000003,
        CreditsUI = 0x10000005,
        GamePlayUI = 0x10000008,
        EpilogueUI = 0x10000009,
        CharacterManagementUI = 0x1000000A,
        CharGenMainUI = 0x1000000B
    }

    public unsafe struct PTR<A> where A : unmanaged {
        public A* ptr;
        public override string ToString() => $"ptr({typeof(A)})->0x{(int)ptr:X8}";
    }
    public unsafe class InterfaceType {
        public Turbine_GUID* InArchiveVersionStack = (Turbine_GUID*)0x00795418;
        public Turbine_GUID* INVALID = (Turbine_GUID*)0x00799D04;
        public Turbine_GUID* ClientHousingSystem = (Turbine_GUID*)0x00008927;
        public Turbine_GUID* Interface = (Turbine_GUID*)0x00793650;
        public Turbine_GUID* IObjectFactory = (Turbine_GUID*)0x00793660;
        public Turbine_GUID* CLCache = (Turbine_GUID*)0x00793670;
        public Turbine_GUID* IQueuedUIEventDeliverer = (Turbine_GUID*)0x007936A8;
        public Turbine_GUID* ClientSystem = (Turbine_GUID*)0x00793730;
        public Turbine_GUID* PlayerDesc = (Turbine_GUID*)0x00793740;
        public Turbine_GUID* CPlayerModule = (Turbine_GUID*)0x00793750;
        public Turbine_GUID* CObjectMaint = (Turbine_GUID*)0x00793760;
        public Turbine_GUID* ClientObjMaintSystem = (Turbine_GUID*)0x00793770;
        public Turbine_GUID* ClientUISystem = (Turbine_GUID*)0x00793780;
        public Turbine_GUID* ClientAdminSystem = (Turbine_GUID*)0x00793790;
        public Turbine_GUID* ClientAllegianceSystem = (Turbine_GUID*)0x007937A0;
        public Turbine_GUID* ClientCombatSystem = (Turbine_GUID*)0x007937B0;
        public Turbine_GUID* ClientCommunicationSystem = (Turbine_GUID*)0x007937C0;
        public Turbine_GUID* ClientFellowshipSystem = (Turbine_GUID*)0x007937D0;
        public Turbine_GUID* ClientMagicSystem = (Turbine_GUID*)0x007937F0;
        public Turbine_GUID* ClientMiniGameSystem = (Turbine_GUID*)0x00793800;
        public Turbine_GUID* CPlayerSystem = (Turbine_GUID*)0x00793810;
        public Turbine_GUID* ClientTradeSystem = (Turbine_GUID*)0x00793820;
        public Turbine_GUID* UIQueueManager = (Turbine_GUID*)0x00793830;
    }

    public unsafe class ClassType {
        public Turbine_GUID* INVALID = (Turbine_GUID*)0x00799D04;
        public Turbine_GUID* GlobalRegistryCommands = (Turbine_GUID*)0x00793B10;
        public Turbine_GUID* Client = (Turbine_GUID*)0x007936B8;
        public Turbine_GUID* UIFlow = (Turbine_GUID*)0x00793B00;
        public Turbine_GUID* CObjectMaint_Factory = (Turbine_GUID*)0x0079C5F8;
        public Turbine_GUID* CPlayerModule = (Turbine_GUID*)0x007A27F4;
        public Turbine_GUID* PlayerDesc = (Turbine_GUID*)0x007A4948;
        public Turbine_GUID* ClientObjMaintSystem = (Turbine_GUID*)0x007B5E50;
        public Turbine_GUID* CObjectMaint = (Turbine_GUID*)0x007BE748;
    }



    public unsafe partial struct AC1Legacy {
        public unsafe struct Vector3 {
            // Struct:
            public AcClient.Vector3 a0;
            public override string ToString() => $"a0(Vector3):{a0}";

            // Functions:

            // Vector3.operator_is_equal:
            public Byte operator_is_equal(AC1Legacy.Vector3* v) => ((delegate* unmanaged[Thiscall]<ref Vector3, AC1Legacy.Vector3*, Byte>)0x0050A9E0)(ref this, v); // .text:00509F10 ; bool __thiscall Vector3::operator==(Vector3 *this, Vector3 *v) .text:00509F10 ??8Vector3@AC1Legacy@@QBE_NABV01@@Z

            // Vector3.operator_minus:
            public AC1Legacy.Vector3* operator_minus(AC1Legacy.Vector3* result, AC1Legacy.Vector3* b) => ((delegate* unmanaged[Thiscall]<ref Vector3, AC1Legacy.Vector3*, AC1Legacy.Vector3*, AC1Legacy.Vector3*>)0x00452500)(ref this, result, b); // .text:004524C0 ; Vector3 *__thiscall Vector3::operator-(Vector3 *this, Vector3 *result, Vector3 *b) .text:004524C0 ??GVector3@AC1Legacy@@QBE?AV01@ABV01@@Z

            // Vector3.UnPack:
            public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Vector3, void**, UInt32, int>)0x00517040)(ref this, addr, size); // .text:00516540 ; int __thiscall Vector3::UnPack(Vector3 *this, void **addr, unsigned int size) .text:00516540 ?UnPack@Vector3@AC1Legacy@@QAEHAAPAXI@Z

            // Vector3.get_heading:
            public Single get_heading() => ((delegate* unmanaged[Thiscall]<ref Vector3, Single>)0x004576F0)(ref this); // .text:004575D0 ; float __thiscall Vector3::get_heading(Vector3 *this) .text:004575D0 ?get_heading@Vector3@AC1Legacy@@QBEMXZ

            // Vector3.get_pitch:
            public Single get_pitch() => ((delegate* unmanaged[Thiscall]<ref Vector3, Single>)0x00457750)(ref this); // .text:00457630 ; float __thiscall Vector3::get_pitch(Vector3 *this) .text:00457630 ?get_pitch@Vector3@AC1Legacy@@QBEMXZ

            // Vector3.is_zero:
            public int is_zero() => ((delegate* unmanaged[Thiscall]<ref Vector3, int>)0x0050F280)(ref this); // .text:0050E7B0 ; int __thiscall Vector3::is_zero(Vector3 *this) .text:0050E7B0 ?is_zero@Vector3@AC1Legacy@@QBEHXZ

            // Vector3.magnitude:
            public Single magnitude() => ((delegate* unmanaged[Thiscall]<ref Vector3, Single>)0x00452410)(ref this); // .text:004523D0 ; float __thiscall Vector3::magnitude(Vector3 *this) .text:004523D0 ?magnitude@Vector3@AC1Legacy@@QBEMXZ

            // Vector3.normalize:
            public AC1Legacy.Vector3* normalize(AC1Legacy.Vector3* result) => ((delegate* unmanaged[Thiscall]<ref Vector3, AC1Legacy.Vector3*, AC1Legacy.Vector3*>)0x00452440)(ref this, result); // .text:00452400 ; Vector3 *__thiscall Vector3::normalize(Vector3 *this, Vector3 *result) .text:00452400 ?normalize@Vector3@AC1Legacy@@QAE?AV12@XZ

            // Vector3.normalize_check_small:
            public int normalize_check_small() => ((delegate* unmanaged[Thiscall]<ref Vector3, int>)0x004524A0)(ref this); // .text:00452460 ; int __thiscall Vector3::normalize_check_small(Vector3 *this) .text:00452460 ?normalize_check_small@Vector3@AC1Legacy@@QAEHXZ
        }



    }


}