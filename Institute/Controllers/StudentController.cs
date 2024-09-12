using Institute.Data;
using Institute.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Institute.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Student/Details/{id}
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> GetStudentDetails(int id)
        {
            //var studentId = GetStudentIdFromClaims();
            //if (studentId != id)
            //{
            //    return Forbid(); // Forbidden if trying to access someone else's data
            //}

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST: api/Student/Register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User()
            {
                Username = student.Username,
                Password = student.Password,
                Role = "student"
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            var existingStudent = await _context.Students
                .FirstOrDefaultAsync(s => s.Email == student.Email);

            if (existingStudent != null)
            {
                return Conflict("Student with this email already exists.");
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentDetails), new { id = student.Id }, student);
        }

        // PUT: api/Student/Update/{id}
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Student ID mismatch.");
            }

            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound("Student not found.");
            }

            // Update allowed fields
            existingStudent.Username = student.Username;
            existingStudent.Email = student.Email;
            existingStudent.Contact = student.Contact;
            existingStudent.Gender = student.Gender;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.Qualification = student.Qualification;
            existingStudent.Address = student.Address;
            existingStudent.InterestToStudy = student.InterestToStudy;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound("Student not found.");
                }
                throw;
            }

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        private int GetStudentIdFromClaims()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
            {
                return userId;
            }
            return 0; // Default or error case
        }
    }
}
