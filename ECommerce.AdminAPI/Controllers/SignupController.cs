using ECommerce.AdminAPI.Models;
using ECommerce.AdminAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.AdminAPI.Utility;

namespace ECommerce.AdminAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignupController : ControllerBase
    {
        private readonly ISignupService _signupService;

        public SignupController(ISignupService signupService)
        {
            _signupService = signupService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignUpDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!Utils.IsValidEmail(request.Email))
                return BadRequest("Invalid email address.");

            if (await _signupService.EmailExistsAsync(request.Email))
                return BadRequest("Email is already registered.");

            if (!Utils.IsValidPassword(request.Password))
                return BadRequest("Password must be at least 8 characters long and contain uppercase, lowercase, digit, and special character (!,@,#,$,^,*)");

            if (!string.IsNullOrWhiteSpace(request.WebsiteURL) && !Utils.IsValidUrl(request.WebsiteURL))
                return BadRequest("Invalid Website URL.");

            if (!Utils.IsValidPhoneNumber(request.PhoneNumber))
                return BadRequest("Phone number must be exactly 10 digits.");

            request.PhoneNumber = Utils.FormatPhoneNumber(request.PhoneNumber);

            if (!Utils.IsValidPostalCode(request.PostalCode))
                return BadRequest("Postal code must be exactly 6 digits.");

            var result = await _signupService.RegisterAsync(request);
            
            if (!result)
                return BadRequest("Failed to register. Try again.");

            return Ok("Registration successful.");
        }        
    }
}