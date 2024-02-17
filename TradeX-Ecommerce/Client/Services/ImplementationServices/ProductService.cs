namespace TradeXEcommerce.Client.Services.ImplementationServices;

public class ProductService : IProductService
{
    private readonly HttpClient httpClient;
    public ProductService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ServiceModel<Product>?> AddProduct(Product NewProduct)
    {
        var product = await httpClient.PostAsJsonAsync("api/Product/AddProduct", NewProduct);
        return await product.Content.ReadFromJsonAsync<ServiceModel<Product>?>();
    }

    public async Task<ServiceModel<Product>?> DeleteProduct(int ProductId)
    {
        var result = await httpClient.DeleteFromJsonAsync<ServiceModel<Product>>($"api/Product/DeleteProduct/{ProductId}");
        return result;
    }

    public async Task<ServiceModel<Product>?> GetProduct(int ProductId)
    {
        var result = await httpClient.GetAsync($"api/Product/GetProduct/{ProductId}");
        return await result.Content.ReadFromJsonAsync<ServiceModel<Product>?>();
    }

    public async Task<ServiceModel<Product>?> GetProductByCategory(string url)
    {
        var result = await httpClient.GetAsync($"api/Product/Category/{url}");
        return await result.Content.ReadFromJsonAsync<ServiceModel<Product>?>();
    }

    public async Task<ServiceModel<Product>?> GetProducts()
    {
        var result = await httpClient.GetAsync("api/Product");
        return await result.Content.ReadFromJsonAsync<ServiceModel<Product>?>();
    }

    public async Task<ServiceModel<Product>?> UpdateProduct(Product NewProduct)
    {
        var result = await httpClient.PutAsJsonAsync("api/Product/UpdateProduct", NewProduct);
        return await result.Content.ReadFromJsonAsync<ServiceModel<Product>>();
    }
}
    