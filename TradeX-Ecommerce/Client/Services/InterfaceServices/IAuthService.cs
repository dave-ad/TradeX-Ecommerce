namespace TradeXEcommerce.Client.Services.InterfaceServices;

public interface IAuthService
{
    Task<RegisterStatus> Register(RegisterModel registerModel);
    Task<LoginStatus> Login(LoginModel loginrModel);
    Task Logout();
}
