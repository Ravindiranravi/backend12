using System.ComponentModel.DataAnnotations;


// DTO for handling login requests
namespace Institute.Models.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // student, trainee, admin
    }
}
