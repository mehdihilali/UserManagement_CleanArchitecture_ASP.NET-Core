using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagementSystem.Application.Features.Users.DTO;
using UserManagementSystem.Application.Features.Users.Handlers;
using UserManagementSystem.Application.Features.Users.Queries;
using UserManagementSystem.Application.Interfaces;
using UserManagementSystem.Domain.Entities;

namespace UserManagementSystem.Tests.Tests.Features
{
    public class GetAllUsersQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;
        private readonly GetAllUsersQueryHandler _handler;

        public GetAllUsersQueryHandlerTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
            _handler = new GetAllUsersQueryHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_List_Of_Users()
        {
            // Arrange

            var users = new List<User>
            {
                new User("Elmehdi", "Elhilali", "elmehdi@gmail.com"),
                new User("Idhem", "Ilalih", "idhem@gmail.com")
            };

            _repositoryMock
                .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(users);

            var query = new GetAllUsersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert 
            result.Should().HaveCount(2);
            result.Should().AllBeOfType<UserDto>();
        }

        [Fact]
        public async Task Handle_Should_Return_Empty_List_When_No_User()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<User>());

            var query = new GetAllUsersQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Handle_Should_Call_Repository_Once()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<User>());

            var query = new GetAllUsersQuery();

            // Act 
            await _handler.Handle(query, CancellationToken.None);

            // Assert
            _repositoryMock.Verify(r => 
                r.GetAllAsync(It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
