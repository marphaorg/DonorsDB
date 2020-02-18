using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ILogger<CampaignController> _logger;

        private readonly IUserService _userService;

        public CampaignController(ILogger<CampaignController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            CampaignViewModel model = new CampaignViewModel();
            model.Campaigns = new List<DTO.Campaign>();
            return View(model);
        }

        public IActionResult New(CampaignViewModel model)
        {
            return View();
        }

        public IActionResult Copy()
        {
            return View();
        }

        public IActionResult Profile(Guid CampaignID)
        {
            return View();
        }
    }
}
