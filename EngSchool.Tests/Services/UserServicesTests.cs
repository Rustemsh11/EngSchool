using AutoFixture;
using AutoMapper;
using EngSchool.Contracts;
using EngSchool.Entities.Exception;
using EngSchool.Entities.Models;
using EngSchool.Service;
using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;
using EngSchool.Shared.DTO.UpdateDTO;
using EngSchool.Shared.RequestFeatures;
using Moq;
using Xunit;

namespace EngSchool.Tests.Services
{
    public class UserServicesTests
    {
        private readonly Mock<IRepositoryManager> _mock;
        private readonly Mock<IMapper> _mapper;
        private readonly IUserService _userService;

        public UserServicesTests()
        {
            _mock = new Mock<IRepositoryManager>();
            _mapper = new Mock<IMapper>();
            _userService = new UserService(_mock.Object, new Mock<ILoggerManager>().Object, _mapper.Object);
        }

        [Fact]
        public async Task UserService_CreateUserAsync_ShouldReturnUserDto()
        {
            
            int positionId = 1;
            var userCreateDto = new Fixture().Build<UserCreateDto>().Create();
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var user = fixture.Build<User>().Create();
            _mock.Setup(c => c.User.CreateUser(positionId, user)).Verifiable();
            SetupReturnForGetPositionAsync(positionId);
            _mapper.Setup(m => m.Map<User>(It.IsAny<UserCreateDto>())).Returns(new User());
            _mapper.Setup(m => m.Map<UserDto>(It.IsAny<User>())).Returns(new UserDto());


            var userDto = await _userService.CreateUserAsync(positionId, userCreateDto, false);

            Assert.IsType<UserDto>(userDto);

        }
        [Fact]
        public async Task UserService_DeleteUserAsync_ShouldThrowNullExceptionIfUserIsNull()
        {
            var fixture = new Fixture();
            var positionId = fixture.Create<int>();
            var userId = fixture.Create<int>();

            SetupReturnForGetPositionAsync(positionId);
            var users = _mock.Setup(c => c.User.GetUserByIdAsync(positionId, userId, It.IsAny<bool>())).ReturnsAsync(null as User);


            await Assert.ThrowsAsync<UserNotFoundException>(() => _userService.DeleteUserAsync(positionId, userId, It.IsAny<bool>()));
        }
        [Fact]
        public async Task UserService_DeleteUserAsync_ShouldThrowNullExceptionIfPositionIsNull()
        {
            var fixture = new Fixture();
            var positionId = fixture.Create<int>();
            var userId = fixture.Create<int>();

            SetupReturnForGetUserAsync(positionId, userId);
            _mock.Setup(c => c.Position.GetPositionAsync(positionId, It.IsAny<bool>())).ReturnsAsync(null as Position);


            await Assert.ThrowsAsync<PositionNotFoundException>(() => _userService.DeleteUserAsync(positionId, userId, It.IsAny<bool>()));
        }


        [Fact]
        public async Task UserService_GetAllUsersAsync_ShouldReturnListOfUserDto()
        {
            var fixture = new Fixture();
            var positionId = fixture.Create<int>();
            var userParameters = fixture.Build<UserParameters>().Create();
            SetupReturnForGetPositionAsync(positionId);
            _mock.Setup(c => c.User.GetAllUsersAsync(positionId, userParameters, It.IsAny<bool>()))
                .ReturnsAsync(new PageList<User>(fixture.Build<List<User>>().Create(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
            _mapper.Setup(c => c.Map<IEnumerable<UserDto>>(It.IsAny<User>())).Returns(new List<UserDto>());

            var result = await _userService.GetAllUsersAsync(positionId, userParameters, It.IsAny<bool>());

            Assert.NotNull(result);
            Assert.IsType<List<UserDto>>(result.userDto.ToList());
        }

        [Fact]
        public async Task UserService_GetUserByIdAsync_ShouldReturnConcreteUserDto()
        {
            var fixture = new Fixture();
            var positionId = fixture.Create<int>();
            var userId = fixture.Create<int>();
            SetupReturnForGetPositionAsync(positionId);
            _mock.Setup(c => c.User.GetUserByIdAsync(positionId, userId, It.IsAny<bool>())).ReturnsAsync(new User());
            _mapper.Setup(c => c.Map<UserDto>(It.IsAny<User>())).Returns(new UserDto());

            var result = await _userService.GetUserByIdAsync(positionId, userId, It.IsAny<bool>());

            Assert.NotNull(result);
            Assert.IsType<UserDto>(result);
        }

        [Fact]
        public async Task UserService_GetUserByIdAsync_ShouldReturnListOfCourseDtoOfUser()
        {
            var fixture = new Fixture();
            var positionId = fixture.Create<int>();
            var userId = fixture.Create<int>();
            SetupReturnForGetPositionAsync(positionId);
            SetupReturnForGetUserAsync(positionId, userId);
            var courseOfUser = _mock.Setup(c => c.CourseOfUsers.GetCourseIdForConcreteUserAsync(userId, It.IsAny<bool>())).ReturnsAsync(new List<CourseOfUsers>());
            _mock.Setup(c => c.Course.GetCourseAsync(It.IsAny<int>(),It.IsAny<int>(), It.IsAny<bool>())).ReturnsAsync(new Course());
            _mapper.Setup(c => c.Map<IEnumerable<CourseDto>>(It.IsAny<IEnumerable<Course>>()));

            var result = await _userService.GetUserCoursesByIdAsync(positionId, userId, It.IsAny<bool>());

            Assert.NotNull(result);
            Assert.IsType<List<CourseDto>>(result.ToList());

        }

        [Fact]
        public async Task UserService_GetUserByIdAsync_ShouldReturnParamsUserEntityAndUserToPatch() 
        {
            var fixture = new Fixture();
            var positionId = fixture.Create<int>();
            var userId = fixture.Create<int>();
            SetupReturnForGetPositionAsync(positionId);
            var excpectedUserEntity = _mock.Setup(c => c.User.GetUserByIdAsync(positionId, userId, It.IsAny<bool>())).ReturnsAsync(new User());
            var expectedUserToPatch = _mapper.Setup(c => c.Map<UserUpdateDto>(It.IsAny<User>())).Returns(new UserUpdateDto());

            var result = await _userService.GetUserForPatch(positionId, userId, It.IsAny<bool>(), It.IsAny<bool>());

            Assert.NotNull(result);
            Assert.IsType<User>(result.userEntity);
            Assert.IsType<UserUpdateDto>(result.userToPatch);
        }

        private void SetupReturnForGetPositionAsync(int positionId)
        {
            _mock.Setup(c => c.Position.GetPositionAsync(positionId, false)).ReturnsAsync(new Position());
        }
        private void SetupReturnForGetUserAsync(int positionId, int userId)
        {
            _mock.Setup(c => c.User.GetUserByIdAsync(positionId, userId, It.IsAny<bool>())).ReturnsAsync(new User());
        }

    }
}
