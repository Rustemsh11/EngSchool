using EngSchool.Contracts;
using EngSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EngSchool.Repository
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(EngSchoolRepositoryContext context):base(context)
        {
                
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<Service> GetServiceAsync(int serviceId, bool trackChanges)
        {            
            return await FindByCondition(c => c.ServiceId.Equals(serviceId), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateService(Service service)
        {
            Create(service);
        }

        public void DeleteService(Service service)
        {
            Delete(service);
        }
    }
}
