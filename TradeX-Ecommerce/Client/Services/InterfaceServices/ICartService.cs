namespace TradeXEcommerce.Client.Services.InterfaceServices;

public interface ICartService
{
    Task AddToCart(CartModel cartModel);
}
