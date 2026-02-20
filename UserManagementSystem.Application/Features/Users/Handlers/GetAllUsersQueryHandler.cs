using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagementSystem.Application.Features.Users.DTO;
using UserManagementSystem.Application.Features.Users.Queries;
using UserManagementSystem.Application.Interfaces;

namespace UserManagementSystem.Application.Features.Users.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();

            return users.Select(u =>
            new UserDto(u.Id, u.FirstName, u.LastName, u.Email))
                .ToList();
        }
    }
}
