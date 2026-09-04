using Aspdotnetkar.Context;
using Aspdotnetkar.Models;
using Aspdotnetkar.ViewModels;
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

        public IActionResult Index()
        {
            ViewBag.dt = ShamsiDatetime.toshamsi(DateTime.Now);

            var blogcategory = _context.blogCategories.ToList();

            var blog = _context.blogs.OrderByDescending(o => o.BlogTitle).Take(3).ToList();
            

            var vm = new BlogViewModel()
            {
                blogvm = blog,
                BlogCategoryvm = blogcategory,
            };

            return View(vm);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
