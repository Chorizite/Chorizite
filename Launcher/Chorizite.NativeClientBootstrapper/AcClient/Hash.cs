using System;

namespace AcClient {
    public unsafe struct HashBase<T> where T : unmanaged {
        // Struct:
        public _Vtbl* vfptr;
        public T table_mask;
        public Int32 key_shift;
        public HashBaseData<T>** buckets;
        public UInt32 table_size;
        public Int32 fPlacementNew_;

        public int Count {
            get {
                Int32 curIndex = 0;

                Int32 curBucket_ = 0;
                HashBaseData<T>* curPtr_ = null;
                bool fEnd_ = false;

                while (true) {
                    if (curPtr_ != null) {
                        curPtr_ = curPtr_->hash_next;
                        curIndex++;
                    }
                    if (curPtr_ == null) {
                        while (true) {
                            curBucket_++;
                            if (curBucket_ >= table_size) {
                                fEnd_ = true;
                                break;
                            }
                            curPtr_ = buckets[curBucket_];
                            if (curPtr_ != null) break;
                        }
                    }
                    if (fEnd_) break;
                }
                return curIndex;
            }
        }

        public HashBaseData<T>* this[int index] { get => GetByIndex(index); }
        public override string ToString() => $"type:HashBase<{typeof(T)}> vfptr:->(_Vtbl*)0x{(Int32)vfptr:X8}, table_mask:{table_mask:X8}, key_shift:{key_shift}, buckets:->(HashBaseData<{typeof(T)}>**)0x{(Int32)buckets:X8}, table_size:{table_size}, fPlacementNew_:{fPlacementNew_}";
        public bool Contains(T item) => GetByID(item) != null;

        public HashBaseData<T>* GetByIndex(int index) {
            Int32 curIndex = 0;
            Int32 curBucket_ = 0;
            HashBaseData<T>* curPtr_ = buckets[curBucket_];
            bool fEnd_ = false;
            while (true) {
                if (curPtr_ != null) {
                    curPtr_ = curPtr_->hash_next;
                    curIndex++;
                }
                if (curPtr_ == null) {
                    while (true) {
                        curBucket_++;
                        if (curBucket_ >= table_size) {
                            fEnd_ = true;
                            break;
                        }
                        curPtr_ = buckets[curBucket_];
                        if (curPtr_ != null) break;
                    }
                }
                if (fEnd_) break;
                if (curIndex == index) return curPtr_;
            }
            return null;
        }


        public HashBaseData<T>* GetByID(T id) {
            if (typeof(T) == typeof(UInt64)) {
                UInt64 local = *(UInt64*)&id;
                HashBaseData<UInt64>* iter = (HashBaseData<UInt64>*)buckets[(local ^ (local >> key_shift)) % table_size];
                while (iter != null && !iter->id.Equals(id)) {
                    iter = iter->hash_next;
                }
                if (iter == null || !iter->id.Equals(id))
                    return null;
                return (HashBaseData<T>*)iter;
            }
            UInt32 local32 = *(UInt32*)&id;
            HashBaseData<UInt32>* iter32 = (HashBaseData<UInt32>*)buckets[(local32 ^ (local32 >> key_shift)) % table_size];
            while (iter32 != null && !iter32->id.Equals(id)) {
                iter32 = iter32->hash_next;
            }
            if (iter32 == null || !iter32->id.Equals(id))
                return null;
            return (HashBaseData<T>*)iter32;
        }
        //public HashBaseData<UInt64>* GetByID(UInt64 id) {
        //    HashBaseData<UInt64>* iter = (HashBaseData<UInt64>*)buckets[(id ^ (id >> key_shift)) % table_size];
        //    while (iter != null && iter->id != id) {
        //        iter = iter->hash_next;
        //    }
        //    if (iter->id != id)
        //        return null;
        //    return iter;
        //}


        //public List<Int32> GetList() {
        //    List<Int32> ret = new List<Int32>();

        //    Int32 curBucket_ = 0;
        //    HashBaseData<T>* lastThisChain_ = null;
        //    HashBaseData<T>* curPtr_ = null;
        //    bool fEnd_ = false;

        //    while (true) {
        //        if (curPtr_ != null) {
        //            lastThisChain_ = curPtr_;
        //            curPtr_ = curPtr_->hash_next;
        //        }
        //        if (curPtr_ == null) {
        //            while (true) {
        //                var v3 = curBucket_ + 1;
        //                lastThisChain_ = null;
        //                curBucket_ = v3;
        //                if (v3 >= table_size) {
        //                    fEnd_ = true;
        //                    break;
        //                }
        //                var v4 = buckets[v3];
        //                curPtr_ = v4;
        //                if (curPtr_ != null)
        //                    break;
        //            }
        //        }
        //        if (fEnd_)
        //            break;

