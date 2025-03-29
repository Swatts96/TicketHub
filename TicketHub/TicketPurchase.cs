using System.ComponentModel.DataAnnotations;

public class TicketPurchase
{
    public int ConcertId { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, MinLength(2), MaxLength(100)]
    public string Name { get; set; }

    [Required, Phone]
    public string Phone { get; set; }

    [Required, Range(1, 10)]
    public int Quantity { get; set; }  // Assume max 10 tickets per purchase

    [Required, CreditCard]
    public string CreditCard { get; set; }

    [Required, RegularExpression(@"\d{2}/\d{2}")]
    public string Expiration { get; set; }  // MM/YY format

    [Required, StringLength(4, MinimumLength = 3)]
    public string SecurityCode { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Province { get; set; }

    [Required, RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$")]
    public string PostalCode { get; set; }  // Canadian postal code format

    [Required]
    public string Country { get; set; }
}
