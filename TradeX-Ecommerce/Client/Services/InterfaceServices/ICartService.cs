namespace TradeXEcommerce.Client.Services.InterfaceServices;

public interface ICartService
{
    event Action OnChange;
    public int Count { get; set; }
    Task AddToCart(CartModel cartModel);
}
