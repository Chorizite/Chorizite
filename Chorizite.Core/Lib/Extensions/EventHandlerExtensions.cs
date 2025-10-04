using Chorizite.Core.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Lib.Extensions {
    /// <summary>
    /// Extension methods for <see cref="EventHandler{T}"/>
    /// </summary>
    public static class EventHandlerExtensions {
        /// <summary>
        /// Invoke a <see cref="EventHandler{T}"/> safely (Catches and logs exceptions without preventing other handlers from running).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler"></param>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public static void InvokeSafely<T>(this EventHandler<T> eventHandler, object sender, T eventArgs) where T : EventArgs {
            foreach (var del in eventHandler.GetInvocationList()) {
                try {
                    del.DynamicInvoke(sender, eventArgs);
                }
                catch (Exception ex) {
                    ChoriziteStatics.Log?.LogError(ex, "Error while running event handler");
                }
            }
        }
    }
}
