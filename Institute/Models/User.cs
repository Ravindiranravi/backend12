//using System.ComponentModel.DataAnnotations;

//namespace Institute.Models
//{
//    public class User
//    {
//        public int Id { get; set; }

//        [Required]
//        public string Username { get; set; }

//        [Required]
//        [DataType(DataType.Password)]
//        public string Password { get; set; }

//        [Required]
//        public string Role { get; set; } // e.g., student, trainee, admin
//    }
//}
using System.ComponentModel.DataAnnotations;

namespace Institute.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // e.g., student, trainee, admin
    }
}

