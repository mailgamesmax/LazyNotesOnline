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
        public DbSet<NoteCategory> Categories { get; set; }      
        public DbSet<NoteContent> Contents { get; set; }      
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasIndex(u => u.NickName)
                .IsUnique();

            modelBuilder
                .Entity<User>()
                .Property(e => e.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (Role)Enum.Parse(typeof(Role), v));

            // user-cat 1toM
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.UserNoteCategories)
                .WithOne(n => n.User)
                .HasForeignKey(k => k.Id);

            // catTitle-catContent 1toM
            modelBuilder
                .Entity<NoteCategory>()
                .HasMany(u => u.NoteContents)
                .WithOne(n => n.NoteCategory)
                .HasForeignKey(k => k.Cat_Id);
        }

    }
}
