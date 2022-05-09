using System;

namespace XProject.Core.Utils.DateTimeUtil
{
    public static class DatetimeExtension
    {
        public static bool Check60sec(this DateTimeOffset dateTimeOffset)
        {
            return DateTimeHelper.Check60sec(dateTimeOffset);
        }

        public static bool Check7Day(this DateTimeOffset dateTimeOffset)
        {
            return DateTimeHelper.Check7Day(dateTimeOffset);
        }
    }
}