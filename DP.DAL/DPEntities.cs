using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DP.DAL
{
    public class DPEntities : DbContext
    {
        public DPEntities()
            : base("DPDBConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DPEntities>(new DropCreateDatabaseIfModelChanges<DPEntities>());

            //Users
            modelBuilder.Entity<User>().Property(ud => ud.Email).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<User>().Property(ud => ud.FirstName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<User>().Property(ud => ud.LastName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<User>().Property(ud => ud.UserName).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<User>().Ignore(ud => ud.Password);
            modelBuilder.Entity<User>().Ignore(ud => ud.ConfirmPassword);

            //Employees
            modelBuilder.Entity<Employee>().Property(e => e.FullName).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Email).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Phone).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Region).HasMaxLength(150).IsRequired();

            //Project
            modelBuilder.Entity<Project>().Property(p => p.Name).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Project>().Property(p => p.Description).HasMaxLength(250).IsOptional();
            modelBuilder.Entity<Project>().Property(p => p.Path).HasMaxLength(1000).IsRequired();
        }
    }
}
