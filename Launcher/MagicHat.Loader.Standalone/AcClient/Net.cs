using System;
using System.Runtime.InteropServices;

//[UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate void* __vecDelDtor(* This, UInt32 a2); // 
namespace AcClient {

    public unsafe struct NetAuthenticator {
        // Struct:
        public StreamPackObj StreamPackObj;
        public UInt32 m_dwAuthType;
        public UInt32 m_dwAuthFlags;
        public UInt32 m_dwConnectionSequenceNumber;
        public accountID m_Account;
        public accountID m_AccountToLogonAs;
        public CGrowBuffer m_CryptoData;
        public CGrowBuffer m_ExtraData;
        public override string ToString() => $"StreamPackObj(StreamPackObj):{StreamPackObj}, m_dwAuthType:{m_dwAuthType:X8}, m_dwAuthFlags:{m_dwAuthFlags:X8}, m_dwConnectionSequenceNumber:{m_dwConnectionSequenceNumber:X8}, m_Account(accountID):{m_Account}, m_AccountToLogonAs(accountID):{m_AccountToLogonAs}, m_CryptoData(NetAuthenticator.CGrowBuffer):{m_CryptoData}, m_ExtraData(NetAuthenticator.CGrowBuffer):{m_ExtraData}";
        public unsafe struct CGrowBuffer {
            // Struct:
            public Char* m_pBuf;
            public UInt32 m_cbAllocatedSize;
            public UInt32 m_cbCurSize;
            public override string ToString() => $"m_pBuf:->(Char*)0x{(Int32)m_pBuf:X8}, m_cbAllocatedSize:{m_cbAllocatedSize:X8}, m_cbCurSize:{m_cbCurSize:X8}";


            // Functions:

            // NetAuthenticator::CGrowBuffer.Grow:
            public static delegate* unmanaged[Thiscall]<CGrowBuffer*, UInt32, Int32> Grow = (delegate* unmanaged[Thiscall]<CGrowBuffer*, UInt32, Int32>)0x00541240; // .text:00540590 ; Int32 __thiscall NetAuthenticator::CGrowBuffer::Grow(NetAuthenticator::CGrowBuffer *this, UInt32 new_size) .text:00540590 ?Grow@CGrowBuffer@NetAuthenticator@@QAEHI@Z

            // NetAuthenticator::CGrowBuffer.StreamPack:
            public static delegate* unmanaged[Thiscall]<CGrowBuffer*, STREAMTYPE, void**, UInt32*, Int32> StreamPack = (delegate* unmanaged[Thiscall]<CGrowBuffer*, STREAMTYPE, void**, UInt32*, Int32>)0x00541430; // .text:00540780 ; Int32 __thiscall NetAuthenticator::CGrowBuffer::StreamPack(NetAuthenticator::CGrowBuffer *this, STREAMTYPE op, void **addr, UInt32 *size) .text:00540780 ?StreamPack@CGrowBuffer@NetAuthenticator@@QAEHW4STREAMTYPE@@AAPAXAAI@Z
        }


        // Functions:

        // NetAuthenticator.Pack:
        public static delegate* unmanaged[Thiscall]<NetAuthenticator*, void**, UInt32, UInt32> Pack = (delegate* unmanaged[Thiscall]<NetAuthenticator*, void**, UInt32, UInt32>)0x00541510; // .text:00540860 ; UInt32 __thiscall NetAuthenticator::Pack(NetAuthenticator *this, void **addr, UInt32 size) .text:00540860 ?Pack@NetAuthenticator@@UAEIAAPAXI@Z

        // NetAuthenticator.__scaDelDtor:
        public static delegate* unmanaged[Thiscall]<NetAuthenticator*, UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<NetAuthenticator*, UInt32, void*>)0x00541570; // .text:005408C0 ; void *__thiscall NetAuthenticator::`scalar deleting destructor'(NetAuthenticator *this, UInt32) .text:005408C0 ??_GNetAuthenticator@@UAEPAXI@Z

        // NetAuthenticator.SetToAuthType:
        public static delegate* unmanaged[Thiscall]<NetAuthenticator*, UInt32, accountID*, UInt32, Char*, Byte> SetToAuthType = (delegate* unmanaged[Thiscall]<NetAuthenticator*, UInt32, accountID*, UInt32, Char*, Byte>)0x00541640; // .text:00540990 ; bool __thiscall NetAuthenticator::SetToAuthType(NetAuthenticator *this, UInt32 dwAuthType, accountID *Account, UInt32 dwBinaryLen, const Char *pData) .text:00540990 ?SetToAuthType@NetAuthenticator@@QAE_NKABVaccountID@@IPBE@Z

        // NetAuthenticator.StreamPack:
        public static delegate* unmanaged[Thiscall]<NetAuthenticator*, STREAMTYPE, void**, UInt32*, Int32> StreamPack = (delegate* unmanaged[Thiscall]<NetAuthenticator*, STREAMTYPE, void**, UInt32*, Int32>)0x005416C0; // .text:00540A10 ; Int32 __thiscall NetAuthenticator::StreamPack(NetAuthenticator *this, STREAMTYPE op, void **addr, UInt32 *size) .text:00540A10 ?StreamPack@NetAuthenticator@@UAEHW4STREAMTYPE@@AAPAXAAI@Z

        // NetAuthenticator.__Dtor:
        public static delegate* unmanaged[Thiscall]<NetAuthenticator*> __Dtor = (delegate* unmanaged[Thiscall]<NetAuthenticator*>)0x00411E10; // .text:00411AB0 ; void __thiscall NetAuthenticator::~NetAuthenticator(NetAuthenticator *this) .text:00411AB0 ??1NetAuthenticator@@UAE@XZ

        // NetAuthenticator.GetPackSize:
        public static delegate* unmanaged[Thiscall]<NetAuthenticator*, UInt32> GetPackSize = (delegate* unmanaged[Thiscall]<NetAuthenticator*, UInt32>)0x00541310; // .text:00540660 ; UInt32 __thiscall NetAuthenticator::GetPackSize(NetAuthenticator *this) .text:00540660 ?GetPackSize@NetAuthenticator@@UBEIXZ

