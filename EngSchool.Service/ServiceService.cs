using AutoMapper;
using EngSchool.Contracts;
using EngSchool.Entities.Exception;
using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;

namespace EngSchool.Service
{
    internal class ServiceService : IServiceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public ServiceService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public async Task<ServiceDto> CreateServiceAsync(ServiceCreateDto serviceCreateDto)
        {
            var service = _mapper.Map<EngSchool.Entities.Models.Service>(serviceCreateDto);
            _repositoryManager.Service.CreateService(service);
            await _repositoryManager.SaveAsync();

            var serviceToReturn = _mapper.Map<ServiceDto>(service);
            return serviceToReturn;
        }

        public  async Task DeleteService(int serviceId, bool trackChanges)
        {
            var service = await GetServiceAndCheckExist(serviceId, trackChanges);
            _repositoryManager.Service.DeleteService(service);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<ServiceDto>> GetAllServicesAsync(bool trackChanges)
        {
            var services = await _repositoryManager.Service.GetAllServicesAsync(trackChanges);
            return _mapper.Map<IEnumerable<ServiceDto>>(services);
        }

        public async Task<ServiceDto> GetServiceAsync(int serviceId, bool trackChanges)
        {
            var service = await GetServiceAndCheckExist(serviceId, trackChanges);
            return _mapper.Map<ServiceDto>(service);
        }

        private async Task<Entities.Models.Service> GetServiceAndCheckExist(int serviceId, bool trackChanges)
        {
            var service = await _repositoryManager.Service.GetServiceAsync(serviceId, trackChanges);
            if (service is null)
            {
                throw new ServiceNotFoundException(serviceId);
            }
            return service;
        }
    }
}
