using Expensy.Data;
using Expensy.Data.DTO;
using Expensy.Logic.Models;

namespace Expensy.Logic
{
    public class RegisterService
    {
        UserRepository userRepository = new UserRepository();

        public async Task<bool> Register(string _username, string _email, string _password)
        {
            var userDTO = ConvertToUserDTO(_username, _email, _password);
            await userRepository.CreateNewUser(userDTO);
            return true;
        }

        private UserDTO ConvertToUserDTO(string _username, string _email, string _password)
        {
            return new UserDTO
            {
                username = _username,
                email = _email,
                password = _password,
            };
        }
    }
}
