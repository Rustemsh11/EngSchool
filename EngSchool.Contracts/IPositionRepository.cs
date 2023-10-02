using EngSchool.Entities.Models;

namespace EngSchool.Contracts
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllPositionAsync(bool trackChanges);        
        Task<Position> GetPositionAsync(int id, bool trackChanges);
        void CreatePosition(Position position);
    }
}
