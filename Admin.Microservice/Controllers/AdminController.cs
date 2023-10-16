using Admin.Microservice.Domain.Entities;
using Admin.Microservice.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing.Text;

namespace Admin.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminEntity _adminEntity;
        private string message;
        public AdminController (IAdminEntity adminEntity, IConfiguration configuration)
        {
            _adminEntity = adminEntity;
            message = $"HOST: ({configuration["HOSTNAME"]})";
        }

        [Authorize(Roles = "Admin")] 
        [HttpGet]
        [Route("adminmess")]
        public IEnumerable<AdminEntity> GetAllMessageForAdmin()
        {
            IEnumerable<AdminEntity> messages = _adminEntity.GetAllMessageForAdmin();
            return messages;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IResult GetMessageForAdminById(int id)
        {
            AdminEntity message = _adminEntity.FindMessageForAdminByID(id);
            if (message == null)
            {
                return Results.NotFound(new { message = "Message for Admin not found" });
            }
            return Results.Json(message);
        }
        [HttpGet]
        [Route("GetHostName")]
        public IActionResult GetHostName()
        {
            return Ok(message);
        }
    }
}