        //        ret.Add((Int32)curPtr_);
        //    }
        //    return ret;
        //}

        // Functions:

        // HashBase<UInt32>.__Dtor:
        public void __Dtor() => ((delegate* unmanaged[Thiscall]<HashBase<T>*>)0x004F7FC0)(); // .text:004F7380 ; void __thiscall HashBase<UInt32>::~HashBase<UInt32>(HashBase<UInt32> *this) .text:004F7380 ??1?$HashBase@K@@UAE@XZ

        // HashBase<UInt32>.InternalInit:
        public HashBase<T>* InternalInit(T table_size) => ((delegate* unmanaged[Thiscall]<ref HashBase<T>, T, HashBase<T>*>)0x004F7FE0)(ref this, table_size); // .text:004F73A0 ; void __thiscall HashBase<UInt32>::InternalInit(HashBase<UInt32> *this, UInt32 _table_size) .text:004F73A0 ?InternalInit@?$HashBase@K@@QAEXI@Z

        //// HashBase<UInt32>.remove:
        public bool Remove(T item) => remove(item) != null;
        public HashBaseData<T>* remove(T key) => ((delegate* unmanaged[Thiscall]<ref HashBase<T>, T, HashBaseData<T>*>)0x005085F0)(ref this, key); // .text:00507AC0 ; HashBaseData<UInt32> *__thiscall HashBase<UInt32>::remove(HashBase<UInt32> *this, UInt32 key) .text:00507AC0 ?remove@?$HashBase@K@@QAEPAV?$HashBaseData@K@@K@Z

        //// HashBase<UInt32>.lookup:
        //public HashBaseData<T>* lookup(UInt32 key) => ((delegate* unmanaged[Thiscall]<ref HashBase<T>, UInt32, HashBaseData<T>*>)0x005231D0)(ref this, key); // .text:00522680 ; MotionData *__thiscall LongHash<MotionData>::lookup(LongHash<MotionData> *this, unsigned int key) .text:00522680 ?lookup@?$LongHash@VMotionData@@@@QBEPAVMotionData@@K@Z proc near

        //// HashBase<UInt32>.clobber:
        public HashBaseData<T>* clobber(HashBaseData<T> newData) => ((delegate* unmanaged[Thiscall]<ref HashBase<T>, ref HashBaseData<T>, HashBaseData<T>*>)0x00512D10)(ref this, ref newData); // .text:00512240 ; HashBaseData<UInt32> *__thiscall HashBase<UInt32>::clobber(HashBase<UInt32> *this, HashBaseData<UInt32> *newData) .text:00512240 ?clobber@?$HashBase@K@@QAEPAV?$HashBaseData@K@@PAV2@@Z

        //// HashBase<UInt64>.remove:
        public bool Remove<UInt64>(UInt64 item) => remove(item) != null;
        public HashBaseData<T>* remove<UInt64>(UInt64 key) => ((delegate* unmanaged[Thiscall]<ref HashBase<T>, UInt64, HashBaseData<T>*>)0x0054AC20)(ref this, key); // .text:0054A080 ; HashBaseData<UInt64> *__thiscall HashBase<UInt64>::remove(HashBase<UInt64> *this, UInt64 key) .text:0054A080 ?remove@?$HashBase@_K@@QAEPAV?$HashBaseData@_K@@_K@Z

        //// HashBase<UInt64>.lookup:
        //public bool Contains<UInt64>(UInt64 item) => (int)lookup(item) != 0;
        //public HashBaseData<T>* lookup<UInt64>(UInt64 key) => ((delegate* unmanaged[Thiscall]<ref HashBase<T>, UInt64, HashBaseData<T>*>)0x0054ACB0)(ref this, key); // .text:0054A110 ; HashBaseData<UInt64> *__thiscall HashBase<UInt64>::lookup(HashBase<UInt64> *this, UInt64 key) .text:0054A110 ?lookup@?$HashBase@_K@@QBEPAV?$HashBaseData@_K@@_K@Z

