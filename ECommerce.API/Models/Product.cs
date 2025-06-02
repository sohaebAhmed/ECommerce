using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Models
{
    [Table("Categories", Schema = "Product")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    [Table("ClothingSizes", Schema = "Product")]
    public class ClothingSize
    {
        [Key]
        public int SizeId { get; set; }
        public string SizeLabel { get; set; }
        public decimal? ChestCM { get; set; }
        public decimal? ChestInch { get; set; }
        public decimal? WaistCM { get; set; }
        public decimal? WaistInch { get; set; }
        public decimal? ShoulderCM { get; set; }
        public decimal? ShoulderInch { get; set; }
        public decimal? SleeveLengthCM { get; set; }
        public decimal? SleeveLengthInch { get; set; }
        public decimal? LengthCM { get; set; }
        public decimal? LengthInch { get; set; }
        public decimal? HipCM { get; set; }
        public decimal? HipInch { get; set; }
    }

    [Table("TargetAudiences", Schema = "Product")]
    public class TargetAudience
    {
        [Key]
        public int TargetAudienceId { get; set; }
        public string AudienceName { get; set; }
    }

    [Table("SubCategories", Schema = "Product")]
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
    }

    [Table("Images", Schema = "Product")]
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsPrimary { get; set; }
        public DateTime? UploadedOn { get; set; }
    }

    [Table("Variants", Schema = "Product")]
    public class ProductVariant
    {
        [Key]
        public int VariantId { get; set; }
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? ClothingSizeId { get; set; }
        public int? FootwearSizeId { get; set; }
        public int QuantityAvailable { get; set; }
        public string? SKU { get; set; }
        public bool? IsActive { get; set; }
    }

    [Table("FootwearSizes", Schema = "Product")]
    public class FootwearSize
    {
        [Key]
        public int SizeId { get; set; }
        public string SizeLabel { get; set; }
    }

    [Table("Details", Schema = "Product")]
    public class ProductDetail
    {
        [Key]
        public int ProductId { get; set; }
        public int MerchantId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int TargetAudienceId { get; set; }
        public string? BrandName { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal FinalPrice => Price - ((Price * (DiscountPercentage ?? 0)) / 100);
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}