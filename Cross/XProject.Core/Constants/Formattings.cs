using Newtonsoft.Json;
using System.Globalization;
using Formatting = Invedia.Core.Constants.Formatting;

namespace XProject.Core.Constants
{
    public static class Formattings
    {
        /// <summary>
        ///     Config use datetime with TimeZone. Default is "UTC", See more:
        ///     https://msdn.microsoft.com/en-us/library/gg154758.aspx
        /// </summary>
        public const string TimeZone = "Asia/Ho_Chi_Minh"; // "UTC"

        public const string DateFormat = "dd/MM/yyyy";

        public const string TimeFormat = "h:mm:ss tt";

        public const string DateTimeFormat = "dd/MM/yyyy hh:mm:ss tt";

        public const string JsDateFormat = "dd/mm/yyyy";

        public const string JsDateTimeFormat = "dd/mm/yyyy HH:ii:ss P";

        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.JsonSerializerSettings.Formatting,
            NullValueHandling = Formatting.JsonSerializerSettings.NullValueHandling,
            MissingMemberHandling = Formatting.JsonSerializerSettings.MissingMemberHandling,
            DateFormatHandling = Formatting.JsonSerializerSettings.DateFormatHandling,
            ReferenceLoopHandling = Formatting.JsonSerializerSettings.ReferenceLoopHandling,
            ContractResolver = Formatting.JsonSerializerSettings.ContractResolver,
            DateFormatString = Formatting.JsonSerializerSettings.DateFormatString,
            Culture = CultureInfo.CurrentCulture
        };
    }
}