        // F- in efficiency; poc
        public void CopyTo(T[] array, int arrayIndex) {
            Int32 curBucket_ = 0;
            Int32 curIndex = 0;
            HashBaseData<T>* lastThisChain_ = null;
            HashBaseData<T>* curPtr_ = null;
            bool fEnd_ = false;

            while (true) {
                if (curPtr_ != null) {
                    lastThisChain_ = curPtr_;
                    curPtr_ = curPtr_->hash_next;
                    curIndex++;
                }
                if (curPtr_ == null) {
                    while (true) {
                        curBucket_++;
                        lastThisChain_ = null;
                        if (curBucket_ >= table_size) {
                            fEnd_ = true;
                            break;
                        }
                        curPtr_ = buckets[curBucket_];
                        if (curPtr_ != null)
                            break;
                    }
                }
                if (fEnd_)
                    break;

                if (curIndex >= arrayIndex)
                    array[curIndex - arrayIndex] = curPtr_->id;
            }
        }
    }




    public unsafe struct HashBaseData<T> where T : unmanaged {
        // Struct:
        public T vfptr; // don't ask.
        public HashBaseData<T>* hash_next;
        public T id;
        public override string ToString() => $"vfptr:->(HashBaseData<UInt32>Vtbl*)0x{vfptr:X8}, hash_next:->(HashBaseData<UInt32>*)0x{(Int32)hash_next:X8}, id:{id:X8}";


        // Functions:

        // HashBaseData<UInt32>.__scaDelDtor:
        public void* __scaDelDtor(UInt32 a2) => ((delegate* unmanaged[Thiscall]<ref HashBaseData<T>, UInt32, void*>)0x00512DB0)(ref this, a2); // .text:0051FE80 ; void *__thiscall HashBaseData<UInt32>::`scalar deleting destructor'(LongNIValHashData<GlobalVoyeurInfo> *this, UInt32) .text:0051FE80 ??_G?$HashBaseData@K@@UAEPAXI@Z
    }




    public unsafe struct HashBaseIter<T> where T : unmanaged {
        // Struct:
        public HashBase<T>* myHash_;
        public UInt32 curBucket_;
        public HashBaseData<T>* curPtr_;
        public HashBaseData<T>* lastThisChain_;
        public Int32 fEnd_;
        public override string ToString() => $"myHash_:->(HashBase<UInt32>*)0x{(Int32)myHash_:X8}, curBucket_:{curBucket_:X8}, curPtr_:->(HashBaseData<UInt32>*)0x{(Int32)curPtr_:X8}, lastThisChain_:->(HashBaseData<UInt32>*)0x{(Int32)lastThisChain_:X8}, fEnd_:{fEnd_}";


        // Functions:

        // HashBaseIter<UInt32>.Next:
        public void Next() => ((delegate* unmanaged[Thiscall]<ref HashBaseIter<T>, void>)0x004D8D00)(ref this); // .text:004D80A0 ; void __thiscall HashBaseIter<UInt32>::Next(HashBaseIter<UInt32> *this) .text:004D80A0 ?Next@?$HashBaseIter@K@@QAEXXZ


        // HashBaseIter<UInt32>.DeleteCurrent:
        public void DeleteCurrent() => ((delegate* unmanaged[Thiscall]<ref HashBaseIter<T>, void>)0x004F8040)(ref this); // .text:004F7400 ; void __thiscall HashBaseIter<UInt32>::DeleteCurrent(HashBaseIter<UInt32> *this) .text:004F7400 ?DeleteCurrent@?$HashBaseIter@K@@QAEXXZ


        // HashBaseIter<UInt64>.DeleteCurrent:
        public void DeleteCurrent<UInt64>() => ((delegate* unmanaged[Thiscall]<ref HashBaseIter<T>, void>)0x0054AB40)(ref this); // .text:00549FA0 ; void __thiscall HashBaseIter<UInt64>::DeleteCurrent(HashBaseIter<UInt64> *this) .text:00549FA0 ?DeleteCurrent@?$HashBaseIter@_K@@QAEXXZ

        // HashBaseIter<UInt64>.Next:
        public void Next<UInt64>() => ((delegate* unmanaged[Thiscall]<ref HashBaseIter<T>, void>)0x0054ABD0)(ref this); // .text:0054A030 ; void __thiscall HashBaseIter<UInt64>::Next(HashBaseIter<UInt64> *this) .text:0054A030 ?Next@?$HashBaseIter@_K@@QAEXXZ

    }















    public unsafe struct LongNIValHash<T> where T : unmanaged {
        public HashBase<UInt32> hash;
    };
    public unsafe struct LongNIValHashData<T> where T : unmanaged {
        public HashBaseData<UInt32> hash;
        public T* data;
    };
    public unsafe struct LongNIValHashIter<T> where T : unmanaged {
        public HashBaseIter<UInt32> iter;
    };





