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
        //public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=saadiatrading;user=root;password=Gtlfx125;TreatTinyAsBoolean=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Inventory>()
                .HasOne(o => o.OldPart)
                .WithOne()
                .HasForeignKey<Inventory>(fk => fk.OldPartFK)
                .OnDelete(DeleteBehavior.ClientSetNull);


            //QuotationItem foreign key with Inventory
            //QuotationItem -> (Quotation,Inventory)
            modelBuilder.Entity<QuotationItem>()
                .HasKey(qt => new { qt.QuotationId, qt.InventoryId});
            //QuotationItem -> Quotation
            modelBuilder.Entity<QuotationItem>()
                .HasOne(qt => qt.Quotation)
                .WithMany(b => b.Items)
                .HasForeignKey(fk => fk.QuotationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //QuotaionItem -> Inventory
            modelBuilder.Entity<QuotationItem>()
                .HasOne<Inventory>(ct => ct.Inventory)
                .WithMany()
                .HasForeignKey(bc => bc.InventoryId);
            //Quotaion Foreign key with Quotaion Item and Customer
            //Quotation -> Customer
            modelBuilder.Entity<Quotation>()
                .HasOne<Customer>(qt => qt.Customer )
                .WithOne()
                .HasForeignKey<Quotation>(fk=> fk.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //Quotation -> Quotation Item
            modelBuilder.Entity<Quotation>()
                .HasMany<QuotationItem>(qt => qt.Items)
                .WithOne(c => c.Quotation)
                .HasForeignKey(fk=> fk.QuotationId);
            
            
            //InvoiceItem foreign key with Inventory
            //InvoiceItem -> (Invoice, Inventory) 
            modelBuilder.Entity<InvoiceItem>()
                .HasKey(qt => new { qt.InvoiceId, qt.InventoryId});
            //InvoiceItem -> Invoice
            modelBuilder.Entity<InvoiceItem>()
                .HasOne(qt => qt.Invoice)
                .WithMany(b => b.Item)
                .HasForeignKey(fk => fk.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //InvoiceItem -> Inventory
            modelBuilder.Entity<InvoiceItem>()
                .HasOne(ct => ct.Inventory)
                .WithMany()
                .HasForeignKey(bc => bc.InventoryId);
            //Quotaion Foreign key with Quotaion Item and Customer
            //Invoice -> Customer
            modelBuilder.Entity<Invoice>()
                .HasOne<Customer>(qt => qt.Customer )
                .WithOne()
                .HasForeignKey<Invoice>(fk=> fk.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //Invoice -> InvoiceItem
            modelBuilder.Entity<Invoice>()
                .HasMany<InvoiceItem>(qt => qt.Item)
                .WithOne(c => c.Invoice)
                .HasForeignKey(fk=> fk.InvoiceId);            
          


            modelBuilder.Entity<User>()
                .HasOne<Role>(r => r.Role)
                .WithOne()
                .HasForeignKey<User>(r => r.RoleFk)
                ;//.OnDelete(DeleteBehavior.;
            
            SeedDataRole(modelBuilder);
            SeedDataCustomer(modelBuilder);
            SeedDataUser(modelBuilder);
            SeedDataInventory(modelBuilder);
            //Seed Master data.

            //Role Data
            /*modelBuilder.Entity<Role>().HasData(new List<Role>
            {
                new Role() {RoleName = "Admin", Id = 1},
                new Role() {RoleName = "User", Id = 2}
            });*/
            /* modelBuilder.Entity<Customer>().HasData(new List<Customer>
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
           */

            /*modelBuilder.Entity<User>().HasData(new List<User>
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
                    RoleFk = 1,
                    //Role = new Role(){Id = 1, RoleName ="Admin" },
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
                    RoleFk = 2,
                    DateUpdate = DateTime.Now
                }
                
            });*/

            /*modelBuilder.Entity<Inventory>().HasData(new List<Inventory>
            {
                new Inventory()
                {
                    Id = 1,
                    PartNumber = "15613-EV015",
                    Description = "OIL FILTER",
                    Location = "1A1",
                    UnitPrice = 0.0M,
                    AvailableQty = 5,
                    Rem = "GN" ,
                    OldPart = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },
                new Inventory()
                {
                    Id = 2,
                    PartNumber = "23304-EV052",
                    Description = "FUEL FILTER",
                    Location = "1A1",
                    UnitPrice = 0.0M,
                    AvailableQty = 3,
                    Rem = "GN" ,
                    OldPartFK = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },
                new Inventory()
                {
                    Id = 3,
                    PartNumber = "23304-78091",
                    Description = "FUEL FILTER",
                    Location = "1A1",
                    UnitPrice = 0.0M,
                    AvailableQty = 2,
                    Rem = "GN" ,
                    OldPartFK = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },

            });*/

        }

        public void SeedDataRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new List<Role>
            {
                new Role() {RoleName = "Admin", Id = 1},
                new Role() {RoleName = "User", Id = 2}
            });
        }
        public void SeedDataUser(ModelBuilder modelBuilder)
        {
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
                    RoleFk = 1,
                    //Role = new Role(){Id = 1, RoleName ="Admin" },
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
                    RoleFk = 2,
                    DateUpdate = DateTime.Now
                }

            });
        }
        public void SeedDataCustomer(ModelBuilder modelBuilder)
        {
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
        }
        public void SeedDataInventory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>().HasData(new List<Inventory>
            {
                new Inventory()
                {
                    Id = 1,
                    PartNumber = "15613-EV015",
                    Description = "OIL FILTER",
                    Location = "1A1",
                    UnitPrice = 0.0M,
                    AvailableQty = 5,
                    Rem = "GN" ,
                    OldPart = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },
                new Inventory()
                {
                    Id = 2,
                    PartNumber = "23304-EV052",
                    Description = "FUEL FILTER",
                    Location = "1A1",
                    UnitPrice = 0.0M,
                    AvailableQty = 3,
                    Rem = "GN" ,
                    OldPartFK = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },
                new Inventory()
                {
                    Id = 3,
                    PartNumber = "23304-78091",
                    Description = "FUEL FILTER",
                    Location = "1A1",
                    UnitPrice = 0.0M,
                    AvailableQty = 2,
                    Rem = "GN" ,
                    OldPartFK = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },

            });
        }
        public void SeedDataOldPart(ModelBuilder modelBuilder) { }
        public void SeedDataInvoice(ModelBuilder modelBuilder) { }
        public void SeedDataInvoiceItem(ModelBuilder modelBuilder) { }
        public void SeedDataQuotation(ModelBuilder modelBuilder) { }
        public void SeedDataQuotationItem(ModelBuilder modelBuilder) { }


    }
}
