using EngSchool.Presentation.ActionFilters;
using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;
using EngSchool.Shared.DTO.UpdateDTO;
using EngSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EngSchool.Presentation.Controllers
{
    [Route("api/position/{positionId}/users")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UserController:ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly IHttpContextAccessor _httpContext;

        public UserController(IServiceManager serviceManager, IHttpContextAccessor httpContext)
        {
            _services = serviceManager;
            _httpContext = httpContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(int positionId, [FromQuery] UserParameters userParameters)
        {            
            var users = await _services.UserService.GetAllUsersAsync(positionId, userParameters,trackChanges: false);

            _httpContext?.HttpContext?.Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(users.metaData));
            return Ok(users.userDto);
        }
        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int positionId,int id)
        {
            var user = await _services.UserService.GetUserByIdAsync(positionId, id, trackChanges: false);
            return Ok(user);
        }
        [HttpGet("{id:int}/courses")]
        public async Task<IActionResult> GetUserCourses(int positionId, int id)
        {
            var courses = await _services.UserService.GetUserCoursesByIdAsync(positionId,id, trackChages: false);
            return Ok(courses);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateUser(int positionId,[FromBody] UserCreateDto userCreateDto)
        {

            var user = await _services.UserService.CreateUserAsync(positionId, userCreateDto, trackChanges: false);

            return CreatedAtAction("GetUser", new { positionId, id = user.UserId }, user);
        }

        [HttpPut("{userId:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUser(int positionId, int userId, [FromBody] UserUpdateDto userUpdateDto)
        {
            
            await _services.UserService.UpdateUserAsync(positionId, userId, userUpdateDto, trackChangesForPosition: false, trackChangesForUser: true);
            return NoContent();
        }

        [HttpPatch("{userId:int}")]
        public async Task<IActionResult> PartiallyUpdateUser(int positionId, int userId, [FromBody] JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            if(patchDoc is null)
            {
                return BadRequest("PatchDoc object is null");
            }
            var result = await _services.UserService.GetUserForPatch(positionId, userId, trackChangesForPosition: false, trackChangesForUser: true);
            patchDoc.ApplyTo(result.userToPatch, ModelState);
            TryValidateModel(result.userToPatch);
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            await _services.UserService.SaveChangesForPatch(result.userToPatch, result.userEntity);
            return NoContent();

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int positionId, int userId)
        {
            await _services.UserService.DeleteUserAsync(positionId, userId, trackChanges: false);
            return NoContent();
        }
    }
}
