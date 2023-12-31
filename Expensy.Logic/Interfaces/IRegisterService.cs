﻿

using Expensy.Logic.Models;

namespace Expensy.Logic.Interfaces
{
    public interface IRegisterService
    {
        Task<bool> Register(string _username, string _email, string _password);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}

