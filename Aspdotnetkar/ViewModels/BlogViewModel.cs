using Aspdotnetkar.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspdotnetkar.ViewModels
{
    public class BlogViewModel
    {
        public List<Blog> Blog { get; set; }

        public List<BlogCategory> BlogCategory { get; set; }

        public List<Blog> LastBlog { get; set; }

    }
}
