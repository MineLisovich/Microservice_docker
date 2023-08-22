using System.ComponentModel.DataAnnotations;

namespace Admin.Microservice.Domain.Entities
{
    public class AdminEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? MessageForAdmin { get; set; }
    }
}
