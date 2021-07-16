using Core.Model;
using Core.Repository;
using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly Guid knowUser = Guid.Parse("026b97e2-50a3-41ba-83d9-a796f1b624b1");

        public Task<User> GetUserByIdAsync(Guid id)
        {
            return id == knowUser ? Task.FromResult(new User() { Id = knowUser, Name = "Tester" }) : Task.FromResult<User>(null);

        }
    }
}
