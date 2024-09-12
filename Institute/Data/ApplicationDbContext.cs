
//using Institute.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Institute.Data
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<User> Users { get; set; }
//        public DbSet<Student> Students { get; set; }
//        public DbSet<Trainee> trainees { get; set; }

//    }
//}


using Institute.Models;
using Microsoft.EntityFrameworkCore;

namespace Institute.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Admin> Admins { get; set; } // Add Admins DbSet

        public DbSet<Batch> Batches { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
