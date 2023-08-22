using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Domain.Entities
{
    public class UserEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? MessageForUser { get; set; }
    }
}
