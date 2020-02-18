using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index()
        {
            UserViewModel model = new UserViewModel();
            model.Users = await _userService.GetUsersAsync();
            return View(model);
        }

        public IActionResult New()
        {
            UserViewModel newUserModel = new UserViewModel();
            newUserModel.User = new User();
            newUserModel.Contact = new Contact();
            newUserModel.Address = new Address();
            return View(newUserModel);
        }

        [HttpPost]
        public async Task<ActionResult> New(UserViewModel newUserModel)
        {
            newUserModel.User.Person.Addresses = new List<Address>();
            newUserModel.User.Person.Addresses.Add(newUserModel.Address);
            newUserModel.User.Person.Contacts = new List<Contact>();
            newUserModel.User.Person.Contacts.Add(newUserModel.Contact);
            await _userService.CreateUserAsync(newUserModel.User);

            return View(newUserModel);
        }

        public IActionResult Profile(Guid UserID)
        {
            return View();
        }
    }
}
