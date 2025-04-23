using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ThiThuGK.AppDbConText;
using THITHUGK_02_NCH_CNTTK23.Dtos;
using THITHUGK_02_NCH_CNTTK23.Entity;


namespace THITHUGK_02_NCH_CNTTK23.Service.EnrollmentService
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext _context;

        public EnrollmentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Enrollment?> ConfirmAsync(Guid id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return null;
            }
            enrollment.Confirmed = true;
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<Enrollment> CreateAsync(EnrollmentCreateRequest enrollment)//EnrollmentCreateRequest enrollment )
        {
            


            var exist1 = new Enrollment
            {
                Id = Guid.NewGuid(),
               CourseId = enrollment.CourseId,
                StudentName = enrollment.StudentName,
               EnrollCode = GenerateCode()
        };

            _context.Enrollments.Add(exist1);
            await _context.SaveChangesAsync();
            return exist1;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return false;
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Enrollment?>> GetByCourseId(Guid Courseid)
        {
           var result = await _context.Enrollments.Where(e => e.CourseId == Courseid).ToListAsync();
            return result;
        }
        private string GenerateCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }





    }
}
