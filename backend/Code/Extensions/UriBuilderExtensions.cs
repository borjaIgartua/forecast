using System;
using System.Web;

namespace backend.Code.Extensions {
    public static class UriBuilderExtensions {
        public static UriBuilder AddParam(this UriBuilder uri, string key, string value) {
            var query = HttpUtility.ParseQueryString(uri.Query);
            query[key] = value;
            uri.Query = query.ToString();
            return uri;
        }
    }
}
