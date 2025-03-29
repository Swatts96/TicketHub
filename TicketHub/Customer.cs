using System.ComponentModel.DataAnnotations;

namespace TicketHubAPI.Models
{
    public class Customer
    {
        public int ConcertId { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; } = string.Empty;

        [Required, MinLength(2), MaxLength(100)]
        public required string FirstName { get; set; } = string.Empty;

        [Required, MinLength(2), MaxLength(100)]
        public required string LastName { get; set; } = string.Empty;

        [Required, Phone]
        public required string Phone { get; set; } = string.Empty;

        [Required, Range(1, 10)]
        public int Quantity { get; set; }  // Assume max 10 tickets per purchase

        [Required, CreditCard]
        public required string CreditCard { get; set; } = string.Empty;

        [Required, RegularExpression(@"\d{2}/\d{2}", ErrorMessage = "Expiration must be in MM/YY format")]
        public required string Expiration { get; set; } = string.Empty;

        [Required, StringLength(4, MinimumLength = 3)]
        public required string SecurityCode { get; set; } = string.Empty;

        [Required]
        public required string Address { get; set; } = string.Empty;

        [Required]
        public required string City { get; set; } = string.Empty;

        [Required]
        public required string Province { get; set; } = string.Empty;

        [Required, RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Invalid Postal Code format")]
        public required string PostalCode { get; set; } = string.Empty; // Canadian postal code format

        [Required]
        public required string Country { get; set; } = string.Empty;
    }
}
