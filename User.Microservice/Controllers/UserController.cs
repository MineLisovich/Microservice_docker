using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using User.Microservice.Domain.Entities;
using User.Microservice.Domain.Repositories;

namespace User.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserEntity _userEntity;

        public UserController(IUserEntity userEntity)
        {
            _userEntity = userEntity;
        }
  

   

        [Authorize(Roles = "User")]
        [HttpPost]
        [Route("usermess")]
        public IEnumerable<UserEntity> GetAllMessageForUser()
        {
            IEnumerable<UserEntity> messages = _userEntity.GetAllMessageForUser();
            return messages;
        }
    }
}
