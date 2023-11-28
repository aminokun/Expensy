using Expensy.Logic.Interfaces;
using Expensy.Data;
using Microsoft.AspNetCore.Mvc;

namespace Expensy.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService registerService;

        public RegisterController(IRegisterService registerService)
        {
            this.registerService = registerService;
        }
    }

}
