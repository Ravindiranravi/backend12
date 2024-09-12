using System.ComponentModel.DataAnnotations;

namespace Institute.Models
{
    public class Course
    {
        [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string CourseName { get; set; }

            [Required]
            public int Duration { get; set; } // Duration in days

            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "Fees must be a positive value")]
            public int Fees { get; set; } // Fees as integer
        }
    }
