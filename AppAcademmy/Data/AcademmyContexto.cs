using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppAcademmy
{
    public class AppAcademmyContext : DbContext
    {
         public AppAcademmyContext(DbContextOptions<AppAcademmyContext> options)
            : base(options)
        {
        }

        public AppAcademmyContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
            .HasKey(c => new { c.ClientId, c.CourseId });         
        }

        public DbSet<Client> clients { get; set; }
        public DbSet<Owner> owners { get; set; }
        public DbSet<Signature> signatures { get; set; }
        public DbSet<Course> courses { get; set; }
     
    }

}