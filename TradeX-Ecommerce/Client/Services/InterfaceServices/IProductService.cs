﻿namespace TradeXEcommerce.Client.Services.InterfaceServices;

public interface IProductService
{
    public Task<ServiceModel?> AddProduct(Product NewProduct);
    public Task<ServiceModel?> GetProducts();
    public Task<ServiceModel?> GetProduct(int ProductId);
}