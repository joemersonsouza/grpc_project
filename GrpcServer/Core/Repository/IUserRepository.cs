using Core.Model;
using System;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid id);
    }
}
