using EngSchool.Entities.Models;

namespace EngSchool.Contracts
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllServicesAsync(bool trackChanges);
        Task<Service> GetServiceAsync(int serviceId, bool trackChanges);
        void CreateService(Service service);
        void DeleteService(Service service);
    }
}
