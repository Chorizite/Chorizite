using MagicHat.Core.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Extensions {
    public static class EventHandlerExtensions {
        public static void InvokeSafely<T>(this EventHandler<T> eventHandler, object sender, T eventArgs) where T : EventArgs {
            foreach (var del in eventHandler.GetInvocationList()) {
                try {
                    del.DynamicInvoke(sender, eventArgs);
                }
                catch (Exception ex) {
                    MagicHatStatics.Log?.LogError(ex, "Error while running event handler");
                }
            }
        }
    }
}
