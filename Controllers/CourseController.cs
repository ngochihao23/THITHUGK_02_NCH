using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THITHUGK_02_NCH_CNTTK23.Dtos;
using THITHUGK_02_NCH_CNTTK23.Entity;
using THITHUGK_02_NCH_CNTTK23.Service.CourseService;

namespace THITHUGK_02_NCH_CNTTK23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("course/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id) 
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null) 
            {
                return BadRequest("Not found");
            }
            return Ok(course);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create ([FromBody] CourseCreateRequest course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _courseService.CreateAsync(course);
            return Ok(created);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CourseUpdateRequest course) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var updated = await _courseService.UpdateAsync(course);
            if (updated == null)
            {
                return NotFound();
            } 
            return Ok(updated);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var courses = await _courseService.DeleteAsync(id);
            return Ok(courses);
        }

    }
}