        // NetAuthenticator.__Ctor:
        public static delegate* unmanaged[Thiscall]<NetAuthenticator*> __Ctor = (delegate* unmanaged[Thiscall]<NetAuthenticator*>)0x005414A0; // .text:005407F0 ; void __thiscall NetAuthenticator::NetAuthenticator(NetAuthenticator *this) .text:005407F0 ??0NetAuthenticator@@QAE@XZ
    }
    public unsafe struct NetError {
        // Struct:
        public PackObj PackObj;
        public UInt32 m_stringID;
        public Int32 m_tableID;
        public override string ToString() => $"PackObj(PackObj):{PackObj}, m_stringID:{m_stringID:X8}, m_tableID:{m_tableID}";


        // Functions:

        // NetError.Pack:
        public static delegate* unmanaged[Thiscall]<NetError*, void**, UInt32, UInt32> Pack = (delegate* unmanaged[Thiscall]<NetError*, void**, UInt32, UInt32>)0x004117B0; // .text:00411450 ; UInt32 __thiscall NetError::Pack(NetError *this, void **addr, UInt32 size) .text:00411450 ?Pack@NetError@@UAEIAAPAXI@Z

        // NetError.UnPack:
        public static delegate* unmanaged[Thiscall]<NetError*, void**, UInt32, Int32> UnPack = (delegate* unmanaged[Thiscall]<NetError*, void**, UInt32, Int32>)0x00411800; // .text:004114A0 ; Int32 __thiscall NetError::UnPack(NetError *this, void **addr, UInt32 size) .text:004114A0 ?UnPack@NetError@@UAEHAAPAXI@Z

        // NetError.GetLogString:
        public static delegate* unmanaged[Thiscall]<NetError*, PStringBase<UInt16>*, PStringBase<UInt16>*> GetLogString = (delegate* unmanaged[Thiscall]<NetError*, PStringBase<UInt16>*, PStringBase<UInt16>*>)0x00412AE0; // .text:00412780 ; PStringBase<UInt16> *__thiscall NetError::GetLogString(NetError *this, PStringBase<UInt16> *result) .text:00412780 ?GetLogString@NetError@@QBE?AV?$PStringBase@G@@XZ
    }

    public unsafe struct QualityRegistrar {
        // Struct:
        public Int32* vfptr; // QualityRegistrarVtbl* todo
        public IntrusiveHashTable<UInt32, PTR<QualityHandler>> m_handlers;
        public QualityHandler m_PlayerQualityHandler;
        public QualityHandler m_GlobalQualityHandler;
        public override string ToString() => $"vfptr:->(QualityRegistrarVtbl*)0x{(Int32)vfptr:X8}, m_handlers(IntrusiveHashTable<UInt32,QualityHandler*,1>):{m_handlers}, m_PlayerQualityHandler(QualityHandler):{m_PlayerQualityHandler}, m_GlobalQualityHandler(QualityHandler):{m_GlobalQualityHandler}";


        // Functions:

        // QualityRegistrar.UnRegisterQualityHandler:
        // public static delegate* unmanaged[Thiscall]<QualityRegistrar*,UInt32,StatType,UInt32,QualityChangeHandler*, Byte> UnRegisterQualityHandler = (delegate* unmanaged[Thiscall]<QualityRegistrar*,UInt32,StatType,UInt32,QualityChangeHandler*, Byte>)0xDEADBEEF; // .text:00692F90 ; bool __thiscall QualityRegistrar::UnRegisterQualityHandler(QualityRegistrar *this, UInt32 i_iidTarget, StatType i_StatType, UInt32 i_StatCode, QualityChangeHandler *i_pcHandler) .text:00692F90 ?UnRegisterQualityHandler@QualityRegistrar@@UAE_NKW4StatType@@KPAVQualityChangeHandler@@@Z

        // QualityRegistrar.UnRegisterQualityHandlerForThePlayer:
        // public static delegate* unmanaged[Thiscall]<QualityRegistrar*,StatType,UInt32,QualityChangeHandler*, Byte> UnRegisterQualityHandlerForThePlayer = (delegate* unmanaged[Thiscall]<QualityRegistrar*,StatType,UInt32,QualityChangeHandler*, Byte>)0xDEADBEEF; // .text:00693000 ; bool __thiscall QualityRegistrar::UnRegisterQualityHandlerForThePlayer(QualityRegistrar *this, StatType i_StatType, UInt32 i_StatCode, QualityChangeHandler *i_pcHandler) .text:00693000 ?UnRegisterQualityHandlerForThePlayer@QualityRegistrar@@UAE_NW4StatType@@KPAVQualityChangeHandler@@@Z

        // QualityRegistrar.CallChangeHandler:
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*, CWeenieObject*, StatType, UInt32, Byte> CallChangeHandler = (delegate* unmanaged[Thiscall]<QualityRegistrar*, CWeenieObject*, StatType, UInt32, Byte>)0x00694010; // .text:00693070 ; bool __thiscall QualityRegistrar::CallChangeHandler(QualityRegistrar *this, CWeenieObject *cwobj, StatType stype, UInt32 senum) .text:00693070 ?CallChangeHandler@QualityRegistrar@@QAE_NPAVCWeenieObject@@W4StatType@@K@Z

        // QualityRegistrar.RegisterQualityHandlerForThePlayer:
        // public static delegate* unmanaged[Thiscall]<QualityRegistrar*,StatType,UInt32,QualityChangeHandler*, Byte> RegisterQualityHandlerForThePlayer = (delegate* unmanaged[Thiscall]<QualityRegistrar*,StatType,UInt32,QualityChangeHandler*, Byte>)0xDEADBEEF; // .text:00693650 ; bool __thiscall QualityRegistrar::RegisterQualityHandlerForThePlayer(QualityRegistrar *this, StatType i_StatType, UInt32 i_StatCode, QualityChangeHandler *i_pcHandler) .text:00693650 ?RegisterQualityHandlerForThePlayer@QualityRegistrar@@UAE_NW4StatType@@KPAVQualityChangeHandler@@@Z

        // QualityRegistrar.RegisterQualityHandler:
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*, UInt32, StatType, UInt32, QualityChangeHandler*, Byte> RegisterQualityHandler = (delegate* unmanaged[Thiscall]<QualityRegistrar*, UInt32, StatType, UInt32, QualityChangeHandler*, Byte>)0x00694730; // .text:00693810 ; bool __thiscall QualityRegistrar::RegisterQualityHandler(QualityRegistrar *this, UInt32 i_iidTarget, StatType i_StatType, UInt32 i_StatCode, QualityChangeHandler *i_pcHandler) .text:00693810 ?RegisterQualityHandler@QualityRegistrar@@UAE_NKW4StatType@@KPAVQualityChangeHandler@@@Z

        // QualityRegistrar.UnRegisterAllQualityHandler:
        // public static delegate* unmanaged[Thiscall]<QualityRegistrar*,QualityChangeHandler*, Byte> UnRegisterAllQualityHandler = (delegate* unmanaged[Thiscall]<QualityRegistrar*,QualityChangeHandler*, Byte>)0xDEADBEEF; // .text:00692D60 ; bool __thiscall QualityRegistrar::UnRegisterAllQualityHandler(QualityRegistrar *this, QualityChangeHandler *i_pcHandler) .text:00692D60 ?UnRegisterAllQualityHandler@QualityRegistrar@@UAE_NPAVQualityChangeHandler@@@Z

        // QualityRegistrar.CallRemoveHandler:
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*, CWeenieObject*, StatType, UInt32, Byte> CallRemoveHandler = (delegate* unmanaged[Thiscall]<QualityRegistrar*, CWeenieObject*, StatType, UInt32, Byte>)0x006940A0; // .text:00693100 ; bool __thiscall QualityRegistrar::CallRemoveHandler(QualityRegistrar *this, CWeenieObject *cwobj, StatType stype, UInt32 senum) .text:00693100 ?CallRemoveHandler@QualityRegistrar@@QAE_NPAVCWeenieObject@@W4StatType@@K@Z

        // QualityRegistrar.UnRegisterAllQualityHandler:
        // public static delegate* unmanaged[Thiscall]<QualityRegistrar*,UInt32, Byte> UnRegisterAllQualityHandler = (delegate* unmanaged[Thiscall]<QualityRegistrar*,UInt32, Byte>)0xDEADBEEF; // .text:00693550 ; bool __thiscall QualityRegistrar::UnRegisterAllQualityHandler(QualityRegistrar *this, UInt32 i_iidTarget) .text:00693550 ?UnRegisterAllQualityHandler@QualityRegistrar@@UAE_NK@Z

        // QualityRegistrar.__Ctor:
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*> __Ctor = (delegate* unmanaged[Thiscall]<QualityRegistrar*>)0x006946D0; // .text:006937B0 ; void __thiscall QualityRegistrar::QualityRegistrar(QualityRegistrar *this) .text:006937B0 ??0QualityRegistrar@@QAE@XZ

        // QualityRegistrar.__Dtor:
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*> __Dtor = (delegate* unmanaged[Thiscall]<QualityRegistrar*>)0x00694870; // .text:00693950 ; void __thiscall QualityRegistrar::~QualityRegistrar(QualityRegistrar *this) .text:00693950 ??1QualityRegistrar@@UAE@XZ

        // QualityRegistrar.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<QualityRegistrar*, UInt32, void*>)0x006948D0; // .text:006939B0 ; void *__thiscall QualityRegistrar::`vector deleting destructor'(QualityRegistrar *this, UInt32) .text:006939B0 ??_EQualityRegistrar@@UAEPAXI@Z

        // Globals:
        public static QualityRegistrar* s_pQR = *(QualityRegistrar**)0x008F958C; // .data:008F858C ; QualityRegistrar *QualityRegistrar::s_pQR .data:008F858C ?s_pQR@QualityRegistrar@@1PAV1@A
    }
    public unsafe struct QualityRegistrarVtbl {
        // Struct:
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*, UInt32, void*> __vecDelDtor; //   void *(__thiscall *__vecDelDtor)(QualityRegistrar *this, UInt32);
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*, UInt32, StatType, UInt32, QualityChangeHandler*, Byte> RegisterQualityHandler; //   bool (__thiscall *RegisterQualityHandler)(QualityRegistrar *this, UInt32, StatType, UInt32, QualityChangeHandler *);
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*, StatType, UInt32, QualityChangeHandler*, Byte> RegisterQualityHandlerForThePlayer; //   bool (__thiscall *RegisterQualityHandlerForThePlayer)(QualityRegistrar *this, StatType, UInt32, QualityChangeHandler *);
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*, UInt32, StatType, UInt32, QualityChangeHandler*, Byte> UnRegisterQualityHandler; //   bool (__thiscall *UnRegisterQualityHandler)(QualityRegistrar *this, UInt32, StatType, UInt32, QualityChangeHandler *);
        public static delegate* unmanaged[Thiscall]<QualityRegistrar*, StatType, UInt32, QualityChangeHandler*, Byte> UnRegisterQualityHandlerForThePlayer; //   bool (__thiscall *UnRegisterQualityHandlerForThePlayer)(QualityRegistrar *this, StatType, UInt32, QualityChangeHandler *);
        public fixed Byte gap14[4];
        //public $A7B84804074FB71AAE824B0DAF3719B7 ___u5;

    }
    public unsafe struct QualityHandler {
        public IntrusiveHashData<UInt32, Int32> IntrusiveHashData; // PTR<QualityHandler>
        public HashTable<UInt64, PTR<SmartArray<PTR<QualityChangeHandler>>>> m_handlers;

        // Functions:

        // QualityHandler.Remove:
        // public static delegate* unmanaged[Thiscall]<QualityHandler*,QualityChangeHandler*, Byte> Remove = (delegate* unmanaged[Thiscall]<QualityHandler*,QualityChangeHandler*, Byte>)0xDEADBEEF; // .text:00692CB0 ; bool __thiscall QualityHandler::Remove(QualityHandler *this, QualityChangeHandler *i_pcHandler) .text:00692CB0 ?Remove@QualityHandler@@QAE_NPAVQualityChangeHandler@@@Z

        // QualityHandler.Remove:
        // public static delegate* unmanaged[Thiscall]<QualityHandler*,UInt64,QualityChangeHandler*, Byte> Remove = (delegate* unmanaged[Thiscall]<QualityHandler*,UInt64,QualityChangeHandler*, Byte>)0xDEADBEEF; // .text:00692E30 ; bool __thiscall QualityHandler::Remove(QualityHandler *this, UInt64 statCode, QualityChangeHandler *i_pcHandler) .text:00692E30 ?Remove@QualityHandler@@QAE_N_KPAVQualityChangeHandler@@@Z

        // QualityHandler.CallChangeHandler:
        // public static delegate* unmanaged[Thiscall]<QualityHandler*,CWeenieObject*,StatType,UInt32, Byte> CallChangeHandler = (delegate* unmanaged[Thiscall]<QualityHandler*,CWeenieObject*,StatType,UInt32, Byte>)0xDEADBEEF; // .text:00692E80 ; bool __thiscall QualityHandler::CallChangeHandler(QualityHandler *this, CWeenieObject *cwobj, StatType stype, UInt32 senum) .text:00692E80 ?CallChangeHandler@QualityHandler@@QAE_NPAVCWeenieObject@@W4StatType@@K@Z

        // QualityHandler.CallRemoveHandler:
        // public static delegate* unmanaged[Thiscall]<QualityHandler*,CWeenieObject*,StatType,UInt32, Byte> CallRemoveHandler = (delegate* unmanaged[Thiscall]<QualityHandler*,CWeenieObject*,StatType,UInt32, Byte>)0xDEADBEEF; // .text:00692F00 ; bool __thiscall QualityHandler::CallRemoveHandler(QualityHandler *this, CWeenieObject *cwobj, StatType stype, UInt32 senum) .text:00692F00 ?CallRemoveHandler@QualityHandler@@QAE_NPAVCWeenieObject@@W4StatType@@K@Z

        // QualityHandler.Add:
        public static delegate* unmanaged[Thiscall]<QualityHandler*, UInt64, QualityChangeHandler*, Byte> Add = (delegate* unmanaged[Thiscall]<QualityHandler*, UInt64, QualityChangeHandler*, Byte>)0x006944F0; // .text:006935D0 ; bool __thiscall QualityHandler::Add(QualityHandler *this, UInt64 statCode, QualityChangeHandler *i_pcHandler) .text:006935D0 ?Add@QualityHandler@@QAE_N_KPAVQualityChangeHandler@@@Z

        // QualityHandler.__Dtor:
        public static delegate* unmanaged[Thiscall]<QualityHandler*> __Dtor = (delegate* unmanaged[Thiscall]<QualityHandler*>)0x00694600; // .text:006936E0 ; void __thiscall QualityHandler::~QualityHandler(QualityHandler *this) .text:006936E0 ??1QualityHandler@@QAE@XZ

    };


    public unsafe struct CAsyncStateHandler {
        // Struct:
        public IntrusiveHashListData<Int32, Int32> hash;
        public CAsyncStateHandlerVtbl* vfptr;
        public CAsyncStateMachine* m_pMachine;
        public override string ToString() => $"hash(IntrusiveHashListData<Int32, PTR<CAsyncStateHandler>>):hash, vfptr:->(CAsyncStateHandlerVtbl*)0x{(Int32)vfptr:X8}, m_pMachine:->(CAsyncStateMachine*)0x{(Int32)m_pMachine:X8}";


        // Functions:

        // CAsyncStateHandler.__Ctor:
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, Int32> __Ctor = (delegate* unmanaged[Thiscall]<CAsyncStateHandler*, Int32>)0x0065ECE0; // .text:0065DC90 ; void __thiscall CAsyncStateHandler::CAsyncStateHandler(CAsyncStateHandler *this, Int32 StateNumber) .text:0065DC90 ??0CAsyncStateHandler@@QAE@H@Z

        // CAsyncStateHandler.GetContextData:
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext, UInt32, Int32> GetContextData = (delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext, UInt32, Int32>)0x0065F230; // .text:0065E1E0 ; Int32 __thiscall CAsyncStateHandler::GetContextData(CAsyncStateHandler *this, AsyncContext hContext, UInt32 dwDataIndex) .text:0065E1E0 ?GetContextData@CAsyncStateHandler@@IBEJVAsyncContext@@K@Z

        // CAsyncStateHandler.SetContextData:
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext, UInt32, Int32, Byte> SetContextData = (delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext, UInt32, Int32, Byte>)0x0065F240; // .text:0065E1F0 ; bool __thiscall CAsyncStateHandler::SetContextData(CAsyncStateHandler *this, AsyncContext hContext, UInt32 dwDataIndex, Int32 dwData) .text:0065E1F0 ?SetContextData@CAsyncStateHandler@@IAE_NVAsyncContext@@KJ@Z

        // CAsyncStateHandler.RegisterContextDataName:
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, PStringBase<Char>*, UInt32> RegisterContextDataName = (delegate* unmanaged[Thiscall]<CAsyncStateHandler*, PStringBase<Char>*, UInt32>)0x00660210; // .text:0065F270 ; UInt32 __thiscall CAsyncStateHandler::RegisterContextDataName(CAsyncStateHandler *this, PStringBase<Char> *DataName) .text:0065F270 ?RegisterContextDataName@CAsyncStateHandler@@IAEKABV?$PStringBase@D@@@Z

        // CAsyncStateHandler.__Dtor:
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*> __Dtor = (delegate* unmanaged[Thiscall]<CAsyncStateHandler*>)0x006605B0; // .text:0065F610 ; void __thiscall CAsyncStateHandler::~CAsyncStateHandler(CAsyncStateHandler *this) .text:0065F610 ??1CAsyncStateHandler@@UAE@XZ

        // CAsyncStateHandler.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<CAsyncStateHandler*,UInt32, void*>)0xDEADBEEF; // .text:0065F660 ; void *__thiscall CAsyncStateHandler::`vector deleting destructor'(CAsyncStateHandler *this, UInt32) .text:0065F660 ??_ECAsyncStateHandler@@UAEPAXI@Z

        // CAsyncStateHandler.EndStateOK:
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext, Int32, AsyncStateMachineStatus> EndStateOK = (delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext, Int32, AsyncStateMachineStatus>)0x0065EB50; // .text:0065DB50 ; AsyncStateMachineStatus __thiscall CAsyncStateHandler::EndStateOK(CAsyncStateHandler *this, AsyncContext hContext, Int32 NextStateNumber) .text:0065DB50 ?EndStateOK@CAsyncStateHandler@@IAE?AW4AsyncStateMachineStatus@@VAsyncContext@@H@Z

        // CAsyncStateHandler.EndStateFailed:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*,AsyncContext> EndStateFailed = (delegate* unmanaged[Thiscall]<CAsyncStateHandler*,AsyncContext>)0xDEADBEEF; // .text:0065DB60 ; void __thiscall CAsyncStateHandler::EndStateFailed(CAsyncStateHandler *this, AsyncContext hContext) .text:0065DB60 ?EndStateFailed@CAsyncStateHandler@@IAEXVAsyncContext@@@Z
    }

    public unsafe struct CAsyncStateHandlerVtbl {
        // Struct:
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, UInt32, void*> __vecDelDtor; //   void *(__thiscall *__vecDelDtor)(CAsyncStateHandler *this, UInt32);
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext> OnContextBegun; //   void (__thiscall *OnContextBegun)(CAsyncStateHandler *this, AsyncContext);
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext> OnStateBegun; //   void (__thiscall *OnStateBegun)(CAsyncStateHandler *this, AsyncContext);
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext, AsyncStateMachineStatus> OnStateEnded; //   void (__thiscall *OnStateEnded)(CAsyncStateHandler *this, AsyncContext, AsyncStateMachineStatus);
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext, AsyncStateMachineStatus> OnContextEnded; //   void (__thiscall *OnContextEnded)(CAsyncStateHandler *this, AsyncContext, AsyncStateMachineStatus);
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*, AsyncContext> CleanupContextData; //   void (__thiscall *CleanupContextData)(CAsyncStateHandler *this, AsyncContext);
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*> OnStateHandlerInit; //   void (__thiscall *OnStateHandlerInit)(CAsyncStateHandler *this);
        public static delegate* unmanaged[Thiscall]<CAsyncStateHandler*> OnStateHandlerDone; //   void (__thiscall *OnStateHandlerDone)(CAsyncStateHandler *this);
    }

    public unsafe struct CAsyncStateMachineVtbl {
        // Struct:
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*, UInt32, void*> __vecDelDtor; //   void *(__thiscall *__vecDelDtor)(CAsyncStateMachine *this, UInt32);
        public fixed Byte gap4[4];
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*, AsyncContext> OnContextBegun; //   void (__thiscall *OnContextBegun)(CAsyncStateMachine *this, AsyncContext);
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*, AsyncContext, AsyncStateMachineStatus> OnContextEnded; //   void (__thiscall *OnContextEnded)(CAsyncStateMachine *this, AsyncContext, AsyncStateMachineStatus);
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*, AsyncContext> CleanupContextData; //   void (__thiscall *CleanupContextData)(CAsyncStateMachine *this, AsyncContext);
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*, AsyncContext, Int32, AsyncStateMachineStatus> Advance; //   AsyncStateMachineStatus (__thiscall *Advance)(CAsyncStateMachine *this, AsyncContext, Int32);
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*, AsyncContext, Int32, AsyncStateMachineStatus> OnHandlerDoneOK; //   AsyncStateMachineStatus (__thiscall *OnHandlerDoneOK)(CAsyncStateMachine *this, AsyncContext, Int32);
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*, AsyncContext> OnHandlerFailed; //   void (__thiscall *OnHandlerFailed)(CAsyncStateMachine *this, AsyncContext);
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*, AsyncContext, CAsyncStateMachine.CAsyncStateData*> AllocateStateData; //   CAsyncStateMachine::CAsyncStateData *(__thiscall *AllocateStateData)(CAsyncStateMachine *this, AsyncContext);

    }



    public unsafe struct PreciseTimerInstance {
        // Struct:
        public TimerInstance<TimeSource_QueryPerformanceCounter> timer;
        public override string ToString() => $"timer(TimerInstance<TimeSource_QueryPerformanceCounter>):{timer}";


        // Functions:

        // PreciseTimerInstance.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<PreciseTimerInstance*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<PreciseTimerInstance*, UInt32, void*>)0x0040FC80; // .text:0040F980 ; void *__thiscall PreciseTimerInstance::`vector deleting destructor'(OutputDebugStringOutputHandler *this, UInt32) .text:0040F980 ??_EPreciseTimerInstance@@MAEPAXI@Z

        // PreciseTimerInstance.__Ctor:
        public static delegate* unmanaged[Thiscall]<PreciseTimerInstance*> __Ctor = (delegate* unmanaged[Thiscall]<PreciseTimerInstance*>)0x0040FC40; // .text:0040F9A0 ; void __thiscall PreciseTimerInstance::PreciseTimerInstance(PreciseTimerInstance *this) .text:0040F9A0 ??0PreciseTimerInstance@@QAE@XZ
    }

    public unsafe struct TimerInstance<T> where T : unmanaged {
        // Struct:
        public Turbine_RefCount _ref;
        public T m_cTimeSource;
        public Double m_rExternalOffset;
        public Double m_tElapsedTime;
        public Double m_tExternalTime;
        public Byte m_bInitialized;
        public override string ToString() => $"_ref(Turbine_RefCount):{_ref}, m_cTimeSource({typeof(T)}):{m_cTimeSource}, m_rExternalOffset:{m_rExternalOffset:n5}, m_tElapsedTime:{m_tElapsedTime:n5}, m_tExternalTime:{m_tExternalTime:n5}, m_bInitialized:{m_bInitialized:X2}";

    }
    public unsafe struct CSpinLock { // <512,0>
        // Struct:
        public volatile Int32 m_Lock;
        public UInt32 m_hCurThread;
        public UInt32 m_nEnterCount;
        public override string ToString() => $"m_Lock(volatile Int32):{m_Lock}, m_hCurThread:{m_hCurThread:X8}, m_nEnterCount:{m_nEnterCount:X8}";


        // Functions:

        // CSpinLock.Enter:
        public static delegate* unmanaged[Thiscall]<CSpinLock*> Enter = (delegate* unmanaged[Thiscall]<CSpinLock*>)0x00411140; // .text:00410DE0 ; void __thiscall CSpinLock::Enter(CSpinLock *this) .text:00410DE0 ?Enter@?$CSpinLock@$0CAA@$0A@@@QAEXXZ
    }

    public unsafe struct TimeSource_QueryPerformanceCounter {
        // Struct:
        public Double m_rPerfsPerSecond;
        public UInt64 m_qwPerfsPerMS;
        public UInt64 m_qwPerfCountTolerance;
        public TimeSource_QueryPerformanceCounter.StateData m_cVolatileState;
        public CSpinLock m_SpinLock; // <512,0>
        public override string ToString() => $"m_rPerfsPerSecond:{m_rPerfsPerSecond:n5}, m_qwPerfsPerMS(UInt64):{m_qwPerfsPerMS}, m_qwPerfCountTolerance(UInt64):{m_qwPerfCountTolerance}, m_cVolatileState(TimeSource_QueryPerformanceCounter.StateData):{m_cVolatileState}, m_SpinLock(CSpinLock):{m_SpinLock}";

        public unsafe struct StateData {
            public Double tLastTime;
            public UInt32 dwFlags;
            public Double tReference;
            public UInt32 dwReferenceTGT;
            public UInt64 qwReferenceQPC;
        };

        // Enums:
        public enum StateFlags : UInt32 {
            sfInitialized = 0x0,
            sfDisableQPC = 0x1,
        };

        // Functions:

        // TimeSource_QueryPerformanceCounter.__Ctor:
        public static delegate* unmanaged[Thiscall]<TimeSource_QueryPerformanceCounter*> __Ctor = (delegate* unmanaged[Thiscall]<TimeSource_QueryPerformanceCounter*>)0x00411190; // .text:00410E30 ; void __thiscall TimeSource_QueryPerformanceCounter::TimeSource_QueryPerformanceCounter(TimeSource_QueryPerformanceCounter *this) .text:00410E30 ??0TimeSource_QueryPerformanceCounter@@QAE@XZ

        // TimeSource_QueryPerformanceCounter.Init:
        public static delegate* unmanaged[Thiscall]<TimeSource_QueryPerformanceCounter*> Init = (delegate* unmanaged[Thiscall]<TimeSource_QueryPerformanceCounter*>)0x004111B0; // .text:00410E50 ; void __thiscall TimeSource_QueryPerformanceCounter::Init(TimeSource_QueryPerformanceCounter *this) .text:00410E50 ?Init@TimeSource_QueryPerformanceCounter@@QAEXXZ

        // TimeSource_QueryPerformanceCounter.ComputeElapsedTime:
        public static delegate* unmanaged[Thiscall]<TimeSource_QueryPerformanceCounter*, Byte, Double> ComputeElapsedTime = (delegate* unmanaged[Thiscall]<TimeSource_QueryPerformanceCounter*, Byte, Double>)0x00411280; // .text:00410F20 ; long Double __thiscall TimeSource_QueryPerformanceCounter::ComputeElapsedTime(TimeSource_QueryPerformanceCounter *this, bool i_bUpdateInternalData) .text:00410F20 ?ComputeElapsedTime@TimeSource_QueryPerformanceCounter@@QAEN_N@Z
    }




    public unsafe struct CAsyncStateMachine {
        // Struct:
        public CAsyncStateMachineVtbl* vfptr;
        public IntrusiveHashList<Int32, PTR<CAsyncStateHandler>> m_States;
        public Int32 m_iLowState;
        public IntrusiveHashList<AsyncContext, PTR<CAsyncStateMachine.CAsyncStateData>> m_ContextHash;
        public AutoGrowHashTable<PStringBase<Char>, UInt32> m_DataNames;
        public UInt32 m_dwNextContextNumber;
        public PreciseTimerInstance* m_pTimer;
        public override string ToString() => $"vfptr:->(CAsyncStateMachineVtbl*)0x{(Int32)vfptr:X8}, m_States(IntrusiveHashList<Int32,CAsyncStateHandler*,1>):{m_States}, m_iLowState:{m_iLowState}, m_ContextHash(IntrusiveHashList<AsyncContext,CAsyncStateMachine.CAsyncStateData*,1>):{m_ContextHash}, m_DataNames(AutoGrowHashTable<PStringBase<Char>,UInt32>):{m_DataNames}, m_dwNextContextNumber:{m_dwNextContextNumber:X8}, m_pTimer:->(PreciseTimerInstance*)0x{(Int32)m_pTimer:X8}";

        public unsafe struct CAsyncStateData {
            // Struct:
            public Turbine_RefCount _ref;
            public IntrusiveHashListData<AsyncContext, Int32> hash; // PTR<CAsyncStateMachine.CAsyncStateData>
            public SmartArray<UInt32> Data;
            public AsyncStateMachineStatus eStatus;
            public Byte bAdvancing;
            public Int32 iDelayedNextStateNumber;
            public CAsyncStateHandler* pCurrentState;
            public Int32 iMaxStateNumber;
            public Double tContextBegan;
            public Double tCurStateBegan;
            public override string ToString() => $"_ref(Turbine_RefCount):{_ref}, hash(IntrusiveHashListData<AsyncContext, PTR<CAsyncStateMachine.CAsyncStateData>>):{hash}, Data(SmartArray<UInt32,1>):{Data}, eStatus(AsyncStateMachineStatus):{eStatus}, bAdvancing:{bAdvancing:X2}, iDelayedNextStateNumber:{iDelayedNextStateNumber}, pCurrentState:->(CAsyncStateHandler*)0x{(Int32)pCurrentState:X8}, iMaxStateNumber:{iMaxStateNumber}, tContextBegan:{tContextBegan:n5}, tCurStateBegan:{tCurStateBegan:n5}";


            // Functions:

            // CAsyncStateMachine::CAsyncStateData.CAsyncStateData:
            // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine.CAsyncStateData*,AsyncContext> CAsyncStateData = (delegate* unmanaged[Thiscall]<CAsyncStateMachine.CAsyncStateData*,AsyncContext>)0xDEADBEEF; // .text:0065DCB0 ; void __thiscall CAsyncStateMachine::CAsyncStateData::CAsyncStateData(CAsyncStateMachine::CAsyncStateData *this, AsyncContext i_hKey) .text:0065DCB0 ??0CAsyncStateData@CAsyncStateMachine@@QAE@VAsyncContext@@@Z

            // CAsyncStateMachine::CAsyncStateData.__vecDelDtor:
            // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine.CAsyncStateData*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<CAsyncStateMachine.CAsyncStateData*,UInt32, void*>)0xDEADBEEF; // .text:0065DDC0 ; void *__thiscall CAsyncStateMachine::CAsyncStateData::`vector deleting destructor'(CAsyncStateMachine::CAsyncStateData *this, UInt32) .text:0065DDC0 ??_ECAsyncStateData@CAsyncStateMachine@@UAEPAXI@Z
        }


        // Functions:

        // CAsyncStateMachine.AddStateHandler:
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*, CAsyncStateHandler*, Byte> AddStateHandler = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*, CAsyncStateHandler*, Byte>)0x0065FC60; // .text:0065ECC0 ; bool __thiscall CAsyncStateMachine::AddStateHandler(CAsyncStateMachine *this, CAsyncStateHandler *pStateHandler) .text:0065ECC0 ?AddStateHandler@CAsyncStateMachine@@QAE_NPAVCAsyncStateHandler@@@Z

        // CAsyncStateMachine.RegisterContextDataName:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,PStringBase<Char>*, UInt32> RegisterContextDataName = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,PStringBase<Char>*, UInt32>)0xDEADBEEF; // .text:0065F150 ; UInt32 __thiscall CAsyncStateMachine::RegisterContextDataName(CAsyncStateMachine *this, PStringBase<Char> *DataName) .text:0065F150 ?RegisterContextDataName@CAsyncStateMachine@@QAEKABV?$PStringBase@D@@@Z

        // CAsyncStateMachine.__Ctor:
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*> __Ctor = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*>)0x00660220; // .text:0065F280 ; void __thiscall CAsyncStateMachine::CAsyncStateMachine(CAsyncStateMachine *this) .text:0065F280 ??0CAsyncStateMachine@@QAE@XZ

        // CAsyncStateMachine.__Dtor:
        public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*> __Dtor = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*>)0x006602C0; // .text:0065F320 ; void __thiscall CAsyncStateMachine::~CAsyncStateMachine(CAsyncStateMachine *this) .text:0065F320 ??1CAsyncStateMachine@@UAE@XZ

        // CAsyncStateMachine.AllocateStateData:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext, CAsyncStateMachine.CAsyncStateData*> AllocateStateData = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext, CAsyncStateMachine.CAsyncStateData*>)0xDEADBEEF; // .text:0065DD10 ; CAsyncStateMachine::CAsyncStateData *__thiscall CAsyncStateMachine::AllocateStateData(CAsyncStateMachine *this, AsyncContext hContext) .text:0065DD10 ?AllocateStateData@CAsyncStateMachine@@MAEPAUCAsyncStateData@1@VAsyncContext@@@Z

        // CAsyncStateMachine.CAsyncStateData.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine.CAsyncStateData*,UInt32, void*> CAsyncStateData.__vecDelDtor = (delegate* unmanaged[Thiscall]<CAsyncStateMachine.CAsyncStateData*,UInt32, void*>)0xDEADBEEF; // .text:0065DDC0 ; void *__thiscall CAsyncStateMachine::CAsyncStateData::`vector deleting destructor'(CAsyncStateMachine::CAsyncStateData *this, UInt32) .text:0065DDC0 ??_ECAsyncStateData@CAsyncStateMachine@@UAEPAXI@Z

        // CAsyncStateMachine.OnHandlerDoneOK:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,Int32, AsyncStateMachineStatus> OnHandlerDoneOK = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,Int32, AsyncStateMachineStatus>)0xDEADBEEF; // .text:0065F010 ; AsyncStateMachineStatus __thiscall CAsyncStateMachine::OnHandlerDoneOK(CAsyncStateMachine *this, AsyncContext hContext, Int32 NextStateNumber) .text:0065F010 ?OnHandlerDoneOK@CAsyncStateMachine@@MAE?AW4AsyncStateMachineStatus@@VAsyncContext@@H@Z

        // CAsyncStateMachine.AllocateAndBeginContext:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext*, AsyncContext*> AllocateAndBeginContext = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext*, AsyncContext*>)0xDEADBEEF; // .text:0065E200 ; AsyncContext *__thiscall CAsyncStateMachine::AllocateAndBeginContext(CAsyncStateMachine *this, AsyncContext *result) .text:0065E200 ?AllocateAndBeginContext@CAsyncStateMachine@@QAE?AVAsyncContext@@XZ

        // CAsyncStateMachine.AllocateContext:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext*, AsyncContext*> AllocateContext = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext*, AsyncContext*>)0xDEADBEEF; // .text:0065EE10 ; AsyncContext *__thiscall CAsyncStateMachine::AllocateContext(CAsyncStateMachine *this, AsyncContext *result) .text:0065EE10 ?AllocateContext@CAsyncStateMachine@@UAE?AVAsyncContext@@XZ

        // CAsyncStateMachine.EndAndReleaseContext:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,AsyncStateMachineStatus> EndAndReleaseContext = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,AsyncStateMachineStatus>)0xDEADBEEF; // .text:0065EED0 ; void __thiscall CAsyncStateMachine::EndAndReleaseContext(CAsyncStateMachine *this, AsyncContext hContext, AsyncStateMachineStatus i_eFinalStatus) .text:0065EED0 ?EndAndReleaseContext@CAsyncStateMachine@@IAEXVAsyncContext@@W4AsyncStateMachineStatus@@@Z

        // CAsyncStateMachine.__scaDelDtor:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,UInt32, void*>)0xDEADBEEF; // .text:0065F640 ; void *__thiscall CAsyncStateMachine::`scalar deleting destructor'(CAsyncStateMachine *this, UInt32) .text:0065F640 ??_GCAsyncStateMachine@@UAEPAXI@Z

        // CAsyncStateMachine.SetTimerInstance:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,PreciseTimerInstance*> SetTimerInstance = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,PreciseTimerInstance*>)0xDEADBEEF; // .text:0065DB70 ; void __thiscall CAsyncStateMachine::SetTimerInstance(CAsyncStateMachine *this, PreciseTimerInstance *i_pTimer) .text:0065DB70 ?SetTimerInstance@CAsyncStateMachine@@QAEXPBVPreciseTimerInstance@@@Z

        // CAsyncStateMachine.GetContextData:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,UInt32, Int32> GetContextData = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,UInt32, Int32>)0xDEADBEEF; // .text:0065DEA0 ; Int32 __thiscall CAsyncStateMachine::GetContextData(CAsyncStateMachine *this, AsyncContext hContext, UInt32 dwDataIndex) .text:0065DEA0 ?GetContextData@CAsyncStateMachine@@QBEJVAsyncContext@@K@Z

        // CAsyncStateMachine.SetContextData:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,UInt32,Int32, Byte> SetContextData = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,UInt32,Int32, Byte>)0xDEADBEEF; // .text:0065DEF0 ; bool __thiscall CAsyncStateMachine::SetContextData(CAsyncStateMachine *this, AsyncContext hContext, UInt32 dwDataIndex, Int32 dwData) .text:0065DEF0 ?SetContextData@CAsyncStateMachine@@QAE_NVAsyncContext@@KJ@Z

        // CAsyncStateMachine.OnHandlerFailed:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext> OnHandlerFailed = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext>)0xDEADBEEF; // .text:0065F040 ; void __thiscall CAsyncStateMachine::OnHandlerFailed(CAsyncStateMachine *this, AsyncContext hContext) .text:0065F040 ?OnHandlerFailed@CAsyncStateMachine@@MAEXVAsyncContext@@@Z

        // CAsyncStateMachine.RemoveStateHandler:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,Int32, Byte> RemoveStateHandler = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,Int32, Byte>)0xDEADBEEF; // .text:0065F540 ; bool __thiscall CAsyncStateMachine::RemoveStateHandler(CAsyncStateMachine *this, Int32 StateNumber) .text:0065F540 ?RemoveStateHandler@CAsyncStateMachine@@QAE_NH@Z

        // CAsyncStateMachine.CAsyncStateData.CAsyncStateData:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine.CAsyncStateData*,AsyncContext> CAsyncStateData.CAsyncStateData = (delegate* unmanaged[Thiscall]<CAsyncStateMachine.CAsyncStateData*,AsyncContext>)0xDEADBEEF; // .text:0065DCB0 ; void __thiscall CAsyncStateMachine::CAsyncStateData::CAsyncStateData(CAsyncStateMachine::CAsyncStateData *this, AsyncContext i_hKey) .text:0065DCB0 ??0CAsyncStateData@CAsyncStateMachine@@QAE@VAsyncContext@@@Z

        // CAsyncStateMachine.BeginContext:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,Int32, AsyncStateMachineStatus> BeginContext = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,Int32, AsyncStateMachineStatus>)0xDEADBEEF; // .text:0065DDF0 ; AsyncStateMachineStatus __thiscall CAsyncStateMachine::BeginContext(CAsyncStateMachine *this, AsyncContext hContext, Int32 StartState) .text:0065DDF0 ?BeginContext@CAsyncStateMachine@@QAE?AW4AsyncStateMachineStatus@@VAsyncContext@@H@Z

        // CAsyncStateMachine.Advance:
        // public static delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,Int32, AsyncStateMachineStatus> Advance = (delegate* unmanaged[Thiscall]<CAsyncStateMachine*,AsyncContext,Int32, AsyncStateMachineStatus>)0xDEADBEEF; // .text:0065DF40 ; AsyncStateMachineStatus __thiscall CAsyncStateMachine::Advance(CAsyncStateMachine *this, AsyncContext hContext, Int32 NextStateNumber) .text:0065DF40 ?Advance@CAsyncStateMachine@@MAE?AW4AsyncStateMachineStatus@@VAsyncContext@@H@Z
    }

    public unsafe struct CLinkStatusPlugin {
        // Struct:
        public CPluginPrototype CPluginPrototype;
        public override string ToString() => $"CPluginPrototype(CPluginPrototype):{CPluginPrototype}";

    }


    public unsafe struct CClientsideLoginStateHandler {
        // Struct:
        public CAsyncStateHandler CAsyncStateHandler;
        public UInt32 m_idxRecipientID;
        public UInt32 m_idxServerAddr;
        public UInt32 m_idxNetAuth;
        public UInt32 m_idxFailureReason;
        public override string ToString() => $"CAsyncStateHandler(CAsyncStateHandler):{CAsyncStateHandler}, m_idxRecipientID:{m_idxRecipientID:X8}, m_idxServerAddr:{m_idxServerAddr:X8}, m_idxNetAuth:{m_idxNetAuth:X8}, m_idxFailureReason:{m_idxFailureReason:X8}";


        // Functions:

        // CClientsideLoginStateHandler.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<CClientsideLoginStateHandler*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<CClientsideLoginStateHandler*, UInt32, void*>)0x00543010; // .text:00542430 ; void *__thiscall CClientsideLoginStateHandler::`vector deleting destructor'(CClientsideLoginStateHandler *this, UInt32) .text:00542430 ??_ECClientsideLoginStateHandler@@UAEPAXI@Z

        // CClientsideLoginStateHandler.OnStateHandlerInit:
        public static delegate* unmanaged[Thiscall]<CClientsideLoginStateHandler*> OnStateHandlerInit = (delegate* unmanaged[Thiscall]<CClientsideLoginStateHandler*>)0x00545150; // .text:00544590 ; void __thiscall CClientsideLoginStateHandler::OnStateHandlerInit(CClientsideLoginStateHandler *this) .text:00544590 ?OnStateHandlerInit@CClientsideLoginStateHandler@@MAEXXZ
    }
    public unsafe struct PacketStatsIncoming {
        public UInt32 cBad;
        public UInt32 cMisc;
        public UInt32 cAck;
        public UInt32 cNak;
        public UInt32 cPak;
        public UInt32 cHeaderOnly;
        public UInt32 cDataOnly;
        public UInt32 cHeaderAndData;
    };

    public unsafe struct CQuickTimer {
        // Struct:
        public UInt32 m_dwStart;
        public UInt32 m_dwInterval;
        public override string ToString() => $"m_dwStart:{m_dwStart:X8}, m_dwInterval:{m_dwInterval:X8}";

    }

    public unsafe struct sockaddr {
        // Struct:
        public UInt16 sa_family;
        public fixed Char sa_data[14];
        public override string ToString() => $"sa_family:{sa_family:X4}, sa_data[14]:{sa_data[14]}";

    }
    public unsafe struct PacketInfo {
        // Struct:
        public UInt32 cbPacketInfo;
        public sockaddr* saRemote;
        public UInt32 cbData;
        public void* pvData;
        public _WSABUF* aIOVecs;
        public UInt32 nVecs;
        public UInt32 cbRemote;
        public PacketInfo.Protocol eProto;
        public _WSABUF iovOldSchool;
        public override string ToString() => $"cbPacketInfo:{cbPacketInfo:X8}, saRemote:->(sockaddr*)0x{(Int32)saRemote:X8}, cbData:{cbData:X8}, pvData:->(void*)0x{(Int32)pvData:X8}, aIOVecs:->(_WSABUF*)0x{(Int32)aIOVecs:X8}, nVecs:{nVecs:X8}, cbRemote:{cbRemote:X8}, eProto(PacketInfo.Protocol):{eProto}, iovOldSchool(_WSABUF):{iovOldSchool}";

        // Enums:
        public enum Protocol : UInt32 {
            fe_tcp = 0x0,
            be_tcp = 0x1,
            fe_udp = 0x2,
        };
    }

    public unsafe struct LoggingFunctions {
        // Struct:
        public static delegate* unmanaged[Cdecl]<PacketInfo*, UInt32> pfnRecvLogger; //   void (__cdecl *pfnRecvLogger)(PacketInfo *, UInt32);
        public static delegate* unmanaged[Cdecl]<PacketInfo*, UInt32> pfnSendLogger; //   void (__cdecl *pfnSendLogger)(PacketInfo *, UInt32);
        public static delegate* unmanaged[Cdecl]<PacketInfo*, UInt32> pfnUncompressedRecvLogger; //   void (__cdecl *pfnUncompressedRecvLogger)(PacketInfo *, UInt32);
        public static delegate* unmanaged[Cdecl]<PacketInfo*, UInt32> pfnUncompressedSendLogger; //   void (__cdecl *pfnUncompressedSendLogger)(PacketInfo *, UInt32);
        public UInt32 dwUserLoggingData;
    }

    public unsafe struct CNetLayerPacket {
        // Struct:
        public NetPacket NetPacket;
        public ProtoHeader m_Hdr;
        public fixed Char m_Data[65484];
        public sockaddr_in m_Addr;
        public CBufferIterator m_Iter;
        public Byte m_bValid;
        public ReceiverData* m_pRecv;
        public RecipientData* m_pRecip;
        public UInt32 m_CryptoKey;
        public override string ToString() => $"NetPacket(NetPacket):{NetPacket}, m_Hdr(ProtoHeader):{m_Hdr}, m_Data[65484]:{m_Data[65484]}, m_Addr(sockaddr_in):{m_Addr}, m_Iter(CBufferIterator):{m_Iter}, m_bValid:{m_bValid:X2}, m_pRecv:->(ReceiverData*)0x{(Int32)m_pRecv:X8}, m_pRecip:->(RecipientData*)0x{(Int32)m_pRecip:X8}, m_CryptoKey:{m_CryptoKey:X8}";


        // Functions:

        // CNetLayerPacket.__scaDelDtor:
        public static delegate* unmanaged[Thiscall]<CNetLayerPacket*, UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<CNetLayerPacket*, UInt32, void*>)0x005437E0; // .text:00542C20 ; void *__thiscall CNetLayerPacket::`scalar deleting destructor'(CNetLayerPacket *this, UInt32) .text:00542C20 ??_GCNetLayerPacket@@UAEPAXI@Z

        // CNetLayerPacket.__Ctor:
        public static delegate* unmanaged[Thiscall]<CNetLayerPacket*> __Ctor = (delegate* unmanaged[Thiscall]<CNetLayerPacket*>)0x005AB5F0; // .text:005AA540 ; void __thiscall CNetLayerPacket::CNetLayerPacket(CNetLayerPacket *this) .text:005AA540 ??0CNetLayerPacket@@IAE@XZ

        // CNetLayerPacket.Clear:
        public static delegate* unmanaged[Thiscall]<CNetLayerPacket*> Clear = (delegate* unmanaged[Thiscall]<CNetLayerPacket*>)0x005AB6C0; // .text:005AA610 ; void __thiscall CNetLayerPacket::Clear(CNetLayerPacket *this) .text:005AA610 ?Clear@CNetLayerPacket@@QAEXXZ

        // CNetLayerPacket.Create:
        // (ERR) .text:005AB6A0 ; public: static class CNetLayerPacket * __cdecl CNetLayerPacket::Create(void) .text:005AB6A0 ?Create@CNetLayerPacket@@SAPAV1@XZ
    }



    public unsafe struct CSeqIDListHeader_8192_33_ {
        // Struct:
        public COptionalHeader COptionalHeader;
        public fixed UInt32 m_IDs[115];
        public override string ToString() => $"COptionalHeader(COptionalHeader):{COptionalHeader}, m_IDs[0]:{m_IDs[0]:X8}";


        // Functions:

        // CSeqIDListHeader<8192,33>.__Ctor:
        public static delegate* unmanaged[Thiscall]<CSeqIDListHeader_8192_33_*, UInt32*, UInt32> __Ctor = (delegate* unmanaged[Thiscall]<CSeqIDListHeader_8192_33_*, UInt32*, UInt32>)0x00548130; // .text:00547570 ; void __thiscall CSeqIDListHeader<8192,33>::CSeqIDListHeader<8192,33>(CSeqIDListHeader<8192,33> *this, UInt32 *IDs, UInt32 nIDs) .text:00547570 ??0?$CSeqIDListHeader@$0CAAA@$0CB@@@IAE@PAKK@Z

        // CSeqIDListHeader<8192,33>.CreateFromStream:
        public static delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*> CreateFromStream = (delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*>)0x005ABEA0; // .text:005AADF0 ; COptionalHeader *__cdecl CSeqIDListHeader<8192,33>::CreateFromStream(CBufferIterator *Buf) .text:005AADF0 ?CreateFromStream@?$CSeqIDListHeader@$0CAAA@$0CB@@@SAPAVCOptionalHeader@@AAVCBufferIterator@@@Z

        // Globals:
        // public static COptionalHeaderAllocatorTemplate<8192,CSeqIDListHeader<8192,33> >* FactoryPlugin = (COptionalHeaderAllocatorTemplate<8192,CSeqIDListHeader<8192,33> >*)0xDEADBEEF; // .data:008EE0DD ; COptionalHeaderAllocatorTemplate<8192,CSeqIDListHeader<8192,33> > CSeqIDListHeader<8192,33>::FactoryPlugin .data:008EE0DD ?FactoryPlugin@?$CSeqIDListHeader@$0CAAA@$0CB@@@1V?$COptionalHeaderAllocatorTemplate@$0CAAA@V?$CSeqIDListHeader@$0CAAA@$0CB@@@@@A
    }
    public unsafe struct CSeqIDListHeader_4096_33_ {
        // Struct:
        public COptionalHeader COptionalHeader;
        public fixed UInt32 m_IDs[115];
        public override string ToString() => $"COptionalHeader(COptionalHeader):{COptionalHeader}, m_IDs[0]:{m_IDs[0]:X8}";


        // Functions:

        // CSeqIDListHeader<4096,33>.CreateFromStream:
        public static delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*> CreateFromStream = (delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*>)0x005ABD60; // .text:005AACB0 ; COptionalHeader *__cdecl CSeqIDListHeader<4096,33>::CreateFromStream(CBufferIterator *Buf) .text:005AACB0 ?CreateFromStream@?$CSeqIDListHeader@$0BAAA@$0CB@@@SAPAVCOptionalHeader@@AAVCBufferIterator@@@Z

        // Globals:
        // public static COptionalHeaderAllocatorTemplate<4096,CSeqIDListHeader<4096,33> >* FactoryPlugin = (COptionalHeaderAllocatorTemplate<4096,CSeqIDListHeader<4096,33> >*)0xDEADBEEF; // .data:008EE0DB ; COptionalHeaderAllocatorTemplate<4096,CSeqIDListHeader<4096,33> > CSeqIDListHeader<4096,33>::FactoryPlugin .data:008EE0DB ?FactoryPlugin@?$CSeqIDListHeader@$0BAAA@$0CB@@@1V?$COptionalHeaderAllocatorTemplate@$0BAAA@V?$CSeqIDListHeader@$0BAAA@$0CB@@@@@A
    }

    public unsafe struct CTimeSyncHeader {
        // Struct:
        public COptionalHeader COptionalHeader;
        public Double m_time;
        public override string ToString() => $"COptionalHeader(COptionalHeader):{COptionalHeader}, m_time:{m_time:n5}";


        // Functions:

        // CTimeSyncHeader.UpdateTimeSensitivePayload:
        public static delegate* unmanaged[Thiscall]<CTimeSyncHeader*, Int32> UpdateTimeSensitivePayload = (delegate* unmanaged[Thiscall]<CTimeSyncHeader*, Int32>)0x00547E50; // .text:00547290 ; Int32 __thiscall CTimeSyncHeader::UpdateTimeSensitivePayload(CTimeSyncHeader *this) .text:00547290 ?UpdateTimeSensitivePayload@CTimeSyncHeader@@UAEHXZ

        // CTimeSyncHeader.CreateFromData:
        public static delegate* unmanaged[Cdecl]<Double, COptionalHeader*> CreateFromData = (delegate* unmanaged[Cdecl]<Double, COptionalHeader*>)0x00548190; // .text:005475D0 ; COptionalHeader *__cdecl CTimeSyncHeader::CreateFromData(long Double time) .text:005475D0 ?CreateFromData@CTimeSyncHeader@@SAPAVCOptionalHeader@@N@Z

        // CTimeSyncHeader.CreateFromStream:
        public static delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*> CreateFromStream = (delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*>)0x005ABAB0; // .text:005AAA00 ; COptionalHeader *__cdecl CTimeSyncHeader::CreateFromStream(CBufferIterator *Buf) .text:005AAA00 ?CreateFromStream@CTimeSyncHeader@@SAPAVCOptionalHeader@@AAVCBufferIterator@@@Z

        // Globals:
        // public static COptionalHeaderAllocatorTemplate<16777216,CTimeSyncHeader>* FactoryPlugin = (COptionalHeaderAllocatorTemplate<16777216,CTimeSyncHeader>*)0xDEADBEEF; // .data:008EE0D9 ; COptionalHeaderAllocatorTemplate<16777216,CTimeSyncHeader> CTimeSyncHeader::FactoryPlugin .data:008EE0D9 ?FactoryPlugin@CTimeSyncHeader@@0V?$COptionalHeaderAllocatorTemplate@$0BAAAAAA@VCTimeSyncHeader@@@@A
    }

    public unsafe struct COnePrimHeader_16384_1_UInt32_ {
        // Struct:
        public COptionalHeader COptionalHeader;
        public UInt32 m_Prim;
        public override string ToString() => $"COptionalHeader(COptionalHeader):{COptionalHeader}, m_Prim:{m_Prim:X8}";


        // Functions:

        // COnePrimHeader<16384,1,UInt32>.CreateFromStream:
        public static delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*> CreateFromStream = (delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*>)0x005ABE40; // .text:005AAD90 ; COptionalHeader *__cdecl COnePrimHeader<16384,1,UInt32>::CreateFromStream(CBufferIterator *Buf) .text:005AAD90 ?CreateFromStream@?$COnePrimHeader@$0EAAA@$00K@@SAPAVCOptionalHeader@@AAVCBufferIterator@@@Z

        // Globals:
        // public static COptionalHeaderAllocatorTemplate<16384,COnePrimHeader<16384,1,UInt32> >* FactoryPlugin = (COptionalHeaderAllocatorTemplate<16384,COnePrimHeader<16384,1,UInt32> >*)0xDEADBEEF; // .data:008EE0DC ; COptionalHeaderAllocatorTemplate<16384,COnePrimHeader<16384,1,UInt32> > COnePrimHeader<16384,1,UInt32>::FactoryPlugin .data:008EE0DC ?FactoryPlugin@?$COnePrimHeader@$0EAAA@$00K@@0V?$COptionalHeaderAllocatorTemplate@$0EAAA@V?$COnePrimHeader@$0EAAA@$00K@@@@A
    }


    public unsafe struct CConnectData {
        // Struct:
        public Double ServerTime;
        public UInt64 qwCookie;
        public UInt32 NetID;
        public UInt32 OutgoingSeed;
        public UInt32 IncomingSeed;
        public override string ToString() => $"ServerTime:{ServerTime:n5}, qwCookie(UInt64):{qwCookie:x16}, NetID:{NetID}, OutgoingSeed:{OutgoingSeed:X8}, IncomingSeed:{IncomingSeed:X8}";

    }

    public unsafe struct CConnectHeader {
        // Struct:
        public COptionalHeader COptionalHeader;
        public CConnectData m_Data;
        public override string ToString() => $"COptionalHeader(COptionalHeader):{COptionalHeader}, m_Data(CConnectData):{m_Data}";


        // Functions:

        // CConnectHeader.CreateFromStream:
        public static delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*> CreateFromStream = (delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*>)0x005ABC40; // .text:005AAB90 ; COptionalHeader *__cdecl CConnectHeader::CreateFromStream(CBufferIterator *Buf) .text:005AAB90 ?CreateFromStream@CConnectHeader@@SAPAVCOptionalHeader@@AAVCBufferIterator@@@Z

        // Globals:
        // public static COptionalHeaderAllocatorTemplate<262144,CConnectHeader>* FactoryPlugin = (COptionalHeaderAllocatorTemplate<262144,CConnectHeader>*)0xDEADBEEF; // .data:008EE0E4 ; COptionalHeaderAllocatorTemplate<262144,CConnectHeader> CConnectHeader::FactoryPlugin .data:008EE0E4 ?FactoryPlugin@CConnectHeader@@0V?$COptionalHeaderAllocatorTemplate@$0EAAAA@VCConnectHeader@@@@A
    }

    public unsafe struct CReferralStruct {
        // Struct:
        public UInt64 qwCookie;
        public sockaddr_in Addr;
        public UInt16 idServer;
        public UInt16 padding;
        public override string ToString() => $"qwCookie(UInt64):{qwCookie:x16}, Addr(sockaddr_in):{Addr}, idServer:{idServer}, padding:{padding:X4}";

    }
    public unsafe struct COnePrimHeader_2048_1073741922_CReferralStruct_ {
        // Struct:
        public COptionalHeader COptionalHeader;
        public CReferralStruct m_Prim;
        public override string ToString() => $"COptionalHeader(COptionalHeader):{COptionalHeader}, m_Prim(CReferralStruct):{m_Prim}";


        // Functions:

        // COnePrimHeader<2048,1073741922,CReferralStruct>.CreateFromData:
        // public static delegate* unmanaged[Cdecl]<CReferralStruct, COptionalHeader*> CreateFromData = (delegate* unmanaged[Cdecl]<CReferralStruct, COptionalHeader*>)0xDEADBEEF; // .text:00543730 ; COptionalHeader *__cdecl COnePrimHeader<2048,1073741922,CReferralStruct>::CreateFromData(CReferralStruct Prim) .text:00543730 ?CreateFromData@?$COnePrimHeader@$0IAA@$0EAAAAAGC@UCReferralStruct@@@@SAPAVCOptionalHeader@@UCReferralStruct@@@Z

        // COnePrimHeader<2048,1073741922,CReferralStruct>.CreateFromStream:
        // public static delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*> CreateFromStream = (delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*>)0xDEADBEEF; // .text:005AB100 ; COptionalHeader *__cdecl COnePrimHeader<2048,1073741922,CReferralStruct>::CreateFromStream(CBufferIterator *Buf) .text:005AB100 ?CreateFromStream@?$COnePrimHeader@$0IAA@$0EAAAAAGC@UCReferralStruct@@@@SAPAVCOptionalHeader@@AAVCBufferIterator@@@Z

        // Globals:
        // public static COptionalHeaderAllocatorTemplate<2048,COnePrimHeader<2048,1073741922,CReferralStruct> >* FactoryPlugin = (COptionalHeaderAllocatorTemplate<2048,COnePrimHeader<2048,1073741922,CReferralStruct> >*)0xDEADBEEF; // .data:008EE0E8 ; COptionalHeaderAllocatorTemplate<2048,COnePrimHeader<2048,1073741922,CReferralStruct> > COnePrimHeader<2048,1073741922,CReferralStruct>::FactoryPlugin .data:008EE0E8 ?FactoryPlugin@?$COnePrimHeader@$0IAA@$0EAAAAAGC@UCReferralStruct@@@@0V?$COptionalHeaderAllocatorTemplate@$0IAA@V?$COnePrimHeader@$0IAA@$0EAAAAAGC@UCReferralStruct@@@@@@A
    }


    public unsafe struct CServerSwitchStruct {
        // Struct:
        public CTimestamp<UInt32> dwSeqNo;
        public ServerSwitchType Type;
        public override string ToString() => $"dwSeqNo(CTimestamp<UInt32>):{dwSeqNo}, Type(ServerSwitchType):{Type}";
    }

    public unsafe struct COnePrimHeader_256_96_CServerSwitchStruct_ {
        // Struct:
        public COptionalHeader COptionalHeader;
        public CServerSwitchStruct m_Prim;
        public override string ToString() => $"COptionalHeader(COptionalHeader):{COptionalHeader}, m_Prim(CServerSwitchStruct):{m_Prim}";


        // Functions:

        // COnePrimHeader<256,96,CServerSwitchStruct>.CreateFromStream:
        // public static delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*> CreateFromStream = (delegate* unmanaged[Cdecl]<CBufferIterator*, COptionalHeader*>)0xDEADBEEF; // .text:005AB030 ; COptionalHeader *__cdecl COnePrimHeader<256,96,CServerSwitchStruct>::CreateFromStream(CBufferIterator *Buf) .text:005AB030 ?CreateFromStream@?$COnePrimHeader@$0BAA@$0GA@UCServerSwitchStruct@@@@SAPAVCOptionalHeader@@AAVCBufferIterator@@@Z

        // Globals:
        // public static COptionalHeaderAllocatorTemplate<256,COnePrimHeader<256,96,CServerSwitchStruct> >* FactoryPlugin = (COptionalHeaderAllocatorTemplate<256,COnePrimHeader<256,96,CServerSwitchStruct> >*)0xDEADBEEF; // .data:008EE0E6 ; COptionalHeaderAllocatorTemplate<256,COnePrimHeader<256,96,CServerSwitchStruct> > COnePrimHeader<256,96,CServerSwitchStruct>::FactoryPlugin .data:008EE0E6 ?FactoryPlugin@?$COnePrimHeader@$0BAA@$0GA@UCServerSwitchStruct@@@@0V?$COptionalHeaderAllocatorTemplate@$0BAA@V?$COnePrimHeader@$0BAA@$0GA@UCServerSwitchStruct@@@@@@A
    }







    public unsafe struct SharedNet {
        // Struct:
        public Vtbl* vfptr;
        public fixed Byte _gap[4];
        public UInt32 m_sockRead;
        public UInt32 m_sockWrite;
        public PortalDH* dh_;
        public UInt16 netID_;
        public fixed Byte receivers_[34816];
        public ReceiverData* connectionsHead_;
        public ReceiverData* connectionsTail_;
        public Double lastDidUseTime_;
        public CQuickTimer m_UseTime_TimeLimit;
        public PacketStatsIncoming m_packetStatsIncoming;
        public PerfMonCounter<UInt64>* m_pBytesSentCounter;
        public PerfMonCounter<UInt64>* m_pBytesReceivedCounter;
        public PerfMonCounter<UInt64>* m_pBadPacketsReceivedCounter;
        public PerfMonCounter<UInt64>* m_pBadPacketsReceivedRawCounter;
        public PerfMonCounter<UInt64>* m_pPacketsRetransmittedCounter;
        public LoggingFunctions m_Loggers;
        public CNetLayerPacket* m_pIncomingPacket;
        public override string ToString() => $"vfptr:->(SharedNetVtbl*)0x{(Int32)vfptr:X8}, m_sockRead:{m_sockRead:X8}, m_sockWrite:{m_sockWrite:X8}, dh_:->(PortalDH*)0x{(Int32)dh_:X8}, netID_:{netID_:X4}, connectionsHead_:->(ReceiverData*)0x{(Int32)connectionsHead_:X8}, connectionsTail_:->(ReceiverData*)0x{(Int32)connectionsTail_:X8}, lastDidUseTime_:{lastDidUseTime_:n5}, m_UseTime_TimeLimit(CQuickTimer):{m_UseTime_TimeLimit}, m_packetStatsIncoming($03CB7E004CA5755A24201E14CFC75D1E):{m_packetStatsIncoming}, m_pBytesSentCounter:->(PerfMonCounter<UInt64>*)0x{(Int32)m_pBytesSentCounter:X8}, m_pBytesReceivedCounter:->(PerfMonCounter<UInt64>*)0x{(Int32)m_pBytesReceivedCounter:X8}, m_pBadPacketsReceivedCounter:->(PerfMonCounter<UInt64>*)0x{(Int32)m_pBadPacketsReceivedCounter:X8}, m_pBadPacketsReceivedRawCounter:->(PerfMonCounter<UInt64>*)0x{(Int32)m_pBadPacketsReceivedRawCounter:X8}, m_pPacketsRetransmittedCounter:->(PerfMonCounter<UInt64>*)0x{(Int32)m_pPacketsRetransmittedCounter:X8}, m_Loggers(LoggingFunctions):{m_Loggers}, m_pIncomingPacket:->(CNetLayerPacket*)0x{(Int32)m_pIncomingPacket:X8}";


        public unsafe struct Vtbl {
            // Struct:
            public static delegate* unmanaged[Thiscall]<SharedNet*, NetPerfCounter, Int32> AddToPerfCounter; //   void (__thiscall *AddToPerfCounter)(SharedNet *this, NetPerfCounter, Int32);
            public fixed Byte gap4[8];
            public static delegate* unmanaged[Thiscall]<SharedNet*, ReceiverData*, Byte> ProcessConnection; //   bool (__thiscall *ProcessConnection)(SharedNet *this, ReceiverData *);
            public static delegate* unmanaged[Thiscall]<SharedNet*> OnUseTimeTimeout; //   void (__thiscall *OnUseTimeTimeout)(SharedNet *this);
            public static delegate* unmanaged[Thiscall]<SharedNet*> BeforeCheckingSocket; //   void (__thiscall *BeforeCheckingSocket)(SharedNet *this);
            public static delegate* unmanaged[Thiscall]<SharedNet*, Byte> ReadAndProcessPackets; //   bool (__thiscall *ReadAndProcessPackets)(SharedNet *this);
            public static delegate* unmanaged[Thiscall]<SharedNet*, UInt32, CNetLayerPacket*, Int32> ReadNextPacket; //   Int32 (__thiscall *ReadNextPacket)(SharedNet *this, UInt32, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> ProcessPacket; //   bool (__thiscall *ProcessPacket)(SharedNet *this, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> VerifyHeader; //   bool (__thiscall *VerifyHeader)(SharedNet *this, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> SplitPacketData; //   bool (__thiscall *SplitPacketData)(SharedNet *this, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> ProcessNewRemoteInterval; //   bool (__thiscall *ProcessNewRemoteInterval)(SharedNet *this, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> ProcessOptionalHeaders; //   bool (__thiscall *ProcessOptionalHeaders)(SharedNet *this, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, COptionalHeader*, CNetLayerPacket*, Byte> ProcessOptionalHeader; //   bool (__thiscall *ProcessOptionalHeader)(SharedNet *this, COptionalHeader *, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> ProcessBlobFrags; //   bool (__thiscall *ProcessBlobFrags)(SharedNet *this, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, UInt16, ConnectionState> SetConnectionState; //   void (__thiscall *SetConnectionState)(SharedNet *this, U__Int3216, ConnectionState);
            public static delegate* unmanaged[Thiscall]<SharedNet*, CTimeSyncHeader*, CNetLayerPacket*> HandleTimeSynch; //   void (__thiscall *HandleTimeSynch)(SharedNet *this, CTimeSyncHeader *, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, CSeqIDListHeader_4096_33_*, CNetLayerPacket*> HandleNak; //   void (__thiscall *HandleNak)(SharedNet *this, CSeqIDListHeader<4096,33> *, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, COnePrimHeader_16384_1_UInt32_*, CNetLayerPacket*> HandlePak; //   void (__thiscall *HandlePak)(SharedNet *this, COnePrimHeader<16384,1,UInt32> *, CNetLayerPacket *);
            public static delegate* unmanaged[Thiscall]<SharedNet*, CSeqIDListHeader_8192_33_*, CNetLayerPacket*> HandleEmptyAck; //   void (__thiscall *HandleEmptyAck)(SharedNet *this, CSeqIDListHeader<8192,33> *, CNetLayerPacket *);
        }
        // Functions:

        // SharedNet.HandleNak:
        public static delegate* unmanaged[Thiscall]<SharedNet*, CSeqIDListHeader_4096_33_*, CNetLayerPacket*> HandleNak = (delegate* unmanaged[Thiscall]<SharedNet*, CSeqIDListHeader_4096_33_*, CNetLayerPacket*>)0x00543280; // .text:005426A0 ; void __thiscall SharedNet::HandleNak(SharedNet *this, CSeqIDListHeader<4096,33> *pNakHdr, CNetLayerPacket *pkt) .text:005426A0 ?HandleNak@SharedNet@@MAEXPBV?$CSeqIDListHeader@$0BAAA@$0CB@@@ABVCNetLayerPacket@@@Z

        // SharedNet.ProcessConnections:
        public static delegate* unmanaged[Thiscall]<SharedNet*, Byte> ProcessConnections = (delegate* unmanaged[Thiscall]<SharedNet*, Byte>)0x005432D0; // .text:005426F0 ; bool __thiscall SharedNet::ProcessConnections(SharedNet *this) .text:005426F0 ?ProcessConnections@SharedNet@@MAE_NXZ

        // SharedNet.ProcessNewRemoteInterval:
        public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> ProcessNewRemoteInterval = (delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte>)0x00544640; // .text:00543A80 ; bool __thiscall SharedNet::ProcessNewRemoteInterval(SharedNet *this, CNetLayerPacket *pkt) .text:00543A80 ?ProcessNewRemoteInterval@SharedNet@@MAE_NABVCNetLayerPacket@@@Z

        // SharedNet.HandleEmptyAck:
        public static delegate* unmanaged[Thiscall]<SharedNet*, CSeqIDListHeader_8192_33_*, CNetLayerPacket*> HandleEmptyAck = (delegate* unmanaged[Thiscall]<SharedNet*, CSeqIDListHeader_8192_33_*, CNetLayerPacket*>)0x005454B0; // .text:005448F0 ; void __thiscall SharedNet::HandleEmptyAck(SharedNet *this, CSeqIDListHeader<8192,33> *pPakHdr, CNetLayerPacket *pkt) .text:005448F0 ?HandleEmptyAck@SharedNet@@MAEXPBV?$CSeqIDListHeader@$0CAAA@$0CB@@@ABVCNetLayerPacket@@@Z

        // SharedNet.ReadNextPacket:
        public static delegate* unmanaged[Thiscall]<SharedNet*, UInt32, CNetLayerPacket*, Int32> ReadNextPacket = (delegate* unmanaged[Thiscall]<SharedNet*, UInt32, CNetLayerPacket*, Int32>)0x00543140; // .text:00542560 ; Int32 __thiscall SharedNet::ReadNextPacket(SharedNet *this, UInt32 S, CNetLayerPacket *pkt) .text:00542560 ?ReadNextPacket@SharedNet@@MAEHIAAVCNetLayerPacket@@@Z

        // SharedNet.ReadAndProcessPackets:
        public static delegate* unmanaged[Thiscall]<SharedNet*, Byte> ReadAndProcessPackets = (delegate* unmanaged[Thiscall]<SharedNet*, Byte>)0x005430C0; // .text:005424E0 ; bool __thiscall SharedNet::ReadAndProcessPackets(SharedNet *this) .text:005424E0 ?ReadAndProcessPackets@SharedNet@@MAE_NXZ

        // SharedNet.AddToPerfCounter:
        public static delegate* unmanaged[Thiscall]<SharedNet*, NetPerfCounter, Int32> AddToPerfCounter = (delegate* unmanaged[Thiscall]<SharedNet*, NetPerfCounter, Int32>)0x00543350; // .text:00542770 ; void __thiscall SharedNet::AddToPerfCounter(SharedNet *this, NetPerfCounter WhichCounter, Int32 n) .text:00542770 ?AddToPerfCounter@SharedNet@@UAEXW4NetPerfCounter@@H@Z

        // SharedNet.SplitPacketData:
        public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> SplitPacketData = (delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte>)0x005439F0; // .text:00542E30 ; bool __thiscall SharedNet::SplitPacketData(SharedNet *this, CNetLayerPacket *pkt) .text:00542E30 ?SplitPacketData@SharedNet@@MAE_NAAVCNetLayerPacket@@@Z

        // SharedNet.SeqIDSanityCheck:
        public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> SeqIDSanityCheck = (delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte>)0x005445E0; // .text:00543A20 ; bool __thiscall SharedNet::SeqIDSanityCheck(SharedNet *this, CNetLayerPacket *pkt) .text:00543A20 ?SeqIDSanityCheck@SharedNet@@IAE_NABVCNetLayerPacket@@@Z

        // SharedNet.SendPacket:
        public static delegate* unmanaged[Thiscall]<SharedNet*, NetPacket*, ProtoHeader*, sockaddr_in*, Byte> SendPacket = (delegate* unmanaged[Thiscall]<SharedNet*, NetPacket*, ProtoHeader*, sockaddr_in*, Byte>)0x00542780; // .text:00541BA0 ; bool __thiscall SharedNet::SendPacket(SharedNet *this, NetPacket *packet, ProtoHeader *pheader, sockaddr_in *addr) .text:00541BA0 ?SendPacket@SharedNet@@QAE_NPAVNetPacket@@PAVProtoHeader@@ABUsockaddr_in@@@Z

        // SharedNet.ProcessOptionalHeaders:
        public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> ProcessOptionalHeaders = (delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte>)0x005425D0; // .text:005419F0 ; bool __thiscall SharedNet::ProcessOptionalHeaders(SharedNet *this, CNetLayerPacket *pkt) .text:005419F0 ?ProcessOptionalHeaders@SharedNet@@MAE_NABVCNetLayerPacket@@@Z

        // SharedNet.ProcessNewSeqNum:
        public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> ProcessNewSeqNum = (delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte>)0x00545250; // .text:00544690 ; bool __thiscall SharedNet::ProcessNewSeqNum(SharedNet *this, CNetLayerPacket *pkt) .text:00544690 ?ProcessNewSeqNum@SharedNet@@IAE_NAAVCNetLayerPacket@@@Z

        // SharedNet.ProcessConnection:
        public static delegate* unmanaged[Thiscall]<SharedNet*, ReceiverData*, Byte> ProcessConnection = (delegate* unmanaged[Thiscall]<SharedNet*, ReceiverData*, Byte>)0x00545510; // .text:00544950 ; bool __thiscall SharedNet::ProcessConnection(SharedNet *this, ReceiverData *recData) .text:00544950 ?ProcessConnection@SharedNet@@MAE_NPAVReceiverData@@@Z

        // SharedNet.ChecksumHeader:
        public static delegate* unmanaged[Thiscall]<SharedNet*, ProtoHeader*, UInt32> ChecksumHeader = (delegate* unmanaged[Thiscall]<SharedNet*, ProtoHeader*, UInt32>)0x00542570; // .text:00541990 ; UInt32 __thiscall SharedNet::ChecksumHeader(SharedNet *this, ProtoHeader *Hdr) .text:00541990 ?ChecksumHeader@SharedNet@@IAEKABVProtoHeader@@@Z

        // SharedNet.ProcessBlobFrags:
        public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> ProcessBlobFrags = (delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte>)0x00542630; // .text:00541A50 ; bool __thiscall SharedNet::ProcessBlobFrags(SharedNet *this, CNetLayerPacket *pkt) .text:00541A50 ?ProcessBlobFrags@SharedNet@@MAE_NABVCNetLayerPacket@@@Z

        // SharedNet.HandlePak:
        public static delegate* unmanaged[Thiscall]<SharedNet*, COnePrimHeader_16384_1_UInt32_*, CNetLayerPacket*> HandlePak = (delegate* unmanaged[Thiscall]<SharedNet*, COnePrimHeader_16384_1_UInt32_*, CNetLayerPacket*>)0x00543240; // .text:00542660 ; void __thiscall SharedNet::HandlePak(SharedNet *this, COnePrimHeader<16384,1,UInt32> *pPakHdr, CNetLayerPacket *pkt) .text:00542660 ?HandlePak@SharedNet@@MAEXPBV?$COnePrimHeader@$0EAAA@$00K@@ABVCNetLayerPacket@@@Z

        // SharedNet.ProcessNewestSeqNum:
        public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*> ProcessNewestSeqNum = (delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*>)0x00542510; // .text:00541930 ; void __thiscall SharedNet::ProcessNewestSeqNum(SharedNet *this, CNetLayerPacket *pkt) .text:00541930 ?ProcessNewestSeqNum@SharedNet@@IAEXABVCNetLayerPacket@@@Z

        // SharedNet.__Dtor:
        public static delegate* unmanaged[Thiscall]<SharedNet*> __Dtor = (delegate* unmanaged[Thiscall]<SharedNet*>)0x005438A0; // .text:00542CE0 ; void __thiscall SharedNet::~SharedNet(SharedNet *this) .text:00542CE0 ??1SharedNet@@QAE@XZ

        // SharedNet.ProcessPacket:
        public static delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte> ProcessPacket = (delegate* unmanaged[Thiscall]<SharedNet*, CNetLayerPacket*, Byte>)0x00545350; // .text:00544790 ; bool __thiscall SharedNet::ProcessPacket(SharedNet *this, CNetLayerPacket *pkt) .text:00544790 ?ProcessPacket@SharedNet@@MAE_NAAVCNetLayerPacket@@@Z

        // SharedNet.UseTime:
        public static delegate* unmanaged[Thiscall]<SharedNet*, Byte> UseTime = (delegate* unmanaged[Thiscall]<SharedNet*, Byte>)0x00543030; // .text:00542450 ; bool __thiscall SharedNet::UseTime(SharedNet *this) .text:00542450 ?UseTime@SharedNet@@QAE_NXZ

        // SharedNet.SendOptionalHeader:
        public static delegate* unmanaged[Thiscall]<SharedNet*, COptionalHeader*, sockaddr_in*, ReceiverData*, Byte> SendOptionalHeader = (delegate* unmanaged[Thiscall]<SharedNet*, COptionalHeader*, sockaddr_in*, ReceiverData*, Byte>)0x00543D20; // .text:00543160 ; bool __thiscall SharedNet::SendOptionalHeader(SharedNet *this, COptionalHeader *pHdr, sockaddr_in *addr, ReceiverData *pRecv) .text:00543160 ?SendOptionalHeader@SharedNet@@QAE_NPAVCOptionalHeader@@ABUsockaddr_in@@PBVReceiverData@@@Z

        // SharedNet.ProcessOptionalHeader:
        public static delegate* unmanaged[Thiscall]<SharedNet*, COptionalHeader*, CNetLayerPacket*, Byte> ProcessOptionalHeader = (delegate* unmanaged[Thiscall]<SharedNet*, COptionalHeader*, CNetLayerPacket*, Byte>)0x00543C30; // .text:00543070 ; bool __thiscall SharedNet::ProcessOptionalHeader(SharedNet *this, COptionalHeader *pHdr, CNetLayerPacket *pkt) .text:00543070 ?ProcessOptionalHeader@SharedNet@@MAE_NPBVCOptionalHeader@@ABVCNetLayerPacket@@@Z

        // SharedNet.EnqueueNaks:
        public static delegate* unmanaged[Thiscall]<SharedNet*, ReceiverData*> EnqueueNaks = (delegate* unmanaged[Thiscall]<SharedNet*, ReceiverData*>)0x00544790; // .text:00543BD0 ; void __thiscall SharedNet::EnqueueNaks(SharedNet *this, ReceiverData *recData) .text:00543BD0 ?EnqueueNaks@SharedNet@@IAEXPAVReceiverData@@@Z

        // SharedNet.__Ctor:
        public static delegate* unmanaged[Thiscall]<SharedNet*, UInt16> __Ctor = (delegate* unmanaged[Thiscall]<SharedNet*, UInt16>)0x00546A40; // .text:00545E80 ; void __thiscall SharedNet::SharedNet(SharedNet *this, U__Int3216 netID) .text:00545E80 ??0SharedNet@@QAE@G@Z

        // SharedNet.EnqueuePak:
        public static delegate* unmanaged[Thiscall]<SharedNet*, ReceiverData*> EnqueuePak = (delegate* unmanaged[Thiscall]<SharedNet*, ReceiverData*>)0x005446D0; // .text:00543B10 ; void __thiscall SharedNet::EnqueuePak(SharedNet *this, ReceiverData *recData) .text:00543B10 ?EnqueuePak@SharedNet@@IAEXPAVReceiverData@@@Z

        // SharedNet.SetConnectionState:
        public static delegate* unmanaged[Thiscall]<SharedNet*, UInt16, ConnectionState> SetConnectionState = (delegate* unmanaged[Thiscall]<SharedNet*, UInt16, ConnectionState>)0x005428A0; // .text:00541CC0 ; void __thiscall SharedNet::SetConnectionState(SharedNet *this, U__Int3216 idRecip, ConnectionState NewState) .text:00541CC0 ?SetConnectionState@SharedNet@@MAEXGW4ConnectionState@@@Z

        // SharedNet.SetNakState:
        public static delegate* unmanaged[Thiscall]<SharedNet*, ReceiverData*, ReceiverState> SetNakState = (delegate* unmanaged[Thiscall]<SharedNet*, ReceiverData*, ReceiverState>)0x00543320; // .text:00542740 ; ReceiverState __thiscall SharedNet::SetNakState(SharedNet *this, ReceiverData *recData) .text:00542740 ?SetNakState@SharedNet@@IAE?AW4ReceiverState@@PAVReceiverData@@@Z

        // SharedNet.SendBuff:
        public static delegate* unmanaged[Thiscall]<SharedNet*, _WSABUF*, Int32, sockaddr_in, Int32> SendBuff = (delegate* unmanaged[Thiscall]<SharedNet*, _WSABUF*, Int32, sockaddr_in, Int32>)0x00542650; // .text:00541A70 ; Int32 __thiscall SharedNet::SendBuff(SharedNet *this, _WSABUF *vecs, Int32 iovNum, sockaddr_in addr_to) .text:00541A70 ?SendBuff@SharedNet@@MAEHPAU_WSABUF@@HUsockaddr_in@@@Z

        // Globals:
        public static SharedNet** s_pNet = (SharedNet**)0x00846F18; // .data:00845F08 ; SharedNet *SharedNet::s_pNet .data:00845F08 ?s_pNet@SharedNet@@0PAV1@A
    }

    public unsafe struct _WSABUF {
        // Struct:
        public UInt32 len;
        public Char* buf;
        public override string ToString() => $"len:{len:X8}, buf:->(Char*)0x{(Int32)buf:X8}";

    }


    public unsafe struct DatIDStamp {
        // Struct:
        public _GUID _maj_vnum;
        public UInt32 _min_vnum;
        public override string ToString() => $"_maj_vnum(_GUID):{_maj_vnum}, _min_vnum:{_min_vnum:X8}";


        // Functions:

        // DatIDStamp.Clear:
        public static delegate* unmanaged[Thiscall]<DatIDStamp*> Clear = (delegate* unmanaged[Thiscall]<DatIDStamp*>)0x00413960; // .text:004136E0 ; void __thiscall DatIDStamp::Clear(DatIDStamp *this) .text:004136E0 ?Clear@DatIDStamp@@QAEXXZ

        // DatIDStamp.__Ctor:
        public static delegate* unmanaged[Thiscall]<DatIDStamp*> __Ctor = (delegate* unmanaged[Thiscall]<DatIDStamp*>)0x00413980; // .text:00413700 ; void __thiscall DatIDStamp::DatIDStamp(DatIDStamp *this) .text:00413700 ??0DatIDStamp@@QAE@XZ

        // DatIDStamp.__Ctor:
        public static delegate* unmanaged[Thiscall]<DatIDStamp*, DatIDStamp*> __Ctor_ = (delegate* unmanaged[Thiscall]<DatIDStamp*, DatIDStamp*>)0x004139A0; // .text:004136B0 ; void __thiscall DatIDStamp::DatIDStamp(DatIDStamp *this, DatIDStamp *rhs) .text:004136B0 ??0DatIDStamp@@QAE@ABV0@@Z
    }


    public unsafe struct ClientNetConfiguration {
        // Struct:
        public LoggingFunctions LoggingFunctions;
        public AC1Legacy.PStringBase<Char> DesiredInterface;
        public UInt32 dwPort;
        public Int32 bAutoGenerateUniquePort;
        public override string ToString() => $"LoggingFunctions(LoggingFunctions):{LoggingFunctions}, DesiredInterface:{DesiredInterface}, dwPort:{dwPort:X8}, bAutoGenerateUniquePort:{bAutoGenerateUniquePort}";
    }


    public unsafe struct ClientNet {
        // Struct:
        public SharedNet SharedNet;
        public CClientsideLoginStateHandler CClientsideLoginStateHandler;
        public CPluginManagerTemplate<CLinkStatusPlugin> m_CLinkStatusPlugin;
        public ClientNet.CLogonData m_LogonData;
        public CAsyncStateMachine m_ConnectionFSM;
        public SmartArray<ClientNet.CReferralQueueEntry> m_ReferralQueue;
        public UInt16 logonRecID_;
        public UInt16 currServerRecID_;
        public UInt32 m_dwCurrentConnectionSequenceNumber;
        public ClientNet.CSwitchHistory m_WorldSwitchHistory;
        public ClientNet.CSwitchHistory m_LogonSwitchHistory;
        public Byte logOffSent_;
        public Byte fCurrentlyInGame_;
        public Double _timeClientSpeedHackDetection;
        public Double m_LastDidUseTime;
        public CLinkStatusSnapshot m_CurrentLinkStatus;
        public CLinkStatusAverages m_LinkStatusAverages;
        public override string ToString() => $"SharedNet(SharedNet):{SharedNet}, CClientsideLoginStateHandler(CClientsideLoginStateHandler):{CClientsideLoginStateHandler}, m_CLinkStatusPlugin(CPluginManagerTemplate<CLinkStatusPlugin>):{m_CLinkStatusPlugin}, m_LogonData(ClientNet.CLogonData):{m_LogonData}, m_ConnectionFSM(CAsyncStateMachine):{m_ConnectionFSM}, m_ReferralQueue(SmartArray<ClientNet.CReferralQueueEntry,1>):{m_ReferralQueue}, logonRecID_:{logonRecID_:X4}, currServerRecID_:{currServerRecID_:X4}, m_dwCurrentConnectionSequenceNumber:{m_dwCurrentConnectionSequenceNumber:X8}, m_WorldSwitchHistory(ClientNet.CSwitchHistory):{m_WorldSwitchHistory}, m_LogonSwitchHistory(ClientNet.CSwitchHistory):{m_LogonSwitchHistory}, logOffSent_:{logOffSent_:X2}, fCurrentlyInGame_:{fCurrentlyInGame_:X2}, _timeClientSpeedHackDetection:{_timeClientSpeedHackDetection:n5}, m_LastDidUseTime:{m_LastDidUseTime:n5}, m_CurrentLinkStatus(CLinkStatusSnapshot):{m_CurrentLinkStatus}, m_LinkStatusAverages(CLinkStatusAverages):{m_LinkStatusAverages}";


        public unsafe struct CLogonData {
            // Struct:
            public AsyncContext hCurrentContext;
            public Int32 timeLastLoginRequestSent;
            public sockaddr_in ServerAddr;
            public NetAuthenticator* pNetAuth;
            public Int32 nRequestsSent;
            public Byte bMyTurn;
            public NetError FailureReason;
            public override string ToString() => $"hCurrentContext(AsyncContext):{hCurrentContext}, timeLastLoginRequestSent:{timeLastLoginRequestSent}, ServerAddr(sockaddr_in):{ServerAddr}, pNetAuth:->(NetAuthenticator*)0x{(Int32)pNetAuth:X8}, nRequestsSent:{nRequestsSent}, bMyTurn:{bMyTurn:X2}, FailureReason(NetError):{FailureReason}";
        }
        public unsafe struct CSwitchHistory {
            // Struct:
            public CTimestamp<UInt32> LastSwitchStamp;
            public Byte bBeenSwitchedBefore;
            public override string ToString() => $"LastSwitchStamp(CTimestamp<UInt32,0>):{LastSwitchStamp}, bBeenSwitchedBefore:{bBeenSwitchedBefore:X2}";
        }
        public unsafe struct CReferralQueueEntry {
            // Struct:
            public UInt32 nAuthsSent;
            public UInt16 idServer;
            public Double localtimeToSendNextWorldAuth;
            public sockaddr_in ServerAddr;
            public UInt64 qwCookie;
            public override string ToString() => $"nAuthsSent:{nAuthsSent:X8}, idServer:{idServer:X4}, localtimeToSendNextWorldAuth:{localtimeToSendNextWorldAuth:n5}, ServerAddr(sockaddr_in):{ServerAddr}, qwCookie(UInt64):{qwCookie}";
        }


        // Enums:
        public enum WAIT_RESULT : UInt32 {
            UNDEF_WAIT_RESULT = 0x0,
            DONE_WAIT_RESULT = 0x1,
            FAILED_WAIT_RESULT = 0x2,
            ROUTED_WAIT_RESULT = 0x3,
            NO_LOGON_SERVER_WAIT_RESULT = 0x4,
            EXPIRED_ZONE_TICKET_RESULT = 0x5,
            FORCE_WAIT_RESULT_32_BIT = 0x7FFFFFFF,
        };

        // Functions:

        // ClientNet.__Ctor:
        public static delegate* unmanaged[Thiscall]<ClientNet*> __Ctor = (delegate* unmanaged[Thiscall]<ClientNet*>)0x00546F20; // .text:00546360 ; void __thiscall ClientNet::ClientNet(ClientNet *this) .text:00546360 ??0ClientNet@@QAE@XZ

        // ClientNet.HandleTimeSynch:
        public static delegate* unmanaged[Thiscall]<ClientNet*, CTimeSyncHeader*, CNetLayerPacket*> HandleTimeSynch = (delegate* unmanaged[Thiscall]<ClientNet*, CTimeSyncHeader*, CNetLayerPacket*>)0x005448F0; // .text:00543D30 ; void __thiscall ClientNet::HandleTimeSynch(ClientNet *this, CTimeSyncHeader *pHdr, CNetLayerPacket *pkt) .text:00543D30 ?HandleTimeSynch@ClientNet@@MAEXPBVCTimeSyncHeader@@ABVCNetLayerPacket@@@Z

        // ClientNet.__scaDelDtor:
        public static delegate* unmanaged[Thiscall]<ClientNet*, UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<ClientNet*, UInt32, void*>)0x005468C0; // .text:00545D00 ; void *__thiscall ClientNet::`scalar deleting destructor'(ClientNet *this, UInt32) .text:00545D00 ??_GClientNet@@UAEPAXI@Z

        // ClientNet.SendBuff:
        public static delegate* unmanaged[Thiscall]<ClientNet*, _WSABUF*, Int32, sockaddr_in, Int32> SendBuff = (delegate* unmanaged[Thiscall]<ClientNet*, _WSABUF*, Int32, sockaddr_in, Int32>)0x00542A70; // .text:00541E90 ; Int32 __thiscall ClientNet::SendBuff(ClientNet *this, _WSABUF *vecs, Int32 vecNum, sockaddr_in addr_to) .text:00541E90 ?SendBuff@ClientNet@@MAEHPAU_WSABUF@@HUsockaddr_in@@@Z

        // ClientNet.VerifyHeader:
        public static delegate* unmanaged[Thiscall]<ClientNet*, CNetLayerPacket*, Byte> VerifyHeader = (delegate* unmanaged[Thiscall]<ClientNet*, CNetLayerPacket*, Byte>)0x00543FE0; // .text:00543420 ; bool __thiscall ClientNet::VerifyHeader(ClientNet *this, CNetLayerPacket *pkt) .text:00543420 ?VerifyHeader@ClientNet@@MAE_NABVCNetLayerPacket@@@Z

        // ClientNet.ProcessReferralQueue:
        public static delegate* unmanaged[Thiscall]<ClientNet*> ProcessReferralQueue = (delegate* unmanaged[Thiscall]<ClientNet*>)0x00544DB0; // .text:005441F0 ; void __thiscall ClientNet::ProcessReferralQueue(ClientNet *this) .text:005441F0 ?ProcessReferralQueue@ClientNet@@IAEXXZ

        // ClientNet.OnContextBegun:
        public static delegate* unmanaged[Thiscall]<ClientNet*, AsyncContext> OnContextBegun = (delegate* unmanaged[Thiscall]<ClientNet*, AsyncContext>)0x00545540; // .text:00544980 ; void __thiscall ClientNet::OnContextBegun(ClientNet *this, AsyncContext hContext) .text:00544980 ?OnContextBegun@ClientNet@@MAEXVAsyncContext@@@Z

        // ClientNet.ProcessConnections:
        public static delegate* unmanaged[Thiscall]<ClientNet*, Byte> ProcessConnections = (delegate* unmanaged[Thiscall]<ClientNet*, Byte>)0x00546000; // .text:00545440 ; bool __thiscall ClientNet::ProcessConnections(ClientNet *this) .text:00545440 ?ProcessConnections@ClientNet@@UAE_NXZ

        // ClientNet.__Dtor:
        public static delegate* unmanaged[Thiscall]<ClientNet*> __Dtor = (delegate* unmanaged[Thiscall]<ClientNet*>)0x00546590; // .text:005459D0 ; void __thiscall ClientNet::~ClientNet(ClientNet *this) .text:005459D0 ??1ClientNet@@UAE@XZ

        // ClientNet.HandleConnectionRequest:
        public static delegate* unmanaged[Thiscall]<ClientNet*, CConnectHeader*, CNetLayerPacket*> HandleConnectionRequest = (delegate* unmanaged[Thiscall]<ClientNet*, CConnectHeader*, CNetLayerPacket*>)0x00546680; // .text:00545AC0 ; void __thiscall ClientNet::HandleConnectionRequest(ClientNet *this, CConnectHeader *pConnectHeader, CNetLayerPacket *pkt) .text:00545AC0 ?HandleConnectionRequest@ClientNet@@MAEXPBVCConnectHeader@@ABVCNetLayerPacket@@@Z

        // ClientNet.HandleReferral:
        public static delegate* unmanaged[Thiscall]<ClientNet*, COnePrimHeader_2048_1073741922_CReferralStruct_*> HandleReferral = (delegate* unmanaged[Thiscall]<ClientNet*, COnePrimHeader_2048_1073741922_CReferralStruct_*>)0x005468F0; // .text:00545D30 ; void __thiscall ClientNet::HandleReferral(ClientNet *this, COnePrimHeader<2048,1073741922,CReferralStruct> *pRefHdr) .text:00545D30 ?HandleReferral@ClientNet@@MAEXPBV?$COnePrimHeader@$0IAA@$0EAAAAAGC@UCReferralStruct@@@@@Z

        // ClientNet.EnterWorld:
        public static delegate* unmanaged[Thiscall]<ClientNet*> EnterWorld = (delegate* unmanaged[Thiscall]<ClientNet*>)0x005429D0; // .text:00541DF0 ; void __thiscall ClientNet::EnterWorld(ClientNet *this) .text:00541DF0 ?EnterWorld@ClientNet@@QAEXXZ

        // ClientNet.LogOffServer:
        public static delegate* unmanaged[Thiscall]<ClientNet*> LogOffServer = (delegate* unmanaged[Thiscall]<ClientNet*>)0x00544AB0; // .text:00543EF0 ; void __thiscall ClientNet::LogOffServer(ClientNet *this) .text:00543EF0 ?LogOffServer@ClientNet@@QAEXXZ

        // ClientNet.OnContextEnded:
        public static delegate* unmanaged[Thiscall]<ClientNet*, AsyncContext, AsyncStateMachineStatus> OnContextEnded = (delegate* unmanaged[Thiscall]<ClientNet*, AsyncContext, AsyncStateMachineStatus>)0x00544880; // .text:00543CC0 ; void __thiscall ClientNet::OnContextEnded(ClientNet *this, AsyncContext hContext, AsyncStateMachineStatus CompletionStatus) .text:00543CC0 ?OnContextEnded@ClientNet@@MAEXVAsyncContext@@W4AsyncStateMachineStatus@@@Z

        // ClientNet.InitAddresses:
        public static delegate* unmanaged[Thiscall]<ClientNet*, NetError*, Char*, Int32, sockaddr_in*, ClientNetConfiguration*, NetError*> InitAddresses = (delegate* unmanaged[Thiscall]<ClientNet*, NetError*, Char*, Int32, sockaddr_in*, ClientNetConfiguration*, NetError*>)0x005456C0; // .text:00544B00 ; NetError *__thiscall ClientNet::InitAddresses(ClientNet *this, NetError *result, const Char *host, Int32 port, sockaddr_in *udp_srv_addr, ClientNetConfiguration *Config) .text:00544B00 ?InitAddresses@ClientNet@@IAE?AVNetError@@PBDHAAUsockaddr_in@@ABUClientNetConfiguration@@@Z

        // ClientNet.ProcessPacket:
        public static delegate* unmanaged[Thiscall]<ClientNet*, CNetLayerPacket*, Byte> ProcessPacket = (delegate* unmanaged[Thiscall]<ClientNet*, CNetLayerPacket*, Byte>)0x00545CC0; // .text:00545100 ; bool __thiscall ClientNet::ProcessPacket(ClientNet *this, CNetLayerPacket *pkt) .text:00545100 ?ProcessPacket@ClientNet@@MAE_NAAVCNetLayerPacket@@@Z

        // ClientNet.RemoveConnection:
        public static delegate* unmanaged[Thiscall]<ClientNet*, UInt16> RemoveConnection = (delegate* unmanaged[Thiscall]<ClientNet*, UInt16>)0x00545F80; // .text:005453C0 ; void __thiscall ClientNet::RemoveConnection(ClientNet *this, U__Int3216 recID) .text:005453C0 ?RemoveConnection@ClientNet@@IAEXG@Z

        // ClientNet.OnStateBegun:
        public static delegate* unmanaged[Thiscall]<ClientNet*, AsyncContext> OnStateBegun = (delegate* unmanaged[Thiscall]<ClientNet*, AsyncContext>)0x005429B0; // .text:00541DD0 ; void __thiscall ClientNet::OnStateBegun(ClientNet *this, AsyncContext hContext) .text:00541DD0 ?OnStateBegun@ClientNet@@MAEXVAsyncContext@@@Z

        // ClientNet.EndState:
        public static delegate* unmanaged[Thiscall]<ClientNet*, NetError*> EndState = (delegate* unmanaged[Thiscall]<ClientNet*, NetError*>)0x00543F40; // .text:00543380 ; void __thiscall ClientNet::EndState(ClientNet *this, NetError *FailureReason) .text:00543380 ?EndState@ClientNet@@IAEXABVNetError@@@Z

        // ClientNet.ProcessConnection:
        public static delegate* unmanaged[Thiscall]<ClientNet*, ReceiverData*, Byte> ProcessConnection = (delegate* unmanaged[Thiscall]<ClientNet*, ReceiverData*, Byte>)0x00546010; // .text:00545450 ; bool __thiscall ClientNet::ProcessConnection(ClientNet *this, ReceiverData *pReceiver) .text:00545450 ?ProcessConnection@ClientNet@@UAE_NPAVReceiverData@@@Z

        // ClientNet.UseTime:
        public static delegate* unmanaged[Thiscall]<ClientNet*, Byte> UseTime = (delegate* unmanaged[Thiscall]<ClientNet*, Byte>)0x00543440; // .text:00542860 ; bool __thiscall ClientNet::UseTime(ClientNet *this) .text:00542860 ?UseTime@ClientNet@@QAE_NXZ

        // ClientNet.AddToPerfCounter:
        public static delegate* unmanaged[Thiscall]<ClientNet*, NetPerfCounter, Int32> AddToPerfCounter = (delegate* unmanaged[Thiscall]<ClientNet*, NetPerfCounter, Int32>)0x00543460; // .text:00542880 ; void __thiscall ClientNet::AddToPerfCounter(ClientNet *this, NetPerfCounter WhichCounter, Int32 n) .text:00542880 ?AddToPerfCounter@ClientNet@@UAEXW4NetPerfCounter@@H@Z

        // ClientNet.SendConnectAck:
        public static delegate* unmanaged[Thiscall]<ClientNet*, ReceiverData*, Byte> SendConnectAck = (delegate* unmanaged[Thiscall]<ClientNet*, ReceiverData*, Byte>)0x00544CB0; // .text:005440F0 ; bool __thiscall ClientNet::SendConnectAck(ClientNet *this, ReceiverData *pReceiver) .text:005440F0 ?SendConnectAck@ClientNet@@IAE_NPAVReceiverData@@@Z

        // ClientNet.ProcessOptionalHeader:
        public static delegate* unmanaged[Thiscall]<ClientNet*, COptionalHeader*, CNetLayerPacket*, Byte> ProcessOptionalHeader = (delegate* unmanaged[Thiscall]<ClientNet*, COptionalHeader*, CNetLayerPacket*, Byte>)0x00545D60; // .text:005451A0 ; bool __thiscall ClientNet::ProcessOptionalHeader(ClientNet *this, COptionalHeader *pHdr, CNetLayerPacket *pkt) .text:005451A0 ?ProcessOptionalHeader@ClientNet@@MAE_NPBVCOptionalHeader@@ABVCNetLayerPacket@@@Z

        // ClientNet.NotifyPluginsOfStatusChange:
        public static delegate* unmanaged[Thiscall]<ClientNet*, NetStatus, Int32, Int32> NotifyPluginsOfStatusChange = (delegate* unmanaged[Thiscall]<ClientNet*, NetStatus, Int32, Int32>)0x00544190; // .text:005435D0 ; void __thiscall ClientNet::NotifyPluginsOfStatusChange(ClientNet *this, NetStatus Status, Int32 Param1, Int32 Param2) .text:005435D0 ?NotifyPluginsOfStatusChange@ClientNet@@IAEXW4NetStatus@@JJ@Z

        // ClientNet.SendLoginRequest:
        public static delegate* unmanaged[Thiscall]<ClientNet*, sockaddr_in*, NetAuthenticator*, Byte> SendLoginRequest = (delegate* unmanaged[Thiscall]<ClientNet*, sockaddr_in*, NetAuthenticator*, Byte>)0x00544B50; // .text:00543F90 ; bool __thiscall ClientNet::SendLoginRequest(ClientNet *this, sockaddr_in *ServerAddr, NetAuthenticator *pNetAuth) .text:00543F90 ?SendLoginRequest@ClientNet@@IAE_NABUsockaddr_in@@PBVNetAuthenticator@@@Z

        // ClientNet.NotifyPluginsOfHeartbeat:
        public static delegate* unmanaged[Thiscall]<ClientNet*> NotifyPluginsOfHeartbeat = (delegate* unmanaged[Thiscall]<ClientNet*>)0x005441E0; // .text:00543620 ; void __thiscall ClientNet::NotifyPluginsOfHeartbeat(ClientNet *this) .text:00543620 ?NotifyPluginsOfHeartbeat@ClientNet@@IAEXXZ

        // ClientNet.HandleServerSwitch:
        public static delegate* unmanaged[Thiscall]<ClientNet*, COnePrimHeader_256_96_CServerSwitchStruct_*, CNetLayerPacket*> HandleServerSwitch = (delegate* unmanaged[Thiscall]<ClientNet*, COnePrimHeader_256_96_CServerSwitchStruct_*, CNetLayerPacket*>)0x005449E0; // .text:00543E20 ; void __thiscall ClientNet::HandleServerSwitch(ClientNet *this, COnePrimHeader<256,96,CServerSwitchStruct> *pSwitchHdr, CNetLayerPacket *pkt) .text:00543E20 ?HandleServerSwitch@ClientNet@@MAEXPBV?$COnePrimHeader@$0BAA@$0GA@UCServerSwitchStruct@@@@ABVCNetLayerPacket@@@Z

        // ClientNet.LogonUseTime:
        public static delegate* unmanaged[Thiscall]<ClientNet*> LogonUseTime = (delegate* unmanaged[Thiscall]<ClientNet*>)0x005455D0; // .text:00544A10 ; void __thiscall ClientNet::LogonUseTime(ClientNet *this) .text:00544A10 ?LogonUseTime@ClientNet@@MAEXXZ

        // ClientNet.Init:
        public static delegate* unmanaged[Thiscall]<ClientNet*, NetError*, Int32, Char*, DatIDStamp*, NetAuthenticator*, ClientNetConfiguration*, NetError*> Init = (delegate* unmanaged[Thiscall]<ClientNet*, NetError*, Int32, Char*, DatIDStamp*, NetAuthenticator*, ClientNetConfiguration*, NetError*>)0x00545BD0; // .text:00545010 ; NetError *__thiscall ClientNet::Init(ClientNet *this, NetError *result, Int32 port, const Char *host, DatIDStamp *dataVer, NetAuthenticator *pNetAuth, ClientNetConfiguration *Config) .text:00545010 ?Init@ClientNet@@QAE?AVNetError@@HPBDAAVDatIDStamp@@PAVNetAuthenticator@@ABUClientNetConfiguration@@@Z

        // ClientNet.ExitWorldDisconnect:
        public static delegate* unmanaged[Thiscall]<ClientNet*> ExitWorldDisconnect = (delegate* unmanaged[Thiscall]<ClientNet*>)0x005429E0; // .text:00541E00 ; void __thiscall ClientNet::ExitWorldDisconnect(ClientNet *this) .text:00541E00 ?ExitWorldDisconnect@ClientNet@@QAEXXZ

        // ClientNet.AbortConnection:
        public static delegate* unmanaged[Thiscall]<ClientNet*> AbortConnection = (delegate* unmanaged[Thiscall]<ClientNet*>)0x00543FC0; // .text:00543400 ; void __thiscall ClientNet::AbortConnection(ClientNet *this) .text:00543400 ?AbortConnection@ClientNet@@QAEXXZ
    }

    public unsafe struct CLinkStatusSnapshot {
        // Struct:
        public Single RoundTripDelay;
        public UInt16 nPktsSent;
        public UInt16 nPktsRetransmitted;
        public UInt16 nPktsReceived;
        public UInt16 nPktsNAKed;
        public UInt32 nBytesSent;
        public UInt32 nBytesReceived;
        public Single TimeSinceLastGotData;
        public Single SnapshotDuration;
        public override string ToString() => $"RoundTripDelay:{RoundTripDelay:n5}, nPktsSent:{nPktsSent:X4}, nPktsRetransmitted:{nPktsRetransmitted:X4}, nPktsReceived:{nPktsReceived:X4}, nPktsNAKed:{nPktsNAKed:X4}, nBytesSent:{nBytesSent:X8}, nBytesReceived:{nBytesReceived:X8}, TimeSinceLastGotData:{TimeSinceLastGotData:n5}, SnapshotDuration:{SnapshotDuration:n5}";

    }

    public unsafe struct PacketController {
        public Vtbl* vfptr;
        public ClientNet* net_;
        public RecipientData** recipients_;
        public NIList<NetBlob>** netQueues_; // 12
        public RecipientData* haveNaks_;
        public PQueueArray<Double, Int32> FlowControlTimers;
        public Double lastEmpty_;
        public UInt64 m_curNonEphemeralID;
        public NetInterface netInterface_;
        public PerfMonCounter<UInt64>* m_pSendBlobCallsCounter;

        public unsafe struct Vtbl {
            // Struct:
            public static delegate* unmanaged[Thiscall]<PacketController*, UInt64> GetNonEphemeralID; //   UInt64 (__thiscall *GetNonEphemeralID)(PacketController *this);
        };
    }


    public unsafe struct NetInterface {

        // Functions:

        // NetInterface.__Ctor:
        public static delegate* unmanaged[Thiscall]<NetInterface*> __Ctor = (delegate* unmanaged[Thiscall]<NetInterface*>)0x005497A0; // .text:00548C40 ; void __thiscall NetInterface::NetInterface(NetInterface *this) .text:00548C40 ??0NetInterface@@QAE@XZ

        // NetInterface.GetNonEphemeralID:
        public static delegate* unmanaged[Thiscall]<NetInterface*, UInt64> GetNonEphemeralID = (delegate* unmanaged[Thiscall]<NetInterface*, UInt64>)0x005497B0; // .text:00548C50 ; UInt64 __thiscall NetInterface::GetNonEphemeralID(NetInterface *this) .text:00548C50 ?GetNonEphemeralID@NetInterface@@QAE_KXZ

        // Globals:
        // public static NetInterface** netInterface_ = (NetInterface**)0xDEADBEEF; // .data:00845F64 ; NetInterface *NetInterface::netInterface_ .data:00845F64 ?netInterface_@NetInterface@@0PAV1@A
    }
    public unsafe struct RecipientData {
        // Struct:
        public Double lastTouched_;
        public Double timeAllocated_;
        public ConnectionState m_ConnectionState;
        public NIList<NetBlob> waitingBlobs_;
        public ClientFlowQueue flowQueue_;
        public RecipientData* next_;
        public UInt16 recID_;
        public Int32 onQueue_;
        public Indicator* dependencies_;
        public UInt32 gidPlayer_;
        public UInt32 flushNum_;
        public override string ToString() => $"lastTouched_:{lastTouched_:n5}, timeAllocated_:{timeAllocated_:n5}, m_ConnectionState(ConnectionState):{m_ConnectionState}, waitingBlobs_(NIList<NetBlob*>):{waitingBlobs_}, flowQueue_(ClientFlowQueue):{flowQueue_}, next_:->(RecipientData*)0x{(Int32)next_:X8}, recID_:{recID_:X4}, onQueue_:{onQueue_}, dependencies_:->(Indicator*)0x{(Int32)dependencies_:X8}, gidPlayer_:{gidPlayer_:X8}, flushNum_:{flushNum_:X8}";


        // Functions:

        // RecipientData.__Ctor:
        public static delegate* unmanaged[Thiscall]<RecipientData*, UInt16, sockaddr_in, Int32, Single> __Ctor = (delegate* unmanaged[Thiscall]<RecipientData*, UInt16, sockaddr_in, Int32, Single>)0x00547A40; // .text:00546E80 ; void __thiscall RecipientData::RecipientData(RecipientData *this, U__Int3216 recID, sockaddr_in addr, Int32 noflow, Single lineNoise) .text:00546E80 ??0RecipientData@@QAE@GUsockaddr_in@@HM@Z

        // RecipientData.__Dtor:
        public static delegate* unmanaged[Thiscall]<RecipientData*> __Dtor = (delegate* unmanaged[Thiscall]<RecipientData*>)0x00547B00; // .text:00546F40 ; void __thiscall RecipientData::~RecipientData(RecipientData *this) .text:00546F40 ??1RecipientData@@QAE@XZ

        // RecipientData.QueueFlush:
        public static delegate* unmanaged[Thiscall]<RecipientData*, UInt32> QueueFlush = (delegate* unmanaged[Thiscall]<RecipientData*, UInt32>)0x00547B90; // .text:00546FD0 ; void __thiscall RecipientData::QueueFlush(RecipientData *this, UInt32 num) .text:00546FD0 ?QueueFlush@RecipientData@@QAEXK@Z

        // RecipientData.ProcessNaks:
        // public static delegate* unmanaged[Thiscall]<RecipientData*,Int32,UInt32*> ProcessNaks = (delegate* unmanaged[Thiscall]<RecipientData*,Int32,UInt32*>)0xDEADBEEF; // .text:00547010 ; void __thiscall RecipientData::ProcessNaks(RecipientData *this, Int32 numNaks, const UInt32 *seqIDs) .text:00547010 ?ProcessNaks@RecipientData@@QAEXHPBK@Z

        // RecipientData.TouchConnection:
        public static delegate* unmanaged[Thiscall]<RecipientData*> TouchConnection = (delegate* unmanaged[Thiscall]<RecipientData*>)0x00547990; // .text:00546DD0 ; void __thiscall RecipientData::TouchConnection(RecipientData *this) .text:00546DD0 ?TouchConnection@RecipientData@@QAEXXZ

        // RecipientData.IndicateReceivedPacket:
        public static delegate* unmanaged[Thiscall]<RecipientData*, NetPacket*, UInt32, Int32> IndicateReceivedPacket = (delegate* unmanaged[Thiscall]<RecipientData*, NetPacket*, UInt32, Int32>)0x005479B0; // .text:00546DF0 ; Int32 __thiscall RecipientData::IndicateReceivedPacket(RecipientData *this, NetPacket *pPacket, UInt32 priority) .text:00546DF0 ?IndicateReceivedPacket@RecipientData@@QAEHPBVNetPacket@@K@Z

        // RecipientData.EnqueueBlob:
        public static delegate* unmanaged[Thiscall]<RecipientData*, NetBlob*> EnqueueBlob = (delegate* unmanaged[Thiscall]<RecipientData*, NetBlob*>)0x005479E0; // .text:00546E20 ; void __thiscall RecipientData::EnqueueBlob(RecipientData *this, NetBlob *newGuy) .text:00546E20 ?EnqueueBlob@RecipientData@@IAEXPAVNetBlob@@@Z

        // RecipientData.UseTime:
        public static delegate* unmanaged[Thiscall]<RecipientData*> UseTime = (delegate* unmanaged[Thiscall]<RecipientData*>)0x00547A00; // .text:00546E40 ; void __thiscall RecipientData::UseTime(RecipientData *this) .text:00546E40 ?UseTime@RecipientData@@QAEXXZ
    }


    public unsafe struct ClientFlowQueue {
        // Struct:
        public FlowQueue FlowQueue;
        public PQueueArray<UInt32, Int32> pqueue_;
        public Int32 BytesPrevSent_;
        public override string ToString() => $"FlowQueue(FlowQueue):{FlowQueue}, pqueue_(PQueueArray<UInt32,void*>):{pqueue_}, BytesPrevSent_:{BytesPrevSent_}";


        // Functions:

        // ClientFlowQueue.__scaDelDtor:
        public static delegate* unmanaged[Thiscall]<ClientFlowQueue*, UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<ClientFlowQueue*, UInt32, void*>)0x00549680; // .text:00548B20 ; void *__thiscall ClientFlowQueue::`scalar deleting destructor'(ClientFlowQueue *this, UInt32) .text:00548B20 ??_GClientFlowQueue@@UAEPAXI@Z

        // ClientFlowQueue.RecordBytesSent:
        public static delegate* unmanaged[Thiscall]<ClientFlowQueue*, Int32> RecordBytesSent = (delegate* unmanaged[Thiscall]<ClientFlowQueue*, Int32>)0x00547CD0; // .text:00547110 ; void __thiscall ClientFlowQueue::RecordBytesSent(ClientFlowQueue *this, Int32 dataAmount) .text:00547110 ?RecordBytesSent@ClientFlowQueue@@UAEXH@Z

        // ClientFlowQueue.Enqueue:
        public static delegate* unmanaged[Thiscall]<ClientFlowQueue*, NetBlob*> Enqueue = (delegate* unmanaged[Thiscall]<ClientFlowQueue*, NetBlob*>)0x00548890; // .text:00547CD0 ; void __thiscall ClientFlowQueue::Enqueue(ClientFlowQueue *this, NetBlob *newBlob) .text:00547CD0 ?Enqueue@ClientFlowQueue@@UAEXPAVNetBlob@@@Z

        // ClientFlowQueue.Dequeue:
        public static delegate* unmanaged[Thiscall]<ClientFlowQueue*, Int32, NetBlob*> Dequeue = (delegate* unmanaged[Thiscall]<ClientFlowQueue*, Int32, NetBlob*>)0x005488E0; // .text:00547D20 ; NetBlob *__thiscall ClientFlowQueue::Dequeue(ClientFlowQueue *this, Int32 __formal) .text:00547D20 ?Dequeue@ClientFlowQueue@@UAEPAVNetBlob@@H@Z

        // ClientFlowQueue.OnLocalIntervalAck:
        public static delegate* unmanaged[Thiscall]<ClientFlowQueue*, IntervalData*, Int32> OnLocalIntervalAck = (delegate* unmanaged[Thiscall]<ClientFlowQueue*, IntervalData*, Int32>)0x00548A80; // .text:00547EC0 ; Int32 __thiscall ClientFlowQueue::OnLocalIntervalAck(ClientFlowQueue *this, IntervalData *IntervalBeingAcked) .text:00547EC0 ?OnLocalIntervalAck@ClientFlowQueue@@UAEHABUInt32ervalData@@@Z

        // ClientFlowQueue.IncrementLocalInterval:
        public static delegate* unmanaged[Thiscall]<ClientFlowQueue*, UInt32> IncrementLocalInterval = (delegate* unmanaged[Thiscall]<ClientFlowQueue*, UInt32>)0x00548AD0; // .text:00547F10 ; void __thiscall ClientFlowQueue::IncrementLocalInterval(ClientFlowQueue *this, UInt32 cIntervals) .text:00547F10 ?IncrementLocalInterval@ClientFlowQueue@@UAEXK@Z

        // ClientFlowQueue.__Ctor:
        public static delegate* unmanaged[Thiscall]<ClientFlowQueue*, sockaddr_in, UInt16, Single> __Ctor = (delegate* unmanaged[Thiscall]<ClientFlowQueue*, sockaddr_in, UInt16, Single>)0x00549260; // .text:00548700 ; void __thiscall ClientFlowQueue::ClientFlowQueue(ClientFlowQueue *this, sockaddr_in addr, U__Int3216 recID, Single lineNoise) .text:00548700 ??0ClientFlowQueue@@QAE@Usockaddr_in@@GM@Z

        // ClientFlowQueue.__Dtor:
        public static delegate* unmanaged[Thiscall]<ClientFlowQueue*> __Dtor = (delegate* unmanaged[Thiscall]<ClientFlowQueue*>)0x00549650; // .text:00548AF0 ; void __thiscall ClientFlowQueue::~ClientFlowQueue(ClientFlowQueue *this) .text:00548AF0 ??1ClientFlowQueue@@UAE@XZ
    }

    public unsafe struct IntervalData {
        // Struct:
        public UInt16 Int32ervalID_;
        public Int32 nBytes_;
        public Int32 FlowLevel_;
        public Int32 nPkts_;
        public override string ToString() => $"Int32ervalID_:{Int32ervalID_:X4}, nBytes_:{nBytes_}, FlowLevel_:{FlowLevel_}, nPkts_:{nPkts_}";

    }


    public unsafe struct QTIsaac {
        // Struct:
        public _Vtbl* vfptr;
        public randctx m_rc;
        public override string ToString() => $"vfptr:->(_Vtbl*)0x{(Int32)vfptr:X8}, m_rc(randctx):{m_rc}";

        public unsafe struct randctx {
            // Struct:
            public UInt32 randcnt;
            public UInt32* randrsl;
            public UInt32* randmem;
            public UInt32 randa;
            public UInt32 randb;
            public UInt32 randc;
            public override string ToString() => $"randcnt:{randcnt:X8}, randrsl:->(UInt32*)0x{(Int32)randrsl:X8}, randmem:->(UInt32*)0x{(Int32)randmem:X8}, randa:{randa:X8}, randb:{randb:X8}, randc:{randc:X8}";


            // Functions:

            // QTIsaac<8,UInt32>::randctx.~randctx:
            public static delegate* unmanaged[Thiscall]<randctx*> __Dtor = (delegate* unmanaged[Thiscall]<randctx*>)0x00660770; // .text:0065F7D0 ; void __thiscall QTIsaac<8,UInt32>::randctx::~randctx(QTIsaac<8,UInt32>::randctx *this) .text:0065F7D0 ??1randctx@?$QTIsaac@$07K@@QAE@XZ
        }


        // Functions:

        // QTIsaac<8,UInt32>.isaac:
        public static delegate* unmanaged[Thiscall]<QTIsaac*, QTIsaac.randctx*> isaac = (delegate* unmanaged[Thiscall]<QTIsaac*, randctx*>)0x00660C00; // .text:0065FC60 ; void __thiscall QTIsaac<8,UInt32>::isaac(QTIsaac<8,UInt32> *this, QTIsaac<8,UInt32>::randctx *ctx) .text:0065FC60 ?isaac@?$QTIsaac@$07K@@MAEXPAUrandctx@1@@Z

        // QTIsaac<8,UInt32>.srand:
        public static delegate* unmanaged[Thiscall]<QTIsaac*, UInt32, UInt32, UInt32, UInt32*> srand = (delegate* unmanaged[Thiscall]<QTIsaac*, UInt32, UInt32, UInt32, UInt32*>)0x006606C0; // .text:0065F720 ; void __thiscall QTIsaac<8,UInt32>::srand(QTIsaac<8,UInt32> *this, UInt32 a, UInt32 b, UInt32 c, UInt32 *s) .text:0065F720 ?srand@?$QTIsaac@$07K@@UAEXKKKPAK@Z

        // QTIsaac<8,UInt32>.__Ctor:
        public static delegate* unmanaged[Thiscall]<QTIsaac*, UInt32, UInt32, UInt32> __Ctor = (delegate* unmanaged[Thiscall]<QTIsaac*, UInt32, UInt32, UInt32>)0x00660790; // .text:0065F7F0 ; void __thiscall QTIsaac<8,UInt32>::QTIsaac<8,UInt32>(QTIsaac<8,UInt32> *this, UInt32 a, UInt32 b, UInt32 c) .text:0065F7F0 ??0?$QTIsaac@$07K@@QAE@KKK@Z

        // QTIsaac<8,UInt32>.randinit:
        public static delegate* unmanaged[Thiscall]<QTIsaac*, QTIsaac.randctx*, Byte> randinit = (delegate* unmanaged[Thiscall]<QTIsaac*, randctx*, Byte>)0x00660810; // .text:0065F870 ; void __thiscall QTIsaac<8,UInt32>::randinit(QTIsaac<8,UInt32> *this, QTIsaac<8,UInt32>::randctx *ctx, bool bUseSeed) .text:0065F870 ?randinit@?$QTIsaac@$07K@@UAEXPAUrandctx@1@_N@Z

        // QTIsaac<8,UInt32>.shuffle:
        public static delegate* unmanaged[Thiscall]<QTIsaac*, UInt32*, UInt32*, UInt32*, UInt32*, UInt32*, UInt32*, UInt32*, UInt32*> shuffle = (delegate* unmanaged[Thiscall]<QTIsaac*, UInt32*, UInt32*, UInt32*, UInt32*, UInt32*, UInt32*, UInt32*, UInt32*>)0x00660AC0; // .text:0065FB20 ; void __thiscall QTIsaac<8,UInt32>::shuffle(QTIsaac<8,UInt32> *this, UInt32 *a, UInt32 *b, UInt32 *c, UInt32 *d, UInt32 *e, UInt32 *f, UInt32 *g, UInt32 *h) .text:0065FB20 ?shuffle@?$QTIsaac@$07K@@MAEXAAK0000000@Z

        // QTIsaac<8,UInt32>.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<QTIsaac*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<QTIsaac*, UInt32, void*>)0x00660B80; // .text:0065FBE0 ; void *__thiscall QTIsaac<8,UInt32>::`vector deleting destructor'(QTIsaac<8,UInt32> *this, UInt32) .text:0065FBE0 ??_E?$QTIsaac@$07K@@UAEPAXI@Z
    }

    public unsafe struct CryptoSystem {
        // Struct:
        public UInt32 lastIter_;
        public UInt32 seed_;
        public QTIsaac* pGenerator_;
        public override string ToString() => $"lastIter_:{lastIter_:X8}, seed_:{seed_:X8}, pGenerator_:->(QTIsaac<8,UInt32>*)0x{(Int32)pGenerator_:X8}";


        // Functions:

        // CryptoSystem.__Dtor:
        public static delegate* unmanaged[Thiscall]<CryptoSystem*> __Dtor = (delegate* unmanaged[Thiscall]<CryptoSystem*>)0x006606A0; // .text:0065F700 ; void __thiscall CryptoSystem::~CryptoSystem(CryptoSystem *this) .text:0065F700 ??1CryptoSystem@@QAE@XZ

        // CryptoSystem.__Ctor:
        public static delegate* unmanaged[Thiscall]<CryptoSystem*, UInt32> __Ctor = (delegate* unmanaged[Thiscall]<CryptoSystem*, UInt32>)0x00660BB0; // .text:0065FC10 ; void __thiscall CryptoSystem::CryptoSystem(CryptoSystem *this, UInt32 seed) .text:0065FC10 ??0CryptoSystem@@QAE@K@Z

        // CryptoSystem.GetNextCryptoSeed:
        public static delegate* unmanaged[Thiscall]<CryptoSystem*, UInt32, UInt32> GetNextCryptoSeed = (delegate* unmanaged[Thiscall]<CryptoSystem*, UInt32, UInt32>)0x00660EA0; // .text:0065FF00 ; UInt32 __thiscall CryptoSystem::GetNextCryptoSeed(CryptoSystem *this, UInt32 iteration) .text:0065FF00 ?GetNextCryptoSeed@CryptoSystem@@QAEKK@Z

        // CryptoSystem.EncryptData:
        public static delegate* unmanaged[Thiscall]<CryptoSystem*, UInt32, Char*, UInt32, UInt32*, UInt32> EncryptData = (delegate* unmanaged[Thiscall]<CryptoSystem*, UInt32, Char*, UInt32, UInt32*, UInt32>)0x00660EE0; // .text:0065FF40 ; UInt32 __thiscall CryptoSystem::EncryptData(CryptoSystem *this, UInt32 iteration, Char *data, UInt32 size, UInt32 *pEncryptSeed) .text:0065FF40 ?EncryptData@CryptoSystem@@QAEKKPAEKPAK@Z
    }

    public unsafe struct NetKeyExch {
        // Struct:
        public PackObj PackObj;
        public PortalDH* dh_;
        public AC1Legacy.vlong rnum_;
        public Int32 fInitialized_;
        public override string ToString() => $"PackObj(PackObj):{PackObj}, dh_:->(PortalDH*)0x{(Int32)dh_:X8}, rnum_(AC1Legacy.vlong):{rnum_}, fInitialized_:{fInitialized_}";


        // Functions:

        // NetKeyExch.GetPackSize:
        // public static delegate* unmanaged[Thiscall]<NetKeyExch*, UInt32> GetPackSize = (delegate* unmanaged[Thiscall]<NetKeyExch*, UInt32>)0xDEADBEEF; // .text:005499C0 ; UInt32 __thiscall NetKeyExch::GetPackSize(NetKeyExch *this) .text:005499C0 ?GetPackSize@NetKeyExch@@UAEIXZ

        // NetKeyExch.__scaDelDtor:
        // public static delegate* unmanaged[Thiscall]<NetKeyExch*,UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<NetKeyExch*,UInt32, void*>)0xDEADBEEF; // .text:005499E0 ; void *__thiscall NetKeyExch::`scalar deleting destructor'(NetKeyExch *this, UInt32) .text:005499E0 ??_GNetKeyExch@@UAEPAXI@Z

        // NetKeyExch.SetPrivateRandom:
        public static delegate* unmanaged[Thiscall]<NetKeyExch*, AC1Legacy.vlong*> SetPrivateRandom = (delegate* unmanaged[Thiscall]<NetKeyExch*, AC1Legacy.vlong*>)0x0054A440; // .text:005498E0 ; void __thiscall NetKeyExch::SetPrivateRandom(NetKeyExch *this, AC1Legacy::vlong *rnum) .text:005498E0 ?SetPrivateRandom@NetKeyExch@@QAEXABVvlong@AC1Legacy@@@Z

        // NetKeyExch.Pack:
        // public static delegate* unmanaged[Thiscall]<NetKeyExch*,void**,UInt32, UInt32> Pack = (delegate* unmanaged[Thiscall]<NetKeyExch*,void**,UInt32, UInt32>)0xDEADBEEF; // .text:00549900 ; UInt32 __thiscall NetKeyExch::Pack(NetKeyExch *this, void **addr, UInt32 size) .text:00549900 ?Pack@NetKeyExch@@UAEIAAPAXI@Z

        // NetKeyExch.UnPack:
        // public static delegate* unmanaged[Thiscall]<NetKeyExch*,void**,UInt32, Int32> UnPack = (delegate* unmanaged[Thiscall]<NetKeyExch*,void**,UInt32, Int32>)0xDEADBEEF; // .text:00549950 ; Int32 __thiscall NetKeyExch::UnPack(NetKeyExch *this, void **addr, UInt32 size) .text:00549950 ?UnPack@NetKeyExch@@UAEHAAPAXI@Z

        // NetKeyExch.__Ctor:
        public static delegate* unmanaged[Thiscall]<NetKeyExch*, PortalDH*> __Ctor = (delegate* unmanaged[Thiscall]<NetKeyExch*, PortalDH*>)0x0054A4F0; // .text:00549990 ; void __thiscall NetKeyExch::NetKeyExch(NetKeyExch *this, PortalDH *dh) .text:00549990 ??0NetKeyExch@@QAE@PAVPortalDH@@@Z
    }

    public unsafe partial struct AC1Legacy {

        public unsafe struct vlong {
            // Struct:
            public PackObj PackObj;
            public AC1Legacy.vlong_value* value;
            public Int32 negative;
            public override string ToString() => $"PackObj(PackObj):{PackObj}, value:->(AC1Legacy.vlong_value*)0x{(Int32)value:X8}, negative:{negative}";


            // Functions:

            // AC1Legacy::vlong.setbit:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32> setbit = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32>)0x005B17F0; // .text:005B0740 ; void __thiscall AC1Legacy::vlong::setbit(AC1Legacy::vlong *this, UInt32 i) .text:005B0740 ?setbit@vlong@AC1Legacy@@QAEXI@Z

            // AC1Legacy::vlong.vlong:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32> __Ctor = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32>)0x005B1900; // .text:005B0850 ; void __thiscall AC1Legacy::vlong::vlong(AC1Legacy::vlong *this, UInt32 x) .text:005B0850 ??0vlong@AC1Legacy@@QAE@I@Z

            // AC1Legacy::vlong.vlong:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, AC1Legacy.vlong*> __Ctor_ = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, AC1Legacy.vlong*>)0x005B1950; // .text:005B08A0 ; void __thiscall AC1Legacy::vlong::vlong(AC1Legacy::vlong *this, AC1Legacy::vlong *x) .text:005B08A0 ??0vlong@AC1Legacy@@QAE@ABV01@@Z

            // AC1Legacy::vlong.~vlong:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*> __Dtor = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*>)0x005B19D0; // .text:005B0920 ; void __thiscall AC1Legacy::vlong::~vlong(AC1Legacy::vlong *this) .text:005B0920 ??1vlong@AC1Legacy@@UAE@XZ

            // AC1Legacy::vlong.operator+=:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, AC1Legacy.vlong*, AC1Legacy.vlong*> operator_plus_equals = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, AC1Legacy.vlong*, AC1Legacy.vlong*>)0x005B1A30; // .text:005B0980 ; AC1Legacy::vlong *__thiscall AC1Legacy::vlong::operator+=(AC1Legacy::vlong *this, AC1Legacy::vlong *x) .text:005B0980 ??Yvlong@AC1Legacy@@QAEAAV01@ABV01@@Z

            // AC1Legacy::vlong.read_from_hex_string:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, Char*, Int32> read_from_hex_string = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, Char*, Int32>)0x005B1BC0; // .text:005B0B10 ; Int32 __thiscall AC1Legacy::vlong::read_from_hex_string(AC1Legacy::vlong *this, const Char *str) .text:005B0B10 ?read_from_hex_string@vlong@AC1Legacy@@QAEHPBD@Z

            // AC1Legacy::vlong.store:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32*, UInt32> store = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32*, UInt32>)0x005B1740; // .text:005B0690 ; void __thiscall AC1Legacy::vlong::store(AC1Legacy::vlong *this, UInt32 *a, UInt32 n) .text:005B0690 ?store@vlong@AC1Legacy@@QBEXPAII@Z

            // AC1Legacy::vlong.docopy:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*> docopy = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*>)0x005B1770; // .text:005B06C0 ; void __thiscall AC1Legacy::vlong::docopy(AC1Legacy::vlong *this) .text:005B06C0 ?docopy@vlong@AC1Legacy@@AAEXXZ

            // AC1Legacy::vlong.operator=:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, AC1Legacy.vlong*, AC1Legacy.vlong*> operator_equals = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, AC1Legacy.vlong*, AC1Legacy.vlong*>)0x005B1970; // .text:005B08C0 ; AC1Legacy::vlong *__thiscall AC1Legacy::vlong::operator=(AC1Legacy::vlong *this, AC1Legacy::vlong *x) .text:005B08C0 ??4vlong@AC1Legacy@@QAEAAV01@ABV01@@Z

            // AC1Legacy::vlong.Pack:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, void**, UInt32, UInt32> Pack = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, void**, UInt32, UInt32>)0x005B1F20; // .text:005B0E70 ; UInt32 __thiscall AC1Legacy::vlong::Pack(AC1Legacy::vlong *this, void **addr, UInt32 size) .text:005B0E70 ?Pack@vlong@AC1Legacy@@UAEIAAPAXI@Z

            // AC1Legacy::vlong.GetPackSize:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32> GetPackSize = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32>)0x005B1880; // .text:005B07D0 ; UInt32 __thiscall AC1Legacy::vlong::GetPackSize(AC1Legacy::vlong *this) .text:005B07D0 ?GetPackSize@vlong@AC1Legacy@@UAEIXZ

            // AC1Legacy::vlong.load:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32*, UInt32> load = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32*, UInt32>)0x005B1890; // .text:005B07E0 ; void __thiscall AC1Legacy::vlong::load(AC1Legacy::vlong *this, UInt32 *a, UInt32 n) .text:005B07E0 ?load@vlong@AC1Legacy@@QAEXPAII@Z

            // AC1Legacy::vlong.bit:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32, UInt32> bit = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32, UInt32>)0x005B17B0; // .text:005B0700 ; UInt32 __thiscall AC1Legacy::vlong::bit(AC1Legacy::vlong *this, UInt32 i) .text:005B0700 ?bit@vlong@AC1Legacy@@QBEII@Z

            // AC1Legacy::vlong.operator*:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, AC1Legacy.vlong*, AC1Legacy.vlong*, AC1Legacy.vlong*> operator_multiply = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, AC1Legacy.vlong*, AC1Legacy.vlong*, AC1Legacy.vlong*>)0x005B1B10; // .text:005B0A60 ; AC1Legacy::vlong *__thiscall AC1Legacy::vlong::operator*(AC1Legacy::vlong *this, AC1Legacy::vlong *result, AC1Legacy::vlong *x) .text:005B0A60 ??Dvlong@AC1Legacy@@QAE?AV01@ABV01@@Z

            // AC1Legacy::vlong.UnPack:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, void**, UInt32, Int32> UnPack = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, void**, UInt32, Int32>)0x005B1F70; // .text:005B0EC0 ; Int32 __thiscall AC1Legacy::vlong::UnPack(AC1Legacy::vlong *this, void **addr, UInt32 size) .text:005B0EC0 ?UnPack@vlong@AC1Legacy@@UAEHAAPAXI@Z

            // AC1Legacy::vlong.__vecDelDtor:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong*, UInt32, void*>)0x005B1FC0; // .text:005B0F10 ; void *__thiscall AC1Legacy::vlong::`vector deleting destructor'(AC1Legacy::vlong *this, UInt32) .text:005B0F10 ??_Evlong@AC1Legacy@@UAEPAXI@Z
        }
        public unsafe struct vlong_value {
            // Struct:
            public AC1Legacy.flex_unit flex_unit;
            public UInt32 share;
            public override string ToString() => $"flex_unit(AC1Legacy.flex_unit):{flex_unit}, share:{share:X8}";


            // Functions:

            // AC1Legacy::vlong_value.bits:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong_value*, UInt32> bits = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong_value*, UInt32>)0x005B1550; // .text:005B04A0 ; UInt32 __thiscall AC1Legacy::vlong_value::bits(AC1Legacy::vlong_value *this) .text:005B04A0 ?bits@vlong_value@AC1Legacy@@QBEIXZ

            // AC1Legacy::vlong_value.cf:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong_value*, AC1Legacy.vlong_value*, Int32> cf = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong_value*, AC1Legacy.vlong_value*, Int32>)0x005B15A0; // .text:005B04F0 ; Int32 __thiscall AC1Legacy::vlong_value::cf(AC1Legacy::vlong_value *this, AC1Legacy::vlong_value *x) .text:005B04F0 ?cf@vlong_value@AC1Legacy@@QBEHAAV12@@Z

            // AC1Legacy::vlong_value.add:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong_value*, AC1Legacy.vlong_value*> add = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong_value*, AC1Legacy.vlong_value*>)0x005B1630; // .text:005B0580 ; void __thiscall AC1Legacy::vlong_value::add(AC1Legacy::vlong_value *this, AC1Legacy::vlong_value *x) .text:005B0580 ?add@vlong_value@AC1Legacy@@QAEXAAV12@@Z

            // AC1Legacy::vlong_value.subtract:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong_value*, AC1Legacy.vlong_value*> subtract = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong_value*, AC1Legacy.vlong_value*>)0x005B16A0; // .text:005B05F0 ; void __thiscall AC1Legacy::vlong_value::subtract(AC1Legacy::vlong_value *this, AC1Legacy::vlong_value *x) .text:005B05F0 ?subtract@vlong_value@AC1Legacy@@QAEXAAV12@@Z

            // AC1Legacy::vlong_value.copy:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.vlong_value*, AC1Legacy.vlong_value*> copy = (delegate* unmanaged[Thiscall]<AC1Legacy.vlong_value*, AC1Legacy.vlong_value*>)0x005B1700; // .text:005B0650 ; void __thiscall AC1Legacy::vlong_value::copy(AC1Legacy::vlong_value *this, AC1Legacy::vlong_value *x) .text:005B0650 ?copy@vlong_value@AC1Legacy@@QAEXAAV12@@Z
        }
        public unsafe struct flex_unit {
            // Struct:
            public UInt32* a;
            public UInt32 z;
            public UInt32 n;
            public override string ToString() => $"a:->(UInt32*)0x{(Int32)a:X8}, z:{z:X8}, n:{n:X8}";


            // Functions:

            // AC1Legacy::flex_unit.reserve:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.flex_unit*, UInt32> reserve = (delegate* unmanaged[Thiscall]<AC1Legacy.flex_unit*, UInt32>)0x005B1330; // .text:005B0280 ; void __thiscall AC1Legacy::flex_unit::reserve(AC1Legacy::flex_unit *this, UInt32 x) .text:005B0280 ?reserve@flex_unit@AC1Legacy@@QAEXI@Z

            // AC1Legacy::flex_unit.set:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.flex_unit*, UInt32, UInt32> set = (delegate* unmanaged[Thiscall]<AC1Legacy.flex_unit*, UInt32, UInt32>)0x005B1390; // .text:005B02E0 ; void __thiscall AC1Legacy::flex_unit::set(AC1Legacy::flex_unit *this, UInt32 i, UInt32 x) .text:005B02E0 ?set@flex_unit@AC1Legacy@@QAEXII@Z

            // AC1Legacy::flex_unit.fast_mul:
            public static delegate* unmanaged[Thiscall]<AC1Legacy.flex_unit*, AC1Legacy.flex_unit*, AC1Legacy.flex_unit*, UInt32> fast_mul = (delegate* unmanaged[Thiscall]<AC1Legacy.flex_unit*, AC1Legacy.flex_unit*, AC1Legacy.flex_unit*, UInt32>)0x005B1450; // .text:005B03A0 ; void __thiscall AC1Legacy::flex_unit::fast_mul(AC1Legacy::flex_unit *this, AC1Legacy::flex_unit *x, AC1Legacy::flex_unit *y, UInt32 keep) .text:005B03A0 ?fast_mul@flex_unit@AC1Legacy@@QAEXAAV12@0I@Z
        }

    }

    public unsafe struct PortalDH {
        // Struct:
        public AC1Legacy.vlong shared_base_;
        public AC1Legacy.vlong shared_prime_;
        public override string ToString() => $"shared_base_(AC1Legacy.vlong):{shared_base_}, shared_prime_(AC1Legacy.vlong):{shared_prime_}";


        // Functions:

        // PortalDH.Init:
        public static delegate* unmanaged[Thiscall]<PortalDH*, AC1Legacy.vlong*, AC1Legacy.vlong*, Int32> Init = (delegate* unmanaged[Thiscall]<PortalDH*, AC1Legacy.vlong*, AC1Legacy.vlong*, Int32>)0x005B1300; // .text:005B0250 ; Int32 __thiscall PortalDH::Init(PortalDH *this, AC1Legacy::vlong *shared_base, AC1Legacy::vlong *shared_prime) .text:005B0250 ?Init@PortalDH@@QAEHAAVvlong@AC1Legacy@@0@Z
    }

    public unsafe struct ReceiverData {
        // Struct:
        public UInt16 m_RecID;
        public UInt16 iteration_;
        public UInt32 highestIDReceived_;
        public ReceiverData* next_;
        public ReceiverData* prev_;
        public Double timeStamp_;
        public Double m_LocalTimeLastGotData;
        public CryptoSystem* cryptoOutgoing_;
        public CryptoSystem* cryptoIncoming_;
        public NetKeyExch* keyExch_;
        public UInt16 m_NetID;
        public sockaddr_in m_Addr;
        public UInt16 m_CurrentRemoteInterval;
        public ReceiverState m_NakState;
        public ConnectionState m_ConnectionState;
        public AVL<UInt32, UInt32> m_SeqIDsWeNAKed;
        public Double m_TimeLastConnectionStateChanged;
        public Double lastSentHandshake_;
        public UInt32 m_BytesReceived;
        public UInt64 m_qwReferralCookie;
        public override string ToString() => $"m_RecID:{m_RecID:X4}, iteration_:{iteration_:X4}, highestIDReceived_:{highestIDReceived_:X8}, next_:->(ReceiverData*)0x{(Int32)next_:X8}, prev_:->(ReceiverData*)0x{(Int32)prev_:X8}, timeStamp_:{timeStamp_:n5}, m_LocalTimeLastGotData:{m_LocalTimeLastGotData:n5}, cryptoOutgoing_:->(CryptoSystem*)0x{(Int32)cryptoOutgoing_:X8}, cryptoIncoming_:->(CryptoSystem*)0x{(Int32)cryptoIncoming_:X8}, keyExch_:->(NetKeyExch*)0x{(Int32)keyExch_:X8}, m_NetID:{m_NetID:X4}, m_Addr(sockaddr_in):{m_Addr}, m_CurrentRemoteInterval:{m_CurrentRemoteInterval:X4}, m_NakState(ReceiverState):{m_NakState}, m_ConnectionState(ConnectionState):{m_ConnectionState}, m_SeqIDsWeNAKed(AVL<UInt32,UInt32>):{m_SeqIDsWeNAKed}, m_TimeLastConnectionStateChanged:{m_TimeLastConnectionStateChanged:n5}, lastSentHandshake_:{lastSentHandshake_:n5}, m_BytesReceived:{m_BytesReceived:X8}, m_qwReferralCookie(UInt64):{m_qwReferralCookie}";


        // Functions:

        // ReceiverData.GetConnectionStateDuration:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, Double> GetConnectionStateDuration = (delegate* unmanaged[Thiscall]<ReceiverData*, Double>)0x005498F0; // .text:00548D90 ; long Double __thiscall ReceiverData::GetConnectionStateDuration(ReceiverData *this) .text:00548D90 ?GetConnectionStateDuration@ReceiverData@@QBENXZ

        // ReceiverData.InitCrypto:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, UInt32, UInt32> InitCrypto = (delegate* unmanaged[Thiscall]<ReceiverData*, UInt32, UInt32>)0x00549900; // .text:00548DA0 ; void __thiscall ReceiverData::InitCrypto(ReceiverData *this, UInt32 seedIncoming, UInt32 seedOutgoing) .text:00548DA0 ?InitCrypto@ReceiverData@@QAEXKK@Z

        // ReceiverData.__Ctor:
        public static delegate* unmanaged[Thiscall]<ReceiverData*> __Ctor = (delegate* unmanaged[Thiscall]<ReceiverData*>)0x00549990; // .text:00548E30 ; void __thiscall ReceiverData::ReceiverData(ReceiverData *this) .text:00548E30 ??0ReceiverData@@QAE@XZ

        // ReceiverData.__Dtor:
        public static delegate* unmanaged[Thiscall]<ReceiverData*> __Dtor = (delegate* unmanaged[Thiscall]<ReceiverData*>)0x005499D0; // .text:00548E70 ; void __thiscall ReceiverData::~ReceiverData(ReceiverData *this) .text:00548E70 ??1ReceiverData@@QAE@XZ

        // ReceiverData.AddNakked:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, UInt32, UInt32*> AddNakked = (delegate* unmanaged[Thiscall]<ReceiverData*, UInt32, UInt32*>)0x00549DA0; // .text:00549240 ; void __thiscall ReceiverData::AddNakked(ReceiverData *this, UInt32 seqNum, UInt32 *pKeyPassed) .text:00549240 ?AddNakked@ReceiverData@@QAEXKPAK@Z

        // ReceiverData.Decrypt:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, UInt32, Char*, UInt32, UInt32*, UInt32> Decrypt = (delegate* unmanaged[Thiscall]<ReceiverData*, UInt32, Char*, UInt32, UInt32*, UInt32>)0x00549880; // .text:00548D20 ; UInt32 __thiscall ReceiverData::Decrypt(ReceiverData *this, UInt32 seqnum, Char *mem, UInt32 len, UInt32 *pDecryptKey) .text:00548D20 ?Decrypt@ReceiverData@@QAEKKPAEKPAK@Z

        // ReceiverData.SetConnectionState:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, ConnectionState> SetConnectionState = (delegate* unmanaged[Thiscall]<ReceiverData*, ConnectionState>)0x005498D0; // .text:00548D70 ; void __thiscall ReceiverData::SetConnectionState(ReceiverData *this, ConnectionState NewState) .text:00548D70 ?SetConnectionState@ReceiverData@@QAEXW4ConnectionState@@@Z

        // ReceiverData.Init:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, sockaddr_in, UInt32, UInt16, UInt16, UInt16, UInt16, NetKeyExch*, UInt32, UInt32> Init = (delegate* unmanaged[Thiscall]<ReceiverData*, sockaddr_in, UInt32, UInt16, UInt16, UInt16, UInt16, NetKeyExch*, UInt32, UInt32>)0x00549B00; // .text:00548FA0 ; void __thiscall ReceiverData::Init(ReceiverData *this, sockaddr_in addr, UInt32 highest, U__Int3216 recID, U__Int3216 netID, U__Int3216 iteration, U__Int3216 remoteInterval, NetKeyExch *keyExch, UInt32 seedIncoming, UInt32 seedOutgoing) .text:00548FA0 ?Init@ReceiverData@@QAEXUsockaddr_in@@KGGGGPAVNetKeyExch@@KK@Z

        // ReceiverData.Clear:
        public static delegate* unmanaged[Thiscall]<ReceiverData*> Clear = (delegate* unmanaged[Thiscall]<ReceiverData*>)0x00549B60; // .text:00549000 ; void __thiscall ReceiverData::Clear(ReceiverData *this) .text:00549000 ?Clear@ReceiverData@@QAEXXZ

        // ReceiverData.SharedInit:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, sockaddr_in*, UInt32, UInt16, UInt16, UInt16, UInt16, NetKeyExch*, UInt32, UInt32> SharedInit = (delegate* unmanaged[Thiscall]<ReceiverData*, sockaddr_in*, UInt32, UInt16, UInt16, UInt16, UInt16, NetKeyExch*, UInt32, UInt32>)0x00549A50; // .text:00548EF0 ; void __thiscall ReceiverData::SharedInit(ReceiverData *this, sockaddr_in *addr, UInt32 highest, U__Int3216 recID, U__Int3216 netID, U__Int3216 iteration, U__Int3216 remoteInterval, NetKeyExch *keyExch, UInt32 seedIncoming, UInt32 seedOutgoing) .text:00548EF0 ?SharedInit@ReceiverData@@QAEXAAUsockaddr_in@@KGGGGPAVNetKeyExch@@KK@Z

        // ReceiverData.GetNaks:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, UInt32*, Int32> GetNaks = (delegate* unmanaged[Thiscall]<ReceiverData*, UInt32*, Int32>)0x00549C20; // .text:005490C0 ; Int32 __thiscall ReceiverData::GetNaks(ReceiverData *this, UInt32 *naks) .text:005490C0 ?GetNaks@ReceiverData@@QAEHPAK@Z

        // ReceiverData.AddToQueue:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, ReceiverData**, ReceiverData**> AddToQueue = (delegate* unmanaged[Thiscall]<ReceiverData*, ReceiverData**, ReceiverData**>)0x005497C0; // .text:00548C60 ; void __thiscall ReceiverData::AddToQueue(ReceiverData *this, ReceiverData **head, ReceiverData **tail) .text:00548C60 ?AddToQueue@ReceiverData@@QAEXAAPAV1@0@Z

        // ReceiverData.RemoveFromQueue:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, ReceiverData**, ReceiverData**> RemoveFromQueue = (delegate* unmanaged[Thiscall]<ReceiverData*, ReceiverData**, ReceiverData**>)0x005497F0; // .text:00548C90 ; void __thiscall ReceiverData::RemoveFromQueue(ReceiverData *this, ReceiverData **head, ReceiverData **tail) .text:00548C90 ?RemoveFromQueue@ReceiverData@@QAEXAAPAV1@0@Z

        // ReceiverData.Encrypt:
        public static delegate* unmanaged[Thiscall]<ReceiverData*, UInt32, Char*, UInt32, UInt32*, UInt32> Encrypt = (delegate* unmanaged[Thiscall]<ReceiverData*, UInt32, Char*, UInt32, UInt32*, UInt32>)0x00549870; // .text:00548D10 ; UInt32 __thiscall ReceiverData::Encrypt(ReceiverData *this, UInt32 seqnum, Char *mem, UInt32 len, UInt32 *pEncryptKey) .text:00548D10 ?Encrypt@ReceiverData@@QAEKKPAEKPAK@Z
    }

    public unsafe struct FlowQueue {
        // Struct:
        public Vtbl* vfptr;
        public NetPacket* waitingPacketsHead_;
        public NetPacket* waitingPacketsTail_;
        public NIList<UInt32> m_ackList;
        public SentPacketStore m_sentPacketStore;
        public NIList<UInt32> m_emptyAckList;
        public HashTable<UInt32, Int32> empties_;
        public fixed UInt32 emptyAcks_[116];
        public Int32 emptyNum_;
        public Int32 m_cPacketsSent;
        public Int32 m_cPacketsAcked;
        public UInt32 highestIDSent_;
        public sockaddr_in addr_;
        public RecipientData* myRecip_;
        public ReceiverData* myReceiverData_;
        public UInt16 netID_;
        public IntervalData CurLocalInterval_;
        public PQueueArray<UInt32, Int32> pqueueSpecial_;
        public Double Int32ervalTime_;
        public UInt16 lastIntervalAcked_;
        public override string ToString() => $"vfptr:->(FlowQueueVtbl*)0x{(Int32)vfptr:X8}, waitingPacketsHead_:->(NetPacket*)0x{(Int32)waitingPacketsHead_:X8}, waitingPacketsTail_:->(NetPacket*)0x{(Int32)waitingPacketsTail_:X8}, m_ackList(NIList<UInt32>):{m_ackList}, m_sentPacketStore(SentPacketStore):{m_sentPacketStore}, m_emptyAckList(NIList<UInt32>):{m_emptyAckList}, empties_(HashTable<UInt32,Int32,0>):{empties_}, emptyAcks_[116]:{emptyAcks_[116]:X8}, emptyNum_:{emptyNum_}, m_cPacketsSent:{m_cPacketsSent}, m_cPacketsAcked:{m_cPacketsAcked}, highestIDSent_:{highestIDSent_:X8}, addr_(sockaddr_in):{addr_}, myRecip_:->(RecipientData*)0x{(Int32)myRecip_:X8}, myReceiverData_:->(ReceiverData*)0x{(Int32)myReceiverData_:X8}, netID_:{netID_:X4}, CurLocalInterval_(IntervalData):{CurLocalInterval_}, pqueueSpecial_(PQueueArray<UInt32,void*>):{pqueueSpecial_}, Int32ervalTime_:{Int32ervalTime_:n5}, lastIntervalAcked_:{lastIntervalAcked_:X4}";
        public unsafe struct Vtbl {
            // Struct:
            public static delegate* unmanaged[Thiscall]<FlowQueue*, UInt32, void*> __vecDelDtor; //   void *(__thiscall *__vecDelDtor)(FlowQueue *this, UInt32);
            public fixed Byte gap4[4];
            public static delegate* unmanaged[Thiscall]<FlowQueue*, Int32, NetBlob*> Dequeue; //   NetBlob *(__thiscall *Dequeue)(FlowQueue *this, Int32);
            public static delegate* unmanaged[Thiscall]<FlowQueue*, UInt32> IncrementLocalInterval; //   void (__thiscall *IncrementLocalInterval)(FlowQueue *this, UInt32);
            public static delegate* unmanaged[Thiscall]<FlowQueue*, Int32, Int32> WireRoomLeft; //   Int32 (__thiscall *WireRoomLeft)(FlowQueue *this, Int32);
            public static delegate* unmanaged[Thiscall]<FlowQueue*, Int32, Int32> FragQueueRoomLeft; //   Int32 (__thiscall *FragQueueRoomLeft)(FlowQueue *this, Int32);
            public static delegate* unmanaged[Thiscall]<FlowQueue*, Int32> RecordBytesSent; //   void (__thiscall *RecordBytesSent)(FlowQueue *this, Int32);
            public static delegate* unmanaged[Thiscall]<FlowQueue*, Int32> RecordBytesQueued; //   void (__thiscall *RecordBytesQueued)(FlowQueue *this, Int32);
            public static delegate* unmanaged[Thiscall]<FlowQueue*, Int32> RecordBytesDequeued; //   void (__thiscall *RecordBytesDequeued)(FlowQueue *this, Int32);
            public static delegate* unmanaged[Thiscall]<FlowQueue*, NetPacket*, NetPacket**, NetPacket**> EnqueuePacket; //   void (__thiscall *EnqueuePacket)(FlowQueue *this, NetPacket *, NetPacket **, NetPacket **);
            public static delegate* unmanaged[Thiscall]<FlowQueue*, NetPacket**, NetPacket**, NetPacket*> DequeuePacket; //   NetPacket *(__thiscall *DequeuePacket)(FlowQueue *this, NetPacket **, NetPacket **);
        }


        // Functions:

        // FlowQueue.CoalesceData:
        public static delegate* unmanaged[Thiscall]<FlowQueue*> CoalesceData = (delegate* unmanaged[Thiscall]<FlowQueue*>)0x00548300; // .text:00547740 ; void __thiscall FlowQueue::CoalesceData(FlowQueue *this) .text:00547740 ?CoalesceData@FlowQueue@@IAEXXZ

        // FlowQueue.__Dtor:
        public static delegate* unmanaged[Thiscall]<FlowQueue*> __Dtor = (delegate* unmanaged[Thiscall]<FlowQueue*>)0x00548E60; // .text:00548300 ; void __thiscall FlowQueue::~FlowQueue(FlowQueue *this) .text:00548300 ??1FlowQueue@@UAE@XZ

        // FlowQueue.CompileEmptyAcks:
        public static delegate* unmanaged[Thiscall]<FlowQueue*> CompileEmptyAcks = (delegate* unmanaged[Thiscall]<FlowQueue*>)0x00549020; // .text:005484C0 ; void __thiscall FlowQueue::CompileEmptyAcks(FlowQueue *this) .text:005484C0 ?CompileEmptyAcks@FlowQueue@@QAEXXZ

        // FlowQueue.SharedStaticInit:
        // (ERR) .text:005496D0 ; public: static void __cdecl FlowQueue::SharedStaticInit(void) .text:005496D0 ?SharedStaticInit@FlowQueue@@SAXXZ

        // FlowQueue.EncryptChecksum:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, NetPacket*, UInt32, UInt32*> EncryptChecksum = (delegate* unmanaged[Thiscall]<FlowQueue*, NetPacket*, UInt32, UInt32*>)0x00547C70; // .text:005470B0 ; void __thiscall FlowQueue::EncryptChecksum(FlowQueue *this, NetPacket *packet, UInt32 seqnum, UInt32 *pKey) .text:005470B0 ?EncryptChecksum@FlowQueue@@IAEXPAVNetPacket@@KPAK@Z

        // FlowQueue.EnqueueOptionalHeader:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, COptionalHeader*> EnqueueOptionalHeader = (delegate* unmanaged[Thiscall]<FlowQueue*, COptionalHeader*>)0x00548230; // .text:00547670 ; void __thiscall FlowQueue::EnqueueOptionalHeader(FlowQueue *this, COptionalHeader *newFrag) .text:00547670 ?EnqueueOptionalHeader@FlowQueue@@QAEXPAVCOptionalHeader@@@Z

        // FlowQueue.__Ctor:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, sockaddr_in, UInt16, Single> __Ctor = (delegate* unmanaged[Thiscall]<FlowQueue*, sockaddr_in, UInt16, Single>)0x00548D40; // .text:005481E0 ; void __thiscall FlowQueue::FlowQueue(FlowQueue *this, sockaddr_in addr, U__Int3216 recID, Single lineNoise) .text:005481E0 ??0FlowQueue@@QAE@Usockaddr_in@@GM@Z

        // FlowQueue.EnqueueEmptyAck:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, UInt32> EnqueueEmptyAck = (delegate* unmanaged[Thiscall]<FlowQueue*, UInt32>)0x00548EE0; // .text:00548380 ; void __thiscall FlowQueue::EnqueueEmptyAck(FlowQueue *this, UInt32 id) .text:00548380 ?EnqueueEmptyAck@FlowQueue@@QAEXK@Z

        // FlowQueue.DequeueEmptyAck:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, UInt32*, Int32> DequeueEmptyAck = (delegate* unmanaged[Thiscall]<FlowQueue*, UInt32*, Int32>)0x00548FA0; // .text:00548440 ; Int32 __thiscall FlowQueue::DequeueEmptyAck(FlowQueue *this, UInt32 *seqID) .text:00548440 ?DequeueEmptyAck@FlowQueue@@QAEHAAK@Z

        // FlowQueue.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<FlowQueue*, UInt32, void*>)0x00549320; // .text:005487C0 ; void *__thiscall FlowQueue::`vector deleting destructor'(FlowQueue *this, UInt32) .text:005487C0 ??_EFlowQueue@@UAEPAXI@Z

        // FlowQueue.Empty:
        public static delegate* unmanaged[Thiscall]<FlowQueue*> Empty = (delegate* unmanaged[Thiscall]<FlowQueue*>)0x00549580; // .text:00548A20 ; void __thiscall FlowQueue::Empty(FlowQueue *this) .text:00548A20 ?Empty@FlowQueue@@QAEXXZ

        // FlowQueue.SharedStaticCleanup:
        // (ERR) .text:00547E70 ; public: static void __cdecl FlowQueue::SharedStaticCleanup(void) .text:00547E70 ?SharedStaticCleanup@FlowQueue@@SAXXZ

        // FlowQueue.IncrementLocalInterval:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, UInt32> IncrementLocalInterval = (delegate* unmanaged[Thiscall]<FlowQueue*, UInt32>)0x00547CC0; // .text:00547100 ; void __thiscall FlowQueue::IncrementLocalInterval(FlowQueue *this, UInt32 cIntervals) .text:00547100 ?IncrementLocalInterval@FlowQueue@@UAEXK@Z

        // FlowQueue.DequeueAck:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, NetPacket*> DequeueAck = (delegate* unmanaged[Thiscall]<FlowQueue*, NetPacket*>)0x00547EB0; // .text:005472F0 ; NetPacket *__thiscall FlowQueue::DequeueAck(FlowQueue *this) .text:005472F0 ?DequeueAck@FlowQueue@@QAEPAVNetPacket@@XZ

        // FlowQueue.TransmitNewPackets:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, Byte> TransmitNewPackets = (delegate* unmanaged[Thiscall]<FlowQueue*, Byte>)0x00548620; // .text:00547A60 ; bool __thiscall FlowQueue::TransmitNewPackets(FlowQueue *this) .text:00547A60 ?TransmitNewPackets@FlowQueue@@IAE_NXZ

        // FlowQueue.Destroy:
        public static delegate* unmanaged[Thiscall]<FlowQueue*> Destroy = (delegate* unmanaged[Thiscall]<FlowQueue*>)0x00549340; // .text:005487E0 ; void __thiscall FlowQueue::Destroy(FlowQueue *this) .text:005487E0 ?Destroy@FlowQueue@@QAEXXZ

        // FlowQueue.DequeuePacket:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, NetPacket**, NetPacket**, NetPacket*> DequeuePacket = (delegate* unmanaged[Thiscall]<FlowQueue*, NetPacket**, NetPacket**, NetPacket*>)0x00547C30; // .text:00547070 ; NetPacket *__thiscall FlowQueue::DequeuePacket(FlowQueue *this, NetPacket **head, NetPacket **tail) .text:00547070 ?DequeuePacket@FlowQueue@@MAEPAVNetPacket@@AAPAV2@0@Z

        // FlowQueue.EnqueuePacket:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, NetPacket*, NetPacket**, NetPacket**> EnqueuePacket = (delegate* unmanaged[Thiscall]<FlowQueue*, NetPacket*, NetPacket**, NetPacket**>)0x00547F70; // .text:005473B0 ; void __thiscall FlowQueue::EnqueuePacket(FlowQueue *this, NetPacket *packet, NetPacket **head, NetPacket **tail) .text:005473B0 ?EnqueuePacket@FlowQueue@@MAEXPAVNetPacket@@AAPAV2@1@Z

        // FlowQueue.TransmitAcks:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, Byte> TransmitAcks = (delegate* unmanaged[Thiscall]<FlowQueue*, Byte>)0x00549110; // .text:005485B0 ; bool __thiscall FlowQueue::TransmitAcks(FlowQueue *this) .text:005485B0 ?TransmitAcks@FlowQueue@@IAE_NXZ

        // FlowQueue.EnqueueAcks:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, UInt32*, Int32> EnqueueAcks = (delegate* unmanaged[Thiscall]<FlowQueue*, UInt32*, Int32>)0x00549440; // .text:005488E0 ; void __thiscall FlowQueue::EnqueueAcks(FlowQueue *this, const UInt32 *id, Int32 nIDs) .text:005488E0 ?EnqueueAcks@FlowQueue@@QAEXPBKH@Z

        // FlowQueue.FlushSentPackets:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, UInt32, Int32> FlushSentPackets = (delegate* unmanaged[Thiscall]<FlowQueue*, UInt32, Int32>)0x00548280; // .text:005476C0 ; void __thiscall FlowQueue::FlushSentPackets(FlowQueue *this, UInt32 id, Int32 fEverything) .text:005476C0 ?FlushSentPackets@FlowQueue@@QAEXKH@Z

        // FlowQueue.TransmitNaks:
        public static delegate* unmanaged[Thiscall]<FlowQueue*, Byte> TransmitNaks = (delegate* unmanaged[Thiscall]<FlowQueue*, Byte>)0x005490A0; // .text:00548540 ; bool __thiscall FlowQueue::TransmitNaks(FlowQueue *this) .text:00548540 ?TransmitNaks@FlowQueue@@IAE_NXZ

        // Globals:
        public static PerfMonCounter<UInt64>** m_pBlobsDequeuedCounter = (PerfMonCounter<UInt64>**)0x00846F64; // .data:00845F54 ; PerfMonCounter<UInt64> *FlowQueue::m_pBlobsDequeuedCounter .data:00845F54 ?m_pBlobsDequeuedCounter@FlowQueue@@1PAV?$PerfMonCounter@_K@@A
    }

    public unsafe struct SentPacketStore {
        // Struct:
        public NIList<NetPacket> m_sentPacketList;
        public HashTable<UInt64, UInt64> m_sentNetBlobIDInfo;
        public override string ToString() => $"m_sentPacketList(NIList<NetPacket*>):{m_sentPacketList}, m_sentNetBlobIDInfo(HashTable<UInt64,UInt64,0>):{m_sentNetBlobIDInfo}";


        // Functions:

        // SentPacketStore.Contains:
        public static delegate* unmanaged[Thiscall]<SentPacketStore*, UInt32, Int32> Contains = (delegate* unmanaged[Thiscall]<SentPacketStore*, UInt32, Int32>)0x0054B400; // .text:0054A8A0 ; Int32 __thiscall SentPacketStore::Contains(SentPacketStore *this, UInt32 seqID) .text:0054A8A0 ?Contains@SentPacketStore@@QAEHK@Z

        // SentPacketStore.GenerateAck:
        public static delegate* unmanaged[Thiscall]<SentPacketStore*, UInt32, NetPacket*> GenerateAck = (delegate* unmanaged[Thiscall]<SentPacketStore*, UInt32, NetPacket*>)0x0054B430; // .text:0054A8D0 ; NetPacket *__thiscall SentPacketStore::GenerateAck(SentPacketStore *this, UInt32 seqID) .text:0054A8D0 ?GenerateAck@SentPacketStore@@QAEPAVNetPacket@@K@Z

        // SentPacketStore.__Ctor:
        public static delegate* unmanaged[Thiscall]<SentPacketStore*> __Ctor = (delegate* unmanaged[Thiscall]<SentPacketStore*>)0x0054B690; // .text:0054AA80 ; void __thiscall SentPacketStore::SentPacketStore(SentPacketStore *this) .text:0054AA80 ??0SentPacketStore@@QAE@XZ

        // SentPacketStore.__Dtor:
        public static delegate* unmanaged[Thiscall]<SentPacketStore*> __Dtor = (delegate* unmanaged[Thiscall]<SentPacketStore*>)0x0054B6C0; // .text:0054AAB0 ; void __thiscall SentPacketStore::~SentPacketStore(SentPacketStore *this) .text:0054AAB0 ??1SentPacketStore@@QAE@XZ

        // SentPacketStore.AddSentPacket:
        public static delegate* unmanaged[Thiscall]<SentPacketStore*, NetPacket*, Int32> AddSentPacket = (delegate* unmanaged[Thiscall]<SentPacketStore*, NetPacket*, Int32>)0x0054B710; // .text:0054AB00 ; Int32 __thiscall SentPacketStore::AddSentPacket(SentPacketStore *this, NetPacket *packet) .text:0054AB00 ?AddSentPacket@SentPacketStore@@QAEHPAVNetPacket@@@Z

        // SentPacketStore.EraseNetBlobID:
        // public static delegate* unmanaged[Thiscall]<SentPacketStore*,UInt64> EraseNetBlobID = (delegate* unmanaged[Thiscall]<SentPacketStore*,UInt64>)0xDEADBEEF; // .text:0054AC50 ; void __thiscall SentPacketStore::EraseNetBlobID(SentPacketStore *this, UInt64 _id) .text:0054AC50 ?EraseNetBlobID@SentPacketStore@@IAEX_K@Z

        // SentPacketStore.Flush:
        // public static delegate* unmanaged[Thiscall]<SentPacketStore*,UInt32,Int32, Int32> Flush = (delegate* unmanaged[Thiscall]<SentPacketStore*,UInt32,Int32, Int32>)0xDEADBEEF; // .text:0054ACD0 ; Int32 __thiscall SentPacketStore::Flush(SentPacketStore *this, UInt32 highest, Int32 everything) .text:0054ACD0 ?Flush@SentPacketStore@@QAEHKH@Z
    }



    public unsafe struct Indicator {
        // Struct:
        public _Vtbl* vfptr;
        public UI64Hash<NetBlob> waitingBlobs_;
        public UI64Hash<ArrivedEphInfo> arrivedEphBlobs_;
        public ArrivedEphInfo* firstInfo_;
        public Double flushStamp_;
        public override string ToString() => $"vfptr:->(IndicatorVtbl*)0x{(Int32)vfptr:X8}, waitingBlobs_(UI64Hash<NetBlob>):{waitingBlobs_}, arrivedEphBlobs_(UI64Hash<ArrivedEphInfo>):{arrivedEphBlobs_}, firstInfo_:->(ArrivedEphInfo*)0x{(Int32)firstInfo_:X8}, flushStamp_:{flushStamp_:n5}";


        // Functions:

        // Indicator.SendBlobToQueue:
        // public static delegate* unmanaged[Thiscall]<Indicator*,NetBlob*> SendBlobToQueue = (delegate* unmanaged[Thiscall]<Indicator*,NetBlob*>)0xDEADBEEF; // .text:0054A200 ; void __thiscall Indicator::SendBlobToQueue(Indicator *this, NetBlob *toSend) .text:0054A200 ?SendBlobToQueue@Indicator@@IAEXPAVNetBlob@@@Z

        // Indicator.__Ctor:
        public static delegate* unmanaged[Thiscall]<Indicator*> __Ctor = (delegate* unmanaged[Thiscall]<Indicator*>)0x0054ADB0; // .text:0054A250 ; void __thiscall Indicator::Indicator(Indicator *this) .text:0054A250 ??0Indicator@@QAE@XZ

        // Indicator.CleanupWaitingBlobs:
        // public static delegate* unmanaged[Thiscall]<Indicator*> CleanupWaitingBlobs = (delegate* unmanaged[Thiscall]<Indicator*>)0xDEADBEEF; // .text:0054A580 ; void __thiscall Indicator::CleanupWaitingBlobs(Indicator *this) .text:0054A580 ?CleanupWaitingBlobs@Indicator@@IAEXXZ

        // Indicator.__Dtor:
        // public static delegate* unmanaged[Thiscall]<Indicator*> __Dtor = (delegate* unmanaged[Thiscall]<Indicator*>)0xDEADBEEF; // .text:0054A790 ; void __thiscall Indicator::~Indicator(Indicator *this) .text:0054A790 ??1Indicator@@UAE@XZ

        // Indicator.CheckInPacket:
        public static delegate* unmanaged[Thiscall]<Indicator*, NetPacket*, UInt16> CheckInPacket = (delegate* unmanaged[Thiscall]<Indicator*, NetPacket*, UInt16>)0x0054B340; // .text:0054A7E0 ; void __thiscall Indicator::CheckInPacket(Indicator *this, NetPacket *packet, U__Int3216 sender) .text:0054A7E0 ?CheckInPacket@Indicator@@QAEXPBVNetPacket@@G@Z

        // Indicator.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<Indicator*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<Indicator*,UInt32, void*>)0xDEADBEEF; // .text:0054A840 ; void *__thiscall Indicator::`vector deleting destructor'(Indicator *this, UInt32) .text:0054A840 ??_EIndicator@@UAEPAXI@Z

        // Indicator.AddArrivedEphInfo:
        public static delegate* unmanaged[Thiscall]<Indicator*, ArrivedEphInfo*> AddArrivedEphInfo = (delegate* unmanaged[Thiscall]<Indicator*, ArrivedEphInfo*>)0x0054AED0; // .text:0054A370 ; void __thiscall Indicator::AddArrivedEphInfo(Indicator *this, ArrivedEphInfo *info) .text:0054A370 ?AddArrivedEphInfo@Indicator@@IAEXPAVArrivedEphInfo@@@Z

        // Indicator.FlushTimedOutEphInfo:
        public static delegate* unmanaged[Thiscall]<Indicator*> FlushTimedOutEphInfo = (delegate* unmanaged[Thiscall]<Indicator*>)0x0054AF30; // .text:0054A3D0 ; void __thiscall Indicator::FlushTimedOutEphInfo(Indicator *this) .text:0054A3D0 ?FlushTimedOutEphInfo@Indicator@@QAEXXZ

        // Indicator.FragIsObsoleteEmphemeral:
        // public static delegate* unmanaged[Thiscall]<Indicator*,UInt64, Int32> FragIsObsoleteEmphemeral = (delegate* unmanaged[Thiscall]<Indicator*,UInt64, Int32>)0xDEADBEEF; // .text:0054A450 ; Int32 __thiscall Indicator::FragIsObsoleteEmphemeral(Indicator *this, UInt64 _netBlobID) .text:0054A450 ?FragIsObsoleteEmphemeral@Indicator@@IAEH_K@Z

        // Indicator.AcceptFrag:
        // public static delegate* unmanaged[Thiscall]<Indicator*,BlobFrag*,UInt16> AcceptFrag = (delegate* unmanaged[Thiscall]<Indicator*,BlobFrag*,UInt16>)0xDEADBEEF; // .text:0054A640 ; void __thiscall Indicator::AcceptFrag(Indicator *this, BlobFrag *newFrag, U__Int3216 sender) .text:0054A640 ?AcceptFrag@Indicator@@QAEXPAVBlobFrag@@G@Z
    }

    public unsafe struct COptionalHeader {
        // Struct:
        public Turbine_RefCount _ref;
        public UInt32 m_dwMask;
        public UInt32 m_Flags;
        public Char* m_pData;
        public UInt32 m_cbData;
        public override string ToString() => $"_ref(Turbine_RefCount):{_ref}, m_dwMask:{m_dwMask:X8}, m_Flags:{m_Flags:X8}, m_pData:->(Char*)0x{(Int32)m_pData:X8}, m_cbData:{m_cbData:X8}";

    }
    public unsafe struct BlobFragHeader_t {
        // Struct:
        public UInt64 blobID;
        public UInt16 numFrags;
        public UInt16 blobFragSize;
        public UInt16 blobNum;
        public UInt16 queueID;
        public override string ToString() => $"blobID(UInt64):{blobID:X8}, numFrags:{numFrags}, blobFragSize:{blobFragSize}, blobNum:{blobNum}, queueID:{queueID}";

    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct in_addr {
        [FieldOffset(0)] public UInt32 S_addr;
        [FieldOffset(0)] public UInt16 s_w1;
        [FieldOffset(2)] public UInt16 s_w2;
        [FieldOffset(0)] public Char s_b1;
        [FieldOffset(1)] public Char s_b2;
        [FieldOffset(2)] public Char s_b3;
        [FieldOffset(3)] public Char s_b4;
        public override string ToString() => $"{s_b1}.{s_b2}.{s_b3}.{s_b4}";
    };

    public unsafe struct sockaddr_in {
        public Sin_family sin_family;
        public UInt16 sin_port;
        public in_addr sin_addr;
        public fixed Char sin_zero[8];
        public override string ToString() => $"sin_family:{sin_family}, sin_port:{sin_port:X4}, sin_addr(in_addr):{sin_addr}, sin_zero[8]:{(UInt64)sin_zero[0]:x16}";
        public enum Sin_family : Int16 {
            AF_UNSPEC = 0,
            AF_UNIX = 1,
            AF_INET = 2,
            AF_IMPLINK = 3,           // arpanet imp addresses
            AF_PUP = 4,        // pup protocols: e.g. BSP
            AF_CHAOS = 5,         // mit CHAOS protocols
            AF_NS = 6,          // XEROX NS protocols
            AF_IPX = AF_NS,           // IPX protocols: IPX, SPX, etc.
            AF_ISO = 7,             // ISO protocols
            AF_OSI = AF_ISO,  // OSI is ISO
            AF_ECMA = 8,   // european computer manufacturers
            AF_DATAKIT = 9,    // datakit protocols
            AF_CCITT = 10,     // CCITT protocols, X.25 etc
            AF_SNA = 11,      // IBM SNA
            AF_DECnet = 12,       // DECnet
            AF_DLI = 13,        // Direct data link interface
            AF_LAT = 14,         // LAT
            AF_HYLINK = 15,          // NSC Hyperchannel
            AF_APPLETALK = 16,           // AppleTalk
            AF_NETBIOS = 17,            // NetBios-style addresses
            AF_VOICEVIEW = 18,            // VoiceView
            AF_FIREFOX = 19,     // Protocols from Firefox
            AF_UNKNOWN1 = 20,      // Somebody is using this!
            AF_BAN = 21,       // Banyan
            AF_ATM = 22,        // Native ATM Services
            AF_INET6 = 23,         // Internetwork Version 6
            AF_CLUSTER = 24,          // Microsoft Wolfpack
            AF_12844 = 25,           // IEEE 1284.4 WG AF
            AF_IRDA = 26,            // IrDA
            AF_NETDES = 28,             // Network Designers OSI & gateway
            AF_MAX = 29,
        };
    };

    public unsafe struct BlobFrag {
        // Struct:
        public Turbine_RefCount _ref;
        public BlobFrag* blobNextFrag_;
        public BlobFragHeader_t* hdrWrite_;
        public BlobFragHeader_t* hdrRead_;
        public BlobFragHeader_t memberHeader_;
        public Char* dat_;
        public NetBlob* myBlob_;
        public override string ToString() => $"_ref(Turbine_RefCount):{_ref}, blobNextFrag_:->(BlobFrag*)0x{(Int32)blobNextFrag_:X8}, hdrWrite_:->(BlobFragHeader_t*)0x{(Int32)hdrWrite_:X8}, hdrRead_:->(BlobFragHeader_t*)0x{(Int32)hdrRead_:X8}, memberHeader_(BlobFragHeader_t):{memberHeader_}, dat_:->(Char*)0x{(Int32)dat_:X8}, myBlob_:->(NetBlob*)0x{(Int32)myBlob_:X8}";


        // Functions:

        // BlobFrag.__Ctor:
        // public static delegate* unmanaged[Thiscall]<BlobFrag*,Char*,UInt32,UInt32*> __Ctor = (delegate* unmanaged[Thiscall]<BlobFrag*,Char*,UInt32,UInt32*>)0xDEADBEEF; // .text:005497C0 ; void __thiscall BlobFrag::BlobFrag(BlobFrag *this, const Char *pbData, UInt32 cbSize, UInt32 *cbUsed) .text:005497C0 ??0BlobFrag@@IAE@PBEKAAK@Z

        // BlobFrag.CreateForSend:
        // public static delegate* unmanaged[Cdecl]<NetBlob*,UInt32,UInt32,Char*,UInt32, BlobFrag*> CreateForSend = (delegate* unmanaged[Cdecl]<NetBlob*,UInt32,UInt32,Char*,UInt32, BlobFrag*>)0xDEADBEEF; // .text:00549820 ; BlobFrag *__cdecl BlobFrag::CreateForSend(NetBlob *myBlob, UInt32 blobNum, UInt32 cTotalBlobs, Char *dat, UInt32 size) .text:00549820 ?CreateForSend@BlobFrag@@SAPAV1@PAVNetBlob@@KKPAEK@Z

        // BlobFrag.CreateForRecv:
        public static delegate* unmanaged[Cdecl]<CBufferIterator*, BlobFrag*> CreateForRecv = (delegate* unmanaged[Cdecl]<CBufferIterator*, BlobFrag*>)0x0054A3C0; // .text:00549860 ; BlobFrag *__cdecl BlobFrag::CreateForRecv(CBufferIterator *Buf) .text:00549860 ?CreateForRecv@BlobFrag@@SAPAV1@AAVCBufferIterator@@@Z

        // BlobFrag.__Ctor:
        // public static delegate* unmanaged[Thiscall]<BlobFrag*,NetBlob*,UInt32,UInt32,Char*,UInt32> __Ctor = (delegate* unmanaged[Thiscall]<BlobFrag*,NetBlob*,UInt32,UInt32,Char*,UInt32>)0xDEADBEEF; // .text:005496F0 ; void __thiscall BlobFrag::BlobFrag(BlobFrag *this, NetBlob *myBlob, UInt32 blobNum, UInt32 cTotalBlobs, Char *dat, UInt32 size) .text:005496F0 ??0BlobFrag@@IAE@PAVNetBlob@@KKPAEK@Z

        // BlobFrag.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<BlobFrag*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<BlobFrag*,UInt32, void*>)0xDEADBEEF; // .text:00549780 ; void *__thiscall BlobFrag::`vector deleting destructor'(BlobFrag *this, UInt32) .text:00549780 ??_EBlobFrag@@MAEPAXI@Z
    }
    public unsafe struct CBufferIterator {
        // Struct:
        public Char* m_pBuf;
        public UInt32 m_dwCurOfs;
        public UInt32 m_cbBufSize;
        public override string ToString() => $"m_pBuf:->(Char*)0x{(Int32)m_pBuf:X8}, m_dwCurOfs:{m_dwCurOfs:X8}, m_cbBufSize:{m_cbBufSize:X8}";


        // Functions:

        // CBufferIterator.ReadPrimArray:
        public static delegate* unmanaged[Thiscall]<CBufferIterator*, UInt32*, Int32, Byte> ReadPrimArray = (delegate* unmanaged[Thiscall]<CBufferIterator*, UInt32*, Int32, Byte>)0x005AB870; // .text:005AA7C0 ; bool __thiscall CBufferIterator::ReadPrimArray(CBufferIterator *this, UInt32 *, Int32) .text:005AA7C0 ?ReadPrimArray@CBufferIterator@@QAE_NPAKH@Z
    }

    public unsafe struct NetPacket {
        // Struct:
        public Turbine_RefCount _ref;
        public NetPacket* next_;
        public COptionalHeader** specialFragList_; // [32];
        public UInt32 numSpecialFrags_;
        public BlobFrag** fragList_; // [29];
        public UInt32 numFrags_;
        public UInt16 recipient_;
        public UInt32 realPriority_;
        public UInt32 size_;
        public UInt32 seqNum_;
        public UInt32 cryptoKey_;
        public UInt32 checksum_;
        public UInt32 flags_;
        public override string ToString() => $"_ref(Turbine_RefCount):{_ref}, next_:->(NetPacket*)0x{(Int32)next_:X8}, specialFragList_[32]:->(COptionalHeader*)0x{(Int32)specialFragList_:X8}, numSpecialFrags_:{numSpecialFrags_:X8}, fragList_[29]:->(BlobFrag*)0x{(Int32)fragList_:X8}, numFrags_:{numFrags_:X8}, recipient_:{recipient_:X4}, realPriority_:{realPriority_:X8}, size_:{size_:X8}, seqNum_:{seqNum_:X8}, cryptoKey_:{cryptoKey_:X8}, checksum_:{checksum_:X8}, flags_:{flags_:X8}";


        // Functions:

        // NetPacket.ApplySpecialFrags:
        public static delegate* unmanaged[Thiscall]<NetPacket*, ProtoHeader*, UInt32> ApplySpecialFrags = (delegate* unmanaged[Thiscall]<NetPacket*, ProtoHeader*, UInt32>)0x00549ED0; // .text:00549370 ; UInt32 __thiscall NetPacket::ApplySpecialFrags(NetPacket *this, ProtoHeader *pHeader) .text:00549370 ?ApplySpecialFrags@NetPacket@@QAEKPAVProtoHeader@@@Z

        // NetPacket.AddToTail:
        public static delegate* unmanaged[Thiscall]<NetPacket*, NetPacket**, NetPacket**> AddToTail = (delegate* unmanaged[Thiscall]<NetPacket*, NetPacket**, NetPacket**>)0x00549F00; // .text:005493A0 ; void __thiscall NetPacket::AddToTail(NetPacket *this, NetPacket **head, NetPacket **tail) .text:005493A0 ?AddToTail@NetPacket@@QAEXAAPAV1@0@Z

        // NetPacket.Remove:
        public static delegate* unmanaged[Thiscall]<NetPacket*, NetPacket*, NetPacket**, NetPacket**> Remove = (delegate* unmanaged[Thiscall]<NetPacket*, NetPacket*, NetPacket**, NetPacket**>)0x00549F80; // .text:00549420 ; void __thiscall NetPacket::Remove(NetPacket *this, NetPacket *prev, NetPacket **head, NetPacket **tail) .text:00549420 ?Remove@NetPacket@@QAEXPAV1@AAPAV1@1@Z

        // NetPacket.AddFrag:
        public static delegate* unmanaged[Thiscall]<NetPacket*, BlobFrag*, UInt16, UInt32> AddFrag = (delegate* unmanaged[Thiscall]<NetPacket*, BlobFrag*, UInt16, UInt32>)0x0054A1A0; // .text:00549640 ; void __thiscall NetPacket::AddFrag(NetPacket *this, BlobFrag *frag, U__Int3216 recip, UInt32 priority) .text:00549640 ?AddFrag@NetPacket@@QAEXPAVBlobFrag@@GK@Z

        // NetPacket.AddOptionalHeader:
        public static delegate* unmanaged[Thiscall]<NetPacket*, COptionalHeader*> AddOptionalHeader = (delegate* unmanaged[Thiscall]<NetPacket*, COptionalHeader*>)0x00549FC0; // .text:00549460 ; void __thiscall NetPacket::AddOptionalHeader(NetPacket *this, COptionalHeader *frag) .text:00549460 ?AddOptionalHeader@NetPacket@@QAEXPAVCOptionalHeader@@@Z

        // NetPacket.RemoveDisposableOptionalHeaders:
        // public static delegate* unmanaged[Thiscall]<NetPacket*, Byte> RemoveDisposableOptionalHeaders = (delegate* unmanaged[Thiscall]<NetPacket*, Byte>)0xDEADBEEF; // .text:00549510 ; bool __thiscall NetPacket::RemoveDisposableOptionalHeaders(NetPacket *this) .text:00549510 ?RemoveDisposableOptionalHeaders@NetPacket@@QAE_NXZ

        // NetPacket.UpdateTimeSensitiveHeaders:
        public static delegate* unmanaged[Thiscall]<NetPacket*, Byte> UpdateTimeSensitiveHeaders = (delegate* unmanaged[Thiscall]<NetPacket*, Byte>)0x0054A130; // .text:005495D0 ; bool __thiscall NetPacket::UpdateTimeSensitiveHeaders(NetPacket *this) .text:005495D0 ?UpdateTimeSensitiveHeaders@NetPacket@@QAE_NXZ

        // NetPacket.CreateForSend:
        public static delegate* unmanaged[Cdecl]<UInt16, NetPacket*> CreateForSend = (delegate* unmanaged[Cdecl]<UInt16, NetPacket*>)0x00543760; // .text:00542BA0 ; NetPacket *__cdecl NetPacket::CreateForSend(U__Int3216 recip) .text:00542BA0 ?CreateForSend@NetPacket@@SAPAV1@G@Z

        // NetPacket.__Dtor:
        public static delegate* unmanaged[Thiscall]<NetPacket*> __Dtor = (delegate* unmanaged[Thiscall]<NetPacket*>)0x00543800; // .text:00542C40 ; void __thiscall NetPacket::~NetPacket(NetPacket *this) .text:00542C40 ??1NetPacket@@MAE@XZ

        // NetPacket.ComputeChecksum:
        public static delegate* unmanaged[Thiscall]<NetPacket*> ComputeChecksum = (delegate* unmanaged[Thiscall]<NetPacket*>)0x00549E10; // .text:005492B0 ; void __thiscall NetPacket::ComputeChecksum(NetPacket *this) .text:005492B0 ?ComputeChecksum@NetPacket@@QAEXXZ

        // NetPacket.AddToHead:
        public static delegate* unmanaged[Thiscall]<NetPacket*, NetPacket**, NetPacket**> AddToHead = (delegate* unmanaged[Thiscall]<NetPacket*, NetPacket**, NetPacket**>)0x00549F30; // .text:005493D0 ; void __thiscall NetPacket::AddToHead(NetPacket *this, NetPacket **head, NetPacket **tail) .text:005493D0 ?AddToHead@NetPacket@@QAEXAAPAV1@0@Z
    }
    public unsafe struct ProtoHeader {
        // Struct:
        public UInt32 seqID_;
        public UInt32 header_;
        public UInt32 checksum_;
        public UInt16 recID_;
        public UInt16 Int32erval_;
        public UInt16 datalen_;
        public UInt16 iteration_;
        public override string ToString() => $"seqID_:{seqID_:X8}, header_:{header_:X8}, checksum_:{checksum_:X8}, recID_:{recID_}, Int32erval_:{Int32erval_}, datalen_:{datalen_}, iteration_:{iteration_}";

    }

    public unsafe struct ArrivedEphInfo {
        // Struct:
        public UI64HashData UI64HashData;
        public ArrivedEphInfo* m_next;
        public UInt64 m_latestNetBlobID;
        public Double m_timeStamp;
        public override string ToString() => $"UI64HashData(UI64HashData):{UI64HashData}, m_next:->(ArrivedEphInfo*)0x{(Int32)m_next:X8}, m_latestNetBlobID(UInt64):{m_latestNetBlobID}, m_timeStamp:{m_timeStamp:n5}";


        // Functions:

        // ArrivedEphInfo.__Ctor:
        // public static delegate* unmanaged[Thiscall]<ArrivedEphInfo*,UInt64,UInt64> __Ctor = (delegate* unmanaged[Thiscall]<ArrivedEphInfo*,UInt64,UInt64>)0xDEADBEEF; // .text:0054ADB0 ; void __thiscall ArrivedEphInfo::ArrivedEphInfo(ArrivedEphInfo *this, UInt64 _sequence, UInt64 _netBlobID) .text:0054ADB0 ??0ArrivedEphInfo@@QAE@_K0@Z

        // ArrivedEphInfo.UpdateNetBlobID:
        // public static delegate* unmanaged[Thiscall]<ArrivedEphInfo*,UInt64> UpdateNetBlobID = (delegate* unmanaged[Thiscall]<ArrivedEphInfo*,UInt64>)0xDEADBEEF; // .text:0054AE00 ; void __thiscall ArrivedEphInfo::UpdateNetBlobID(ArrivedEphInfo *this, UInt64 _netBlobID) .text:0054AE00 ?UpdateNetBlobID@ArrivedEphInfo@@QAEX_K@Z

        // ArrivedEphInfo.fTimedOut:
        public static delegate* unmanaged[Thiscall]<ArrivedEphInfo*, Byte> fTimedOut = (delegate* unmanaged[Thiscall]<ArrivedEphInfo*, Byte>)0x0054BA40; // .text:0054AE30 ; bool __thiscall ArrivedEphInfo::fTimedOut(ArrivedEphInfo *this) .text:0054AE30 ?fTimedOut@ArrivedEphInfo@@QBE_NXZ

        // ArrivedEphInfo.__scaDelDtor:
        // public static delegate* unmanaged[Thiscall]<ArrivedEphInfo*,UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<ArrivedEphInfo*,UInt32, void*>)0xDEADBEEF; // .text:0054AE50 ; void *__thiscall ArrivedEphInfo::`scalar deleting destructor'(ArrivedEphInfo *this, UInt32) .text:0054AE50 ??_GArrivedEphInfo@@UAEPAXI@Z
    }

    public unsafe struct LinkStatusHolder {
        // Struct:
        public CLinkStatusPlugin CLinkStatusPlugin;
        public LinkStatus m_eLinkState;
        public Double m_tLastHeardFromCurServer;
        public Single m_fConnectionProgress;
        public Single m_fPacketLoss;
        public NetError m_errFinal;
        public Int32 m_nodropKick;
        public override string ToString() => $"CLinkStatusPlugin(CLinkStatusPlugin):{CLinkStatusPlugin}, m_eLinkState:{m_eLinkState}, m_tLastHeardFromCurServer:{m_tLastHeardFromCurServer:n5}, m_fConnectionProgress:{m_fConnectionProgress:n5}, m_fPacketLoss:{m_fPacketLoss:n5}, m_errFinal(NetError):{m_errFinal}, m_nodropKick:{m_nodropKick}";


        // Functions:

        // LinkStatusHolder.GetConnectionStatus:
        public static delegate* unmanaged[Thiscall]<LinkStatusHolder*, Int32*, Double> GetConnectionStatus = (delegate* unmanaged[Thiscall]<LinkStatusHolder*, Int32*, Double>)0x004116E0; // .text:00411380 ; long Double __thiscall LinkStatusHolder::GetConnectionStatus(LinkStatusHolder *this, Int32 *bConnected) .text:00411380 ?GetConnectionStatus@LinkStatusHolder@@QBENAAH@Z

        // LinkStatusHolder.OnHeartbeat:
        public static delegate* unmanaged[Thiscall]<LinkStatusHolder*, CLinkStatusAverages*> OnHeartbeat = (delegate* unmanaged[Thiscall]<LinkStatusHolder*, CLinkStatusAverages*>)0x00411730; // .text:004113D0 ; void __thiscall LinkStatusHolder::OnHeartbeat(LinkStatusHolder *this, CLinkStatusAverages *Avgs) .text:004113D0 ?OnHeartbeat@LinkStatusHolder@@MAEXABVCLinkStatusAverages@@@Z

        // LinkStatusHolder.OnNetStatusChange:
        public static delegate* unmanaged[Thiscall]<LinkStatusHolder*, NetStatus, Int32, Int32> OnNetStatusChange = (delegate* unmanaged[Thiscall]<LinkStatusHolder*, NetStatus, Int32, Int32>)0x00411CC0; // .text:00411960 ; void __thiscall LinkStatusHolder::OnNetStatusChange(LinkStatusHolder *this, NetStatus Status, Int32 Param1, Int32 Param2) .text:00411960 ?OnNetStatusChange@LinkStatusHolder@@MAEXW4NetStatus@@JJ@Z

        // LinkStatusHolder.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<LinkStatusHolder*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<LinkStatusHolder*, UInt32, void*>)0x00412E10; // .text:00412AB0 ; void *__thiscall LinkStatusHolder::`vector deleting destructor'(LinkStatusHolder *this, UInt32) .text:00412AB0 ??_ELinkStatusHolder@@UAEPAXI@Z

        // LinkStatusHolder.GetPacketLossPercentage:
        public static delegate* unmanaged[Thiscall]<LinkStatusHolder*, Single> GetPacketLossPercentage = (delegate* unmanaged[Thiscall]<LinkStatusHolder*, Single>)0x004116D0; // .text:00411370 ; Single __thiscall LinkStatusHolder::GetPacketLossPercentage(LinkStatusHolder *this) .text:00411370 ?GetPacketLossPercentage@LinkStatusHolder@@QBEMXZ
    }


    /// <summary>
    /// BIG todo here.
    /// </summary>
    public unsafe struct CLinkStatusAverages {
        // Struct:
        public CLinkStatusSnapshot m_Snapshot;
        public Double m_LocalTimeOfSnapshot;
        public CLinkStatusAverages.CAverager<Single> m_RoundTripDelays;
        public CLinkStatusAverages.CAverager<UInt16> m_nPktsSent;
        public CLinkStatusAverages.CAverager<UInt16> m_nPktsRetransmitted;
        public CLinkStatusAverages.CAverager<UInt16> m_nPktsReceived;
        public CLinkStatusAverages.CAverager<UInt16> m_nPktsNAKed;
        public CLinkStatusAverages.CAverager<UInt32> m_nBytesSent;
        public CLinkStatusAverages.CAverager<UInt32> m_nBytesReceived;
        public CLinkStatusAverages.CAverager<Double> m_TimeDiffs;
        public override string ToString() => $"m_Snapshot(CLinkStatusSnapshot):{m_Snapshot}, m_LocalTimeOfSnapshot:{m_LocalTimeOfSnapshot:n5}, m_RoundTripDelays(CAverager<Single,>):{m_RoundTripDelays}, m_nPktsSent(CAverager<UInt16>):{m_nPktsSent}, m_nPktsRetransmitted(CAverager<UInt16>):{m_nPktsRetransmitted}, m_nPktsReceived(CAverager<UInt16>):{m_nPktsReceived}, m_nPktsNAKed(CAverager<UInt16>):{m_nPktsNAKed}, m_nBytesSent(CAverager<UInt32>):{m_nBytesSent}, m_nBytesReceived(CAverager<UInt32>):{m_nBytesReceived}, m_TimeDiffs(CAverager<Double>):{m_TimeDiffs}";

        public unsafe struct CAverager<TYPE> where TYPE : unmanaged {
            // Struct:
            public TYPE m_Sample_0;
            public TYPE m_Sample_1;
            public TYPE m_Sample_2;
            public TYPE m_Sample_3;
            public Double m_CurTotal;
            public UInt16 m_nSamples;
            public UInt16 m_idxFirst;
            public override string ToString() => $"m_Samples[4]:{m_Sample_0},{m_Sample_1},{m_Sample_2},{m_Sample_3} m_CurTotal:{m_CurTotal:n5}, m_nSamples:{m_nSamples:X4}, m_idxFirst:{m_idxFirst:X4}";

            // Functions:

            // CLinkStatusAverages::CAverager<Single,4>.AddSample:
            public static delegate* unmanaged[Thiscall]<CAverager<Single>*, Single> AddSample_Single => (delegate* unmanaged[Thiscall]<CAverager<Single>*, Single>)0x00547000; // .text:00546440 ; void __thiscall CLinkStatusAverages::CAverager<Single,4>::AddSample(CLinkStatusAverages::CAverager<Single,4> *this, Single Data) .text:00546440 ?AddSample@?$CAverager@M$03@CLinkStatusAverages@@QAEXM@Z


            // CLinkStatusAverages::CAverager<UInt16,40>.AddSample:
            public static delegate* unmanaged[Thiscall]<CAverager<UInt16>*, UInt16> AddSample_UInt16 => (delegate* unmanaged[Thiscall]<CAverager<UInt16>*, UInt16>)0x00547070; // .text:005464B0 ; void __thiscall CLinkStatusAverages::CAverager<UInt16,40>::AddSample(CLinkStatusAverages::CAverager<UInt16,40> *this, U__Int3216 Data) .text:005464B0 ?AddSample@?$CAverager@G$0CI@@CLinkStatusAverages@@QAEXG@Z


            // CLinkStatusAverages::CAverager<UInt32,2>.AddSample:
            public static delegate* unmanaged[Thiscall]<CAverager<UInt32>*, UInt32> AddSample_UInt32 => (delegate* unmanaged[Thiscall]<CAverager<UInt32>*, UInt32>)0x005470E0; // .text:00546520 ; void __thiscall CLinkStatusAverages::CAverager<UInt32,2>::AddSample(CLinkStatusAverages::CAverager<UInt32,2> *this, UInt32 Data) .text:00546520 ?AddSample@?$CAverager@K$01@CLinkStatusAverages@@QAEXK@Z

            // CLinkStatusAverages::CAverager<Double,2>.AddSample:
            public static delegate* unmanaged[Thiscall]<CAverager<Double>*, Double> AddSample = (delegate* unmanaged[Thiscall]<CAverager<Double>*, Double>)0x00547160; // .text:005465A0 ; void __thiscall CLinkStatusAverages::CAverager<Double,2>::AddSample(CLinkStatusAverages::CAverager<Double,2> *this, long Double Data) .text:005465A0 ?AddSample@?$CAverager@N$01@CLinkStatusAverages@@QAEXN@Z
        }

        // Functions:

        // CLinkStatusAverages.__Ctor:
        public static delegate* unmanaged[Thiscall]<CLinkStatusAverages*> __Ctor = (delegate* unmanaged[Thiscall]<CLinkStatusAverages*>)0x00542F40; // .text:00542360 ; void __thiscall CLinkStatusAverages::CLinkStatusAverages(CLinkStatusAverages *this) .text:00542360 ??0CLinkStatusAverages@@QAE@XZ

        // CLinkStatusAverages.GetAveragePacketLoss:
        public static delegate* unmanaged[Thiscall]<CLinkStatusAverages*, Double> GetAveragePacketLoss = (delegate* unmanaged[Thiscall]<CLinkStatusAverages*, Double>)0x005471D0; // .text:00546610 ; long Double __thiscall CLinkStatusAverages::GetAveragePacketLoss(CLinkStatusAverages *this) .text:00546610 ?GetAveragePacketLoss@CLinkStatusAverages@@QBENXZ

        // CLinkStatusAverages.AddSnapshot:
        public static delegate* unmanaged[Thiscall]<CLinkStatusAverages*, CLinkStatusSnapshot*> AddSnapshot = (delegate* unmanaged[Thiscall]<CLinkStatusAverages*, CLinkStatusSnapshot*>)0x00547210; // .text:00546650 ; void __thiscall CLinkStatusAverages::AddSnapshot(CLinkStatusAverages *this, CLinkStatusSnapshot *Snap) .text:00546650 ?AddSnapshot@CLinkStatusAverages@@QAEXABUCLinkStatusSnapshot@@@Z

        // CLinkStatusAverages.OnPingResponse:
        public static delegate* unmanaged[Thiscall]<CLinkStatusAverages*, Single> OnPingResponse = (delegate* unmanaged[Thiscall]<CLinkStatusAverages*, Single>)0x005472F0; // .text:00546730 ; void __thiscall CLinkStatusAverages::OnPingResponse(CLinkStatusAverages *this, Single RoundTripDelay) .text:00546730 ?OnPingResponse@CLinkStatusAverages@@QAEXM@Z
    }





    public unsafe struct PerfMonCounter<T> where T : unmanaged {
        public PerfMonCounterInfo PerfMonCounterInfo;
        public T m_counter;
    };
    public unsafe struct PerfMonCounterInfo {
        public Turbine_RefCount _ref;
        public UInt32 m_CounterType;
        public _List<PerfMonCounterNameHelp> m_CounterNamesList;
        public Byte m_fCounterExistedPreviously;

        public unsafe struct PerfMonCounterNameHelp {
            public UInt16 m_languageID;
            public PStringBase<UInt16> m_name;
            public PStringBase<UInt16> m_help;
        };
    };

}