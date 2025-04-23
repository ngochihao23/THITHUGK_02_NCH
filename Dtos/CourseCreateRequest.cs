namespace THITHUGK_02_NCH_CNTTK23.Dtos
{
    public class CourseCreateRequest
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        //[Required]
        public DateTime StartDate { get; set; }
    }
}
