using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagementSystem.Application.Features.Users.Commands;
using UserManagementSystem.Application.Interfaces;

namespace UserManagementSystem.Application.Features.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id)
                ?? throw new Exception("User Not Found");

            user.Update(request.FirstName, request.LastName, request.Email);

            await _repository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
