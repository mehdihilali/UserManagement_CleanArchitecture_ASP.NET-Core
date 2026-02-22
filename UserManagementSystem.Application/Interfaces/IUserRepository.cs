using System;
using System.Collections.Generic;
using System.Text;
using UserManagementSystem.Domain.Entities;

namespace UserManagementSystem.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
