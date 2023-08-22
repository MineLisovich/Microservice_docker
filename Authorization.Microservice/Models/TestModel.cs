using Authorization.Microservice.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Authorization.Microservice.Models
{
    public class TestModel
    {
        public IEnumerable<Users> usersList { get; set; }
        public string? response { get; set; }
    }
}
