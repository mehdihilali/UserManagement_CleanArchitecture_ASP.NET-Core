using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagementSystem.Application.Features.Users.Commands
{
    public record UpdateUserCommand
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email
    ) : IRequest<Unit>;
}
