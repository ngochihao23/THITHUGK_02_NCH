using System.ComponentModel.DataAnnotations;
using THITHUGK_02_NCH_CNTTK23.Entity;

namespace THITHUGK_02_NCH_CNTTK23.Dtos
{
    public class EnrollmentCreateRequest
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public string StudentName { get; set; }



    }
}
