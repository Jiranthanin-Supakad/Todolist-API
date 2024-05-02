using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Models
{

    public class WebApiDemoContext : DbContext
    {

        public WebApiDemoContext(DbContextOptions<WebApiDemoContext> options)  : base(options)
        {
        }

        public  DbSet<TodoEntry> TodoEntries { get; set;}

        //public  DbSet<TodoTag> Tags { get; set;}
        //public  DbSet<Users> Users { get; set;} = null;

        // public  DbSet<TodoTag> Uesrs { get; set;} = null;

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<TodoEntry>()
        //     .HasMany(e => e.Tags)
        //     .WithMany(e => e.TaggedEntries);

        //     // modelBuilder.Entity<Users>()
        //     // .HasMany(e => e.TaggedEntries)
        //     // .WithMany(e => e.Owner);
        // }
    }
}