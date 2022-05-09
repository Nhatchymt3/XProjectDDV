using Flurl;
using Invedia.Core.CheckUtils;
using Invedia.Data.IO;
using Invedia.Data.IO.DirectoryUtils;
using Microsoft.Extensions.Configuration;
using System.IO;
using XProject.Core.Configs;
using XProject.Core.Constants;

namespace XProject.Core.Utils
{
    public static class SystemHelper
    {
        public static SystemSettingModel Setting => SystemSettingModel.Instance;
        public static IConfiguration Configs => SystemSettingModel.Configs;
        public static string AppDb => SystemSettingModel.Configs.GetConnectionString("DefaultConnection");

        public static string AzureServiceBus => SystemSettingModel.Configs.GetConnectionString("AzureServiceBus");

        public static string GetAbsoluteEndpoint(string endpoint)
        {
            endpoint = endpoint.Trim(' ', '~');

            return Setting.AssetsDomain.AppendPathSegment(endpoint);
        }

        public static string GetSaveFileLocation(string clientId, string userId, string fileName)
        {
            CheckHelper.CheckNullOrWhiteSpace(clientId, nameof(clientId));

            CheckHelper.CheckNullOrWhiteSpace(userId, nameof(userId));

            CheckHelper.CheckNullOrWhiteSpace(fileName, nameof(fileName));

            var date = CoreHelper.SystemTimeNow.ToString("yyyy-MM-dd");

            var folderLocation = Path.Combine(Locations.SavePath, date, clientId, userId);

            DirectoryHelper.CreateIfNotExist(PathHelper.GetFullPath(folderLocation));

            var fileLocation = Path.Combine(folderLocation, fileName);

            return fileLocation;
        }
    }
}