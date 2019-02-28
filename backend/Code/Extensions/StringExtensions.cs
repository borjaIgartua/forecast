using System;
using System.Web;

namespace backend.Code.Extensions {
    public static class StringExtensions {
        public static string AddParam(this string query, string key, string value) {
            if (!String.IsNullOrEmpty(key) && !String.IsNullOrEmpty(value)) {
                if (!query.Contains("?")) {
                    query += "?";

                } else {
                    query += "&";
                }

                query += key + "=" + value;
            }

            return query;
        }
    }
}
