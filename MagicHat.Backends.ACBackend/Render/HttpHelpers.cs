
namespace MagicHat.Backends.ACBackend.Render {
    internal class HttpHelpers {
        internal static Dictionary<string, string> ParseQueryString(string query) {
            var q = query.Substring(0);
            if (query.StartsWith("?")) {
                q = query.Substring(1);
            }

            var pairs = q.Split('&');
            var dict = new Dictionary<string, string>();

            foreach ( var pair in pairs ) {
                var parts = pair.Split('=');
                if (parts.Length == 2) {
                    dict[parts[0]] = parts[1];
                }
            }

            return dict;
        }
    }
}