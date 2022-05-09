using System.ComponentModel;

namespace XProject.Core.Constants
{
    public class ApplicationConstants
    {
        public const string SYSTEM = "system";
        public const string MASTER = "master";

        public const string TOKEN2FA = "2fa";
    }

    public enum NotificationCategory
    {
        [Description("NONE")]
        None = 0,

        [Description("GENERAL")]
        General = 1,

        [Description("UPLOAD")]
        Upload = 2,

        [Description("DOWNLOAD")]
        Download = 3,

        [Description("DEPOSIT")]
        Deposit = 3
    }

    public enum ReadStatus
    {
        [Description("UNREAD")] UnRead = 0,
        [Description("READ")] Read = 1
    }

    public class ClaimConstant
    {
        public const string CLAIM_USERNAME = "Username";
        public const string USER_ANONYMOUS = "Anonymous";
    }

    public class AuthenticationScheme
    {
        public const string BEARER = "Bearer";
        public const string BASIC = "Basic";
    }
}