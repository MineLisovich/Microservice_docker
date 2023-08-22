using Authorization.Microservice.Domain.Entities;
using Authorization.Microservice.Domain.Repositories;
using Authorization.Microservice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Hosting;

namespace Authorization.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestToUserMicroservController : ControllerBase
    {
        [HttpPost]
        [Route("getusermess")]
        public async Task<IActionResult> GetUsermess () // https://localhost:44373/api/TestUserForAuthMicrosrv/usermessPost
        {
           

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"http://user");
                var response = await httpClient.GetAsync("/api/TestUserForAuthMicrosrv/usermessGet");

                if (response.IsSuccessStatusCode) {
                   
                   var result =  await response.Content.ReadAsStringAsync();

                    var final_result = "Это сообщение было получено с микросервиса User: " + result;
                    return Ok(final_result);
                }
                else
                {
                    return null;
                }
                
            }
        }
        [HttpGet]
        [Route("GetdataFromAdminMicroNoSQL")]
        public async Task<IActionResult> Getdata()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"http://admin");
                var response = httpClient.GetAsync("/api/TestAdminForAuthM/getresponse").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var final_result = "Это сообщение было получено с микросервиса Admin: " + result;
                    return Ok(final_result);
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
