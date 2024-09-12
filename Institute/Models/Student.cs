using System;
using System.ComponentModel.DataAnnotations;

namespace Institute.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Gender { get; set; } // e.g., Male, Female, Other

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public string InterestToStudy { get; set; }
    }
}

//using Institute.Models;
//using System.ComponentModel.DataAnnotations;

//public class Student
//{
//    public int Id { get; set; }
//    [Required]
//    public string Username { get; set; }
//    [Required]
//    [DataType(DataType.Password)]
//    public string Password { get; set; }
//    [Required]
//    public string Email { get; set; }
//    [Required]
//    public string Contact { get; set; }
//    [Required]
//    public string Gender { get; set; }
//    [Required]
//    public DateTime DateOfBirth { get; set; }
//    [Required]
//    public string Address { get; set; }
//    [Required]
//    public string Qualification { get; set; }
//    [Required]
//    public string InterestToStudy { get; set; }
//    [Required]
//    public int UserId { get; set; } // Foreign key
//    public virtual User User { get; set; } // Navigation property
//}
