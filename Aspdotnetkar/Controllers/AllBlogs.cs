using Aspdotnetkar.Context;
using Aspdotnetkar.Models;
using Aspdotnetkar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aspdotnetkar.Controllers
{
    public class AllBlogs : Controller
    {
        private SiteContext _context;
        public AllBlogs(SiteContext context)
        {
            _context = context;
        }

        [Route("Blogs")]
        public IActionResult Showblog()
        {
            var blogs = _context.blogs
               .Include(i => i.BlogCategory)
               .Take(9)
               .ToList();

            var cat = _context.blogCategories
                .Include(i=>i.blogs)
                .ToList();

            var vm = new BlogViewModel
            {
                AllBlog = blogs,
                Getcat = cat,
               
            };
            return View(vm);
        }
    }
}
