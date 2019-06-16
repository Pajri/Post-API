using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PostAPI.Models
{
    public partial class PostContext : DbContext
    {
        public PostContext()
        {
        }

        public PostContext(DbContextOptions<PostContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Title).IsRequired();
            });
        }
    }
}
