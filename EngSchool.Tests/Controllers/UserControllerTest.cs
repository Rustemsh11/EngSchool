using AutoFixture;
using Azure;
using EngSchool.Entities.Models;
using EngSchool.Presentation.Controllers;
using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;
using EngSchool.Shared.DTO.UpdateDTO;
using EngSchool.Shared.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EngSchool.Tests.Controllers
{

    public class UserControllerTest
    {
        //private readonly IServiceManager _serviceManager;
        private readonly UserController _controller;
        private readonly Mock<IServiceManager> mock;
        private readonly Mock<IHttpContextAccessor> mockContext;
        public UserControllerTest()
        {
            mock = new Mock<IServiceManager>();
            mockContext = new Mock<IHttpContextAccessor>();
            _controller = new UserController(mock.Object, mockContext.Object);
        }

        [Fact]
        public async Task UserController_GetAllUsers_ItSouldReturnOk()
        {
            //arrange
            int positionId = 1;
            var userParameters = new Fixture().Build<UserParameters>().Create();
             
            var userDto = mock.Setup(c => c.UserService.GetAllUsersAsync(positionId, userParameters, false))
                .ReturnsAsync((new List<UserDto>(), new Fixture().Build<MetaData>().Create()));
            //act
            var result = await _controller.GetAllUsers(positionId,userParameters);
            //assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public async Task UserController_GetUser_ShouldReturnOk()
        {
            int positionId = 1;
            int userId = 2;
            var userDto = mock.Setup(c => c.UserService.GetUserByIdAsync(positionId, userId, false)).ReturnsAsync(new UserDto());

            //act
            var result = await _controller.GetUser(positionId, userId);
            //assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public async Task UserController_GetUserCourses_ShouldReturnOk()
        {
            int positionId = 2;
            int userId = 4;
            var courses = mock.Setup(c => c.UserService.GetUserCoursesByIdAsync(positionId, userId, false)).ReturnsAsync(new List<CourseDto>());

            //act
            var result = await _controller.GetUserCourses(positionId, userId);
            //assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public async Task UserController_CreateUser_ShouldReturnCreatedAtActionResult()
        {
            int positionId = 1;
            var userCreateDto = new Fixture().Build<UserCreateDto>().Without(c=>c.Name).Create();
            var userDto = mock.Setup(c => c.UserService.CreateUserAsync(positionId, userCreateDto, false)).ReturnsAsync(new UserDto());
            
            //act
            var result = await _controller.CreateUser(positionId, userCreateDto);
            //assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
        [Fact]
        public async Task UserController_UpdateUser_ShouldReturnNoContent()
        {
            int positionId = 1;
            int userId = 4;
            var userUpdateDto = new Fixture().Build<UserUpdateDto>().Create();
            mock.Setup(c => c.UserService.UpdateUserAsync(positionId, userId, userUpdateDto, false, true));

            //act
            var result = await _controller.UpdateUser(positionId, userId, userUpdateDto);
            //assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public async Task UserController_DeleteUser_ShouldReturnNoContent()
        {
            int positionId = 1;
            int userId = 4;
            mock.Setup(c=>c.UserService.DeleteUserAsync(positionId,userId,false)).Returns(Task.CompletedTask);

            //act
            var result = await _controller.DeleteUser(positionId, userId);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
