using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.IdentityService.Api.Controllers;
using L2Synergy.Shared.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L2Synergy.IdentityService.Application.Queries.UserQueries.LoginUser;
using L2Synergy.IdentityService.Domain.Models;
using L2Synergy.IdentityService.Application.Queries.UserQueries.GetUserByRefreshToken;

namespace L2Synergy.IdentityService.Tests.ControllerTests
{
    public class UserControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock = new Mock<IMediator>();
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _controller = new UserController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Login_WithValidLogin_ReturnsOkResult()
        {
            // Arrange
            var user = new User();
            var loginDto = new LoginDto("testUser", "testpassword");
            var tokenDto = new TokenDto("", new DateTimeOffset(), "", new DateTimeOffset(), new UserDto(user.Id, user.Username, user.Email, user.MemberId));
            var loginResult = Result<TokenDto>.Success(tokenDto);
            _mediatorMock.Setup(x => x.Send(
            It.Is<LoginUserQuery>(q => q.Login == loginDto),
            default))
                .Returns(Task.FromResult(loginResult));

            // Act
            var result = await _controller.Login(loginDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(tokenDto, okResult.Value);
        }

        [Fact]
        public async Task Login_WithInvalidLogin_ReturnsBadRequest()
        {
            // Arrange
            var user = new User();
            var loginDto = new LoginDto("testUser", "testpassword");
            var tokenDto = new TokenDto("", new DateTimeOffset(), "", new DateTimeOffset(), new UserDto(user.Id, user.Username, user.Email, user.MemberId));
            var loginResult = Result<TokenDto>.Failure(400);

            _mediatorMock.Setup(x => x.Send(
            It.Is<LoginUserQuery>(q => q.Login == loginDto),
            default))
                .Returns(Task.FromResult(loginResult));

            // Act
            var result = await _controller.Login(loginDto);

            // Assert
            //Assert.IsType<BadRequestObjectResult>(result);
            var BadRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, BadRequestResult.StatusCode);
            //Assert.Equal(tokenDto, BadRequestResult.Value);
        }

        [Fact]
        public async Task Relogin_WithValidToken_ReturnsOkResult()
        {
            // Arrange
            var refreshToken = "valid_refresh_token";
            var user = new User();
            var tokenDto = new TokenDto("accessToken", new DateTimeOffset(), "refreshToken",
                new DateTimeOffset(), new UserDto(user.Id, user.Username, user.Email, user.MemberId));

            // Usa IResult en lugar de Result
            IResult<TokenDto> loginResult = Result<TokenDto>.Success(tokenDto);

            _mediatorMock.Setup(x => x.Send(
                It.Is<GetUserByRefreshTokenQuery>(q => q.RefreshToken == refreshToken),
                default))
                .Returns(Task.FromResult(loginResult));

            // Act
            var result = await _controller.Relogin(refreshToken);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(tokenDto, okResult.Value);
        }

        [Fact]
        public async Task Relogin_WithInvalidToken_ReturnsNotFound()
        {
            // Arrange
            var refreshToken = "invalid_refresh_token";

            // Usa IResult en lugar de Result
            IResult<TokenDto> loginResult = Result<TokenDto>.Failure(404);

            _mediatorMock.Setup(x => x.Send(
                It.Is<GetUserByRefreshTokenQuery>(q => q.RefreshToken == refreshToken),
                default))
                .Returns(Task.FromResult(loginResult));

            // Act
            var result = await _controller.Relogin(refreshToken);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }


    }
}
