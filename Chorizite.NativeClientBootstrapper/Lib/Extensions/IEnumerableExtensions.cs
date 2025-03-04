using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Backends.ACBackend.Extensions {
    internal static class IEnumerableExtensions {
        public static IEnumerable<T> TakeAllButLast<T>(this IEnumerable<T> source) {
            var it = source.GetEnumerator();
            bool hasRemainingItems = false;
            bool isFirst = true;
            T? item = default;

            do {
                hasRemainingItems = it.MoveNext();
                if (hasRemainingItems) {
                    if (!isFirst) yield return item!;
                    item = it.Current;
                    isFirst = false;
                }
            } while (hasRemainingItems);
        }
    }
}
