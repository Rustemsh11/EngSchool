using EngSchool.Shared.DTO;

namespace EngSchool.Service.Contracts
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync(bool trackChanges);
        Task<ServiceDto> GetServiceAsync(int serviceId, bool trackChanges);
        Task<ServiceDto> CreateServiceAsync(ServiceCreateDto serviceCreateDto);
        Task DeleteService(int serviceId, bool trackChanges);
    }
}
