using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UI.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ILogger<CampaignController> _logger;

        public CampaignController(ILogger<CampaignController> logger)
        {
            _logger = logger;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
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
