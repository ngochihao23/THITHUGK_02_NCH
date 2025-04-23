namespace THITHUGK_02_NCH_CNTTK23.Dtos
{
    public class CourseUpdateRequest :CourseCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
