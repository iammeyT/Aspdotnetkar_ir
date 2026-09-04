using Aspdotnetkar.Context;
using Aspdotnetkar.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

            var blogcategory = _context.blogCategories.ToList();

            var blog = _context.blogs.OrderByDescending(o => o.BlogTitle).Take(3).ToList();


            var vm = new BlogViewModel()
            {
                blogvm = blog,
                BlogCategoryvm = blogcategory,

            };

            return View("/Views/ComponentViews/blogandcategory.cshtml", vm);
        }
    }
}
