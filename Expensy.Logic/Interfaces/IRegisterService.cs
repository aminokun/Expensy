using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensy.Logic.Interfaces
{
    public interface IRegisterService
    {
        Task<bool> Register(string _username, string _email, string _password);
    }
}

