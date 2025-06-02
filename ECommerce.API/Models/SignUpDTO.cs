namespace ECommerce.API.Models
{
    public class SignUpDTO
    {
        public string Role { get; set; } // "Customer" or "Merchant"

        // Common fields
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        // Customer-specific
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? GenderId { get; set; }

        // Merchant-specific
        public string Name { get; set; }
        public string WebsiteURL { get; set; }

        // Shared Address (optional to start with)
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string FullAddress { get; set; }
        public string PostalCode { get; set; }

    }
}