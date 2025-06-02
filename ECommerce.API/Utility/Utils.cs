using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ECommerce.API.Utility
{
    public class Utils
    {
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            var hasMinimum8Chars = password.Length >= 8;
            var hasUpperChar = password.Any(char.IsUpper);
            var hasLowerChar = password.Any(char.IsLower);
            var hasNumber = password.Any(char.IsDigit);
            var hasSpecialChar = Regex.IsMatch(password, @"[!@#$^*]");

            return hasMinimum8Chars && hasUpperChar && hasLowerChar && hasNumber && hasSpecialChar;
        }
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            // Add default scheme if missing
            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "https://" + url; // Default to https
            }

            return Uri.TryCreate(url, UriKind.Absolute, out var tempUri)
                   && (tempUri.Scheme == Uri.UriSchemeHttp || tempUri.Scheme == Uri.UriSchemeHttps);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber)
                && Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }

        public static string FormatPhoneNumber(string phoneNumber)
        {
            return $"+91{phoneNumber}";
        }

        public static bool IsValidPostalCode(string postalCode)
        {
            return !string.IsNullOrWhiteSpace(postalCode)
                && Regex.IsMatch(postalCode, @"^[1-9][0-9]{5}$");
        }
    }
}