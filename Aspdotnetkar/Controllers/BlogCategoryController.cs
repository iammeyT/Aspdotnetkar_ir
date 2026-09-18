using Aspdotnetkar.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aspdotnetkar.Controllers
{
    public class BlogCategoryController : Controller
    {
        private SiteContext _context;

        public BlogCategoryController(SiteContext context)
        {
            _context = context;
        }

        [Route("Group/{id}")]
        public IActionResult AllBlog(int id)
        {
            var category = _context.blogCategories
                .Where(w => w.Id == id)
                .Include(i => i.blogs)
                .Select(s => s.blogs)
                .ToList();

            return View(category);


        }
    }
}
