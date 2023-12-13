using Expensy.Data;
using Expensy.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Expensy.Controllers
{
    public class GroupController : Controller
    {
        private readonly GroupService groupService;

        public GroupController()
        {
            GroupRepository groupRepository = new GroupRepository();
            this.groupService = new GroupService(groupRepository);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string groupName)
        {
            try
            {
                var createdGroup = groupService.CreateGroup(groupName);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(nameof(groupName), ex.Message);
                return View();
            }
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(int groupId, int userId)
        {
            try
            {
                groupService.AddUserToGroup(groupId, userId);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(nameof(userId), ex.Message);
                return View();
            }
        }
    }
}
