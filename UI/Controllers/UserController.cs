using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using DTO;
using DTO.Enum;
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

        public IActionResult NewUser()
        {
            UserViewModel newUserModel = new UserViewModel();
            newUserModel.User = new User();
            newUserModel.Contact = new Contact();
            newUserModel.Address = new Address();
            return View(newUserModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewUser(UserViewModel newUserModel)
        {
            newUserModel.User.Person.Addresses = new List<Address>();
            newUserModel.User.Person.Addresses.Add(newUserModel.Address);
            newUserModel.User.Person.Contacts = new List<Contact>();
            newUserModel.User.Person.Contacts.Add(newUserModel.Contact);
            newUserModel.User.UserName = newUserModel.Contact.Email;
            newUserModel.User.Password = Helper.HelperPassword.HashPassword("myPassword");
            newUserModel.User.UserRole = (short)UserRole.User;
            newUserModel.User.IsActive = true;
            newUserModel.User.DateCreated = DateTime.UtcNow;
            newUserModel.User.DateLastActive = null;
            await _userService.CreateUserAsync(newUserModel.User);

            //send email with temp password
                        
            //Redirect to profile page
            return RedirectToAction("Profile", new { UserID = newUserModel.User.UserID });
        }

        public IActionResult NewManager()
        {
            UserViewModel newManager = new UserViewModel();
            newManager.User = new User();
            newManager.Contact = new Contact();
            newManager.Address = new Address();
            return View(newManager);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewManager(UserViewModel newManager)
        {
            newManager.User.Person.Addresses = new List<Address>();
            newManager.User.Person.Addresses.Add(newManager.Address);
            newManager.User.Person.Contacts = new List<Contact>();
            newManager.User.Person.Contacts.Add(newManager.Contact);
            newManager.User.UserName = newManager.Contact.Email;
            newManager.User.Password = Helper.HelperPassword.HashPassword("myPassword");
            newManager.User.UserRole = (short)UserRole.Manager;
            newManager.User.IsActive = true;
            newManager.User.DateCreated = DateTime.UtcNow;
            newManager.User.DateLastActive = null;
            await _userService.CreateUserAsync(newManager.User);

            //send email with temp password

            return View(newManager);
        }

        public async Task<IActionResult> Profile(Guid UserID)
        {
            UserViewModel model = new UserViewModel();

            var _user = await _userService.GetUserAsync(UserID);

            model.User = _user;
            model.Contact = _user.Person.Contacts.FirstOrDefault();
            model.Address = _user.Person.Addresses.FirstOrDefault();

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid UserID)
        {
            UserViewModel model = new UserViewModel();

            var _user = await _userService.GetUserAsync(UserID);

            model.User = _user;
            model.Contact = _user.Person.Contacts.FirstOrDefault();
            model.Address = _user.Person.Addresses.FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            model.User.Person.Addresses = new List<Address>();
            model.User.Person.Addresses.Add(model.Address);
            model.User.Person.Contacts = new List<Contact>();
            model.User.Person.Contacts.Add(model.Contact);
            model.User.UserName = model.Contact.Email;           
            model.User.UserRole = (short)UserRole.User;            
            model.User.DateUpdated = DateTime.UtcNow;
            
            await _userService.UpdateUserAsync(model.User);

            //Redirect to profile page
            return RedirectToAction("Profile", new { UserID = model.User.UserID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid UserID)
        {
            await _userService.DeleteUserAsync(UserID);
            //Redirect to Index page
            return RedirectToAction("Index");
        }
    }
}
