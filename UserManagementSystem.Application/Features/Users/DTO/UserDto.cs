using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagementSystem.Application.Features.Users.DTO
{
    public record UserDto
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email
    );
}
