using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XProject.Core.Exceptions
{
    public class ErrorModel
    {
        public ErrorModel()
        {
        }

        public ErrorModel(string code)
        {
            Code = code;
        }

        public ErrorModel(string code, string message) : this(code)
        {
            Message = message;
        }

        public ErrorModel(string code, string message, int statusCode) : this(code, message)
        {
            StatusCode = statusCode;
        }

        public ErrorModel(CoreException exception)
        {
            Code = exception.Code;
            Message = exception.Message;
            StatusCode = exception.StatusCode;
            AdditionalData = exception.AdditionalData;
        }

        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        ///     Unique error code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Message/Description of error
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Http response code
        /// </summary>
        public int StatusCode { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> AdditionalData { get; set; } = new Dictionary<string, object>();
    }
}