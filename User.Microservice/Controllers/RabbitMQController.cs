using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Microservice.RabbitMQ;

namespace User.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private readonly IRabbitMqService _mqService;

        public RabbitMQController(IRabbitMqService mqService)
        {
            _mqService = mqService;
        }

        [Route("[action]/{message}")]
        [HttpGet]
        public IActionResult SendMessage(string message)
        {
            _mqService.SendProductMessage(message);

            return Ok("Сообщение отправлено");
        }
    }
}
