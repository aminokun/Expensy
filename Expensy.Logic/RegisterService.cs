using Expensy.Logic.Interfaces;
using Expensy.Logic.Models;

namespace Expensy.Logic
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository registerRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await registerRepository.GetUserByEmailAsync(email);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await registerRepository.GetUserByUsernameAsync(username);
        }

        public async Task<bool> Register(string _username, string _email, string _password)
        {
            var user = ConvertToUser(_username, _email, _password);

            var existingUser = await GetUserByEmailAsync(_email);
            if (existingUser != null)
            {
                return false;
                throw new ArgumentException("User with the same email already exists");
            }

            existingUser = await GetUserByUsernameAsync(_username);
            if (existingUser != null)
            {
                return false;
                throw new ArgumentException("User with the same username already exists");
            }

            await registerRepository.CreateNewUser(user);
            return true;
        }

        private User ConvertToUser(string _username, string _email, string _password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(_password);

            return new User
            {
                username = _username,
                email = _email,
                password = passwordHash,
            };
        }
    }
}

