using System.ComponentModel.DataAnnotations;

namespace THITHUGK_02_NCH_CNTTK23.Entity
{
    public class Enrollment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        [Required]
        public string StudentName { get; set; }

        [StringLength(6)]
        public string EnrollCode { get; set; }

        public bool Confirmed { get; set; } = false;

    }
}
