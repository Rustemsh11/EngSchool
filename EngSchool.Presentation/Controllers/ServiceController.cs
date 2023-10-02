using EngSchool.Presentation.ActionFilters;
using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EngSchool.Presentation.Controllers
{
    [Route("api/service")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ServiceController: ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public ServiceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _serviceManager.ServiceService.GetAllServicesAsync(trackChanges: false);
            return Ok(services);
        }

        [HttpGet]
        [Route("{serviceId:int}", Name = "ServiceById")]
        public async Task<IActionResult> GetService(int serviceId)
        {
            var service = await _serviceManager.ServiceService.GetServiceAsync(serviceId, trackChanges: false);
            return Ok(service);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateService([FromBody] ServiceCreateDto serviceCreateDto)
        {

            var createdService = await _serviceManager.ServiceService.CreateServiceAsync(serviceCreateDto);
            return CreatedAtRoute("ServiceById", new { serviceId = createdService.ServiceId }, createdService);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteService(int serviceId)
        {
            await _serviceManager.ServiceService.DeleteService(serviceId, trackChanges: false);
            return NoContent();
        }
    }
}
