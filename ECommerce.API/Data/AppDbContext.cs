using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // 🏙️ Common Schema
        public DbSet<City> Cities { get; set; }
        public DbSet<Color> Colors { get; set; }
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

        // 🛍️ Product Schema
        public DbSet<Category> ProductCategories { get; set; }
        public DbSet<ClothingSize> ClothingSizes { get; set; }
        public DbSet<TargetAudience> TargetAudiences { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<FootwearSize> FootwearSizes { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensures entity class names match the schema and table (in case needed explicitly)
            modelBuilder.Entity<City>().ToTable("Cities", "Common");
            modelBuilder.Entity<Color>().ToTable("Colors", "Common");
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

            modelBuilder.Entity<Category>().ToTable("Categories", "Product");
            modelBuilder.Entity<ClothingSize>().ToTable("ClothingSizes", "Product");
            modelBuilder.Entity<TargetAudience>().ToTable("TargetAudiences", "Product");
            modelBuilder.Entity<SubCategory>().ToTable("SubCategories", "Product");
            modelBuilder.Entity<ProductImage>().ToTable("Images", "Product");
            modelBuilder.Entity<ProductVariant>().ToTable("Variants", "Product");
            modelBuilder.Entity<FootwearSize>().ToTable("FootwearSizes", "Product");
            modelBuilder.Entity<ProductDetail>().ToTable("Details", "Product");
        }
    }
}