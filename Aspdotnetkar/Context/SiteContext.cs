using Aspdotnetkar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Aspdotnetkar.Context
{
    public class SiteContext:DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options): base(options)
        {
          
        }

        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<SiteService> services { get; set; }
        public DbSet<BlogCategory> blogCategories { get; set; }
        public DbSet<Blog> blogs { get; set; }
    }
}
