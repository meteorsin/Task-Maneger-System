using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XinyuLi.TaskManagerSystem.Core.Entities;

namespace XinyuLi.TaskManagerSystem.Infrastructure.Data
{
    public class TaskManagerDbContext: DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Task>(ConfigureTask);
            modelBuilder.Entity<TaskHistory>(ConfigureTaskHistory);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        { 
            builder.ToTable("User");   
            builder.HasMany(t => t.Tasks).WithOne(t => t.User).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(t => t.TaskHistories).WithOne(t => t.User).OnDelete(DeleteBehavior.Cascade);
            builder.Property(t => t.Email).HasMaxLength(50);
            builder.Property(t => t.Password).IsRequired().HasMaxLength(10);
            builder.Property(t => t.Fullname).HasMaxLength(50);
            builder.Property(t => t.Mobileno).HasMaxLength(50);
        }
        private void ConfigureTask(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task");
            builder.HasOne(t => t.User).WithMany(t => t.Tasks).OnDelete(DeleteBehavior.Cascade);
            builder.Property(t => t.Title).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.Priority).HasMaxLength(1);
            builder.Property(t => t.Remarks).HasMaxLength(500);
        }
        private void ConfigureTaskHistory(EntityTypeBuilder<TaskHistory> builder)
        {
            builder.ToTable("TaskHistory");
            builder.HasKey(t => t.TaskId);
            builder.HasOne(t => t.User).WithMany(t => t.TaskHistories).OnDelete(DeleteBehavior.Cascade);
            builder.Property(t => t.Title).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.Remarks).HasMaxLength(500);
        }
    }
}
