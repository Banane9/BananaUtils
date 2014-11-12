using System;
using System.Collections.Generic;
using System.Linq;

namespace BananaUtils
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);

        /// <summary>
        /// Converts a <see cref="long"/> Unix Timestamp into a <see cref="DateTime"/>.
        /// </summary>
        /// <param name="timestamp">The Unix Timestamp.</param>
        /// <returns>The <see cref="DateTime"/> Timestamp representing the same time as the Unix Timestamp.</returns>
        public static DateTime FromUnixTimestampToDateTime(this long timestamp)
        {
            return unixEpoch.AddSeconds(timestamp);
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> into a <see cref="long"/> Unix Timestamp.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/>.</param>
        /// <returns>The <see cref="long"/> Unix Timestamp representing the same time as the <see cref="DateTime"/>.</returns>
        public static long ToUnixTimeStamp(this DateTime dateTime)
        {
            return (long)(dateTime - unixEpoch).TotalSeconds;
        }
    }
}