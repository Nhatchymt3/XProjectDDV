using System;

namespace XProject.Core.Utils.DateTimeUtil
{
    public static class DateTimeHelper
    {
        public static bool Check60sec(DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.AddMinutes(1) <= DateTimeOffset.UtcNow;
        }

        public static bool Check7Day(DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.AddDays(7) <= DateTimeOffset.UtcNow;
        }
    }
}