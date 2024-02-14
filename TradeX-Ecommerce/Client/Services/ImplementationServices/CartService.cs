
using Microsoft.JSInterop;

namespace TradeXEcommerce.Client.Services.ImplementationServices;

public class CartService : ICartService
{
    private readonly ILocalStorageService localStorageService;
    private readonly IJSRuntime jSRuntime;

    public CartService(ILocalStorageService localStorageService, IJSRuntime jSRuntime)
    {
        this.localStorageService = localStorageService;
        this.jSRuntime = jSRuntime;
    }

    public async Task AddToCart(CartModel cartModel)
    {
        var MyCart = await localStorageService.GetItemAsync<List<CartModel>>("MyCart");
        if (MyCart == null)
        {
            MyCart = new List<CartModel>();
        }

        if (cartModel != null)
        {
            var item = MyCart.FirstOrDefault(p => p.ProductId == cartModel.ProductId);
            if (item != null)
            {
                MyCart.Remove(item);
                MyCart.Add(cartModel);
                await localStorageService.SetItemAsync("MyCart", MyCart);
                await jSRuntime.InvokeVoidAsync("alert", "Product updated!");
            }
            else
            {
                MyCart.Add(cartModel);
                await localStorageService.SetItemAsync("MyCart", MyCart);
                await jSRuntime.InvokeVoidAsync("alert", "Product added to cart!");
            }
        }
        else
        {
            await jSRuntime.InvokeVoidAsync("alert", "Product cart cannot be empty!");
        }
    }
}
