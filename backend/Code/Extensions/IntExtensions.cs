using System;
namespace backend.Code.Extensions {
    public static class IntExtensions {
        public static DateTime UnixTimeStampToDateTime(this int unixTimeStamp) {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
            return dtDateTime;
        }
    }
}
