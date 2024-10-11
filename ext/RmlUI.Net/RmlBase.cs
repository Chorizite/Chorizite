using System;

namespace RmlUiNet
{
    public interface IRmlBase
    {
    }

    public abstract class RmlBase<T> : IRmlBase, IDisposable
        where T : class
    {
        #region Members

        public IntPtr NativePtr { get; protected set; }

        #endregion

        #region Methods

        protected RmlBase(IntPtr ptr, bool automaticallyRegisterInCache = false)
        {
            NativePtr = ptr;

            if (automaticallyRegisterInCache) {
                ManuallyRegisterCache(ptr, this);
            }
        }

        ~RmlBase()
        {
            Dispose(false);
        }

        protected static T? GetOrCreateCache(IntPtr ptr, RmlInstanceCache.CreateInstance createInstance)
        {
            if (ptr == IntPtr.Zero) {
                return null;
            }
            
            return RmlInstanceCache.Instance.GetOrCreate<T>(ptr, createInstance);
        }

        protected static void ManuallyRegisterCache(IntPtr ptr, IRmlBase instance)
        {
            RmlInstanceCache.Instance.ManuallyRegisterCache(ptr, instance);
        }

        #endregion

        #region IDisposable

        #region Properties

        public bool IsDisposed { get; private set; }

        #endregion

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) {
                return;
            }

            RmlInstanceCache.Instance.Remove(NativePtr);

            IsDisposed = true;
        }

        protected void ThrowExceptionIfDisposed()
        {
            if (IsDisposed) {
                throw new ObjectDisposedException(typeof(T).FullName);
            }
        }

        #endregion
    }
}
