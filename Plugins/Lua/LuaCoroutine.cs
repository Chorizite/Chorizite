using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XLua;

namespace Lua {
    internal class LuaCoroutine : IDisposable {
        private ILogger _log;

        private readonly TaskCompletionSource<object[]?> _taskCompletionSource;
        private List<Task> _tasks = new List<Task>();

        public LuaThread Thread { get; set; }
        public LuaContext Context { get; set; }
        public Task<object[]?> Task => _taskCompletionSource.Task;
        public string Name { get; }

        public LuaCoroutine(LuaThread thread, LuaContext context, ILogger log) {
            Thread = thread;
            Context = context;
            _log = log;
            _taskCompletionSource = new TaskCompletionSource<object[]?>();
        }

        /// <summary>
        /// Updates the coroutine
        /// </summary>
        /// <returns>Return true if the coroutine is still running, false otherwise</returns>
        public bool Update(params object[] args) {
            try {
                if (_tasks.Any(task => !(task.IsCompleted))) {
                    return true;
                }

                if (Thread.Status != LuaCoroutineStatus.Suspended) {
                    _taskCompletionSource.SetException(new Exception("Thread is not suspended"));
                    return false;
                }

                var (threadSuccess, res) = Thread.Resume(args);
                if (!threadSuccess) {
                    if (res.Length > 0 && res.First() is string error) {
                        var ex = new LuaException(error);
                        _taskCompletionSource.SetException(ex);
                        throw ex;
                    }
                    _taskCompletionSource.SetException(new LuaException("Thread failed to resume"));
                    return false;
                }

                if (Thread.Status == LuaCoroutineStatus.Dead) {
                    _taskCompletionSource.SetResult(res);
                    return false;
                }
                else if (res is not null) {
                    _tasks.AddRange(res.Where(t => t is Task).Cast<Task>());
                }

                return true;
            }
            catch (LuaException ex) {
                _log.LogError(Context.FormatDocumentException(ex));
                return false;
            }
            catch (Exception ex) {
                _log.LogError(ex, "Error resuming coroutine");
                return false;
            }
        }

        public void Dispose() {
            Thread = null!;
            Context = null!;
            _tasks = null!;
        }
    }
}
