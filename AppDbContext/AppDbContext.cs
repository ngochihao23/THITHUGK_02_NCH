using Microsoft.EntityFrameworkCore;
using THITHUGK_02_NCH_CNTTK23.Entity; 

namespace ThiThuGK.AppDbConText 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }



    }
}
