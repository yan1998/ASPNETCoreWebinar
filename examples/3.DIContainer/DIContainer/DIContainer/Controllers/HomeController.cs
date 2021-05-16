using DIContainer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIContainer.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private readonly IGuidWrapperService _guidWrapperService;
        private readonly IGuidService _guidService;

        public HomeController(IGuidWrapperService guidWrapperService,
            IGuidService guidService)
        {
            _guidWrapperService = guidWrapperService;
            _guidService = guidService;
        }

        [HttpGet]
        public void Trigger()
        {
            _guidService.ShowGuid();
            _guidWrapperService.ShowGuid();
        }
    }
}
