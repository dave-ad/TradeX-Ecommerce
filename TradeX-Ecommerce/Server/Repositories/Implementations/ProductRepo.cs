namespace TradeXEcommerce.Server.Repositories.Implementations;

public class ProductRepo : IProductRepo
{
    private readonly AppDbContext appDbContext;

    public ProductRepo(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<ServiceModel<Product>> AddProduct(Product newProduct)
    {
        var Response = new ServiceModel<Product>();
        if (newProduct != null)
        {
            try
            {
                appDbContext.Products.Add(newProduct);
                await appDbContext.SaveChangesAsync();
                Response.Single = newProduct;
                Response.Success = true;
                Response.Message = "Product added successfully!";
                Response.CssClass = "success";
                return Response;
            }
            catch (Exception exMessage)
            {
                Response.CssClass = "danger";
                Response.Message = exMessage.Message.ToString();
                return Response;
            }
        }
        else
        {
            Response.Success = false;
            Response.Message = "Sorry, new product object is empty!";
            Response.CssClass = "warning";
            Response.Single = null!;
            return Response;
        }
    }

    public async Task<ServiceModel<Product>> DeleteProduct(int ProductId)
    {
        var response = new ServiceModel<Product>();
        var product = await GetProduct(ProductId);
        if (product.Single != null)
        {
            appDbContext.Products.Remove(product.Single);
            await appDbContext.SaveChangesAsync();
            response.Message = "Product Deleted!";
            response.CssClass = "success fw-bold";
            response.Single = product.Single;
            var products = await GetProducts();
            response.List = products.List;
        }
        else
        {
            response.Message = product.Message;
            response.CssClass = product.CssClass;
        }
        return response;
    }

    public async Task<ServiceModel<Product>> GetProduct(int ProductId)
    {
        var Response = new ServiceModel<Product>();
        if (ProductId > 0)
        {
            try
            {
                var product = await appDbContext.Products.SingleOrDefaultAsync(p => p.Id == ProductId);
                if (product != null)
                {
                    Response.Single = product;
                    Response.Success = true;
                    Response.Message = "Product found!";
                    Response.CssClass = "success";
                    return Response;
                }
                else
                {
                    Response.Success = false;
                    Response.Message = "Sorry product you are looking for doesn't exist!";
                    Response.CssClass = "info";
                    Response.Single = null!;
                    return Response;
                }

            }
            catch (Exception exMessage)
            {
                Response.CssClass = "danger";
                Response.Message = exMessage.Message.ToString();
                return Response;
            }
        }
        else
        {
            Response.Success = false;
            Response.Message = "Sorry New product object is empty!";
            Response.CssClass = "warning";
            Response.Single = null!;
            return Response;
        }
    }

    public async Task<ServiceModel<Product>> GetProductByCategory(string name)
    {
        var Response = new ServiceModel<Product>();
        if (name != null)
        {
            try
            {
                var product = await appDbContext.Products
                    .Where(p => p.Category!.Name == name.ToLower()).ToListAsync();
                if (product != null)
                {
                    Response.List = product;
                    Response.Success = true;
                    Response.Message = "Product found!";
                    Response.CssClass = "success";
                    return Response;
                }
                else
                {
                    Response.Success = false;
                    Response.Message = "Sorry product you are looking for doesn't exist!";
                    Response.CssClass = "info";
                    Response.Single = null!;
                    return Response;
                }

            }
            catch (Exception exMessage)
            {
                Response.CssClass = "danger";
                Response.Message = exMessage.Message.ToString();
                return Response;
            }
        }
        else
        {
            Response.Success = false;
            Response.Message = "Sorry New product object is empty!";
            Response.CssClass = "warning";
            Response.Single = null!;
            return Response;
        }
    }

    public async Task<ServiceModel<Product>> GetProducts()
    {
        var Response = new ServiceModel<Product>();
        try
        {
            var products = await appDbContext.Products.ToListAsync();
            if (products != null)
            {
                Response.List = products;
                Response.Success = true;
                Response.Message = "Products found!";
                Response.CssClass = "success";
                return Response;
            }
            else
            {
                Response.Success = false;
                Response.Message = "Sorry No products found!";
                Response.CssClass = "info";
                Response.List = null!;
                return Response;
            }

        }
        catch (Exception exMessage)
        {
            Response.CssClass = "danger";
            Response.Message = exMessage.Message.ToString();
            return Response;
        }
    }

    public async Task<ServiceModel<Product>> UpdateProduct(Product NewProduct)
    {
        var response = new ServiceModel<Product>();
        if (NewProduct != null)
        {
            var product = await GetProduct(NewProduct.Id);
            if (product.Single != null)
            {
                product.Single.Name = NewProduct.Name;
                product.Single.OriginalPrice = NewProduct.OriginalPrice;
                product.Single.NewPrice = NewProduct.NewPrice;
                product.Single.Description = NewProduct.Description;
                product.Single.Description = NewProduct.Description;
                product.Single.Quantity = NewProduct.Quantity;
                product.Single.Image = NewProduct.Image;
                await appDbContext.SaveChangesAsync();
                response.Message = "Product updated successfully";
                response.Success = true;
                response.CssClass = "success fw-bold";
                response.Single = product.Single;
            }
            else
            {
                response.Message = "Sorry product not found";
                response.Success = false;
                response.CssClass = "danger fw-bold";
            }
        }
        else
        {
            response.Message = "Sorry product object is empty";
            response.Success = false;
            response.CssClass = "danger fw-bold";
        }
        return response;
    }
}
