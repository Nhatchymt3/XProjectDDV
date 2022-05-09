using Invedia.Core.EnvUtils;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace XProject.WebApi.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ILogger _logger;

        public HomeController()
        {
            _logger = Log.Logger;
        }

        public IActionResult Index()
        {
            var info = $"Service is running normally on {EnvHelper.CurrentEnvironment}...";
            return Ok(info);
        }

        [HttpGet("/version")]
        public ActionResult<string> GetVersion()
        {
            var version = typeof(Program).Assembly.GetName().Version?.ToString();
            _logger.Information($"Version = {version}");
            return version;
        }
    }
}