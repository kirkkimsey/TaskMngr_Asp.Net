using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class TaskContext : DbContext
    {
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public TaskContext() : base("TaskContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .HasOptional(m => m.AssignedUser)
                .WithMany()
                .HasForeignKey(m => m.AssignedToID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Tasks>()
                .HasRequired(m => m.TaskOwner)
                .WithMany()
                .HasForeignKey(m => m.OwnerID)
                .WillCascadeOnDelete(false);
        }

    }
}