    public unsafe struct LongNIHash<T> where T : unmanaged {
        public LongNIHashData<T>** buckets;
        public Int32 table_size;
    };
    public unsafe struct LongNIHashData<T> where T : unmanaged {
        public LongNIHashData<T>* next;
        public T* data;
        public UInt32 key;
    };
    public unsafe struct LongNIHashIter<T> where T : unmanaged {
        public LongNIHash<T>* hash;
        public Int32 bucketNo;
        public LongNIHashData<T>* curDat;
        public Int32 fDone;
    };







    public unsafe struct StrHashData {
        public StrHashData* hash_next;
        public Char* name;
    };//no functions


    public unsafe struct UI64Hash<T> where T : unmanaged {
        // Struct:
        public HashBase<UInt64> a0;
        public override string ToString() => $"UI64Hash<{typeof(T)}>->HashBase<UInt64>({a0})";

        // Functions:

        // UI64Hash.add:
        public void add(T* data) => ((delegate* unmanaged[Thiscall]<ref UI64Hash<T>, T*, void>)0x0054A160)(ref this, data); // .text:0054A160 ; void __thiscall UI64Hash<NetBlob>::add(UI64Hash<NetBlob> *this, NetBlob *data) .text:0054A160 ?add@?$UI64Hash@VNetBlob@@@@QAEXPAVNetBlob@@@Z

        // UI64Hash.destroy_contents:
        public void destroy_contents() => ((delegate* unmanaged[Thiscall]<ref UI64Hash<T>, void>)0x0054A520)(ref this); // .text:0054A520 ; void __thiscall UI64Hash<ArrivedEphInfo>::destroy_contents(UI64Hash<ArrivedEphInfo> *this) .text:0054A520 ?destroy_contents@?$UI64Hash@VArrivedEphInfo@@@@QAEXXZ
    }
    public unsafe struct UI64HashData {
        // Struct:
        public HashBaseData<UInt64> a0;
        public override string ToString() => $"UI64HashData->HashBaseData<UInt64>({a0})";

    }
    public unsafe struct UI64HashIter<T> where T : unmanaged {
        // Struct:
        public HashBaseIter<UInt64> a0;
        public override string ToString() => $"UI64HashIter<{typeof(T)}>->HashBaseIter<UInt64>({a0})";
    }






    public unsafe struct LongHash<T> where T : unmanaged {
        // Struct:
        public HashBase<UInt32> a0;
        public override string ToString() => $"LongHash<{typeof(T)}>->HashBase<UInt32>({a0})";
        // Functions:

        // LongHash.lookup:
        public T* lookup(UInt32 key) => ((delegate* unmanaged[Thiscall]<ref LongHash<T>, UInt32, T*>)0x00522680)(ref this, key); // .text:00522680 ; MotionData *__thiscall LongHash<MotionData>::lookup(LongHash<MotionData> *this, unsigned int key) .text:00522680 ?lookup@?$LongHash@VMotionData@@@@QBEPAVMotionData@@K@Z

    }
    public unsafe struct LongHashIter<T> where T : unmanaged {
        // Struct:
        public HashBaseIter<UInt32> a0;
        public override string ToString() => $"LongHashIter<{typeof(T)}>->HashBaseIter<UInt32>({a0})";
    }

    public unsafe struct LongHashData {
        // Struct:
        public HashBaseData<UInt32> a0;
        public override string ToString() => $"LongHashData->HashBaseData<UInt32>({a0})";

    }









