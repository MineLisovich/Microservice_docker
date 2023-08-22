using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authorization.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCookieController : ControllerBase
    {
        [HttpGet]
        public IActionResult DieCookie() {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Application.Id",
              new CookieOptions
              {
                  Expires = DateTime.Now.AddDays(-10)
              });
            return Ok();
        }
    }
}
