using Microsoft.EntityFrameworkCore;

namespace FluentAPI
{
    class MyContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");

        #region Required

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
                        modelBuilder.Entity<Blog>()
                            .Property(b => b.Url)
                            .IsRequired();
            */
            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);


        }

        #endregion
    }
}