using Institute.Data;
using Institute.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Student CRUD

        [HttpGet("Students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }


        [HttpPost("Hii")]

        public async Task<IActionResult> Test(Student student)
        {
            return Ok();

        }

        [HttpGet("Students/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("Students")]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {


            //Console.WriteLine(stuent.username+""+)
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var user = new User()
            {
                Username = student.Username,
                Password = student.Password,
                Role = "student"
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("Students/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("Students/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        #endregion

        #region Trainee CRUD

        [HttpGet("Trainees")]
        public async Task<IActionResult> GetTrainees()
        {
            var trainees = await _context.Trainees.ToListAsync();
            return Ok(trainees);
        }

        [HttpGet("Trainees/{id}")]
        public async Task<IActionResult> GetTrainee(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }
            return Ok(trainee);
        }

        [HttpPost("Trainees")]
        public async Task<IActionResult> CreateTrainee([FromBody] Trainee trainee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                Username = trainee.Username,
                Password = trainee.Password,
                Role = "trainee"
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            _context.Trainees.Add(trainee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrainee), new { id = trainee.Id }, trainee);
        }

        [HttpPut("Trainees/{id}")]
        public async Task<IActionResult> UpdateTrainee(int id, [FromBody] Trainee trainee)
        {
            if (id != trainee.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraineeExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("Trainees/{id}")]
        public async Task<IActionResult> DeleteTrainee(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }

            _context.Trainees.Remove(trainee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraineeExists(int id)
        {
            return _context.Trainees.Any(e => e.Id == id);
        }

        #endregion

        #region User CRUD

        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("Users/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("Users")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var useradmin = new Admin()
            {
                Username = user.Username,
                Password = user.Password,


            };
            _context.Admins.Add(useradmin);
            await _context.SaveChangesAsync();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("Users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("Users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        #endregion

        #region Batch CRUD

        [HttpGet("Batches")]
        public async Task<IActionResult> GetBatches()
        {
            var batches = await _context.Batches.ToListAsync();
            return Ok(batches);
        }

        [HttpGet("Batches/{id}")]
        public async Task<IActionResult> GetBatch(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            return Ok(batch);
        }

        [HttpPost("Batches")]
        public async Task<IActionResult> CreateBatch([FromBody] Batch batch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Batches.Add(batch);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBatch), new { id = batch.Id }, batch);
        }

        [HttpPut("Batches/{id}")]
        public async Task<IActionResult> UpdateBatch(int id, [FromBody] Batch batch)
        {
            if (id != batch.Id)
            {
                return BadRequest();
            }

            _context.Entry(batch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("Batches/{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }

            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BatchExists(int id)
        {
            return _context.Batches.Any(e => e.Id == id);
        }

        #endregion

        #region Course CRUD

        [HttpGet("Courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return Ok(courses);
        }

        [HttpGet("Courses/{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost("Courses")]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        [HttpPut("Courses/{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("Courses/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        #endregion
    }
}
