using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THITHUGK_02_NCH_CNTTK23.Dtos;
using THITHUGK_02_NCH_CNTTK23.Entity;
using THITHUGK_02_NCH_CNTTK23.Service.EnrollmentService;

namespace THITHUGK_02_NCH_CNTTK23.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByCourseId([FromQuery] Guid courseId)
        {
            var list = await _enrollmentService.GetByCourseId(courseId);
            return Ok(list);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnrollmentCreateRequest enrollment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            var created = await _enrollmentService.CreateAsync(enrollment);
            return Ok(created);
        }

        [HttpPut("confirm")]
        public async Task<IActionResult> Confirm([FromQuery] Guid id)
        {
            var result = await _enrollmentService.ConfirmAsync(id);
            if (result == null)
            { 
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _enrollmentService.DeleteAsync(id);
            //return deleted ? NoContent() : NotFound();
            return Ok(deleted);
        }
    }
}
