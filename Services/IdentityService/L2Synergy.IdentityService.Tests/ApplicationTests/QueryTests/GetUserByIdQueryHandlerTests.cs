using L2Synergy.IdentityService.Application.Queries.UserQueries.GetUserById;
using L2Synergy.IdentityService.Domain.Models;
using L2Synergy.IdentityService.Infrastructure.Repositories.Contracts;
using L2Synergy.IdentityService.Shared.Dtos.UserDtos;
using L2Synergy.Shared.Results;
using Moq;
using System.Linq.Expressions;

namespace L2Synergy.IdentityService.Tests.ApplicationTests.QueryTests
{
    public class GetUserByIdQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepo;
        private readonly GetUserByIdQueryHandler _handler;

        public GetUserByIdQueryHandlerTests()
        {
            _mockUserRepo = new Mock<IUserRepository>();
            _handler = new GetUserByIdQueryHandler(_mockUserRepo.Object);
        }

        [Fact]
        public async Task Handle_WhenUserNotFound_ReturnsNotFoundResult()
        {
            // Arrange
            _mockUserRepo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<CancellationToken>()))!
                          .ReturnsAsync((User)null!);

            var query = new GetUserByIdQuery(userId: Guid.NewGuid().ToString());

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task Handle_WhenUserFound_ReturnsUserDto()
        {
            // Arrange 
            string userId = Guid.NewGuid().ToString();
            var testUser = new User { Id = userId, Username = "test", Email = "test@test.com" };
            _mockUserRepo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(testUser);

            var query = new GetUserByIdQuery(userId: userId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsType<Result<UserDto>>(result);
            Assert.Equal("test", result.Value!.Username);
        }

        [Fact]
        public async Task Handle_WithUserRole_PopulatesRoleName()
        {
            // Arrange
            string userId = Guid.NewGuid().ToString();
            var testUser = new User
            {
                Id = userId,
                Username = "test",
                Email = "test@test.com",
                Role = new Role { RoleName = "Admin" }
            };
            _mockUserRepo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(testUser);

            var query = new GetUserByIdQuery(userId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal("Admin", result.Value!.Role);
        }
    }

}
