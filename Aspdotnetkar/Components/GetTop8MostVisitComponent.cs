using Aspdotnetkar.Context;
using Aspdotnetkar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Aspdotnetkar.Components
{

    public class GetTop8MostVisitComponent : ViewComponent
    {
        private SiteContext _context;
        public GetTop8MostVisitComponent(SiteContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var topvisit = _context.blogs
                .Include(i => i.BlogCategory)
                .OrderByDescending(b => b.BlogVisitCount)
                .Take(8)
                .ToList();

            var vm = new BlogViewModel
            {
                TopBlogVisit = topvisit
            };

            return View("/Views/ComponentViews/GetTop8MostVisitComponentview.cshtml", vm);
        }
    }
}
