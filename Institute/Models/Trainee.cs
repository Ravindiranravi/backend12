//using System.ComponentModel.DataAnnotations;

//namespace Institute.Models
//{

//        public class Trainee
//        {
//            public int Id { get; set; }

//            [Required]
//            public string Username { get; set; }

//            [Required]
//            [DataType(DataType.Password)]
//            public string Password { get; set; }

//            [Required]
//            public string Email { get; set; }

//            [Required]
//            public string Contact { get; set; }

//            [Required]
//            public string TrainingProgram { get; set; } // Specific to trainees
//        }
//    }

using System.ComponentModel.DataAnnotations;

namespace Institute.Models
{
    public class Trainee
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
        public string Gender { get; set; }
        [Required]
        public DateTime dateofBirth { get; set; }


        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }
        [Required]
        public string Qualification { get; set; }

        [Required]
        public string TrainingProgram { get; set; } // Specific to trainees
    }
}
