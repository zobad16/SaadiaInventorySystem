﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaadiaInventorySystem.Data;

namespace SaadiaInventorySystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200702100349_ChangesToQuotationTable")]
    partial class ChangesToQuotationTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SaadiaInventorySystem.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CompanyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Postcode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Trn")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "QTS",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "zobad.mahmood@gmail.com",
                            FirstName = "Zobad",
                            IsActive = 1,
                            LastName = "Mahmood"
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "Saadia",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "hamza@gmail.com",
                            FirstName = "Hamza",
                            IsActive = 1,
                            LastName = "Sheikh"
                        });
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AvailableQty")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("OldPartFK")
                        .HasColumnType("int");

                    b.Property<string>("PartNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Rem")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("Id");

                    b.HasIndex("OldPartFK")
                        .IsUnique();

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableQty = 5,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 891, DateTimeKind.Local).AddTicks(8060),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 891, DateTimeKind.Local).AddTicks(8960),
                            Description = "OIL FILTER",
                            IsActive = 1,
                            Location = "1A1",
                            PartNumber = "15613-EV015",
                            Rem = "GN",
                            UnitPrice = 0.0m
                        },
                        new
                        {
                            Id = 2,
                            AvailableQty = 3,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1106),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1133),
                            Description = "FUEL FILTER",
                            IsActive = 1,
                            Location = "1A1",
                            PartNumber = "23304-EV052",
                            Rem = "GN",
                            UnitPrice = 0.0m
                        },
                        new
                        {
                            Id = 3,
                            AvailableQty = 2,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1176),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1181),
                            Description = "FUEL FILTER",
                            IsActive = 1,
                            Location = "1A1",
                            PartNumber = "23304-78091",
                            Rem = "GN",
                            UnitPrice = 0.0m
                        },
                        new
                        {
                            Id = 4,
                            AvailableQty = 1,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1188),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1192),
                            Description = "OIL FILTER",
                            IsActive = 1,
                            Location = "1A1",
                            PartNumber = "S1560-71480",
                            Rem = "GN",
                            UnitPrice = 0.0m
                        },
                        new
                        {
                            Id = 5,
                            AvailableQty = 2,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1198),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1203),
                            Description = "FUEL FILTER",
                            IsActive = 1,
                            Location = "1A1",
                            PartNumber = "23304-78110",
                            Rem = "GN",
                            UnitPrice = 0.0m
                        },
                        new
                        {
                            Id = 6,
                            AvailableQty = 11,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1223),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1225),
                            Description = "OIL FILTER",
                            IsActive = 1,
                            Location = "1A1",
                            PartNumber = "15607-2250",
                            Rem = "NG AZUMI",
                            UnitPrice = 0.0m
                        },
                        new
                        {
                            Id = 7,
                            AvailableQty = 6,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1232),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1236),
                            Description = "OIL FILTER",
                            IsActive = 1,
                            Location = "1A1",
                            PartNumber = "15607-2210",
                            Rem = "NG MARINA",
                            UnitPrice = 0.0m
                        },
                        new
                        {
                            Id = 8,
                            AvailableQty = 10,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1243),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1248),
                            Description = "OIL SEAL",
                            IsActive = 1,
                            Location = "1B1",
                            PartNumber = "SZ319-40002",
                            Rem = "GN HINO",
                            UnitPrice = 0.0m
                        },
                        new
                        {
                            Id = 9,
                            AvailableQty = 4,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1275),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1279),
                            Description = "OIL SEAL",
                            IsActive = 1,
                            Location = "1B1",
                            PartNumber = "SZ311-48002",
                            Rem = "GN",
                            UnitPrice = 0.0m
                        },
                        new
                        {
                            Id = 10,
                            AvailableQty = 2,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1289),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1291),
                            Description = "OIL SEAL",
                            IsActive = 1,
                            Location = "1B1",
                            PartNumber = "SZ311-3700",
                            Rem = "GN",
                            UnitPrice = 0.0m
                        },
                        new
                        {
                            Id = 11,
                            AvailableQty = 2,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1298),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1300),
                            Description = "OIL SEAL",
                            IsActive = 1,
                            Location = "1B1",
                            OldPartFK = 1,
                            PartNumber = "SZ311-52004",
                            Rem = "GN",
                            UnitPrice = 0.0m
                        });
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.InvoiceItem", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId", "InventoryId");

                    b.HasIndex("InventoryId");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.OldPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PartNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Rem")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("OldParts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = 0,
                            PartNumber = "9828-52115"
                        });
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(8679),
                            DateUpdated = new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(9342),
                            IsActive = 0
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 893, DateTimeKind.Local).AddTicks(32),
                            DateUpdated = new DateTime(2020, 7, 2, 13, 3, 48, 893, DateTimeKind.Local).AddTicks(77),
                            IsActive = 0
                        });
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<double>("OfferedPrice")
                        .HasColumnType("double");

                    b.Property<int>("OrderQty")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("double");

                    b.HasKey("OrderId", "InventoryId");

                    b.HasIndex("InventoryId");

                    b.ToTable("OrderItem");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            InventoryId = 10,
                            OfferedPrice = 200.0,
                            OrderQty = 2,
                            Total = 400.0
                        },
                        new
                        {
                            OrderId = 1,
                            InventoryId = 3,
                            OfferedPrice = 200.0,
                            OrderQty = 2,
                            Total = 400.0
                        },
                        new
                        {
                            OrderId = 2,
                            InventoryId = 3,
                            OfferedPrice = 200.0,
                            OrderQty = 2,
                            Total = 400.0
                        },
                        new
                        {
                            OrderId = 2,
                            InventoryId = 10,
                            OfferedPrice = 200.0,
                            OrderQty = 2,
                            Total = 400.0
                        });
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.Quotation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Attn")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("MS")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Message")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("OfferedDiscount")
                        .HasColumnType("double");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("QuotationNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("VAT")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Quotations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Attn = "Negotiation",
                            CustomerId = 2,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 894, DateTimeKind.Local).AddTicks(8592),
                            DateUpdated = new DateTime(2020, 7, 2, 13, 3, 48, 894, DateTimeKind.Local).AddTicks(9266),
                            IsActive = 1,
                            MS = "SAADIA TRADING CO.LLC",
                            Message = @"Delivery: 5 days on order confirmation., Price quoted Net in UAE Dirhams, ex-warehouse.
