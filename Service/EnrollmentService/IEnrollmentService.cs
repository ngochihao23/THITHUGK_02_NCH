using THITHUGK_02_NCH_CNTTK23.Dtos;
using THITHUGK_02_NCH_CNTTK23.Entity;

namespace THITHUGK_02_NCH_CNTTK23.Service.EnrollmentService
{
    public interface IEnrollmentService
    {
        Task<List<Enrollment>> GetByCourseId(Guid Courseid);
        Task<Enrollment> CreateAsync(EnrollmentCreateRequest enrollment);
        Task<Enrollment?> ConfirmAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);

    }
}
