namespace TradeXEcommerce.Client.Services.InterfaceServices;

public interface ICartService
{
    event Action? OnChange;
    public int Count { get; set; }
    Task AddToCart(MyCartModel cartModel);

    Task<List<CartModel>> GetCart();

    Task RemoveCartItem(int productId);
}
