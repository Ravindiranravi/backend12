//using Institute.Data;
//using Institute.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Threading.Tasks;

//namespace Institute.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthenticationController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public AuthenticationController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        [HttpPost("signin")]
//        public async Task<IActionResult> SignIn([FromBody] User loginUser)
//        {
//            if (loginUser == null)
//                return BadRequest("Invalid client request");

//            var user = await _context.Users
//                .Include(u => u.Student)
//                .Include(u => u.Trainee)
//                .FirstOrDefaultAsync(u => u.Username == loginUser.Username && u.Password == loginUser.Password);

//            if (user == null)
//                return Unauthorized("Invalid credentials");

//            string redirectUrl = user.Role switch
//            {
//                "student" => "/student-dashboard",
//                "trainee" => "/trainee-dashboard",
//                "admin" => "/admin-dashboard",
//                _ => null
//            };

//            if (redirectUrl == null)
//                return Unauthorized("Invalid user role");

//            return Ok(new { RedirectUrl = redirectUrl });
//        }
//    }
//}



//using Institute.Data;
//using Institute.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace Institute.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthenticationController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public AuthenticationController(ApplicationDbContext context)
//        {
//            _context = context;
//        }



//        [HttpPost("signin")]
//        public async Task<IActionResult> SignIn([FromBody] User model)
//        {
//            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
//            {
//                return BadRequest("Invalid request.");
//            }

//            var user = await _context.Users

//                .Include(u => u.Student) // Include Student if necessary
//                .Include(u => u.Trainee) // Include Trainee if necessary
//                .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password && u.Role == model.Role);

//            if (user != null)
//            {
//                if (user.Role == "student" && user.Student != null)
//                {
//                    var redirectUrl = $"/student-dashboard/{user.Student.Id}";
//                    return Ok(new { Message = "Sign-in successful", RedirectUrl = redirectUrl, Student = user.Student });
//                }

//                if (user.Role == "trainee" && user.Trainee != null)
//                {
//                    var redirectUrl = $"/trainee-dashboard/{user.Trainee.Id}";
//                    return Ok(new { Message = "Sign-in successful", RedirectUrl = redirectUrl, Trainee = user.Trainee });
//                }

//                var roleRedirectUrl = user.Role switch
//                {
//                    "admin" => "/admin-dashboard",
//                    _ => "/unknown"
//                };

//                return Ok(new { Message = "Sign-in successful", RedirectUrl = roleRedirectUrl });
//            }

//            return Unauthorized("Invalid username or password.");
//        }

//    }
//}

using Institute.Data;
using Institute.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Institute.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] User model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Invalid request.");
            }

            // Find user with matching username, password, and role
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password && u.Role == model.Role);

            if (user != null)
            {
                if(model.Role == "trainee")
                {
                    var trainee = await _context.Trainees.FirstOrDefaultAsync(t => t.Username ==model.Username && t.Password == model.Password);
                    if (trainee!=null)
                    { 
                    return Ok(new { RedirectUrl = "/traineeDashboard", Id = trainee.Id });

                    }
                }
                if (model.Role == "student")
                {
                   
                    var student = await _context.Students.FirstOrDefaultAsync(t => t.Username == model.Username && t.Password == model.Password);
                     if (student != null)
                    {
                        return Ok(new { RedirectUrl = "/studentdashboard", Id = student.Id });

                    }
                   
                }
                if (model.Role == "admin")
                {

                    var admin = await _context.Admins.FirstOrDefaultAsync(t => t.Username == model.Username && t.Password == model.Password);
                    if (admin != null)
                    {
                        return Ok(new { RedirectUrl = "/admindashboard", Id = admin.Id });

                    }

                }


                // Define the redirect URL based on the user's role
                //string redirectUrl = user.Role switch
                //{
                //    "student" => "/studentDashboard",
                //    "trainee" => "/traineeDashboard",
                //    "admin" => "/adminDashboard",
                //    _ => "/unknown"
                //};

                return Ok(new { RedirectUrl = "/unknown"});
            }

            return Unauthorized("Invalid username or password.");
        }
    }
}
