using EngSchool.Presentation.ActionFilters;
using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;
using EngSchool.Shared.DTO.UpdateDTO;
using EngSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EngSchool.Presentation.Controllers
{
    [Route("api/service/{serviceId}/courses")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CoursesController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CoursesController(IServiceManager serviceManager)
        {
           _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses(int serviceId, [FromQuery] CourseParameters courseParameters)
        {
            var courses = await _serviceManager.CourseService.GetAllCoursesAsync(serviceId, courseParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(courses.metaData));
            return Ok(courses.courseDto);
            
        }
        [HttpGet("{courseId:int}", Name = "GetCourse")]
       
        public async Task<IActionResult> GetCourse(int serviceId, int courseId)
        {
            var courseDto = await _serviceManager.CourseService.GetCourseAsync(serviceId, courseId, trackChanges: false);
            return Ok(courseDto);
        }


        [HttpGet("{courseId:int}/users")]
        public async Task<IActionResult> GetUsersForCourse(int serviceId,int courseId)
        {
            var users = await _serviceManager.CourseService.GetUsersForCourseByIdAsync(serviceId, courseId, false);
            return Ok(users);
        }


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCourse(int serviceId, [FromBody] CourseCreateDto createDto)
        {
            var courseDto = await _serviceManager.CourseService.CreateCourseAsync(serviceId, createDto, trackChanges:false);

            return CreatedAtAction("GetCourse", new { serviceId, courseId = courseDto.CourseId }, courseDto);
        }

        [HttpPut("{courseId:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCourse(int serviceId, int courseId, [FromBody] CoursesUpdateDto coursesUpdateDto)
        {
            await _serviceManager.CourseService.UpdateCourseAsync(serviceId, courseId, coursesUpdateDto, trackChangesForService: false, trackChangesForCourse: true);
            return NoContent();
        }


        [HttpPatch("{courseId:int}")]
        public async Task<IActionResult> PartialUpdateCourse(int serviceId, int courseId, [FromBody] JsonPatchDocument<CoursesUpdateDto> jsonPatch)
        {
            if(jsonPatch is null)
            {
                return BadRequest("JsonPatchDocument is null");
            }
            var result = await _serviceManager.CourseService.GetCourseForPatchAsync(serviceId, courseId, trackChangesForService: false, trackChangesForCourse: true);
            jsonPatch.ApplyTo(result.courseToPatch, ModelState);
            TryValidateModel(result.courseToPatch);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            await _serviceManager.CourseService.SaveChangesForPatchAsync(result.courseToPatch, result.courseEntity);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int serviceId,int courseId)
        {
            await _serviceManager.CourseService.DeleteCourse(serviceId, courseId, trackChanges: false);
            return NoContent();
        }
    }
}
