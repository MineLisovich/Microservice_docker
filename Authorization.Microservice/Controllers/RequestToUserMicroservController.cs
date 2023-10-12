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
                httpClient.BaseAddress = new Uri($"http://admin:6199");
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
        [HttpGet]
        [Route("TryKillAdminMicroservice")]
        public async Task<IActionResult> TryKillAdminMicroservice()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"http://admin:6199");

                for(; ; )
                {
                    var response = httpClient.GetAsync("/api/Killing/kill").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        var final_result = "Это сообщение было получено с микросервиса Admin: " + result;
                      //  return Ok(final_result);
                    }
                    else
                    {
                      //  return null;
                    }
                }
               
            }
        }

        [HttpGet]
        [Route("GetdataFromUserMicroNoSQL")]
        public async Task<IActionResult> GetdataUserMic()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri($"http://user:7111");
                var response = httpClient.GetAsync("/api/TestUserForAuthMicrosrv/noSqlresponse").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

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
        [Route("TryKillUserMicro10")]
        public async Task<IActionResult> TryKillUserMic()
        {
          
                using (var httpClient = new HttpClient())
                {
                var final_result="";
               
                for (int i = 0; i < 10; i++)
                         {
                    httpClient.BaseAddress = new Uri($"http://user:7111");
                    var response = httpClient.GetAsync("/api/TestUserForAuthMicrosrv/noSqlresponse").Result;
                           if (response.IsSuccessStatusCode)
                           {
                             var result = await response.Content.ReadAsStringAsync();

                               final_result = i + "Это сообщение было получено с микросервиса User: " + result;
                            
                           } 
                         }
                        return Ok(final_result);

                }
           
        }


    }
}
