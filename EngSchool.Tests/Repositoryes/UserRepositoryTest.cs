using AutoFixture;
using EngSchool.Contracts;
using EngSchool.Entities.Models;
using EngSchool.Repository;
using EngSchool.Shared.RequestFeatures;
using EngSchool.Tests.Repositoryes.Helper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace EngSchool.Tests.Repositoryes
{
    public class UserRepositoryTest
    {
        private readonly Fixture _fixture;
        private readonly Mock<TestDataBaseContext> _context;
        private readonly UserRepository _userRepository;
        public UserRepositoryTest()
        {
            _fixture = new Fixture();
            _context = new Mock<TestDataBaseContext>();

            _userRepository = new UserRepository(_context.Object.Context);
        }

        [Fact]
        public async Task UserRepository_GetAllUsersAsync_ShouldReturnUsersByPositionId()
        {
            int positionId = _fixture.Create<int>();

            var countUsers = await _context.Object.Context.Users.Where(c => c.PositionId == positionId).CountAsync();
            var users = await _userRepository.GetAllUsersAsync(positionId,_fixture.Build<UserParameters>().Create(), It.IsAny<bool>());
            
            if(countUsers == 0)
            {
                Assert.Empty(users);
            }
            else
            {
                Assert.NotNull(users);
                Assert.Equal(countUsers, users.Count());
                Assert.IsType<List<User>>(users);
            }
        } 

        [Fact]
        public async Task UserRepository_GetUserByIdAsync_ShouldReturnSingleUser()
        {
            int positionId = _fixture.Create<int>();
            int userId = _fixture.Create<int>();

            var isExistPosition = await _context.Object.Context.Positions.AnyAsync(c => c.PositionId.Equals(positionId));
            var isExistUser = await _context.Object.Context.Users.AnyAsync(c => c.UserId.Equals(userId));
            var user = await _userRepository.GetUserByIdAsync(positionId, userId, It.IsAny<bool>());

            if (isExistPosition && isExistUser)
            {
                Assert.NotNull(user);
                Assert.IsType<User>(user);
            }
            else
            {
                Assert.Null(user);
            }
        }

        
    }
}
