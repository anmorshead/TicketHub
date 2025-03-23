using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TicketHub
{
    public class PurchaseInfo
    {
        [Required(ErrorMessage = "Concert ID is required.")]
        public int ConcertId { get; set; } = 0;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        public int Quantity { get; set; } = 0;

        [Required(ErrorMessage = "Credit card number is required.")]
        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        public string CreditCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration date is required.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/(\d{2}|\d{4})$", ErrorMessage = "Expiration must be in MM/YY or MM/YYYY format.")]
        public string Expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security code is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Security code must be 3 or 4 digits.")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required.")]
        public string Province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^[A-Za-z0-9\s-]{5,10}$", ErrorMessage = "Invalid postal code format.")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty;
    }
}

