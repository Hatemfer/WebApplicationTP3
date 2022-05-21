using Microsoft.EntityFrameworkCore;

namespace WebApplicationSchoolTp4.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }

}