    public unsafe struct PackableHashData<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public KEY _key;
        public DATA _data;
        public PackableHashData<KEY, DATA>* _next;
        public Int32 _hashVal;
        public override string ToString() => $"_key:{_key}, _data:({_data}), _next:->0x{(int)_next:X8}, _hashVal:{_hashVal}";

    };
    //public unsafe struct PackableHashTable<KEY, DATA> : System.Collections.Generic.IList<KEY> where KEY : unmanaged where DATA : unmanaged {
    public unsafe struct PackableHashTable<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        // Struct:
        public PackObj a0;
        public Int32 m_fThrowawayDuplicateKeysOnUnPack;
        public PackableHashData<KEY, DATA>** _buckets;
        public UInt32 _table_size;
        public UInt32 _currNum;

        public unsafe PackableHashData<KEY, DATA>* lookup(KEY _key) {
            PackableHashData<KEY, DATA>* cur_iter;
            if (_table_size == 0 || _buckets == null) {
                return null;
            }
            cur_iter = _buckets[(*(uint*)&_key) % _table_size];
            if (cur_iter != null) {
                while (!_key.Equals(cur_iter->_key)) {
                    cur_iter = cur_iter->_next;
                    if (cur_iter == null)
                        return null;
                }
                return cur_iter;
            }
            return null;
        }
        public int Count { get => (int)_currNum; }

        public bool IsReadOnly => false;

        public bool Contains(KEY item) => lookup(item) != null;

        public PackableHashData<KEY, DATA>* this[int index] {
            get => GetByIndex(index);
            set => throw new NotImplementedException();
        }

        public PackableHashData<KEY, DATA>* GetByIndex(int _index) {
            if (_table_size == 0 || _buckets == null || _index < 0 || _index >= (int)_currNum) return null;
            Int32 curIndex = 0;
            Int32 curBucket_ = 0;
            PackableHashData<KEY, DATA>* curPtr_ = _buckets[curBucket_];
            bool fEnd_ = false;
            while (true) {

                if (curPtr_ != null) {
                    if (curIndex == _index) return curPtr_;
                    curPtr_ = curPtr_->_next;
                    curIndex++;
                }
                if (curPtr_ == null) {
                    while (true) {
                        curBucket_++;
                        if (curBucket_ >= _table_size) {
                            fEnd_ = true;
                            break;
                        }
                        curPtr_ = _buckets[curBucket_];
                        if (curPtr_ != null) break;
                    }
                }
                if (fEnd_) break;
            }
            return null;
        }

        public override string ToString() => $"a0(PackObj):{a0}, m_fThrowawayDuplicateKeysOnUnPack(int):{m_fThrowawayDuplicateKeysOnUnPack}, _buckets:->(PackableHashData<UInt32,UInt32>**)0x{(int)_buckets:X8}, _table_size:{_table_size:X8}, _currNum:{_currNum:X8}";

        /// <summary>
        /// copy to (pre-initialized) array.
        /// </summary>
        /// <param name="array">pre initialized array to hold items from table</param>
        /// <param name="_index">index to start at (for chunking)</param>
        // ex:
        //    CBaseQualities* playerQualities = &(*CPhysicsObj.player_object)->weenie_obj->m_pQualities->a0.a1;
        //    var table = playerQualities->_strStatsTable;
        //    AcClient.PackableHashData<uint, AC1Legacy.PStringBase<char>>*[] mytable = new AcClient.PackableHashData<uint, AC1Legacy.PStringBase<char>>*[16];
        //    table->CopyTo(mytable, StartIDX);
        //    
        // set the maximum length, by initializing the array at the length you want.
        public void CopyTo(PackableHashData<KEY, DATA>*[] array, int _index) {
            if (_table_size == 0 || _buckets == null || _index < 0 || _index >= (int)_currNum) return;
            Int32 curIndex = 0;
            Int32 curBucket_ = 0;
            Int32 lastIdx = 0;
            PackableHashData<KEY, DATA>* curPtr_ = _buckets[curBucket_];
            bool fEnd_ = false;
            while (true) {

                if (curPtr_ != null) {
                    if (curIndex >= _index) {
                        if (lastIdx == array.Length) return;
                        array[lastIdx] = curPtr_;
                        lastIdx++;
                    }
                    curPtr_ = curPtr_->_next;
                    curIndex++;
                }
                if (curPtr_ == null) {
                    while (true) {
                        curBucket_++;
                        if (curBucket_ >= _table_size) {
                            fEnd_ = true;
                            break;
                        }
                        curPtr_ = _buckets[curBucket_];
                        if (curPtr_ != null) break;
                    }
                }
                if (fEnd_) break;
            }
            return;
        }

        //public bool Remove(KEY item) {
        //    PackableHashData<KEY, DATA>* lastThisChain = null;
        //    uint v6 = (*(uint*)(&item)) % _table_size;
        //    PackableHashData<KEY, DATA>* curPtr = _buckets[v6];
        //    if (_table_size > 0 && _buckets != null && (curPtr != null)) {
        //        while (!curPtr->_key.Equals(item)) {
        //            lastThisChain = curPtr;
        //            curPtr = curPtr->_next;
        //            if (curPtr == null)
        //                return false;
        //        }
        //        //pop code
        //        //retval->objcell_id = curPtr->_data.objcell_id;
        //        //Frame::operator= ((int)&retval->frame, (int)&curPtr->_data.frame);
        //        if (lastThisChain != null)
        //            lastThisChain->_next = curPtr->_next;
        //        else
        //            _buckets[(*(uint*)(&item)) % _table_size] = curPtr->_next;
        //        *(uint*)&curPtr->_data = 0x0079385C; // .rdata:0079385C ; const PackObj::`vftable'
        //        operator_delete(curPtr);
        //        --_currNum;
        //        return true;
        //    }
        //    return false;
        //}

        public static delegate* unmanaged[Cdecl]<void*, void> operator_delete = (delegate* unmanaged[Cdecl]<void*, void>)0x005DF15E; // .text:005DF15E ; void __cdecl operator delete(void *)

    }
    //public unsafe struct PackableHashIterator<KEY, DATA> : IEnumerator<KEY> where KEY : unmanaged where DATA : unmanaged {
    public unsafe struct PackableHashIterator<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public _Vtbl* vfptr;
        public PackableHashData<KEY, DATA>* current;
        public PackableHashData<KEY, DATA>** _buckets;
        public UInt32 _table_size;
    }




    public unsafe struct PHashTable<W, X> where W : unmanaged where X : unmanaged {
        public HashTable<W, X> hashTable;
        public StreamPackObj streamPackObj;
    };


    public unsafe struct AutoGrowHashTable<W, X> where W : unmanaged where X : unmanaged {
        public HashTable<W, X> hashTable;
    };





    public unsafe struct HashSetData<W> where W : unmanaged {
        public UInt32 m_hashKey;
        public Int32* m_hashNext;
    };
    public unsafe struct HashSet<T> where T : unmanaged {
        public _Vtbl* vfptr;
        public IntrusiveHashTable<T, HashSetData<T>> m_Int32rusiveTable;
    };



    public unsafe struct HashTableData<W, X> where W : unmanaged where X : unmanaged {
        public UInt32 m_hashKey;
        public HashTableData<W, X>* m_hashNext;
        public X m_data;
    };



    public unsafe struct IntrusiveHashTable<W, X> where W : unmanaged where X : unmanaged {
        public _Vtbl* vfptr;
        public fixed Int32 m_aInplaceBuckets[23];
        public X** m_buckets;
        public X* m_firstInterestingBucket;
        public UInt32 m_numBuckets;
        public UInt32 m_numElements;
    };



    public unsafe struct IntrusiveHashList<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public _Vtbl* vfptr;
        public fixed Int32 m_aInplaceBuckets[23];
        public DATA** m_buckets;
        public DATA** m_firstInterestingBucket;
        public UInt32 m_numBuckets;
        public UInt32 m_numElements;
        public DLListBase m_list;
    };

    public unsafe struct IntrusiveHashData<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public KEY m_hashKey;
        public DATA* m_hashNext;
    };

    public unsafe struct IntrusiveHashListData<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public IntrusiveHashData<KEY, DATA> IntrusiveHashData;
        public DLListData DLListData;
    };

    public unsafe struct IntrusiveHashListIterator<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public DATA* m_pData;
        public IntrusiveHashList<KEY, DATA>* m_pHashList;
    };
    public unsafe struct IntrusiveHashIterator<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public IntrusiveHashList<KEY, DATA>* m_currHashTable;
        public DATA** m_currBucket;
        public DATA* m_currElement;
    };


    //









    public unsafe struct HashTable<W, X> where W : unmanaged where X : unmanaged {
        public _Vtbl* vfptr;
        public IntrusiveHashTable<W, HashTableData<W, X>> m_Int32rusiveTable;
    };
    public unsafe struct HashSetIterator<W> where W : unmanaged {
        public IntrusiveHashIterator<W, HashSetData<W>> m_iter;
    };

    public unsafe struct HashList<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        public _Vtbl* vfptr;
        public fixed Int32 m_aInplaceBuckets[23];
        public HashListData** m_buckets;
        public HashListData** m_firstInterestingBucket;
        public UInt32 m_numBuckets;
        public UInt32 m_numElements;
        public DLListBase m_list;
        public unsafe struct HashListData {
            public DATA* m_hashKey;
            public KEY* m_hashNext;
            public DLListData DLListData;
            public KEY* m_data;
        };
    };



    /// <summary>
    /// 
    /// </summary>




    //workaround for UIRegion having a .... strange implementation
    public unsafe struct IntrusiveHashTable_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_1_ {
        public _Vtbl* vfptr;
        public fixed Int32 m_aInplaceBuckets[23]; // HashList_UIRegionPTR_UIRegionPTR_1___HashListData*
        public HashList_UIRegionPTR_UIRegionPTR_1___HashListData** m_buckets;
        public HashList_UIRegionPTR_UIRegionPTR_1___HashListData** m_firstInterestingBucket;
        public UInt32 m_numBuckets;
        public UInt32 m_numElements;
    };
    public unsafe struct HashList_UIRegionPTR_UIRegionPTR_1___HashListData {
        public IntrusiveHashListData_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_ Int32rusiveHashListData;
        public UIRegion* m_data;
    };
    public unsafe struct IntrusiveHashData_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_ {
        public UIRegion* m_hashKey;
        public HashList_UIRegionPTR_UIRegionPTR_1___HashListData* m_hashNext;
    };
    public unsafe struct IntrusiveHashListData_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_ {
        public IntrusiveHashData_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_ Int32rusiveHashData;
        public DLListData dLListData;
    };
    public unsafe struct IntrusiveHashList_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_1_ {
        public IntrusiveHashTable_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_1_ m_hash;
        public DLListBase m_list;
    };
    public unsafe struct HashList_UIRegionPTR_UIRegionPTR_1_ {
        public IntrusiveHashList_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_1_ m_ihlIntrusive;
    };
    public unsafe struct IntrusiveHashListIterator_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_1_ {
        public HashList_UIRegionPTR_UIRegionPTR_1___HashListData* m_pData;
        public IntrusiveHashList_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_1_* m_pHashList;
    };
    public unsafe struct HashListIterator_HashList_UIRegionPTR_UIRegionPTR_1_ {
        public IntrusiveHashListIterator_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_1_ m_iter;
    };
    public unsafe struct IntrusiveHashIterator_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_1_ {
        public IntrusiveHashTable_UIRegionPTR_HashList_UIRegionPTR_UIRegionPTR_1___HashListDataPTR_1_* m_currHashTable;
        public HashList_UIRegionPTR_UIRegionPTR_1___HashListData** m_currBucket;
        public HashList_UIRegionPTR_UIRegionPTR_1___HashListData* m_currElement;
    };

    // completely untested.
    public unsafe struct PriorityHash<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        // Struct:
        public IntrusivePriorityHash<KEY, DATA> m_cIntrusivePriorityHash;
        public override string ToString() => $"m_cIntrusivePriorityHash:{m_cIntrusivePriorityHash}";
        public unsafe struct PriorityHashData {
            public IntrusivePriorityHashData<KEY, DATA> a0;
            public override string ToString() => $"a0(IntrusivePriorityHashData<ControlSpecification,CInputManager_WIN32.ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32.ButtonHistoryEntry>.PriorityHashData*>):{a0}";
        }

        // Functions:

        // PriorityHash.insert<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>:
        public void insert(KEY key, CInputManager_WIN32.ButtonHistoryEntry pri) => ((delegate* unmanaged[Thiscall]<ref PriorityHash<KEY, DATA>, KEY, CInputManager_WIN32.ButtonHistoryEntry, void>)0x00689520)(ref this, key, pri); // .text:00688490 ; void __thiscall PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::insert(PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1> *this, ControlSpecification key, CInputManager_WIN32::ButtonHistoryEntry pri) .text:00688490 ?insert@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@QAEXVControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@@Z

        // PriorityHash.lookup<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>:
        public Byte lookup(KEY i_key, CInputManager_WIN32.ButtonHistoryEntry* o_pri) => ((delegate* unmanaged[Thiscall]<ref PriorityHash<KEY, DATA>, KEY, CInputManager_WIN32.ButtonHistoryEntry*, Byte>)0x006881A0)(ref this, i_key, o_pri); // .text:00687150 ; bool __thiscall PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::lookup(PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1> *this, ControlSpecification i_key, CInputManager_WIN32::ButtonHistoryEntry *o_pri) .text:00687150 ?lookup@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@QBE_NVControlSpecification@@AAUButtonHistoryEntry@CInputManager_WIN32@@@Z
    }
    public unsafe struct IntrusivePriorityHash<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        // Struct:
        public IntrusiveHashTable<KEY, PTR<DATA>> m_hashTable;
        public SmartArray<PTR<PriorityHash<KEY, DATA>.PriorityHashData>> m_array;
        public override string ToString() => $"m_hashTable(IntrusiveHashTable<ControlSpecification,PriorityHash<ControlSpecification,CInputManager_WIN32.ButtonHistoryEntry,1>.PriorityHashData*,1>):{m_hashTable}, m_array(SmartArray<PriorityHash<ControlSpecification,CInputManager_WIN32.ButtonHistoryEntry,1>.PriorityHashData*,1>):{m_array}";

        // Functions:

        // IntrusivePriorityHash.bubble_down<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1>:
        public void bubble_down(UInt32 i, PriorityHash<KEY, DATA>.PriorityHashData data) => ((delegate* unmanaged[Thiscall]<ref IntrusivePriorityHash<KEY, DATA>, UInt32, PriorityHash<KEY, DATA>.PriorityHashData, void>)0x00687ED0)(ref this, i, data); // .text:00686E80 ; void __thiscall IntrusivePriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1>::bubble_down(IntrusivePriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1> *this, unsigned int i, PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *data) .text:00686E80 ?bubble_down@?$IntrusivePriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@PAVPriorityHashData@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@$00@@AAEXKPAVPriorityHashData@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@@Z

        // IntrusivePriorityHash.bubble_up<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1>:
        public void bubble_up(UInt32 i, PriorityHash<KEY, DATA>.PriorityHashData data) => ((delegate* unmanaged[Thiscall]<ref IntrusivePriorityHash<KEY, DATA>, UInt32, PriorityHash<KEY, DATA>.PriorityHashData, void>)0x00687E40)(ref this, i, data); // .text:00686DF0 ; void __thiscall IntrusivePriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1>::bubble_up(IntrusivePriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1> *this, unsigned int i, PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *data) .text:00686DF0 ?bubble_up@?$IntrusivePriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@PAVPriorityHashData@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@$00@@AAEXKPAVPriorityHashData@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@@Z

        // IntrusivePriorityHash.bubble_up_or_down<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1>:
        public void bubble_up_or_down(UInt32 i, PriorityHash<KEY, DATA>.PriorityHashData data) => ((delegate* unmanaged[Thiscall]<ref IntrusivePriorityHash<KEY, DATA>, UInt32, PriorityHash<KEY, DATA>.PriorityHashData, void>)0x00688000)(ref this, i, data); // .text:00686FB0 ; void __thiscall IntrusivePriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1>::bubble_up_or_down(IntrusivePriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1> *this, unsigned int i, PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *data) .text:00686FB0 ?bubble_up_or_down@?$IntrusivePriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@PAVPriorityHashData@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@$00@@AAEXKPAVPriorityHashData@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@@Z

        // IntrusivePriorityHash.insert<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1>:
        public Byte insert(PriorityHash<KEY, DATA>.PriorityHashData i_pData) => ((delegate* unmanaged[Thiscall]<ref IntrusivePriorityHash<KEY, DATA>, PriorityHash<KEY, DATA>.PriorityHashData, Byte>)0x006892E0)(ref this, i_pData); // .text:00688250 ; bool __thiscall IntrusivePriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1>::insert(IntrusivePriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1> *this, PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *i_pData) .text:00688250 ?insert@?$IntrusivePriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@PAVPriorityHashData@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@$00@@QAE_NPAVPriorityHashData@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@@Z

        // IntrusivePriorityHash.remove<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1>:
        public PriorityHash<KEY, DATA>.PriorityHashData* remove(ControlSpecification key) => ((delegate* unmanaged[Thiscall]<ref IntrusivePriorityHash<KEY, DATA>, ControlSpecification, PriorityHash<KEY, DATA>.PriorityHashData*>)0x00689350)(ref this, key); // .text:006882C0 ; PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *__thiscall IntrusivePriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1>::remove(IntrusivePriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,PriorityHash<ControlSpecification,CInputManager_WIN32::ButtonHistoryEntry,1>::PriorityHashData *,1> *this, ControlSpecification key) .text:006882C0 ?remove@?$IntrusivePriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@PAVPriorityHashData@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@$00@@QAEPAVPriorityHashData@?$PriorityHash@VControlSpecification@@UButtonHistoryEntry@CInputManager_WIN32@@$00@@VControlSpecification@@@Z
    }

    public unsafe struct IntrusivePriorityHashData<KEY, DATA> where KEY : unmanaged where DATA : unmanaged {
        // Struct:
        public IntrusiveHashData<KEY, DATA> a0;
        public CInputManager_WIN32.ButtonHistoryEntry m_PriorityHashPriority;
        public UInt32 m_PriorityHashArrayIndex;
        public override string ToString() => $"a0(IntrusiveHashData<ControlSpecification,PriorityHash<ControlSpecification,CInputManager_WIN32.ButtonHistoryEntry>.PriorityHashData*>):{a0}, m_PriorityHashPriority(CInputManager_WIN32.ButtonHistoryEntry):{m_PriorityHashPriority}, m_PriorityHashArrayIndex:{m_PriorityHashArrayIndex:X8}";
    }







}