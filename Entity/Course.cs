using System.ComponentModel.DataAnnotations;

namespace THITHUGK_02_NCH_CNTTK23.Entity
{
    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        //[Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        //[Required]
        public DateTime StartDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
