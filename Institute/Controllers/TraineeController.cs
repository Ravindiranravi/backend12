//using Institute.Data;
//using Institute.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace Institute.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    [Authorize(Roles = "trainee")]
//    public class TraineeController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public TraineeController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // Get current trainee's data
//        [HttpGet("me")]
//        public async Task<IActionResult> GetCurrentTrainee()
//        {
//            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
//            var trainee = await _context.Trainees.FirstOrDefaultAsync(t => t.Id == userId);

//            if (trainee == null)
//                return NotFound();

//            return Ok(trainee);
//        }

//        // Update trainee's data
//        [HttpPost("update")]
//        public async Task<IActionResult> UpdateTrainee([FromBody] Trainee trainee)
//        {
//            _context.Trainees.Update(trainee);
//            await _context.SaveChangesAsync();
//            return Ok(trainee);
//        }
//    }
//}





//using Institute.Data;
//using Institute.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Claims;

//namespace Institute.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    [Authorize(Roles = "trainee")]
//    public class TraineeController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public TraineeController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // Get the current trainee's information
//        [HttpGet("me")]
//        public async Task<IActionResult> GetCurrentTrainee()
//        {
//            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
//            if (userIdClaim == null)
//            {
//                return Unauthorized("User ID not found in token.");
//            }

//            if (!int.TryParse(userIdClaim.Value, out var userId))
//            {
//                return BadRequest("Invalid user ID.");
//            }

//            var trainee = await _context.Users
//                .FirstOrDefaultAsync(u => u.Id == userId && u.Role == "trainee");

//            if (trainee == null)
//            {
//                return NotFound("Trainee not found.");
//            }

//            return Ok(trainee);
//        }
//    }
//}

using Institute.Data;
using Institute.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TraineeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TraineeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Trainee/Details/{id}
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> GetTraineeDetails(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound("Trainee not found.");
            }

            return Ok(trainee);
        }

        // PUT: api/Trainee/Update/{id}
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateTrainee(int id, [FromBody] Trainee updatedTrainee)
        {
            if (id != updatedTrainee.Id)
            {
                return BadRequest("Trainee ID mismatch.");
            }

            var existingTrainee = await _context.Trainees.FindAsync(id);
            if (existingTrainee == null)
            {
                return NotFound("Trainee not found.");
            }

            // Update allowed fields
            existingTrainee.Username = updatedTrainee.Username;
            existingTrainee.Email = updatedTrainee.Email;
            existingTrainee.Contact = updatedTrainee.Contact;
            existingTrainee.TrainingProgram = updatedTrainee.TrainingProgram;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraineeExists(id))
                {
                    return NotFound("Trainee not found.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TraineeExists(int id)
        {
            return _context.Trainees.Any(e => e.Id == id);
        }
    }
}


