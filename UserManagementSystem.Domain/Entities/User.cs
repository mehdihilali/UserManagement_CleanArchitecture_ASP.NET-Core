using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagementSystem.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private User() { } //Pour EF

        public User(string fisrtName, string lastName, string email)
        {
            Id = Guid.NewGuid();
            FirstName = fisrtName;
            LastName = lastName;
            Email = email;
            CreatedAt = DateTime.UtcNow;

        }

        public void Update(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
