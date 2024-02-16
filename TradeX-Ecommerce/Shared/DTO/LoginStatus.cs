namespace TradeXEcommerce.Shared.DTO;

public class LoginStatus
{
    public bool Successful { get; set; }
    public string? Error { get; set; }
    public string? Token { get; set; }
}
