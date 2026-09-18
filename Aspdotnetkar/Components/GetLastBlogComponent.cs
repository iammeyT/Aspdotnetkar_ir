using Aspdotnetkar.Context;
using Aspdotnetkar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aspdotnetkar.Components
{
    public class GetLastBlogComponent : ViewComponent
    {
        private SiteContext _context;

        public GetLastBlogComponent(SiteContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lastblog = _context.blogs
                .Include(i=>i.BlogCategory)
                .OrderByDescending(a => a.BlogCreateDate)
                .Take(8)
                .ToList();

            var vm = new BlogViewModel
            {
                LastBlog = lastblog,
            };
            return View("/Views/ComponentViews/GetLastBlogComponentview.cshtml", vm);
        }

    }
}
