namespace TradeXEcommerce.Shared.DTO;

public record UserSession(string? Id, string? FirstName, string? LastName, string? Email, string? Role)
{
    public string Name => $"{FirstName} {LastName}";
}