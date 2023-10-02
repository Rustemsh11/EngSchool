using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EngSchool.Presentation.Controllers
{
    [ApiController]
    [Route("api/courseOfUsers")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CourseOfUsersController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public CourseOfUsersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignInCourse([FromBody] CreateCourseOfUsersDto createCourseOfUsersDto)
        {
            var result = await _serviceManager.CourseOfUsersService.CreateCourseOfUsersAsync(createCourseOfUsersDto,false);
            return CreatedAtAction("GetUserCourses", "User", new {positionId = result.PositionId, id = result.UserId},result);
        }
        [HttpDelete]
        public async Task<IActionResult> SignOutFromCours([FromBody] CourseOfUsersDto courseCreateDto)
        {
            await _serviceManager.CourseOfUsersService.DeleteCourseOfUsersAsync(courseCreateDto, false);
            return NoContent();
        }
    }
}
