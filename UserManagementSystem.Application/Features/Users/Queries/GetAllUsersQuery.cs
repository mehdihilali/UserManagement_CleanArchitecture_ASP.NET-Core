using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagementSystem.Application.Features.Users.DTO;

namespace UserManagementSystem.Application.Features.Users.Queries
{
    public record GetAllUsersQuery() : IRequest<List<UserDto>>;
}
