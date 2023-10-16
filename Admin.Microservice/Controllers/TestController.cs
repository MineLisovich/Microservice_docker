using Admin.Microservice.Domain.Entities;
using Admin.Microservice.Domain.Repositories;
using Admin.Microservice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Admin.Microservice.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class TestController : Controller
    {
        private readonly IAdminEntity _adminEntity;
        private string message;
        public TestController (IAdminEntity adminEntity, IConfiguration configuration)
        {
            _adminEntity = adminEntity;
            message = $"HOST: ({configuration["HOSTNAME"]})";
        }

        public IActionResult Index()
        {
            ViewBag.Message = message;  
            return View();
        }

        [HttpGet]
        public IActionResult GetAdminView()
        {
            var messagesforadm = _adminEntity.GetAllMessageForAdmin();

            TestModels models = new TestModels { 
             Entities = messagesforadm
            };
            return View(models);
        }

        [HttpGet]
        public IActionResult GetViewFromAdmin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Kill()
        {
            throw new Exception("EEEEE");
        }

    }
}
