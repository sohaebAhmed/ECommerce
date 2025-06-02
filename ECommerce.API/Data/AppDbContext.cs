using ECommerce.AdminAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.AdminAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // 🏙️ Common Schema
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<State> States { get; set; }

        // 👤 Customer Schema
        public DbSet<Address> CustomerAddresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }

        // 🏪 Merchant Schema
        public DbSet<MerchantAddress> MerchantAddresses { get; set; }
        public DbSet<MerchantDetails> MerchantDetails { get; set; }

        // 🛡️ User Schema
        public DbSet<Role> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensures entity class names match the schema and table (in case needed explicitly)
            modelBuilder.Entity<City>().ToTable("Cities", "Common");
            modelBuilder.Entity<Country>().ToTable("Countries", "Common");
            modelBuilder.Entity<Gender>().ToTable("Gender", "Common");
            modelBuilder.Entity<Season>().ToTable("Seasons", "Common");
            modelBuilder.Entity<State>().ToTable("States", "Common");

            modelBuilder.Entity<Address>().ToTable("Address", "Customer");
            modelBuilder.Entity<AddressType>().ToTable("AddressType", "Customer");
            modelBuilder.Entity<CustomerDetails>().ToTable("Details", "Customer");

            modelBuilder.Entity<MerchantAddress>().ToTable("Address", "Merchant");
            modelBuilder.Entity<MerchantDetails>().ToTable("Details", "Merchant");

            modelBuilder.Entity<Role>().ToTable("Roles", "User");
        }
    }
}