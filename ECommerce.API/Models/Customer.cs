using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Models
{
    [Table("Address", Schema = "Customer")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public int? AddressTypeId { get; set; }
        public int? CustomerId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string? FullAddress { get; set; }
        public string? PostalCode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? AddedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? RemovedOn { get; set; }
    }

    [Table("AddressType", Schema = "Customer")]
    public class AddressType
    {
        [Key]
        public int? AddressTypeId { get; set; }
        public string? Name { get; set; }
    }

    [Table("Details", Schema = "Customer")]
    public class CustomerDetails
    {
        [Key]
        public int CustomerId { get; set; }
        public int RoleId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool? IsEmailVerfied { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? IsPhoneNumberVerfied { get; set; }
        public string? Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //public int? AddressId { get; set; }
        public int? GenderId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? JoinedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
