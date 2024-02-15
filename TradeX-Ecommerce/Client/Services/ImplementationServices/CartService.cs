namespace TradeXEcommerce.Client.Services.ImplementationServices;

public class CartService : ICartService
{
    private readonly ILocalStorageService localStorageService;
    private readonly IJSRuntime jSRuntime;
    private readonly IProductService productService;

    public CartService(ILocalStorageService localStorageService, IJSRuntime jSRuntime, IProductService productService)
    {
        this.localStorageService = localStorageService;
        this.jSRuntime = jSRuntime;
        this.productService = productService;
    }

    public int Count { get; set; }

    public event Action OnChange;

    public async Task AddToCart(MyCartModel cartModel)
    {
        var MyCart = await localStorageService.GetItemAsync<List<MyCartModel>>("MyCart");
        if (MyCart == null)
        {
            MyCart = new List<MyCartModel>();
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

        Count = (await localStorageService.GetItemAsync<List<MyCartModel>>("MyCart")).Count();
        OnChange?.Invoke();
    }

    public async Task<List<CartModel>> GetCart()
    {
        var CartModel = new List<CartModel>();
        var MyCart = await localStorageService.GetItemAsync<List<MyCartModel>>("MyCart");
        if (MyCart != null)
        {
            foreach(var item in MyCart)
            {
                var product = await productService.GetProduct(item.ProductId);
                if (product != null)
                {
                    var model = new CartModel
                    {
                        ProductId = item.ProductId,
                        Quantity = item.UserQuantity,
                        Name = product.Single!.Name,
                        Image = product.Single.Image,
                        Price = product.Single.NewPrice != 0 && product.Single.NewPrice < product.Single.OriginalPrice ? 
                        product.Single.NewPrice : product.Single.OriginalPrice,
                        SubTotal = (product.Single.NewPrice != 0 && product.Single.NewPrice < product.Single.OriginalPrice ?
                        product.Single.NewPrice : product.Single.OriginalPrice) * item.UserQuantity
                    };
                    CartModel.Add(model);
                }
            }
        }
        return CartModel;
    }

    public async Task RemoveCartItem(int productId)
    {
        var MyCart = await localStorageService.GetItemAsync<List<MyCartModel>>("MyCart");
        if (MyCart != null)
        {
            var product = MyCart.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                MyCart.Remove(product);
                await localStorageService.SetItemAsync("MyCart", MyCart);

            }
        }
    }
}
