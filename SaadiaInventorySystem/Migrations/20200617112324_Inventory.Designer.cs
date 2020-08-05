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
    [Migration("20200617112324_Inventory")]
    partial class Inventory
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

                    b.Property<string>("ComapnyName")
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
                            ComapnyName = "QTS",
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
                            ComapnyName = "Saadia",
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(4793),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(5212),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6115),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6126),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6141),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6142),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6144),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6144),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6146),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6147),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6155),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6156),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6158),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6159),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6160),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6161),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6163),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6164),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6167),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6168),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6170),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6171),
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

            modelBuilder.Entity("SaadiaInventorySystem.Model.Quotation", b =>
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

                    b.ToTable("Quotations");
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.QuotationItem", b =>
                {
                    b.Property<int>("QuotationId")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("QuotationId", "InventoryId");

                    b.HasIndex("InventoryId");

                    b.ToTable("QuotationItems");
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 813, DateTimeKind.Local).AddTicks(9232),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 814, DateTimeKind.Local).AddTicks(8251),
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
                            DateCreated = new DateTime(2020, 6, 17, 14, 23, 23, 814, DateTimeKind.Local).AddTicks(8781),
                            DateUpdate = new DateTime(2020, 6, 17, 14, 23, 23, 814, DateTimeKind.Local).AddTicks(8801),
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

            modelBuilder.Entity("SaadiaInventorySystem.Model.Quotation", b =>
                {
                    b.HasOne("SaadiaInventorySystem.Model.Customer", "Customer")
                        .WithOne()
                        .HasForeignKey("SaadiaInventorySystem.Model.Quotation", "CustomerId")
                        .IsRequired();
                });

            modelBuilder.Entity("SaadiaInventorySystem.Model.QuotationItem", b =>
                {
                    b.HasOne("SaadiaInventorySystem.Model.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaadiaInventorySystem.Model.Quotation", "Quotation")
                        .WithMany("Items")
                        .HasForeignKey("QuotationId")
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