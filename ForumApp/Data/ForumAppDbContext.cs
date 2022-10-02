using ForumApp.Data.Configure;
using ForumApp.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Post>(new PostConfiguration());
        }

        public virtual DbSet<Post> Posts { get; set; }

    }
}
