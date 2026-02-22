using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagementSystem.Application.Features.Users.Commands;
using UserManagementSystem.Application.Features.Users.Handlers;
using UserManagementSystem.Application.Interfaces;
using UserManagementSystem.Domain.Entities;

namespace UserManagementSystem.Tests.Tests.Features
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
            _handler = new CreateUserCommandHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Create_User_And_Return_Id()
        {
            // Arrange
            var command = new CreateUserCommand(
                "elmehdi",
                "elhilali",
                "elmehdi.elhilali@gmail.com"
            );

            _repositoryMock
                .Setup(r => r.AddAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert 
            result.Should().NotBe(Guid.Empty);

            _repositoryMock.Verify(
                r => r.AddAsync(It.IsAny<User>()),
                Times.Once
            );
        }
    }
}
