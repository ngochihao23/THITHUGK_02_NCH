using ThiThuGK.AppDbConText;
using THITHUGK_02_NCH_CNTTK23.Entity;
using Microsoft.EntityFrameworkCore;
using THITHUGK_02_NCH_CNTTK23.Service.CourseService;
using THITHUGK_02_NCH_CNTTK23.Dtos;


namespace ThiThuGK.Service
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync() =>
            await _context.Courses.ToListAsync();

        public async Task<Course?> GetByIdAsync(Guid id) =>
            await _context.Courses.FindAsync(id);

        public async Task<Course> CreateAsync(CourseCreateRequest course)
        {
            var exist = new Course
            {
                Id = Guid.NewGuid(),
                Title = course.Title,
                Description = course.Description,
                StartDate = DateTime.Now,

            };
            _context.Courses.Add(exist);
            
            await _context.SaveChangesAsync();
            return exist;
        }

        public async Task<Course?> UpdateAsync(CourseUpdateRequest course)
        {
            var existing = await _context.Courses.FindAsync(course.Id);
            if (existing == null) return null;
            existing.Title = course.Title;
            existing.Description = course.Description;
            existing.StartDate = course.StartDate;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
