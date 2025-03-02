using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace AcClient {


    public unsafe struct AVLIterator<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public AVLNode<KEY, DATA>* _current;
    };

    public unsafe struct AVL<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public AVLNode<KEY, DATA>* _root;
        public KEY _currNum;
    };
    public unsafe struct AVLNode<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public AVLNode<KEY, DATA>* _left;
        public AVLNode<KEY, DATA>* _right;
        public AVLNode<KEY, DATA>* _parent;
        public Int32 _leftHeight;
        public Int32 _rightHeight;
        public Int32 _height;
        public KEY _key;
        public DATA* _data;
        public Byte _parentsize;
    };

    public unsafe struct _STL {
        public unsafe struct Pair<FIRST, SECOND> where FIRST : unmanaged where SECOND : unmanaged {
            public FIRST first;
            public SECOND second;
        }
    }

    public unsafe struct IDListNode {
        public UInt32 id;
        public IDListNode* prev;
        public IDListNode* next;
    };
    public unsafe struct IDList {
        // Struct:
        public PackObj a0;
        public IDListNode* first;
        public IDListNode* last;
        public IDListNode* curNode;
        public int numIDs;
        public int curNum;
        //public override string ToString() => $"a0(PackObj):{a0}, first:->(IDListNode*)0x{(int)first:X8}, last:->(IDListNode*)0x{(int)last:X8}, curNode:->(IDListNode*)0x{(int)curNode:X8}, numIDs(int):{numIDs}, curNum(int):{curNum}";

        public override string ToString() {
            if (numIDs == 0) return "null";
            string[] Chars = new string[numIDs];
            IDListNode* cur = first;
            for (Int32 i = 0; i < numIDs; i++) {
                if (cur == null) break;
                Chars[i] = $"{(cur->id):X8}";
                cur = cur->next;
            }
            return $"numIDs:{numIDs} {string.Join(", ", Chars)}";
        }

        // Functions:

        // IDList.SetCurToNext:
        public int SetCurToNext() => ((delegate* unmanaged[Thiscall]<ref IDList, int>)0x005ADC00)(ref this); // .text:005ADC00 ; int __thiscall IDList::SetCurToNext(IDList *this) .text:005ADC00 ?SetCurToNext@IDList@@QAEHXZ

        // IDList.GetNodeByNum:
        public IDListNode* GetNodeByNum(int _num) => ((delegate* unmanaged[Thiscall]<ref IDList, int, IDListNode*>)0x005ADC40)(ref this, _num); // .text:005ADC40 ; IDListNode *__thiscall IDList::GetNodeByNum(IDList *this, int _num) .text:005ADC40 ?GetNodeByNum@IDList@@IAEPAVIDListNode@@H@Z

        // IDList.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref IDList, void>)0x005ADD00)(ref this); // .text:005ADD00 ; void __thiscall IDList::IDList(IDList *this) .text:005ADD00 ??0IDList@@QAE@XZ

        // IDList.GetByNum:
        public UInt32 GetByNum(int _num) => ((delegate* unmanaged[Thiscall]<ref IDList, int, UInt32>)0x005ADE40)(ref this, _num); // .text:005ADE40 ; unsigned int __thiscall IDList::GetByNum(IDList *this, int _num) .text:005ADE40 ?GetByNum@IDList@@QAEKH@Z

        // IDList.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref IDList, void**, UInt32, UInt32>)0x005ADF40)(ref this, addr, size); // .text:005ADF40 ; unsigned int __thiscall IDList::Pack(IDList *this, void **addr, unsigned int size) .text:005ADF40 ?Pack@IDList@@UAEIAAPAXI@Z

        // IDList.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref IDList, void**, UInt32, int>)0x005ADFF0)(ref this, addr, size); // .text:005ADFF0 ; int __thiscall IDList::UnPack(IDList *this, void **addr, unsigned int size) .text:005ADFF0 ?UnPack@IDList@@UAEHAAPAXI@Z

        // IDList.GetPlaceInList:
        public int GetPlaceInList(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref IDList, UInt32, int>)0x005ADBA0)(ref this, _id); // .text:005ADBA0 ; int __thiscall IDList::GetPlaceInList(IDList *this, unsigned int _id) .text:005ADBA0 ?GetPlaceInList@IDList@@QAEHK@Z

        // IDList.IsInList:
        public int IsInList(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref IDList, UInt32, int>)0x005ADBD0)(ref this, _id); // .text:005ADBD0 ; int __thiscall IDList::IsInList(IDList *this, unsigned int _id) .text:005ADBD0 ?IsInList@IDList@@QAEHK@Z

        // IDList.AddAtNum:
        public int AddAtNum(UInt32 _id, int _num, int _addAtEndOnFail) => ((delegate* unmanaged[Thiscall]<ref IDList, UInt32, int, int, int>)0x005ADD20)(ref this, _id, _num, _addAtEndOnFail); // .text:005ADD20 ; int __thiscall IDList::AddAtNum(IDList *this, unsigned int _id, int _num, int _addAtEndOnFail) .text:005ADD20 ?AddAtNum@IDList@@QAEHKHH@Z

        // IDList.SetCurToNum:
        public int SetCurToNum(int _num) => ((delegate* unmanaged[Thiscall]<ref IDList, int, int>)0x005ADF10)(ref this, _num); // .text:005ADF10 ; int __thiscall IDList::SetCurToNum(IDList *this, int _num) .text:005ADF10 ?SetCurToNum@IDList@@QAEHH@Z

        // IDList.AddList:
        public void AddList(IDList* _list) => ((delegate* unmanaged[Thiscall]<ref IDList, IDList*, void>)0x005AE090)(ref this, _list); // .text:005AE090 ; void __thiscall IDList::AddList(IDList *this, IDList *_list) .text:005AE090 ?AddList@IDList@@QAEXAAV1@@Z

        // IDList.Add:
        public void Add(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref IDList, UInt32, void>)0x005ADB50)(ref this, _id); // .text:005ADB50 ; void __thiscall IDList::Add(IDList *this, unsigned int _id) .text:005ADB50 ?Add@IDList@@QAEXK@Z

        // IDList.GetCurID:
        public UInt32 GetCurID() => ((delegate* unmanaged[Thiscall]<ref IDList, UInt32>)0x005ADC30)(ref this); // .text:005ADC30 ; unsigned int __thiscall IDList::GetCurID(IDList *this) .text:005ADC30 ?GetCurID@IDList@@QAEKXZ

        // IDList.RemoveNode:
        public int RemoveNode(IDListNode* _node) => ((delegate* unmanaged[Thiscall]<ref IDList, IDListNode*, int>)0x005ADCA0)(ref this, _node); // .text:005ADCA0 ; int __thiscall IDList::RemoveNode(IDList *this, IDListNode *_node) .text:005ADCA0 ?RemoveNode@IDList@@IAEHPAVIDListNode@@@Z

        // IDList.RemoveByID:
        public int RemoveByID(UInt32 _id) => ((delegate* unmanaged[Thiscall]<ref IDList, UInt32, int>)0x005ADDF0)(ref this, _id); // .text:005ADDF0 ; int __thiscall IDList::RemoveByID(IDList *this, unsigned int _id) .text:005ADDF0 ?RemoveByID@IDList@@QAEHK@Z

        // IDList.Clear:
        public void Clear() => ((delegate* unmanaged[Thiscall]<ref IDList, void>)0x005ADE60)(ref this); // .text:005ADE60 ; void __thiscall IDList::Clear(IDList *this) .text:005ADE60 ?Clear@IDList@@QAEXXZ

        // IDList.__Ctor:
        public void __Ctor(IDList* _list) => ((delegate* unmanaged[Thiscall]<ref IDList, IDList*, void>)0x005AE160)(ref this, _list); // .text:005AE160 ; void __thiscall IDList::IDList(IDList *this, IDList *_list) .text:005AE160 ??0IDList@@QAE@AAV0@@Z

    }






    public unsafe struct _List_PTR<T> where T : unmanaged {
        public _Vtbl* vfptr;
        public _ListNode_PTR<T>* _head;
        public _ListNode_PTR<T>* _tail;
        public UInt32 _num_elements;
    };
    public unsafe struct _ListIterator_PTR<T> where T : unmanaged {
        public _Vtbl* vfptr;
        public _ListNode_PTR<T>* _current;
        public _List_PTR<T>* _list;
    };
    public unsafe struct _ListNode_PTR<T> where T : unmanaged {
        public T* data;
        public _ListNode_PTR<T>* next;
        public _ListNode_PTR<T>* prev;
    };


    public unsafe struct _List<T> where T : unmanaged {
        public _Vtbl* vfptr;
        public _ListNode<T>* _head;
        public _ListNode<T>* _tail;
        public UInt32 _num_elements;
    };
    public unsafe struct _ListIterator<T> where T : unmanaged {
        public _Vtbl* vfptr;
        public _ListNode<T>* _current;
        public _List<T>* _list;
    };
    public unsafe struct _ListNode<T> where T : unmanaged {
        public T data;
        public _ListNode<T>* next;
        public _ListNode<T>* prev;
    };
    public unsafe struct PList<T> where T : unmanaged {
        public PackObj packObj;
        public _List<T> list;
    };

    // <W, X> where W : unmanaged where X : unmanaged
    public unsafe struct LList<T> where T : unmanaged {
        public LListBase a0;
        public override string ToString() => $"a0(LListBase,{typeof(T)}):{a0}";

    };

    public unsafe struct LListBase {
        public LListData* head_;
        public LListData* tail_;
        public override string ToString() => $"head_:->0x{(int)head_:X8}, tail_:->0x{(int)tail_:X8}";

        // Functions:

        // LListBase.RemoveTail:
        public LListData* RemoveTail() => ((delegate* unmanaged[Thiscall]<ref LListBase, LListData*>)0x00555870)(ref this); // .text:00555870 ; LListData *__thiscall LListBase::RemoveTail(LListBase *this) .text:00555870 ?RemoveTail@LListBase@@QAEPAVLListData@@XZ

    };

    public unsafe struct LListData {
        public LListData* llist_next;
        public override string ToString() => $"llist_next:->0x{(int)llist_next:X8}";

    };


    public unsafe struct NIListElement<T> where T : unmanaged {
        public T* data_;
        public NIListElement<T>* next_;
        public override string ToString() => $"data_:->({typeof(T)}*)0x{(int)data_:X8}, next_:->(NIListElement<{typeof(T)}>*)0x{(int)next_:X8}";

    };
    public unsafe struct NIList<T> where T : unmanaged {
        public NIListElement<T>* head_;
        public NIListElement<T>* tail_;
        public override string ToString() => $"head_:->(NIListElement<{typeof(T)}>*)0x{(int)head_:X8}, tail_:->(NIListElement<{typeof(T)}>*)0x{(int)tail_:X8}";
        // Functions:

        // NIList.AddToTail:
        public void AddToTail(T inData) => ((delegate* unmanaged[Thiscall]<ref NIList<T>, T, void>)0x004537C0)(ref this, inData); // .text:004537C0 ; void __thiscall NIList<NetBlob *>::AddToTail(NIList<unsigned long> *this, unsigned int inData) .text:004537C0 ?AddToTail@?$NIList@PAVNetBlob@@@@QAEXPAVNetBlob@@@Z

        // NIList.DeleteContents:
        public void DeleteContents() => ((delegate* unmanaged[Thiscall]<ref NIList<T>, void>)0x004C59B0)(ref this); // .text:004C59B0 ; void __thiscall NIList<unsigned long>::DeleteContents(NIList<NetPacket *> *this) .text:004C59B0 ?DeleteContents@?$NIList@K@@QAEXXZ

    };


    public unsafe struct DLList<T> where T : unmanaged {
        public DLListBase a0;
        public override string ToString() => a0.ToString();

    };
    public unsafe struct DLListData {
        // Struct:
        public DLListData* dllist_next;
        public DLListData* dllist_prev;
        public override string ToString() => $"dllist_next:->(DLListData*)0x{(int)dllist_next:X8}, dllist_prev:->(DLListData*)0x{(int)dllist_prev:X8}";
    }

    public unsafe struct DLListBase {
        // Struct:
        public DLListData* head_;
        public DLListData* tail_;
        public override string ToString() => $"head_:->(DLListData*)0x{(int)head_:X8}, tail_:->(DLListData*)0x{(int)tail_:X8}";

        // Functions:

        // DLListBase.InsertAfter:
        public void InsertAfter(DLListData* to_add, DLListData* where) => ((delegate* unmanaged[Thiscall]<ref DLListBase, DLListData*, DLListData*, void>)0x00410560)(ref this, to_add, where); // .text:00410560 ; void __thiscall DLListBase::InsertAfter(DLListBase *this, DLListData *to_add, DLListData *where) .text:00410560 ?InsertAfter@DLListBase@@QAEXPAVDLListData@@0@Z

        // DLListBase.Remove:
        public void Remove(DLListData* to_remove) => ((delegate* unmanaged[Thiscall]<ref DLListBase, DLListData*, void>)0x004105C0)(ref this, to_remove); // .text:004105C0 ; void __thiscall DLListBase::Remove(DLListBase *this, DLListData *to_remove) .text:004105C0 ?Remove@DLListBase@@QAEXPAVDLListData@@@Z
    }




    public unsafe struct PackableLLIter<T> where T : unmanaged {
        // Struct:
        public Vtbl vfptr;
        public PackableLLNode<T>* _current;
        public override string ToString() => $"vfptr(Vtbl):{vfptr}, _current:->(PackableLLNode<{typeof(T)}>*)0x{(int)_current:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<PackableLLIter<T>*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(PackableLLIter<UInt32> *this, unsigned int);
        }
    }
    public unsafe struct PackableLLNode<T> where T : unmanaged {
        // Struct:
        public T data;
        public PackableLLNode<T>* next;
        public PackableLLNode<T>* prev;
        public override string ToString() => $"data:{data}, next:->(PackableLLNode<{typeof(T)}>*)0x{(int)next:X8}, prev:->(PackableLLNode<{typeof(T)}>*)0x{(int)prev:X8}";
    }
    public unsafe struct PackableList<T> where T : unmanaged {
        // Struct:
        public PackObj a0;
        public PackableLLNode<T>* head;
        public PackableLLNode<T>* tail;
        public UInt32 curNum;
        //public override string ToString() => $"a0(PackObj):{a0}, head:->(PackableLLNode<{typeof(T)}>*)0x{(int)head:X8}, tail:->(PackableLLNode<UInt32>*)0x{(int)tail:X8}, curNum:{curNum:X8}";

        public string GetList() {
            if (head == null) return "";
            System.Text.StringBuilder Chars = new System.Text.StringBuilder();
            PackableLLNode<T>* iter = head;
            while (iter != null) {
                Chars.Append(iter->data.ToString() + ",");
                iter = iter->next;
            }
            return Chars.ToString(0, Chars.Length - 1);
        }
        public override string ToString() {
            if (head == null) return "null";
            System.Text.StringBuilder Chars = new System.Text.StringBuilder();
            PackableLLNode<T>* iter = head;
            while (iter != null) {
                Chars.Append("(" + iter->data.ToString() + "), ");
                iter = iter->next;
            }
            return $"curNum:{curNum}, {Chars.ToString(0, Chars.Length - 2)}";
        }
        //public unsafe IEnumerable<T> it() {
        //    PackableLLNode<T>* iter = head;
        //    while (iter != null) {
        //        yield return iter->data;
        //        iter = iter->next;
        //    }
        //}

        ////
        //public Int32 Pack(void** addr, UInt32 size) => ((def_Pack)Marshal.GetDelegateForFunctionPointer((IntPtr)0x0048B9F0, typeof(def_Pack)))(ref this, addr, size); // .text:0048B9F0 ; public: virtual UInt32 __thiscall PackableList<UInt32>::Pack(void * &,UInt32)
        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate Int32 def_Pack(ref PackableList<T> This, void** addr, UInt32 size); // signed Int32 __thiscall PackableList<UInt32>::Pack(PackableList<UInt32> *this, void **addr, UInt32 size);

        ////
        //public Int32 pack_size() => ((def_pack_size)Marshal.GetDelegateForFunctionPointer((IntPtr)0x0048BA40, typeof(def_pack_size)))(ref this); // .text:0048BA40 ; protected: UInt32 __thiscall PackableList<UInt32>::pack_size(void)
        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate Int32 def_pack_size(ref PackableList<T> This); // signed Int32 __thiscall PackableList<UInt32>::pack_size(PackableList<UInt32> *this);


        ////
        //public void Flush() => ((def_Flush)Marshal.GetDelegateForFunctionPointer((IntPtr)0x0048BC30, typeof(def_Flush)))(ref this); // .text:0048BC30 ; public: void __thiscall PackableList<UInt32>::Flush(void)
        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate void def_Flush(ref PackableList<T> This); // void __thiscall PackableList<UInt32>::Flush(PackableList<UInt32> *this); // idb

        ////
        //public void _PackableList() => ((def__PackableList)Marshal.GetDelegateForFunctionPointer((IntPtr)0x0048BCC0, typeof(def__PackableList)))(ref this); // .text:0048BCC0 ; public: virtual __thiscall PackableList<UInt32>::~PackableList<UInt32>(void)
        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate void def__PackableList(ref PackableList<T> This); // void __thiscall PackableList<UInt32>::~PackableList<UInt32>(PackableList<UInt32> *this); // idb

        ////
        //public Int32 UnPack(void** addr, UInt32 size) => ((def_UnPack)Marshal.GetDelegateForFunctionPointer((IntPtr)0x0048BCE0, typeof(def_UnPack)))(ref this, addr, size); // .text:0048BCE0 ; public: virtual Int32 __thiscall PackableList<UInt32>::UnPack(void * &,UInt32)
        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate Int32 def_UnPack(ref PackableList<T> This, void** addr, UInt32 size); // Int32 __thiscall PackableList<UInt32>::UnPack(PackableList<UInt32> *this, void **addr, UInt32 size); // idb

        ////
        //public Int32 InsertTail(T* val) => ((def_InsertTail)Marshal.GetDelegateForFunctionPointer((IntPtr)0x0048BD40, typeof(def_InsertTail)))(ref this, val); // .text:0048BD40 ; public: UInt32 __thiscall PackableList<UInt32>::InsertTail(UInt32 &)
        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate Int32 def_InsertTail(ref PackableList<T> This, T* val); // Int32 __thiscall PackableList<UInt32>::InsertTail(PackableList<UInt32> *this, UInt32 *val);

        ////
        //public PackableList<UInt32>* __vecDelDtor(UInt32 a2) => (PackableList<UInt32>*)((def___vecDelDtor)Marshal.GetDelegateForFunctionPointer((IntPtr)0x0048BDA0, typeof(def___vecDelDtor)))(ref this, a2); // .text:0048BDA0 ; Int32 __thiscall PackableList<UInt32>::`vector deleting destructor'(void *, Char)
        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate Int32 def___vecDelDtor(ref PackableList<T> This, UInt32 a2); // PackableList<UInt32> *__thiscall PackableList<UInt32>::__vecDelDtor(PackableList<UInt32> *this, UInt32 a2);

        ////
        //public Int32 InsertPos(UInt32 pos, T* val) => ((def_InsertPos)Marshal.GetDelegateForFunctionPointer((IntPtr)0x005D5320, typeof(def_InsertPos)))(ref this, pos, val); // .text:005D5320 ; UInt32 __thiscall PackableList<UInt32>::InsertPos(PackableList<UInt32> *this, UInt32 pos, UInt32 *val)
        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate Int32 def_InsertPos(ref PackableList<T> This, UInt32 pos, T* val); // UInt32 __thiscall PackableList<UInt32>::InsertPos(PackableList<UInt32> *this, UInt32 pos, UInt32 *val); // idb

        ////
        //public Int32 Remove(T* val) => ((def_Remove)Marshal.GetDelegateForFunctionPointer((IntPtr)0x005D57A0, typeof(def_Remove)))(ref this, val); // .text:005D57A0 ; public: Int32 __thiscall PackableList<UInt32>::Remove(UInt32 &)
        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate Int32 def_Remove(ref PackableList<T> This, T* val); // Int32 __thiscall PackableList<UInt32>::Remove(PackableList<UInt32> *this, UInt32 *val); // idb


        // Functions:

        // PackableList.InsertTail:
        public UInt32 InsertTail(T* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, T*, UInt32>)0x0048BA60)(ref this, val); // .text:0048BA60 ; unsigned int __thiscall PackableList<UInt32>::InsertTail(PackableList<UInt32> *this, const unsigned int *val) .text:0048BA60 ?InsertTail@?$PackableList@K@@QAEKABK@Z

        // PackableList.InsertPos:
        public UInt32 InsertPos(UInt32 pos, T* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32, T*, UInt32>)0x005D42A0)(ref this, pos, val); // .text:005D42A0 ; unsigned int __thiscall PackableList<UInt32>::InsertPos(PackableList<UInt32> *this, const unsigned int pos, const unsigned int *val) .text:005D42A0 ?InsertPos@?$PackableList@K@@QAEKKABK@Z

        // PackableList.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x0048BA00)(ref this, addr, size); // .text:0048BA00 ; int __thiscall PackableList<UInt32>::UnPack(PackableList<UInt32> *this, void **addr, unsigned int size) .text:0048BA00 ?UnPack@?$PackableList@K@@UAEHAAPAXI@Z

        // PackableList.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, UInt32>)0x0048B710)(ref this, addr, size); // .text:0048B710 ; unsigned int __thiscall PackableList<UInt32>::Pack(PackableList<UInt32> *this, void **addr, unsigned int size) .text:0048B710 ?Pack@?$PackableList@K@@UAEIAAPAXI@Z

        // PackableList.pack_size:
        public UInt32 pack_size() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32>)0x0048B760)(ref this); // .text:0048B760 ; unsigned int __thiscall PackableList<UInt32>::pack_size(PackableList<UInt32> *this) .text:0048B760 ?pack_size@?$PackableList@K@@IAEIXZ

        // PackableList.Flush:
        public void Flush() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x0048B950)(ref this); // .text:0048B950 ; void __thiscall PackableList<UInt32>::Flush(PackableList<UInt32> *this) .text:0048B950 ?Flush@?$PackableList@K@@QAEXXZ

        // PackableList.Remove:
        public int Remove(T* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, T*, int>)0x005D4720)(ref this, val); // .text:005D4720 ; int __thiscall PackableList<UInt32>::Remove(PackableList<UInt32> *this, unsigned int *val) .text:005D4720 ?Remove@?$PackableList@K@@QAEHAAK@Z




        //// PackableList.Pack:
        //public UInt32 Pack<ContentProfile>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, UInt32>)0x006ADA10)(ref this, addr, size); // .text:006ADA10 ; unsigned int __thiscall PackableList<ContentProfile>::Pack(PackableList<ContentProfile> *this, void **addr, unsigned int size) .text:006ADA10 ?Pack@?$PackableList@VContentProfile@@@@UAEIAAPAXI@Z

        //// PackableList.pack_size:
        //public UInt32 pack_size<CreationProfile>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32>)0x0058F570)(ref this); // .text:0058F570 ; unsigned int __thiscall PackableList<CreationProfile>::pack_size(PackableList<CreationProfile> *this) .text:0058F570 ?pack_size@?$PackableList@VCreationProfile@@@@IAEIXZ

        //// PackableList.Flush:
        //public void Flush<Emote>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x005965A0)(ref this); // .text:005965A0 ; void __thiscall PackableList<Emote>::Flush(PackableList<Emote> *this) .text:005965A0 ?Flush@?$PackableList@VEmote@@@@QAEXXZ

        //// PackableList.pack_size:
        //public UInt32 pack_size<HousePayment>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32>)0x005C9930)(ref this); // .text:005C9930 ; unsigned int __thiscall PackableList<HousePayment>::pack_size(PackableList<SalvageResult> *this) .text:005C9930 ?pack_size@?$PackableList@VHousePayment@@@@IAEIXZ

        //// PackableList.InsertTail:
        ////public UInt32 InsertTail<SalvageResult>(SalvageResult* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, SalvageResult*, UInt32>)0x005C9A70)(ref this, val); // .text:005C9A70 ; unsigned int __thiscall PackableList<SalvageResult>::InsertTail(PackableList<SalvageResult> *this, SalvageResult *val) .text:005C9A70 ?InsertTail@?$PackableList@VSalvageResult@@@@QAEKABVSalvageResult@@@Z

        //// PackableList.Search:
        //public int Search<ContentProfile>(ContentProfile* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, ContentProfile*, int>)0x005B9F60)(ref this, val); // .text:005B9F60 ; int __thiscall PackableList<ContentProfile>::Search(PackableList<ContentProfile> *this, ContentProfile *val) .text:005B9F60 ?Search@?$PackableList@VContentProfile@@@@QBEHABVContentProfile@@@Z

        //// PackableList.Flush:
        //public void Flush<GeneratorQueueNode>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x005D0770)(ref this); // .text:005D0770 ; void __thiscall PackableList<GeneratorQueueNode>::Flush(PackableList<GeneratorQueueNode> *this) .text:005D0770 ?Flush@?$PackableList@VGeneratorQueueNode@@@@QAEXXZ

        //// PackableList.Flush:
        ////public void Flush<AC1Legacy.PStringBase<char>>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x006A5240)(ref this); // .text:006A5240 ; void __thiscall PackableList<AC1Legacy.PStringBase<char>>::Flush(PackableList<AC1Legacy.PStringBase<char> > *this) .text:006A5240 ?Flush@?$PackableList@V?$PStringBase@D@AC1Legacy@@@@QAEXXZ

        //// PackableList.pack_size:
        //public UInt32 pack_size<Enchantment>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32>)0x004B7790)(ref this); // .text:004B7790 ; unsigned int __thiscall PackableList<Enchantment>::pack_size(PackableList<Enchantment> *this) .text:004B7790 ?pack_size@?$PackableList@VEnchantment@@@@IAEIXZ

        //// PackableList.Flush:
        //public void Flush<Enchantment>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x004B7AD0)(ref this); // .text:004B7AD0 ; void __thiscall PackableList<Enchantment>::Flush(PackableList<Enchantment> *this) .text:004B7AD0 ?Flush@?$PackableList@VEnchantment@@@@QAEXXZ

        //// PackableList.UnPack:
        //public int UnPack<Enchantment>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x004B7CF0)(ref this, addr, size); // .text:004B7CF0 ; int __thiscall PackableList<Enchantment>::UnPack(PackableList<Enchantment> *this, void **addr, unsigned int size) .text:004B7CF0 ?UnPack@?$PackableList@VEnchantment@@@@UAEHAAPAXI@Z

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<Enchantment>(Enchantment* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, Enchantment*, UInt32>)0x004B7D70)(ref this, val); // .text:004B7D70 ; unsigned int __thiscall PackableList<Enchantment>::InsertTail(PackableList<Enchantment> *this, Enchantment *val) .text:004B7D70 ?InsertTail@?$PackableList@VEnchantment@@@@QAEKABVEnchantment@@@Z

        //// PackableList.Flush:
        //public void Flush<ItemProfile>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x004C10B0)(ref this); // .text:004C10B0 ; void __thiscall PackableList<ItemProfile>::Flush(PackableList<ItemProfile> *this) .text:004C10B0 ?Flush@?$PackableList@VItemProfile@@@@QAEXXZ

        //// PackableList.Flush:
        //public void Flush<AdminPlayerData>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x006AE260)(ref this); // .text:006AE260 ; void __thiscall PackableList<AdminPlayerData>::Flush(PackableList<AdminPlayerData> *this) .text:006AE260 ?Flush@?$PackableList@VAdminPlayerData@@@@QAEXXZ

        //// PackableList.UnPack:
        //public int UnPack<AdminAccountData>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x006AE2C0)(ref this, addr, size); // .text:006AE2C0 ; int __thiscall PackableList<AdminAccountData>::UnPack(PackableList<AdminAccountData> *this, void **addr, unsigned int size) .text:006AE2C0 ?UnPack@?$PackableList@VAdminAccountData@@@@UAEHAAPAXI@Z

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<Emote>(Emote* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, Emote*, UInt32>)0x005962F0)(ref this, val); // .text:005962F0 ; unsigned int __thiscall PackableList<Emote>::InsertTail(PackableList<Emote> *this, Emote *val) .text:005962F0 ?InsertTail@?$PackableList@VEmote@@@@QAEKABVEmote@@@Z

        //// PackableList.UnPack:
        //public int UnPack<HousePayment>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x005BAC90)(ref this, addr, size); // .text:005BAC90 ; int __thiscall PackableList<HousePayment>::UnPack(PackableList<HousePayment> *this, void **addr, unsigned int size) .text:005BAC90 ?UnPack@?$PackableList@VHousePayment@@@@UAEHAAPAXI@Z

        //// PackableList.Pack:
        //public UInt32 Pack<SalvageResult>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, UInt32>)0x005C98E0)(ref this, addr, size); // .text:005C98E0 ; unsigned int __thiscall PackableList<SalvageResult>::Pack(PackableList<SalvageResult> *this, void **addr, unsigned int size) .text:005C98E0 ?Pack@?$PackableList@VSalvageResult@@@@UAEIAAPAXI@Z

        //// PackableList.UnPack:
        //public int UnPack<SalvageResult>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x005C99E0)(ref this, addr, size); // .text:005C99E0 ; int __thiscall PackableList<SalvageResult>::UnPack(PackableList<SalvageResult> *this, void **addr, unsigned int size) .text:005C99E0 ?UnPack@?$PackableList@VSalvageResult@@@@UAEHAAPAXI@Z

        //// PackableList.RemoveHead:
        //public int RemoveHead<HousePayment>(HousePayment* retVal) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, HousePayment*, int>)0x004A2970)(ref this, retVal); // .text:004A2970 ; int __thiscall PackableList<HousePayment>::RemoveHead(PackableList<HousePayment> *this, HousePayment *retVal) .text:004A2970 ?RemoveHead@?$PackableList@VHousePayment@@@@QAEHAAVHousePayment@@@Z

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<InventoryPlacement>(InventoryPlacement* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, InventoryPlacement*, UInt32>)0x00557C10)(ref this, val); // .text:00557C10 ; unsigned int __thiscall PackableList<InventoryPlacement>::InsertTail(PackableList<InventoryPlacement> *this, InventoryPlacement *val) .text:00557C10 ?InsertTail@?$PackableList@VInventoryPlacement@@@@QAEKABVInventoryPlacement@@@Z

        //// PackableList.operator_equals:
        //public PackableList<EmoteSet>* operator_equals<EmoteSet>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, PackableList<EmoteSet>*>)0x00594FA0)(ref this); // .text:00594FA0 ; public: class PackableList<class EmoteSet> & __thiscall PackableList<class EmoteSet>::operator=(class PackableList<class EmoteSet> const &) .text:00594FA0 ??4?$PackableList@VEmoteSet@@@@QAEAAV0@ABV0@@Z

        //// PackableList.Pack:
        //public UInt32 Pack<Emote>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, UInt32>)0x00596370)(ref this, addr, size); // .text:00596370 ; unsigned int __thiscall PackableList<Emote>::Pack(PackableList<Emote> *this, void **addr, unsigned int size) .text:00596370 ?Pack@?$PackableList@VEmote@@@@UAEIAAPAXI@Z

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<EmoteSet>(EmoteSet* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, EmoteSet*, UInt32>)0x00594E30)(ref this, val); // .text:00594E30 ; unsigned int __thiscall PackableList<EmoteSet>::InsertTail(PackableList<EmoteSet> *this, EmoteSet *val) .text:00594E30 ?InsertTail@?$PackableList@VEmoteSet@@@@QAEKABVEmoteSet@@@Z

        //// PackableList.pack_size:
        //public UInt32 pack_size<GeneratorProfile>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32>)0x005D01D0)(ref this); // .text:005D01D0 ; unsigned int __thiscall PackableList<GeneratorProfile>::pack_size(PackableList<GeneratorProfile> *this) .text:005D01D0 ?pack_size@?$PackableList@VGeneratorProfile@@@@IAEIXZ

        //// PackableList.Flush:
        //public void Flush<GeneratorProfile>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x005D0210)(ref this); // .text:005D0210 ; void __thiscall PackableList<GeneratorProfile>::Flush(PackableList<GeneratorProfile> *this) .text:005D0210 ?Flush@?$PackableList@VGeneratorProfile@@@@QAEXXZ

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<ItemProfile>(ItemProfile* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, ItemProfile*, UInt32>)0x004C08A0)(ref this, val); // .text:004C08A0 ; unsigned int __thiscall PackableList<ItemProfile>::InsertTail(PackableList<ItemProfile> *this, ItemProfile *val) .text:004C08A0 ?InsertTail@?$PackableList@VItemProfile@@@@QAEKABVItemProfile@@@Z

        //// PackableList.Remove:
        //public int Remove<ItemProfile>(ItemProfile* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, ItemProfile*, int>)0x004C0FD0)(ref this, val); // .text:004C0FD0 ; int __thiscall PackableList<ItemProfile>::Remove(PackableList<ItemProfile> *this, ItemProfile *val) .text:004C0FD0 ?Remove@?$PackableList@VItemProfile@@@@QAEHAAVItemProfile@@@Z

        //// PackableList.UnPack:
        //public int UnPack<InventoryPlacement>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x00560380)(ref this, addr, size); // .text:00560380 ; int __thiscall PackableList<InventoryPlacement>::UnPack(PackableList<InventoryPlacement> *this, void **addr, unsigned int size) .text:00560380 ?UnPack@?$PackableList@VInventoryPlacement@@@@UAEHAAPAXI@Z

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<CreationProfile>(CreationProfile* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, CreationProfile*, UInt32>)0x0058F4B0)(ref this, val); // .text:0058F4B0 ; unsigned int __thiscall PackableList<CreationProfile>::InsertTail(PackableList<CreationProfile> *this, CreationProfile *val) .text:0058F4B0 ?InsertTail@?$PackableList@VCreationProfile@@@@QAEKABVCreationProfile@@@Z

        //// PackableList.Flush:
        //public void Flush<CreationProfile>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x0058F7B0)(ref this); // .text:0058F7B0 ; void __thiscall PackableList<CreationProfile>::Flush(PackableList<CreationProfile> *this) .text:0058F7B0 ?Flush@?$PackableList@VCreationProfile@@@@QAEXXZ

        //// PackableList.operator_equals:
        //public PackableList<InventoryPlacement>* operator_equals<InventoryPlacement>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, PackableList<InventoryPlacement>*>)0x005594D0)(ref this); // .text:005594D0 ; public: class PackableList<class InventoryPlacement> & __thiscall PackableList<class InventoryPlacement>::operator=(class PackableList<class InventoryPlacement> const &) .text:005594D0 ??4?$PackableList@VInventoryPlacement@@@@QAEAAV0@ABV0@@Z

        //// PackableList.UnPack:
        ////public int UnPack<AC1Legacy.PStringBase<char>>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x006A52A0)(ref this, addr, size); // .text:006A52A0 ; int __thiscall PackableList<AC1Legacy.PStringBase<char>>::UnPack(PackableList<AC1Legacy.PStringBase<char> > *this, void **addr, unsigned int size) .text:006A52A0 ?UnPack@?$PackableList@V?$PStringBase@D@AC1Legacy@@@@UAEHAAPAXI@Z

        //// PackableList.Pack:
        //public UInt32 Pack<InventoryPlacement>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, UInt32>)0x004C0910)(ref this, addr, size); // .text:004C0910 ; unsigned int __thiscall PackableList<InventoryPlacement>::Pack(PackableList<GeneratorQueueNode> *this, void **addr, unsigned int size) .text:004C0910 ?Pack@?$PackableList@VInventoryPlacement@@@@UAEIAAPAXI@Z

        //// PackableList.Remove:
        //public int Remove<Enchantment>(Enchantment* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, Enchantment*, int>)0x005941C0)(ref this, val); // .text:005941C0 ; int __thiscall PackableList<Enchantment>::Remove(PackableList<Enchantment> *this, Enchantment *val) .text:005941C0 ?Remove@?$PackableList@VEnchantment@@@@QAEHAAVEnchantment@@@Z

        //// PackableList.UnPack:
        //public int UnPack<EmoteSet>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x00595030)(ref this, addr, size); // .text:00595030 ; int __thiscall PackableList<EmoteSet>::UnPack(PackableList<EmoteSet> *this, void **addr, unsigned int size) .text:00595030 ?UnPack@?$PackableList@VEmoteSet@@@@UAEHAAPAXI@Z

        //// PackableList.RemoveHead:
        //public int RemoveHead<AdminAccountData>(AdminAccountData* retVal) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, AdminAccountData*, int>)0x006AE100)(ref this, retVal); // .text:006AE100 ; int __thiscall PackableList<AdminAccountData>::RemoveHead(PackableList<AdminAccountData> *this, AdminAccountData *retVal) .text:006AE100 ?RemoveHead@?$PackableList@VAdminAccountData@@@@QAEHAAVAdminAccountData@@@Z

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<ContentProfile>(ContentProfile* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, ContentProfile*, UInt32>)0x0055A910)(ref this, val); // .text:0055A910 ; unsigned int __thiscall PackableList<ContentProfile>::InsertTail(PackableList<ContentProfile> *this, ContentProfile *val) .text:0055A910 ?InsertTail@?$PackableList@VContentProfile@@@@QAEKABVContentProfile@@@Z

        //// PackableList.UnPack:
        //public int UnPack<ContentProfile>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x0055AF50)(ref this, addr, size); // .text:0055AF50 ; int __thiscall PackableList<ContentProfile>::UnPack(PackableList<ContentProfile> *this, void **addr, unsigned int size) .text:0055AF50 ?UnPack@?$PackableList@VContentProfile@@@@UAEHAAPAXI@Z

        //// PackableList.Pack:
        //public UInt32 Pack<EmoteSet>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, UInt32>)0x00594EA0)(ref this, addr, size); // .text:00594EA0 ; unsigned int __thiscall PackableList<EmoteSet>::Pack(PackableList<EmoteSet> *this, void **addr, unsigned int size) .text:00594EA0 ?Pack@?$PackableList@VEmoteSet@@@@UAEIAAPAXI@Z

        //// PackableList.UnPack:
        //public int UnPack<GeneratorProfile>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x005D0290)(ref this, addr, size); // .text:005D0290 ; int __thiscall PackableList<GeneratorProfile>::UnPack(PackableList<GeneratorProfile> *this, void **addr, unsigned int size) .text:005D0290 ?UnPack@?$PackableList@VGeneratorProfile@@@@UAEHAAPAXI@Z

        //// PackableList.RemoveHead:
        ////public int RemoveHead<AC1Legacy.PStringBase<char>>(AC1Legacy.PStringBase<char>* retVal) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, AC1Legacy.PStringBase<char>*, int>)0x006A51A0)(ref this, retVal); // .text:006A51A0 ; int __thiscall PackableList<AC1Legacy.PStringBase<char>>::RemoveHead(PackableList<AC1Legacy.PStringBase<char> > *this, AC1Legacy.PStringBase<char> *retVal) .text:006A51A0 ?RemoveHead@?$PackableList@V?$PStringBase@D@AC1Legacy@@@@QAEHAAV?$PStringBase@D@AC1Legacy@@@Z

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<AdminPlayerData>(AdminPlayerData* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, AdminPlayerData*, UInt32>)0x006AE080)(ref this, val); // .text:006AE080 ; unsigned int __thiscall PackableList<AdminPlayerData>::InsertTail(PackableList<AdminPlayerData> *this, AdminPlayerData *val) .text:006AE080 ?InsertTail@?$PackableList@VAdminPlayerData@@@@QAEKABVAdminPlayerData@@@Z

        //// PackableList.Remove:
        //public int Remove<InventoryPlacement>(InventoryPlacement* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, InventoryPlacement*, int>)0x0058D4A0)(ref this, val); // .text:0058D4A0 ; int __thiscall PackableList<InventoryPlacement>::Remove(PackableList<InventoryPlacement> *this, InventoryPlacement *val) .text:0058D4A0 ?Remove@?$PackableList@VInventoryPlacement@@@@QAEHAAVInventoryPlacement@@@Z

        //// PackableList.UnPack:
        //public int UnPack<Emote>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x00596770)(ref this, addr, size); // .text:00596770 ; int __thiscall PackableList<Emote>::UnPack(PackableList<Emote> *this, void **addr, unsigned int size) .text:00596770 ?UnPack@?$PackableList@VEmote@@@@UAEHAAPAXI@Z

        //// PackableList.Pack:
        //public UInt32 Pack<GeneratorProfile>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, UInt32>)0x005D0180)(ref this, addr, size); // .text:005D0180 ; unsigned int __thiscall PackableList<GeneratorProfile>::Pack(PackableList<GeneratorProfile> *this, void **addr, unsigned int size) .text:005D0180 ?Pack@?$PackableList@VGeneratorProfile@@@@UAEIAAPAXI@Z

        //// PackableList.pack_size:
        ////public UInt32 pack_size<AC1Legacy.PStringBase<char>>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32>)0x006A5160)(ref this); // .text:006A5160 ; unsigned int __thiscall PackableList<AC1Legacy.PStringBase<char>>::pack_size(PackableList<AC1Legacy.PStringBase<char> > *this) .text:006A5160 ?pack_size@?$PackableList@V?$PStringBase@D@AC1Legacy@@@@IAEIXZ

        //// PackableList.operator_equals:
        //public PackableList<HousePayment>* operator_equals<HousePayment>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, PackableList<HousePayment>*>)0x004A2AC0)(ref this); // .text:004A2AC0 ; public: class PackableList<class HousePayment> & __thiscall PackableList<class HousePayment>::operator=(class PackableList<class HousePayment> const &) .text:004A2AC0 ??4?$PackableList@VHousePayment@@@@QAEAAV0@ABV0@@Z

        //// PackableList.Flush:
        //public void Flush<InventoryPlacement>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x00559480)(ref this); // .text:00559480 ; void __thiscall PackableList<InventoryPlacement>::Flush(PackableList<InventoryPlacement> *this) .text:00559480 ?Flush@?$PackableList@VInventoryPlacement@@@@QAEXXZ

        //// PackableList.InsertHead:
        //public void InsertHead<Enchantment>(Enchantment* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, Enchantment*, void>)0x00593D60)(ref this, val); // .text:00593D60 ; void __thiscall PackableList<Enchantment>::InsertHead(PackableList<Enchantment> *this, Enchantment *val) .text:00593D60 ?InsertHead@?$PackableList@VEnchantment@@@@QAEXABVEnchantment@@@Z

        //// PackableList.Remove:
        //public int Remove<ContentProfile>(ContentProfile* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, ContentProfile*, int>)0x005BA220)(ref this, val); // .text:005BA220 ; int __thiscall PackableList<ContentProfile>::Remove(PackableList<ContentProfile> *this, ContentProfile *val) .text:005BA220 ?Remove@?$PackableList@VContentProfile@@@@QAEHAAVContentProfile@@@Z

        //// PackableList.operator_equals:
        //public PackableList<ItemProfile>* operator_equals<ItemProfile>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, PackableList<ItemProfile>*>)0x004C2340)(ref this); // .text:004C2340 ; public: class PackableList<class ItemProfile> & __thiscall PackableList<class ItemProfile>::operator=(class PackableList<class ItemProfile> const &) .text:004C2340 ??4?$PackableList@VItemProfile@@@@QAEAAV0@ABV0@@Z

        //// PackableList.pack_size:
        //public UInt32 pack_size<Emote>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32>)0x005963C0)(ref this); // .text:005963C0 ; unsigned int __thiscall PackableList<Emote>::pack_size(PackableList<Emote> *this) .text:005963C0 ?pack_size@?$PackableList@VEmote@@@@IAEIXZ

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<AdminAccountData>(AdminAccountData* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, AdminAccountData*, UInt32>)0x006AE000)(ref this, val); // .text:006AE000 ; unsigned int __thiscall PackableList<AdminAccountData>::InsertTail(PackableList<AdminAccountData> *this, AdminAccountData *val) .text:006AE000 ?InsertTail@?$PackableList@VAdminAccountData@@@@QAEKABVAdminAccountData@@@Z

        //// PackableList.RemoveHead:
        //public int RemoveHead<AdminPlayerData>(AdminPlayerData* retVal) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, AdminPlayerData*, int>)0x006AE180)(ref this, retVal); // .text:006AE180 ; int __thiscall PackableList<AdminPlayerData>::RemoveHead(PackableList<AdminPlayerData> *this, AdminPlayerData *retVal) .text:006AE180 ?RemoveHead@?$PackableList@VAdminPlayerData@@@@QAEHAAVAdminPlayerData@@@Z

        //// PackableList.UnPack:
        //public int UnPack<AdminPlayerData>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x006AE390)(ref this, addr, size); // .text:006AE390 ; int __thiscall PackableList<AdminPlayerData>::UnPack(PackableList<AdminPlayerData> *this, void **addr, unsigned int size) .text:006AE390 ?UnPack@?$PackableList@VAdminPlayerData@@@@UAEHAAPAXI@Z

        //// PackableList.Flush:
        //public void Flush<HousePayment>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x004A2A10)(ref this); // .text:004A2A10 ; void __thiscall PackableList<HousePayment>::Flush(PackableList<HousePayment> *this) .text:004A2A10 ?Flush@?$PackableList@VHousePayment@@@@QAEXXZ

        //// PackableList.Flush:
        //public void Flush<ContentProfile>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x0055AAB0)(ref this); // .text:0055AAB0 ; void __thiscall PackableList<ContentProfile>::Flush(PackableList<ContentProfile> *this) .text:0055AAB0 ?Flush@?$PackableList@VContentProfile@@@@QAEXXZ

        //// PackableList.InsertPos:
        //public UInt32 InsertPos<InventoryPlacement>(UInt32 pos, InventoryPlacement* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32, InventoryPlacement*, UInt32>)0x0058CF90)(ref this, pos, val); // .text:0058CF90 ; unsigned int __thiscall PackableList<InventoryPlacement>::InsertPos(PackableList<InventoryPlacement> *this, const unsigned int pos, InventoryPlacement *val) .text:0058CF90 ?InsertPos@?$PackableList@VInventoryPlacement@@@@QAEKKABVInventoryPlacement@@@Z

        //// PackableList.operator_equals:
        //public int operator_equals<Emote>(int a1) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, int, int>)0x00596730)(ref this, a1); // .text:00596730 ; int __thiscall PackableList<Emote>::operator=(PackableList<Emote> *this, int) .text:00596730 ??4?$PackableList@VEmote@@@@QAEAAV0@ABV0@@Z

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<GeneratorProfile>(GeneratorProfile* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, GeneratorProfile*, UInt32>)0x005D0120)(ref this, val); // .text:005D0120 ; unsigned int __thiscall PackableList<GeneratorProfile>::InsertTail(PackableList<GeneratorProfile> *this, GeneratorProfile *val) .text:005D0120 ?InsertTail@?$PackableList@VGeneratorProfile@@@@QAEKABVGeneratorProfile@@@Z

        //// PackableList.InsertHead:
        //public void InsertHead<ItemProfile>(ItemProfile* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, ItemProfile*, void>)0x004C0840)(ref this, val); // .text:004C0840 ; void __thiscall PackableList<ItemProfile>::InsertHead(PackableList<ItemProfile> *this, ItemProfile *val) .text:004C0840 ?InsertHead@?$PackableList@VItemProfile@@@@QAEXABVItemProfile@@@Z

        //// PackableList.RemoveTail:
        //public int RemoveTail<ItemProfile>(ItemProfile* retVal) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, ItemProfile*, int>)0x004C0F70)(ref this, retVal); // .text:004C0F70 ; int __thiscall PackableList<ItemProfile>::RemoveTail(PackableList<ItemProfile> *this, ItemProfile *retVal) .text:004C0F70 ?RemoveTail@?$PackableList@VItemProfile@@@@QAEHAAVItemProfile@@@Z

        //// PackableList.pack_size:
        //public UInt32 pack_size<ContentProfile>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32>)0x006ADA60)(ref this); // .text:006ADA60 ; unsigned int __thiscall PackableList<ContentProfile>::pack_size(PackableList<ContentProfile> *this) .text:006ADA60 ?pack_size@?$PackableList@VContentProfile@@@@IAEIXZ

        //// PackableList.Flush:
        //public void Flush<SalvageResult>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x005C9970)(ref this); // .text:005C9970 ; void __thiscall PackableList<SalvageResult>::Flush(PackableList<SalvageResult> *this) .text:005C9970 ?Flush@?$PackableList@VSalvageResult@@@@QAEXXZ

        //// PackableList.InsertTail:
        ////public UInt32 InsertTail<AC1Legacy.PStringBase<char>>(AC1Legacy.PStringBase<char>* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, AC1Legacy.PStringBase<char>*, UInt32>)0x006A4860)(ref this, val); // .text:006A4860 ; unsigned int __thiscall PackableList<AC1Legacy.PStringBase<char>>::InsertTail(PackableList<AC1Legacy.PStringBase<char> > *this, AC1Legacy.PStringBase<char> *val) .text:006A4860 ?InsertTail@?$PackableList@V?$PStringBase@D@AC1Legacy@@@@QAEKABV?$PStringBase@D@AC1Legacy@@@Z

        //// PackableList.Flush:
        //public void Flush<AdminAccountData>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x006AE200)(ref this); // .text:006AE200 ; void __thiscall PackableList<AdminAccountData>::Flush(PackableList<AdminAccountData> *this) .text:006AE200 ?Flush@?$PackableList@VAdminAccountData@@@@QAEXXZ

        //// PackableList.Pack:
        //public UInt32 Pack<Enchantment>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, UInt32>)0x004B7740)(ref this, addr, size); // .text:004B7740 ; unsigned int __thiscall PackableList<Enchantment>::Pack(PackableList<Enchantment> *this, void **addr, unsigned int size) .text:004B7740 ?Pack@?$PackableList@VEnchantment@@@@UAEIAAPAXI@Z

        //// PackableList.UnPack:
        //public int UnPack<ItemProfile>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x004C1120)(ref this, addr, size); // .text:004C1120 ; int __thiscall PackableList<ItemProfile>::UnPack(PackableList<ItemProfile> *this, void **addr, unsigned int size) .text:004C1120 ?UnPack@?$PackableList@VItemProfile@@@@UAEHAAPAXI@Z

        //// PackableList.pack_size:
        //public UInt32 pack_size<EmoteSet>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32>)0x00594EF0)(ref this); // .text:00594EF0 ; unsigned int __thiscall PackableList<EmoteSet>::pack_size(PackableList<EmoteSet> *this) .text:00594EF0 ?pack_size@?$PackableList@VEmoteSet@@@@IAEIXZ

        //// PackableList.Flush:
        //public void Flush<EmoteSet>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void>)0x00594F30)(ref this); // .text:00594F30 ; void __thiscall PackableList<EmoteSet>::Flush(PackableList<EmoteSet> *this) .text:00594F30 ?Flush@?$PackableList@VEmoteSet@@@@QAEXXZ

        //// PackableList.pack_size:
        //public UInt32 pack_size<InventoryPlacement>() => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32>)0x004C0960)(ref this); // .text:004C0960 ; unsigned int __thiscall PackableList<InventoryPlacement>::pack_size(PackableList<GeneratorQueueNode> *this) .text:004C0960 ?pack_size@?$PackableList@VInventoryPlacement@@@@IAEIXZ

        //// PackableList.Pack:
        //public UInt32 Pack<CreationProfile>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, UInt32>)0x0058F520)(ref this, addr, size); // .text:0058F520 ; unsigned int __thiscall PackableList<CreationProfile>::Pack(PackableList<CreationProfile> *this, void **addr, unsigned int size) .text:0058F520 ?Pack@?$PackableList@VCreationProfile@@@@UAEIAAPAXI@Z

        //// PackableList.UnPack:
        //public int UnPack<CreationProfile>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x0058FA50)(ref this, addr, size); // .text:0058FA50 ; int __thiscall PackableList<CreationProfile>::UnPack(PackableList<CreationProfile> *this, void **addr, unsigned int size) .text:0058FA50 ?UnPack@?$PackableList@VCreationProfile@@@@UAEHAAPAXI@Z

        //// PackableList.UnPack:
        //public int UnPack<GeneratorQueueNode>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, int>)0x005D07E0)(ref this, addr, size); // .text:005D07E0 ; int __thiscall PackableList<GeneratorQueueNode>::UnPack(PackableList<GeneratorQueueNode> *this, void **addr, unsigned int size) .text:005D07E0 ?UnPack@?$PackableList@VGeneratorQueueNode@@@@UAEHAAPAXI@Z

        //// PackableList.InsertPos:
        //public UInt32 InsertPos<ContentProfile>(UInt32 pos, ContentProfile* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, UInt32, ContentProfile*, UInt32>)0x005BA100)(ref this, pos, val); // .text:005BA100 ; unsigned int __thiscall PackableList<ContentProfile>::InsertPos(PackableList<ContentProfile> *this, const unsigned int pos, ContentProfile *val) .text:005BA100 ?InsertPos@?$PackableList@VContentProfile@@@@QAEKKABVContentProfile@@@Z

        //// PackableList.InsertTail:
        //public UInt32 InsertTail<GeneratorQueueNode>(GeneratorQueueNode* val) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, GeneratorQueueNode*, UInt32>)0x005D0700)(ref this, val); // .text:005D0700 ; unsigned int __thiscall PackableList<GeneratorQueueNode>::InsertTail(PackableList<GeneratorQueueNode> *this, GeneratorQueueNode *val) .text:005D0700 ?InsertTail@?$PackableList@VGeneratorQueueNode@@@@QAEKABVGeneratorQueueNode@@@Z

        //// PackableList.Pack:
        ////public UInt32 Pack<AC1Legacy.PStringBase<char>>(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PackableList<T>, void**, UInt32, UInt32>)0x006A5110)(ref this, addr, size); // .text:006A5110 ; unsigned int __thiscall PackableList<AC1Legacy.PStringBase<char>>::Pack(PackableList<AC1Legacy.PStringBase<char> > *this, void **addr, unsigned int size) .text:006A5110 ?Pack@?$PackableList@V?$PStringBase@D@AC1Legacy@@@@UAEIAAPAXI@Z


    }


}