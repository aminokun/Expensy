using Expensy.Logic.Interfaces;
using Expensy.Logic.Models;

namespace Expensy.Logic
{
    public class RegisterService : IRegisterService
    {
        private readonly dynamic _registerRepository;

        public RegisterService(dynamic registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public async Task<bool> Register(string _username, string _email, string _password)
        {
            var userDTO = ConvertToUserDTO(_username, _email, _password);
            await _registerRepository.CreateNewUser(userDTO);
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

