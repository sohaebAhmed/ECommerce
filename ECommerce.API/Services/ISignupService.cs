using ECommerce.API.Data;
using ECommerce.API.Models;
using ECommerce.API.Utility;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Services
{
    public class SignupService : ISignupService
    {
        private readonly AppDbContext _context;

        public SignupService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(SignUpDTO request)
        {
            if (request.Role.ToLower() == "customer")
            {
                var customer = new CustomerDetails
                {
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Password = request.Password,
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    GenderId = request.GenderId,
                    JoinedOn = DateTime.UtcNow,
                    IsActive = true,
                    IsEmailVerfied = false,
                    IsPhoneNumberVerfied = false,
                    RoleId = 3
                };

                _context.CustomerDetails.Add(customer);
                await _context.SaveChangesAsync(); // So that customer ID is generated

                var address = new Address
                {
                    CustomerId = customer.CustomerId,
                    FullAddress = request.FullAddress,
                    PostalCode = request.PostalCode,
                    CountryId = request.CountryId,
                    StateId = request.StateId,
                    CityId = request.CityId,
                    IsActive = true,
                    IsDeleted = false,
                    AddedOn = DateTime.UtcNow
                };

                _context.CustomerAddresses.Add(address);
                await _context.SaveChangesAsync();

                // Update AddressId in customer
                customer.AddressId = address.AddressId;
                _context.CustomerDetails.Update(customer);
            }
            else if (request.Role.ToLower() == "merchant")
            {
                var merchant = new MerchantDetails
                {
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Password = request.Password,
                    Name = request.Name,
                    WebsiteURL = request.WebsiteURL,
                    JoinedOn = DateTime.UtcNow,
                    IsActive = true,
                    IsEmailVerified = false,
                    IsPhoneNumberVerified = false,
                    RoleID = 2
                };

                _context.MerchantDetails.Add(merchant);
                await _context.SaveChangesAsync(); // To get MerchantId

                var address = new MerchantAddress
                {
                    MerchantId = merchant.MerchantId,
                    FullAddress = request.FullAddress,
                    PostalCode = request.PostalCode,
                    CountryId = request.CountryId,
                    StateId = request.StateId,
                    CityId = request.CityId
                };

                _context.MerchantAddresses.Add(address);
                await _context.SaveChangesAsync();

                // Update AddressId in merchant
                merchant.AddressId = address.AddressId;
                _context.MerchantDetails.Update(merchant);
            }
            else
            {
                return false;
            }

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.CustomerDetails.AnyAsync(x => x.Email == email)
                || await _context.MerchantDetails.AnyAsync(x => x.Email == email);
        }
    }
    public interface ISignupService
    {
        Task<bool> RegisterAsync(SignUpDTO request);
        Task<bool> EmailExistsAsync(string email);
    }
}