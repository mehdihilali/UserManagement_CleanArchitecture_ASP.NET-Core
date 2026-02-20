using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagementSystem.Application.Features.Users.Commands;
using UserManagementSystem.Application.Interfaces;

namespace UserManagementSystem.Application.Features.Users.Handlers
{
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id)
                ?? throw new Exception("User Not Found");

            await _repository.DeleteAsync(user);
        }
    }
}
