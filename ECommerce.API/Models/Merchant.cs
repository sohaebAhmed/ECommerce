using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.AdminAPI.Models
{
    [Table("Address", Schema = "Merchant")]
    public class MerchantAddress
    {
        [Key]
        public int AddressId { get; set; }
        public int? MerchantId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string? FullAddress { get; set; }
        public string? PostalCode { get; set; }
    }

    [Table("Details", Schema = "Merchant")]
    public class MerchantDetails
    {
        [Key]
        public int MerchantId { get; set; }
        public int? RoleID { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
        public bool? IsEmailVerified { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public bool? IsPhoneNumberVerified { get; set; }
        public string Password { get; set; } = null!;
        public int? AddressId { get; set; }
        public string? WebsiteURL { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? JoinedOn { get; set; }
    }
}