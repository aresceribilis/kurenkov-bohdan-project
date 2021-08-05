using System;
using Vismy.Application.Services;
using Xunit;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Vismy.Application.DTOs;
using Vismy.WEB.Controllers;

namespace Vismy.Test
{
    public class UserServiceTest
    {
        [Fact]
        public void LoginTest()
        {
            // Arrange
            var userService = new Mock<UserService>();
            var mapper = new Mock<Mapper>();
            var userDto = new UserInfoDTO()
            {
                Id = Guid.NewGuid().ToString(),
                Password = "123456A"
            };
            userService.Setup(us => us.Login(userDto));
            var controller = new AccountController(userService.Object, mapper.Object);

            // Act
            var result = controller.Login();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            





        }
    }
}
