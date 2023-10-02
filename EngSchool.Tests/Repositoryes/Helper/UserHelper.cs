using EngSchool.Entities.Models;

namespace EngSchool.Tests.Repositoryes.Helper
{
    public static class UserHelper
    {
        public static IEnumerable<User> GetManyUsers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return GetOne();
            }
        }

        public static User GetOne()
        {
            return new User()
            {
                Name = "Аскар",
                Adress = "test adress",
                Age = 12,
                Email = "dsnfjds",
                Phone = "87446553423",
                PositionId = 1
            };
        }
    }
}
