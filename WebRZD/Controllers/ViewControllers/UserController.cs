using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebRZD.Controllers.ViewControllers
{
    [Route("User")]
    public class UserController : Controller
    {
        [Authorize]
        [HttpGet("User")]
        public IActionResult User()
        {
            string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            return Ok();
        }
    }
}
