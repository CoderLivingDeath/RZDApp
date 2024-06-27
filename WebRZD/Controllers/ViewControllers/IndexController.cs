using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebRZD.Controllers.ViewControllers
{
    [Route("home")]
    public class IndexController : Controller
    {
        private readonly ILogger<IndexController> logger;

        public IndexController(ILogger<IndexController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            await HttpContext.AuthenticateAsync();

            return View();
        }
    }
}
