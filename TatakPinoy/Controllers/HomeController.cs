using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TatakPinoy.Data;
using TatakPinoy.Models;

namespace TatakPinoy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TatakPinoyContext _context;

        public HomeController(ILogger<HomeController> logger, TatakPinoyContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Authorize]
        public IActionResult ConfidentialData()
        {
            return View();
        }

        public IActionResult Index()
        {
            

            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Track(string Track)
        {
            var consignees = from c in _context.Consignee select c;
            if (!String.IsNullOrEmpty(Track))
            {
                consignees = consignees.Where(x => x.TrackingNo!.Contains(Track));
            }
            return View(consignees.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
