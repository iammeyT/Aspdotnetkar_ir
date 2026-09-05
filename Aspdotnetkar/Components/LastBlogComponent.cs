using Aspdotnetkar.Context;
using Aspdotnetkar.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Aspdotnetkar.Components
{
    public class LastBlogComponent : ViewComponent
    {
        SiteContext _context;
        public LastBlogComponent(SiteContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Mostvisit = _context.blogs
                .OrderByDescending(b => b.BlogVisitCount)
                .Take(10)
                .ToList();

            var LastBlog = _context.blogs
                .OrderByDescending(b => b.BlogCreateDate)
                .Take(10)
                .ToList();

            var vm = new BlogViewModel()
            {
                Blog = Mostvisit,
                LastBlog = LastBlog
            };

            return View(
                "/Views/ComponentViews/LastandMostvisitBlog.cshtml",
                vm
            );
        }
    }
}
