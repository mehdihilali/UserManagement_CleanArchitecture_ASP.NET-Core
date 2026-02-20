using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagementSystem.Application.Features.Users.Commands;
using UserManagementSystem.Application.Interfaces;
using UserManagementSystem.Domain.Entities;

namespace UserManagementSystem.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
                (
                request.FirstName,
                request.LastName,
                request.Email
                );

            await _repository.AddAsync(user);

            return user.Id;
        }
    }
}
