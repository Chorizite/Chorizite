using System;
using System.Collections.Generic;

namespace RmlUiNet
{
    public class RmlInstanceCache
    {
        #region Members

        private readonly Dictionary<IntPtr, IRmlBase> _cache = new Dictionary<IntPtr, IRmlBase>();

        #endregion

        #region Methods

        public T Get<T>(IntPtr ptr)
            where T : class 
        {
            if (ptr == IntPtr.Zero || !_cache.ContainsKey(ptr)) {
                throw new Exception("Pointer not found in cache");
            }

            return _cache[ptr] as T;
        }

        public T GetOrCreate<T>(IntPtr ptr, CreateInstance createInstance)
            where T : class 
        {
            if (ptr == IntPtr.Zero) {
                return default;
            }

            if (!_cache.TryGetValue(ptr, out IRmlBase? value)) {
                value = createInstance(ptr);
                _cache.Add(ptr, value);
            }
            if (value is not T && value.GetType() == typeof(ElementGeneric))
            {
                _cache.Remove(ptr);
                value = createInstance(ptr);
                _cache.Add(ptr, value);
            }

            return value as T;
        }

        public void ManuallyRegisterCache(IntPtr ptr, IRmlBase instance)
        {
            if (_cache.ContainsKey(ptr)) {
                throw new InvalidOperationException("Instance already registered");
            }

            _cache.Add(ptr, instance);
        }

        public void Remove(IntPtr cameraPtr)
        {
            if (_cache.ContainsKey(cameraPtr)) {
                _cache.Remove(cameraPtr);
            }
        }

        internal void Clear()
        {
            _cache.Clear();
        }

        #endregion

        public delegate IRmlBase CreateInstance(IntPtr ptr);

        #region Singleton

        public static RmlInstanceCache Instance { get; }

        static RmlInstanceCache()
        {
            Instance = new RmlInstanceCache();
        }

        #endregion
    }
}