Make: Genuine Part
Validity: 1 week 
Payment: 100% cash on order confirmation.
Awaiting your valued order & assuring you of our best services always.",
                            Note = "Dear Sir.Thank you for your inquiry. We are pleased to quote our best prices as follows:",
                            OfferedDiscount = 0.0,
                            OrderId = 1,
                            ReferenceNumber = "NISSAN.TFA430K00725",
                            VAT = 5.0
                        });
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = 1,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("RoleFk")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleFk");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 885, DateTimeKind.Local).AddTicks(9451),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 887, DateTimeKind.Local).AddTicks(1957),
                            FirstName = "Zobad",
                            IsActive = 1,
                            LastName = "Mahmood",
                            Password = "1234",
                            RoleFk = 1,
                            UserName = "zobad"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2020, 7, 2, 13, 3, 48, 887, DateTimeKind.Local).AddTicks(3224),
                            DateUpdate = new DateTime(2020, 7, 2, 13, 3, 48, 887, DateTimeKind.Local).AddTicks(3269),
                            FirstName = "Hamza",
                            IsActive = 1,
                            LastName = "Sheikh",
                            Password = "1234",
                            RoleFk = 2,
                            UserName = "hamza"
                        });
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.Inventory", b =>
                {
                    b.HasOne("SaadiaInventorySystem.Model.OldPart", "OldPart")
                        .WithOne()
                        .HasForeignKey("SaadiaInventorySystem.Model.Inventory", "OldPartFK");
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.Invoice", b =>
                {
                    b.HasOne("SaadiaInventorySystem.Model.Customer", "Customer")
                        .WithOne()
                        .HasForeignKey("SaadiaInventorySystem.Model.Invoice", "CustomerId")
                        .IsRequired();
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.InvoiceItem", b =>
                {
                    b.HasOne("SaadiaInventorySystem.Model.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaadiaInventorySystem.Model.Invoice", "Invoice")
                        .WithMany("Item")
                        .HasForeignKey("InvoiceId")
                        .IsRequired();
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.OrderItem", b =>
                {
                    b.HasOne("SaadiaInventorySystem.Model.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaadiaInventorySystem.Model.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.Quotation", b =>
                {
                    b.HasOne("SaadiaInventorySystem.Model.Customer", "Customer")
                        .WithOne()
                        .HasForeignKey("SaadiaInventorySystem.Model.Quotation", "CustomerId")
                        .IsRequired();

                    b.HasOne("SaadiaInventorySystem.Model.Order", "Order")
                        .WithOne()
                        .HasForeignKey("SaadiaInventorySystem.Model.Quotation", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.User", b =>
                {
                    b.HasOne("SaadiaInventorySystem.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleFk");
                });
#pragma warning restore 612, 618
        }
    }
}
