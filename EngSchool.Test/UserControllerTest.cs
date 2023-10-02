using EngSchool.Presentation.Controllers;
using EngSchool.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace EngSchool.Test
{
    public class UserControllerTest
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserController _controller;
        public UserControllerTest(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _controller = new UserController(serviceManager);
        }

        [Fact]
        public async Task UserController_GetAllUsers_ShouldReturnsOkWithAllUsers()
        {
            //arrange
            int positionId = 1;
            //act
            var actual = await _controller.GetAllUsers(positionId);
            //asser
            Xunit.Assert.IsType<OkObjectResult>(actual as OkObjectResult);
        }
    }
}
