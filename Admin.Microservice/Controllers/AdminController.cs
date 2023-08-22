using Admin.Microservice.Domain.Entities;
using Admin.Microservice.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Admin.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminEntity _adminEntity;

        public AdminController (IAdminEntity adminEntity)
        {
            _adminEntity = adminEntity;
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
    }
}
