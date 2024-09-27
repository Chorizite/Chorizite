using System;
namespace AcClient {

    public unsafe partial struct AC1Legacy {
        public unsafe struct SmartArray<T> where T : unmanaged {
            public T* m_data;
            public UInt32 m_sizeAndDeallocate;
            public UInt32 m_num;
            public override string ToString() {
                if (m_num == 0) return "null";
                string[] Chars = new string[m_num];
                for (Int32 i = 0; i < m_num; i++) {
                    Chars[i] = $"{m_data[i]}";
                }
                return $"num:{m_num} {string.Join(", ", Chars)}";
            }
        };

        public unsafe struct PQueueArray<T> where T : unmanaged {
            public _Vtbl* vfptr;
            public PQueueNode<T>* A;
            public Int32 curNumNodes;
            public Int32 allocatedNodes;
            public Int32 minAllocatedNodes;
        };
        public unsafe struct PQueueNode<T> where T : unmanaged {
            public T key;
            public void* data;
        };
    }
    public unsafe struct SmartArray<T> where T : unmanaged {
        public T* m_data;
        public UInt32 m_sizeAndDeallocate;
        public UInt32 m_num;
    };

    public unsafe struct DArray<T> where T : unmanaged {
        public T** data;
        public UInt32 blocksize;
        public UInt32 next_available;
        public UInt32 sizeOf;
        public override string ToString() => $"DArray<{typeof(T)}>[{sizeOf}]";

    };
    public unsafe struct SArray<T> where T : unmanaged {
        public T** data;
        public UInt16 sizeOf;
        /*(0051ADD0)
void __thiscall SArray<CPhysicsObj *>::grow(SArray<CPhysicsObj *> *this, U__Int3216 size); // idb
void __thiscall SArray<CPhysicsObj *>::shrink(SArray<CPhysicsObj *> *this, const U__Int3216 size); // idb


        */
    };


    public unsafe struct FixedArray<T> where T : unmanaged {
        // Struct:
        public T* m_data;
        public UInt32 m_num;
        public override string ToString() => $"m_data:->({typeof(T)}*)0x{(int)m_data:X8}, m_num:{m_num:X8}";

        // Functions:

        // FixedArray.Create<PStringBase<char>>:
        // public void Create(UInt32 i_numElements) => ((delegate* unmanaged[Thiscall]<ref FixedArray<T>, UInt32, void>)0xDEADBEEF)(ref this, i_numElements); // .text:00435090 ; void __thiscall FixedArray<PStringBase<char>>::Create(FixedArray<PStringBase<char> > *this, unsigned int i_numElements) .text:00435090 ?Create@?$FixedArray@V?$PStringBase@D@@@@QAEXI@Z
    }


    public unsafe struct PQueueArray<T, U> where T : unmanaged where U : unmanaged {
        public _Vtbl* vfptr;
        public PQueueNode<T, U>* A;
        public Int32 curNumNodes;
        public Int32 allocatedNodes;
        public Int32 minAllocatedNodes;
    };
    public unsafe struct PQueueNode<T, U> where T : unmanaged where U : unmanaged {
        public T key;
        public U* data;
    };




    public unsafe struct PSmartArray<T> where T : unmanaged {
        public StreamPackObj streamPackObj;
        public AC1Legacy.SmartArray<T> array;
    };

    public unsafe struct OldSmartArray<T> where T : unmanaged {
        public T** data;
        public Int32 grow_size;
        public Int32 mem_size;
        public Int32 num_in_array;
        /*(00521630)
Int32 __thiscall OldSmartArray<PhysicsScriptData *>::Grow(OldSmartArray<PhysicsScriptData *> *this, Int32 _size); // idb

        */
    };


    public unsafe struct PrimitiveInplaceArray<T> where T : unmanaged {
        public SmartArray<T> array;
        public fixed Int32 m_aPrimitiveInplaceMemory[16];
    };
}