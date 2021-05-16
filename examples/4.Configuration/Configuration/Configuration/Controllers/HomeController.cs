using Configuration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Configuration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserOptions _userOptions;

        public HomeController(IConfiguration config,
            IOptions<UserOptions> userOptions)
        {
            _config = config;
            _userOptions = userOptions.Value;
        }

        [HttpGet("Variables")]
        public string GetVariables()
        {
            var response = $"variable1 = {_config["variable1"]}\n" +
                $"variable2 = {_config.GetValue<string>("variable2")}\n" +
                $"varible3 = {_config["variable3"]}\n";
            return response;
        }

        [HttpGet("UserInfo")]
        public UserOptions GetUserInformation()
        {
            return _userOptions;
        }
    }
}
