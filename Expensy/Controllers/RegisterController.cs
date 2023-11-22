using Expensy.Logic.Interfaces;
using Expensy.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Expensy.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService registerService;
        private readonly RegisterRepository registerRepository;

        public RegisterController(IRegisterService registerService, dynamic registerRepository)
        {
            this.registerService = registerService;
            this.registerRepository = registerRepository;
        }


    }

}
