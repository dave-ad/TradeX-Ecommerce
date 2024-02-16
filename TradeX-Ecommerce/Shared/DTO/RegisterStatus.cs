namespace TradeXEcommerce.Shared.DTO;

public class RegisterStatus
{
    public bool Successful { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}