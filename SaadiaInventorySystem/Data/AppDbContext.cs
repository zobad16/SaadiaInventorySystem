using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public DbSet<Invoice> Invoices { get; set; }
        //public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        //public DbSet<QuotationItem> QuotationItems { get; set; }
        
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                .AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseMySql("server=localhost;database=saadiatrading;user=root;password=Gtlfx125;TreatTinyAsBoolean=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Inventory>()
                .HasOne(o => o.OldPart)
                .WithOne()
                .HasForeignKey<Inventory>(fk => fk.OldPartFK)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //OrderItem composite key
            //OrderId and InventoryId
            modelBuilder.Entity<OrderItem>()
                .HasKey(qt => new { qt.OrderId, qt.InventoryId });

            //Order and OrderItem
            //1 Order Has many Order Items
            //OrderItems has foreign key OrderId
            modelBuilder.Entity<OrderItem>()
                .HasOne(qt => qt.Order)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(fk => fk.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            
            //OrderItem -> Inventory
            modelBuilder.Entity<OrderItem>()
                .HasOne<Inventory>(inventory => inventory.Inventory)
                .WithMany()
                .HasForeignKey(orderitem => orderitem.InventoryId);
            
            //Quotaion Foreign key with Order Item and Customer
            //Quotation -> Customer
            modelBuilder.Entity<Quotation>()
                .HasOne<Customer>(qt => qt.Customer )
                .WithMany()
                .HasForeignKey(fk=> fk.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            //Quotation -> Order
            //Quoation has 1 Order
            //Quotation => Order foreign key on OrderId
            modelBuilder.Entity<Quotation>()
                .HasOne<Order>(qt => qt.Order)
                .WithOne()
                .HasForeignKey<Quotation>(quotation=> quotation.OrderId);
            modelBuilder.Entity<Customer>()
                .HasMany<Quotation>()
                .WithOne(i => i.Customer)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Invoice>()
                .HasOne<Customer>(qt => qt.Customer )
                .WithOne()
                .HasForeignKey<Invoice>(fk=> fk.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Customer>()
                .HasMany<Invoice>()
                .WithOne(i => i.Customer)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Invoice>()
               .HasOne<Order>(qt => qt.Order)
               .WithOne()
               .HasForeignKey<Invoice>(invoice => invoice.OrderId);
            
            

            modelBuilder.Entity<User>()
                .HasOne<Role>(a => a.Role)
                .WithMany()
                .HasForeignKey(b => b.RoleFk)
                ;
                //.OnDelete(DeleteBehavior.;
            
            SeedDataRole(modelBuilder);
            SeedDataCustomer(modelBuilder);
            SeedDataUser(modelBuilder);
            SeedDataInventory(modelBuilder);
            SeedDataOrder(modelBuilder);
            SeedDataOrderItems(modelBuilder);
            SeedDataQuotation(modelBuilder);
            //Seed Master data.

        }

        public void SeedDataRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new List<Role>
            {
                new Role() {RoleName = "Admin", Id = 1, IsActive =1 },
                new Role() {RoleName = "User", Id = 2,IsActive =1}
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
                    CompanyName = "QTS",
                    IsActive = 1
                },
                new Customer()
                {
                    Id= 2 ,
                    FirstName = "Hamza",
                    LastName="Sheikh",
                    EmailAddress="hamza@gmail.com",
                    CompanyName="Saadia",
                    IsActive = 1
                }

            });
        }
        public void SeedDataInventory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OldPart>().HasData(new List<OldPart>
            {
                new OldPart{ Id =1, PartNumber="9828-52115"}

            });
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
                new Inventory()
                {
                    Id = 4,
                    PartNumber = "S1560-71480",
                    Description = "OIL FILTER",
                    Location = "1A1",
                    UnitPrice = 0.0M,
                    AvailableQty = 1,
                    Rem = "GN" ,
                    OldPartFK = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },
                new Inventory()
                {
                    Id = 5,
                    PartNumber = "23304-78110",
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
                new Inventory()
                {
                    Id = 6,
                    PartNumber = "15607-2250",
                    Description = "OIL FILTER",
                    Location = "1A1",
                    UnitPrice = 0.0M,
                    AvailableQty = 11,
                    Rem = "NG AZUMI" ,
                    OldPartFK = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },
                new Inventory()
                {
                    Id = 7,
                    PartNumber = "15607-2210",
                    Description = "OIL FILTER",
                    Location = "1A1",
                    UnitPrice = 0.0M,
                    AvailableQty = 6,
                    Rem = "NG MARINA" ,
                    OldPartFK = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },
                new Inventory()
                {
                    Id = 8,
                    PartNumber = "SZ319-40002",
                    Description = "OIL SEAL",
                    Location = "1B1",
                    UnitPrice = 0.0M,
                    AvailableQty = 10,
                    Rem = "GN HINO" ,
                    OldPartFK = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },
                new Inventory()
                {
                    Id = 9,
                    PartNumber = "SZ311-48002",
                    Description = "OIL SEAL",
                    Location = "1B1",
                    UnitPrice = 0.0M,
                    AvailableQty = 4,
                    Rem = "GN" ,
                    OldPartFK = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },
                new Inventory()
                {
                    Id = 10,
                    PartNumber = "SZ311-3700",
                    Description = "OIL SEAL",
                    Location = "1B1",
                    UnitPrice = 0.0M,
                    AvailableQty = 2,
                    Rem = "GN" ,
                    OldPartFK = null,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },
                new Inventory()
                {
                    Id = 11,
                    PartNumber = "SZ311-52004",
                    Description = "OIL SEAL",
                    Location = "1B1",
                    UnitPrice = 0.0M,
                    AvailableQty = 2,
                    Rem = "GN" ,
                    OldPartFK = 1,
                    IsActive = 1,
                    DateCreated = DateTime.Now,
                    DateUpdate = DateTime.Now
                },

            });
        }
        public void SeedDataOldPart(ModelBuilder modelBuilder) { }
        public void SeedDataInvoice(ModelBuilder modelBuilder) { }
        public void SeedDataInvoiceItem(ModelBuilder modelBuilder) { }
        public void SeedDataQuotation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quotation>().HasData(new List<Quotation>()
            {
                new Quotation()
                { 
                    Id = 1,
                    CustomerId = 2,
                    OrderId = 1,
                    ReferenceNumber = "NISSAN.TFA430K00725",
                    IsActive =1,
                    Attn = "Negotiation",
                    VAT = 5.00,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    MS = "SAADIA TRADING CO.LLC",
                    OfferedDiscount = 0.00,
                    Message = "Dear Sir.Thank you for your inquiry. We are pleased to quote our best prices as follows:",
                    Note = "Delivery: 5 days on order confirmation., Price quoted Net in UAE Dirhams, ex-warehouse.\nMake: Genuine Part\nValidity: 1 week \nPayment: 100% cash on order confirmation.\nAwaiting your valued order & assuring you of our best services always.",
                    

                }

            });

        }
        public void SeedDataOrder(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Order>().HasData(new List<Order>()
            {
                new Order()
                {
                    Id =1,
                    DateCreated= DateTime.Now,
                    DateUpdated= DateTime.Now,
                },
                new Order()
                {
                    Id =2,
                    DateCreated= DateTime.Now,
                    DateUpdated= DateTime.Now,
                }

            }); 
        }
        public void SeedDataOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasData(new List<OrderItem>() 
            {
                new OrderItem()
                {
                    InventoryId=10,
                    OrderId = 1,
                    OfferedPrice= 200,
                    OrderQty = 2,
                    Total = 400.00

                },
                new OrderItem()
                {
                    InventoryId=3,
                    OrderId = 1,
                    OfferedPrice= 200,
                    OrderQty = 2,
                    Total = 400.00

                },
                new OrderItem()
                {
                    InventoryId=3,
                    OrderId = 2,
                    OfferedPrice= 200,
                    OrderQty = 2,
                    Total = 400.00

                },
                new OrderItem()
                {
                    InventoryId=10,
                    OrderId = 2,
                    OfferedPrice= 200,
                    OrderQty = 2,
                    Total = 400.00

                }
            });


        }


    }
}
