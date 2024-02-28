namespace TradeXEcommerce.Shared.DTO;

public class ServiceResponses
{
    public record class GeneralResponse(bool Flag, String Message);
    public record class LoginResponse(bool Flag, string Token, String Message);
}
