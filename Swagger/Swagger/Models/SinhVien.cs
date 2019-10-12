using System.ComponentModel.DataAnnotations;

namespace Swagger.Models
{
    public class SinhVien
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Name cannot excced 30 characters")]
        public string Name { get; set; }
//        [Required]
//        [EmailAddress]
//        public string Email { get; set; }
    }
}