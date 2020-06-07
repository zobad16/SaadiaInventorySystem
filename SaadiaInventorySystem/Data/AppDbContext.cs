using Microsoft.EntityFrameworkCore;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<OldPart> OldParts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=saadiatrading;user=root;password=Gtlfx125;TreatTinyAsBoolean=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //Seed Master data.

            //Role Data
            modelBuilder.Entity<Role>().HasData(new List<Role>
            {
                new Role() {Name = "Admin", Id = 1},
                new Role() {Name = "User", Id = 2}
            });
            modelBuilder.Entity<Customer>().HasData(new List<Customer>
            {
                new Customer()
                {
                    Id = 1,
                    FirstName = "Zobad",
                    LastName = "Mahmood",
                    EmailAddress = "zobad.mahmood@gmail.com",
                    ComapnyName = "QTS"
                },
                new Customer()
                {
                    Id= 2 ,
                    FirstName = "Hamza",
                    LastName="Sheikh",
                    EmailAddress="hamza@gmail.com",
                    ComapnyName="Saadia"
                }

            });
           

            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new User()
                {
                    Id = 1,
                    UserName = "zobad" ,
                    Password = "1234",
                    FirstName = "Zobad",
                    LastName = "Mahmood",
                    DateCreated = DateTime.Now,
                    IsActive = 1,
                    RoleId = 1,
                    DateUpdate = DateTime.Now
                },
                new User()
                {
                    Id = 2,
                    UserName = "hamza" ,
                    Password = "1234",
                    FirstName = "Hamza",
                    LastName = "Sheikh",
                    DateCreated = DateTime.Now,
                    IsActive = 1,
                    RoleId = 2,
                    DateUpdate = DateTime.Now
                }
                
            });


        }

    }
}
