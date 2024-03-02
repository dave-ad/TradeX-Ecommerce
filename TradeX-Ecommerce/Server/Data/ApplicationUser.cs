namespace TradeXEcommerce.Server.Data;
public class ApplicationUser : IdentityUser
{
    [Key]
    public override string Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string? FirstName { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string? LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public string? Gender { get; set; }
    
    public string? City { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }
}