using Microsoft.EntityFrameworkCore;
using SaadiaInventorySystem.Model;

namespace SaadiaInventorySystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
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
        //protected override void OnModelCreating(ModelBuilder modelBuilder) { }

    }
}
