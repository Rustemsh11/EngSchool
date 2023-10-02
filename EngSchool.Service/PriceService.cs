using AutoMapper;
using EngSchool.Contracts;
using EngSchool.Service.Contracts;

namespace EngSchool.Service
{
    public class PriceService:IPriceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public PriceService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
             _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }
    }
}
