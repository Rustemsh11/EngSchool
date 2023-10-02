
using EngSchool.Presentation.ActionFilters;
using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EngSchool.Presentation.Controllers
{
    [ApiController]
    [Route("api/positions")]
    [ApiExplorerSettings(GroupName ="v1")]
    public class PositionController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PositionController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPositions() 
        {
            var positions = await _serviceManager.PositionService.GetAllPositionAsync(trackChanges: false);
            return Ok(positions);
        }

        [HttpGet]
        [Route("{positionId:int}", Name = "GetPosition")]
        public async Task<IActionResult> GetPosition(int positionId)
        {
            var position = await _serviceManager.PositionService.GetPositionAsync(positionId, trackChanges: false);
            return Ok(position);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePosition([FromBody] PositionCreateDto positionDto)
        {
            var position = await _serviceManager.PositionService.CreatePositionAsync(positionDto);
            return CreatedAtAction("GetPosition", new { positionId = position.PositionId}, position);
        }
    }
}
