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
    public class TestUserForAuthMicrosrvController : ControllerBase
    {
        private readonly IUserEntity _userEntity;

        public TestUserForAuthMicrosrvController(IUserEntity userEntity)
        {
            _userEntity = userEntity;
        }
        [HttpGet]
        [Route("usermessGet")]
        public IEnumerable<UserEntity> GetAllMessageForUserGet()
        {
            IEnumerable<UserEntity> messages = _userEntity.GetAllMessageForUser();
            return messages;
        }

        [HttpGet]
        [Route("noSqlresponse")]
        public IActionResult GetTestData()
        {
            var text = "User mocroservice";

            return Ok(text);
        }
    }

}
