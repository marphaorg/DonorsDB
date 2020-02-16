using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DonorsDBUI.Controllers
{
    public class SignInController : Controller
    {
        private readonly ILogger<SignInController> _logger;

        public SignInController(ILogger<SignInController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string username, string password)
        {
            var validate = string.Compare(username, "hello@marpha.org") == 0 && string.Compare(password, "admin") == 0;
            if (validate)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}