﻿using L2Synergy.IdentityService.Application.Queries.RoleQueries.GetRoles;
using L2Synergy.IdentityService.Domain.Models;
using L2Synergy.IdentityService.Infrastructure.Repositories.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.IdentityService.Tests.ApplicationTests.QueryTests
{
    public class GetRolesQueryHandlerTests
    {
        private readonly Mock<IRoleRepository> mockRoleRepo;
        private readonly GetRolesQueryHandler queryHandler;

        public GetRolesQueryHandlerTests()
        {
            mockRoleRepo = new Mock<IRoleRepository>();
            queryHandler = new GetRolesQueryHandler(mockRoleRepo.Object);
        }

        [Fact]
        public async Task Handle_WhenCalled_ReturnsRolesFromRepository()
        {
            // Arrange
            string userRoleId = Guid.NewGuid().ToString();
            string adminRoleId = Guid.NewGuid().ToString();
            var roles = new List<Role>
            {
                new Role { Id = adminRoleId, RoleName = "Admin", Description = "Administrator" },
                new Role { Id = userRoleId, RoleName = "User", Description = "Standard User" }
            };

            mockRoleRepo.Setup(r => r.GetAllAsync(null!, It.IsAny<CancellationToken>()))
                .ReturnsAsync(roles);

            // Act
            var result = await queryHandler.Handle(new GetRolesQuery(), CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Values!.Count());
            Assert.Contains(adminRoleId, result.Values.Select(r => r.Id));
            Assert.Contains(userRoleId, result.Values.Select(r => r.Id));
        }

        [Fact]
        public async Task Handle_WhenRepositoryThrows_ReturnsFailure()
        {
            // Arrange
            mockRoleRepo.Setup(r => r.GetAllAsync(null!, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new System.Exception("Database error"));

            // Act
            var result = await queryHandler.Handle(new GetRolesQuery(), CancellationToken.None);

            // Assert
            Assert.True(!result.IsSuccess);
        }
    }

}
