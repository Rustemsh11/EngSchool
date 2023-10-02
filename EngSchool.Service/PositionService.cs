using AutoMapper;
using EngSchool.Contracts;
using EngSchool.Entities.Models;
using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;
using Microsoft.Extensions.Logging;

namespace EngSchool.Service
{
    public class PositionService : IPositionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public PositionService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper )
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PositionDto> CreatePositionAsync(PositionCreateDto positionDto)
        {
            var position = _mapper.Map<Position>(positionDto);
            _repositoryManager.Position.CreatePosition(position);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<PositionDto>(position);
        }

        public async Task<IEnumerable<PositionDto>> GetAllPositionAsync(bool trackChanges)
        {
            var positions = await _repositoryManager.Position.GetAllPositionAsync(trackChanges);
            return _mapper.Map<IEnumerable<PositionDto>>(positions);
        }

        public async Task<PositionDto> GetPositionAsync(int positionId, bool trackChanges)
        {
            var position = await _repositoryManager.Position.GetPositionAsync(positionId, trackChanges);
            return _mapper.Map<PositionDto>(position);
        }

    }
}
