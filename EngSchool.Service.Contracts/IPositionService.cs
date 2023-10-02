using EngSchool.Shared.DTO;
using System.Diagnostics.SymbolStore;

namespace EngSchool.Service.Contracts
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDto>> GetAllPositionAsync(bool trackChanges);
        Task<PositionDto> GetPositionAsync(int positionId, bool trackChanges);
        Task<PositionDto> CreatePositionAsync(PositionCreateDto positionDto);
    }
}
