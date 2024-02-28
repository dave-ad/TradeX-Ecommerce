using TradeXEcommerce.Shared.DTO;
using static TradeXEcommerce.Shared.DTO.ServiceResponses;

namespace TradeXEcommerce.Shared.Contracts;

public interface IUserAccount
{
    Task<GeneralResponse> CreateAccount(UserDTO userDTO);
    Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
}
