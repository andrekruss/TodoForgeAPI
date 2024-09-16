using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class TodoForgeDbContext : DbContext
    {

        public TodoForgeDbContext(DbContextOptions options) : base(options)
        {
               
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Board to User relationship
            modelBuilder.Entity<Board>()
                .HasOne(b => b.Owner)
                .WithMany(u => u.Boards)
                .HasForeignKey(b => b.OwnerId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Set cascading delete behavior

            // TaskItem to User relationship(Task owner)
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Owner)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict); // Optional: no cascade delete

            // TaskItem to Board relationship
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete: deleting a board deletes its tasks
        }
    }
}
