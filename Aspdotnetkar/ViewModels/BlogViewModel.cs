using Aspdotnetkar.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspdotnetkar.ViewModels
{
    public class BlogViewModel
    {
        public List<Blog> blogvm { get; set; }

        public List<BlogCategory> BlogCategoryvm { get; set; }

    }
}
