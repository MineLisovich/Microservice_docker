using System.ComponentModel.DataAnnotations;

namespace Authorization.Microservice.Domain.Entities
{
    public class Users
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Login { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
