namespace TradeXEcommerce.Client.Services.InterfaceServices;

public interface IProductService
{
    public Task<ServiceModel<Product>?> AddProduct(Product NewProduct);
    public Task<ServiceModel<Product>?> UpdateProduct(Product NewProduct);
    public Task<ServiceModel<Product>?> GetProducts();
    public Task<ServiceModel<Product>?> GetProduct(int ProductId);
    public Task<ServiceModel<Product>?> GetProductByCategory(string name);
    public Task<ServiceModel<Product>?> DeleteProduct(int ProductId);
}