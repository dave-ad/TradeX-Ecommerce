namespace TradeXEcommerce.Server.Repositories.Interfaces;

public interface IProductRepo
{
    public Task<ServiceModel> AddProduct(Product NewProduct);
    public Task<ServiceModel> UpdateProduct(Product NewProduct);
    public Task<ServiceModel> GetProducts();
    public Task<ServiceModel> GetProduct(int ProductId);
    public Task<ServiceModel> DeleteProduct(int ProductId);
}
