using Aspdotnetkar.Context;
using Aspdotnetkar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aspdotnetkar.Components
{
    public class BlogComponent : ViewComponent
    {
        SiteContext _context;
        public BlogComponent(SiteContext context)
        {
            _context = context;
        }

            public async Task<IViewComponentResult> InvokeAsync()
        {
            var last5Blog = await _context.blogs
                .OrderByDescending(o => o.BlogCreateDate)
                .Take(5)
                .ToListAsync();

            var showBlogcategory = await _context.blogCategories
                .Include(c => c.blogs)
                .ToListAsync();

            var category = new BlogViewModel
            {
                LastBlog = last5Blog,
                BlogCategory = showBlogcategory
            };

            return View("/Views/ComponentViews/blogandcategory.cshtml", category);
        }
    }
}
