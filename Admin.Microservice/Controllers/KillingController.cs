using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Admin.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KillingController : ControllerBase
    {
        [HttpGet]
        [Route("kill")]
        public async Task<IActionResult> Kill()
        {
            
            for (int i = 0; i<100; i++)
            {
                Thread thread = new Thread(result);
                thread.Start();
            }
            
            return Ok();
        }
        private void result()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread thread2 = new Thread(result2);
                thread2.Start();
            }
            Thread.Sleep(400);
        }
        private void result2()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread thread3 = new Thread(result3);
                thread3.Start();
            }
            Thread.Sleep(400);
        }
        private void result3()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread thread4 = new Thread(result4);
                thread4.Start();
            }
            Thread.Sleep(400);
        }
        private void result4()
        {
            for (int i = 0; i < 100; i++)
            {
                int ll = 1231;
                ll *= 4;
            }
            Thread.Sleep(400);
        }
    }
}
