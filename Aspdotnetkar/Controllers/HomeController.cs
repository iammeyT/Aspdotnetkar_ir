using Aspdotnetkar.Context;
using Aspdotnetkar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Aspdotnetkar.Controllers
{
    public class HomeController : Controller
    {
        private SiteContext _context;
        public HomeController(SiteContext context)
        {
            _context = context;
        }

        public IActionResult blogPartial()
        {
            var bc = _context.blogs.ToList();
            return View();
        }

        public IActionResult Index()
        {

            ViewBag.dt = ShamsiDatetime.toshamsi(DateTime.Now);
            return View();
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
