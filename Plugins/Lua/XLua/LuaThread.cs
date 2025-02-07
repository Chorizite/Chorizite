using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chorizite.Core.Input;

#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif
using XLua;

namespace XLua {
    public enum LuaCoroutineStatus {
        Invalid,
        Suspended,
        Running,
        Dead,
    }

    public class LuaThread : LuaBase {
        public LuaThread(int reference, LuaEnv luaenv) : base(reference, luaenv) {
        }

        public LuaCoroutineStatus Status {
            get {
                var L = luaEnv.L;
                int oldTop = LuaAPI.lua_gettop(L);
                try {
                    string result;

                    // Get coroutine table
                    LuaAPI.xlua_getglobal(L, "coroutine");
                    if (!LuaAPI.lua_istable(L, -1)) {
                        throw new LuaException("`coroutine' is not a valid table");
                    }

                    // Get status function
                    LuaAPI.lua_pushstring(L, "status");
                    LuaAPI.xlua_pgettable(L, -2);
                    if (!LuaAPI.lua_isfunction(L, -1)) {
                        throw new LuaException("`coroutine.status' is not a valid function");
                    }

                    LuaAPI.lua_getref(L, luaReference);
                    if (!LuaAPI.lua_isthread(L, -1)) {
                        throw new LuaException($"Failed to get valid thread from registry reference {_L}");
                    }

                    // Remove coroutine table while keeping status function and thread
                    LuaAPI.lua_remove(L, -3);

                    // Do the call (1 argument - the thread, 1 result expected - status)
                    if (LuaAPI.lua_pcall(L, 1, 1, 0) != 0) {
                        var s = LuaAPI.lua_tostring(L, -1);
                        throw new LuaException($"error calling function `coroutine.status': {s}");
                    }

                    if (!LuaAPI.lua_isstring(L, -1)) {
                        throw new LuaException($"function `coroutine.status' must return a string");
                    }

                    result = LuaAPI.lua_tostring(L, -1);

                    switch (result) {
                        case "suspended":
                            return LuaCoroutineStatus.Suspended;
                        case "running":
                            return LuaCoroutineStatus.Running;
                        case "dead":
                            return LuaCoroutineStatus.Dead;
                        default:
                            return LuaCoroutineStatus.Invalid;
                    }
                }
                finally {
                    LuaAPI.lua_settop(L, oldTop); // clean up stack
                }
            }
        }

        public (bool success, object[] results) Resume(params object[] args) {
            var L = luaEnv.L;
            int oldTop = LuaAPI.lua_gettop(L);
            try {
                // Get coroutine table
                LuaAPI.xlua_getglobal(L, "coroutine");
                if (!LuaAPI.lua_istable(L, -1)) {
                    throw new LuaException("`coroutine' is not a valid table");
                }

                // Get resume function
                LuaAPI.lua_pushstring(L, "resume");
                LuaAPI.xlua_pgettable(L, -2);
                if (!LuaAPI.lua_isfunction(L, -1)) {
                    throw new LuaException("`coroutine.resume' is not a valid function");
                }

                LuaAPI.lua_getref(L, luaReference);
                if (!LuaAPI.lua_isthread(L, -1)) {
                    throw new LuaException($"Failed to get valid thread from registry reference {_L}");
                }

                // Remove coroutine table while keeping resume function and thread
                LuaAPI.lua_remove(L, -3);

                // push args
                for (int i = 0; i < args.Length; i++) {
                    luaEnv.translator.PushAny(L, args[i]);
                }

                int preCallTop = LuaAPI.lua_gettop(L);
                if (LuaAPI.lua_pcall(L, 1 + args.Length, -1, 0) != 0) {
                    var s = LuaAPI.lua_tostring(L, -1);
                    throw new LuaException($"error calling function `coroutine.resume': {s}");
                }

                int numResults = LuaAPI.lua_gettop(L) - (preCallTop - 2);

                // First result is always the success boolean
                bool success = LuaAPI.lua_toboolean(L, -(numResults));

                // Convert remaining results
                if (numResults < 1) {
                    return (success, []);
                }
                object[] results = new object[numResults - 1];
                for (int i = 0; i < numResults - 1; i++) {
                    results[i] = luaEnv.translator.GetObject(L, -(numResults - 1 - i));
                }

                return (success, results);
            }
            finally {
                LuaAPI.lua_settop(L, oldTop);
            }
        }
    }
}
