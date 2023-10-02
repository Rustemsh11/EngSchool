using EngSchool.Entities.Models;

namespace EngSchool.Tests.Repositoryes.Helper
{
    public static class PositionHelper
    {
        public static IEnumerable<Position> GetManyPosition()
        {
            yield return GetOne();
        }

        public static Position GetOne()
        {
            return new Position()
            {
                PositionName = "testPosition"
            };
        }
    }
}
