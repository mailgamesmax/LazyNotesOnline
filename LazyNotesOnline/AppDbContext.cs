using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Reflection.Emit;
using LazyNotesOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace LazyNotesOnline
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Property(e => e.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (Role)Enum.Parse(typeof(Role), v));
        }
    }
}
