
---@class TypeWrapper
---@diagnostic disable-next-line: undefined-doc-name
---@field UnderlyingSystemType CS.System.Type The underlying system type

CS = CS or {}
CS.System = CS.System or {}
CS.System.Collections = CS.System.Collections or {}
CS.System.Collections.Generic = CS.System.Collections.Generic or {}

---@class CS.System.ArrayTypeWrapper : TypeWrapper
---@class CS.System.Array: { [number]: any }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.Array = {} --[[@as CS.System.ArrayTypeWrapper]]

---@class CS.System.SpanTypeWrapper : TypeWrapper
---@class CS.System.Span<T>: { [number]: T }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.Span = {} --[[@as CS.System.SpanTypeWrapper]]

---@class CS.System.ReadOnlySpanTypeWrapper : TypeWrapper
---@class CS.System.ReadOnlySpan<T>: { [number]: T }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.ReadOnly = {} --[[@as CS.System.ReadOnlySpanTypeWrapper]]

-- The CS.System.Collections.Generic.Dictionary type.
---@class CS.System.Collections.Generic.DictionaryTypeWrapper : TypeWrapper
---@class CS.System.Collections.Generic.Dictionary<K, V>: { [K]: V }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.Collections.Generic.Dictionary = {} --[[@as CS.System.Collections.Generic.DictionaryTypeWrapper]]

-- The CS.System.Collections.Generic.Dictionary type.
---@class CS.System.Collections.Generic.IReadOnlyDictionaryTypeWrapper : TypeWrapper
---@class CS.System.Collections.Generic.IReadOnlyDictionary<K, V>: { [K]: V }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.Collections.Generic.IReadOnlyDictionary = {} --[[@as CS.System.Collections.Generic.IReadOnlyDictionaryTypeWrapper]]

-- The CS.System.Collections.Generic.IList type.
---@class CS.System.Collections.Generic.IListTypeWrapper : TypeWrapper
---@class CS.System.Collections.Generic.IList<T>: { [number]: T }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.Collections.Generic.IList = {} --[[@as CS.System.Collections.Generic.IListTypeWrapper]]

-- The CS.System.Collections.Generic.List type.
---@class CS.System.Collections.Generic.ListTypeWrapper : TypeWrapper
---@class CS.System.Collections.Generic.List<T>: { [number]: T }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.Collections.Generic.List = {} --[[@as CS.System.Collections.Generic.ListTypeWrapper]]

-- The CS.System.Collections.Generic.IReadOnlyList type.
---@class CS.System.Collections.Generic.IReadOnlyListTypeWrapper : TypeWrapper
---@class CS.System.Collections.Generic.IReadOnlyList<T>: { [number]: T }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.Collections.Generic.IReadOnlyList = {} --[[@as CS.System.Collections.Generic.IReadOnlyListTypeWrapper]]

-- The CS.System.Collections.Generic.IEnumerable type.
---@class CS.System.Collections.Generic.IEnumerableTypeWrapper : TypeWrapper
---@class CS.System.Collections.Generic.IEnumerable<T>: { [number]: T }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.Collections.Generic.IEnumerable = {} --[[@as CS.System.Collections.Generic.IEnumerableTypeWrapper]]

-- The CS.System.Collections.Generic.Queue type.
---@class CS.System.Collections.Generic.QueueTypeWrapper : TypeWrapper
---@class CS.System.Collections.Generic.Queue<T>: { [number]: T }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.Collections.Generic.Queue = {} --[[@as CS.System.Collections.Generic.QueueTypeWrapper]]

-- The CS.System.Collections.Generic.ISet type.
---@class CS.System.Collections.Generic.ISetTypeWrapper : TypeWrapper
---@class CS.System.Collections.Generic.ISet<T>: { [number]: T }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.System.Collections.Generic.ISet = {} --[[@as CS.System.Collections.Generic.ISetTypeWrapper]]


CS.DatReaderWriter = CS.DatReaderWriter or {}
CS.DatReaderWriter.Lib = CS.DatReaderWriter.Lib or {}

-- The CS.DatReaderWriter.Lib.DBObjCollection type.
---@class CS.DatReaderWriter.Lib.DBObjCollectionTypeWrapper : TypeWrapper
---@class CS.DatReaderWriter.Lib.DBObjCollection<T>: { [number]: T }
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.DatReaderWriter.Lib.DBObjCollection = {} --[[@as CS.DatReaderWriter.Lib.DBObjCollectionTypeWrapper]]


CS.XLua = CS.XLua or {}

---@class CS.XLua.LuaEnvTypeWrapper  : TypeWrapper
---@class CS.XLua.LuaEnv
---@diagnostic disable-next-line: assign-type-mismatch, missing-fields
CS.XLua.LuaEnv = {} --[[@as CS.XLua.LuaEnvTypeWrapper]]

---@alias Action fun()
---@alias Action1<P1> fun(P1: P1)
---@alias Action2<P1,P2> fun(P1: P1, P2: P2)
---@alias Action3<P1,P2,P3> fun(P1: P1, P2: P2, P3: P3)
---@alias Action4<P1,P2,P3,P4> fun(P1: P1, P2: P2, P3: P3, P4: P4)
---@alias Action5<P1,P2,P3,P4,P5> fun(P1: P1, P2: P2, P3: P3, P4: P4, P5: P5)

---@alias Func<K> fun(): K
---@alias Func2<P1,K> fun(P1: P1): K
---@alias Func3<P1,P2,K> fun(P1: P1, P2: P2): K
---@alias Func4<P1,P2,P3,K> fun(P1: P1, P2: P2, P3: P3): K
---@alias Func5<P1,P2,P3,P4,K> fun(P1: P1, P2: P2, P3: P3, P4: P4): K