using THITHUGK_02_NCH_CNTTK23.Dtos;
using THITHUGK_02_NCH_CNTTK23.Entity;

namespace THITHUGK_02_NCH_CNTTK23.Service.CourseService
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(Guid id);
        Task<Course> CreateAsync(CourseCreateRequest course);
        Task<Course?> UpdateAsync(CourseUpdateRequest course);
        Task<bool> DeleteAsync(Guid id);
    }
}
