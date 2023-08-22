using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAdminForAuthMController : ControllerBase
    {
        [HttpGet]
        [Route("getresponse")]
        public IActionResult GetTestData()
        {
            var text = "УРААААА";

            return Ok(text);
        }
    }
}
