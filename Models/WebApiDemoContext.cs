using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Models
{

    public class WebApiDemoContext : DbContext
    {

        public WebApiDemoContext(DbContextOptions<WebApiDemoContext> options)  : base(options)
        {
        }

        public  DbSet<TodoEntry> TodoEntries { get; set;}
    }
}