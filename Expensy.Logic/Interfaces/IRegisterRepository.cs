using Expensy.Logic.Models;

namespace Expensy.Logic.Interfaces
{
    public interface IRegisterRepository
    {
        Task CreateNewUser(User user);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}
