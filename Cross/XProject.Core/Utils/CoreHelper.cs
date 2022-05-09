using Invedia.Core.DateTimeUtils;
using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Security.Cryptography;
using XProject.Core.Constants;

namespace XProject.Core.Utils
{
    public static class CoreHelper
    {
        public static HttpContext CurrentHttpContext =>
            Invedia.Web.Middlewares.HttpContextMiddleware.HttpContext.Current;

        public static TimeZoneInfo SystemTimeZoneInfo => DateTimeHelper.GetTimeZoneInfo(Formattings.TimeZone);

        public static DateTimeOffset SystemTimeNow => DateTimeOffset.UtcNow;

        public static DateTime UtcToSystemTime(this DateTimeOffset dateTimeOffsetUtc)
        {
            return dateTimeOffsetUtc.UtcDateTime.UtcToSystemTime();
        }

        public static DateTime UtcToSystemTime(this DateTime dateTimeUtc)
        {
            var dateTimeWithTimeZone = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, SystemTimeZoneInfo);

            return dateTimeWithTimeZone;
        }

        public static int GetWeekOfMonth(this DateTime time)
        {
            DateTime first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        public static int GetWeekOfYear(this DateTime time)
        {
            GregorianCalendar _gc = new GregorianCalendar();

            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        public static string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}