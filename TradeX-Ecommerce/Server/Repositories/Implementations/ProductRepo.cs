namespace TradeXEcommerce.Server.Repositories.Implementations;

public class ProductRepo : IProductRepo
{
    private readonly AppDbContext appDbContext;

    public ProductRepo(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<ServiceModel> AddProduct(Product NewProduct)
    {
        var Response = new ServiceModel();
        if (NewProduct != null)
        {
            try
            {
                appDbContext.Products.Add(NewProduct);
                await appDbContext.SaveChangesAsync();
                Response.SingleProduct = NewProduct;
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
            Response.Message = "Sorry new product object is empty!";
            Response.CssClass = "warning";
            Response.SingleProduct = null!;
            return Response;
        }
    }

    public async Task<ServiceModel> DeleteProduct(int ProductId)
    {
        var response = new ServiceModel();
        var product = await GetProduct(ProductId);
        if (product.SingleProduct != null)
        {
            appDbContext.Products.Remove(product.SingleProduct);
            await appDbContext.SaveChangesAsync();
            response.Message = "Product Deleted!";
            response.CssClass = "success fw-bold";
            response.SingleProduct = product.SingleProduct;
            var products = await GetProducts();
            response.ProductList = products.ProductList;
        }
        else
        {
            response.Message = product.Message;
            response.CssClass = product.CssClass;
        }
        return response;
    }

    public async Task<ServiceModel> GetProduct(int ProductId)
    {
        var Response = new ServiceModel();
        if (ProductId > 0)
        {
            try
            {
                var product = await appDbContext.Products.SingleOrDefaultAsync(p => p.Id == ProductId);
                if (product != null)
                {
                    Response.SingleProduct = product;
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
                    Response.SingleProduct = null!;
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
            Response.SingleProduct = null!;
            return Response;
        }
    }

    public async Task<ServiceModel> GetProducts()
    {
        var Response = new ServiceModel();
        try
        {
            var products = await appDbContext.Products.ToListAsync();
            if (products != null)
            {
                Response.ProductList = products;
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
                Response.ProductList = null!;
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

    public async Task<ServiceModel> UpdateProduct(Product NewProduct)
    {
        var response = new ServiceModel();
        if(NewProduct != null)
        {
            var product = await GetProduct(NewProduct.Id);
            if (product.SingleProduct != null)
            {
                product.SingleProduct.Name = NewProduct.Name;
                product.SingleProduct.OriginalPrice = NewProduct.OriginalPrice;
                product.SingleProduct.NewPrice = NewProduct.NewPrice;
                product.SingleProduct.Description = NewProduct.Description;
                product.SingleProduct.Description = NewProduct.Description;
                product.SingleProduct.Quantity = NewProduct.Quantity;
                product.SingleProduct.Image = NewProduct.Image;
                await appDbContext.SaveChangesAsync();
                response.Message = "Product updated successfully";
                response.Success = true;
                response.CssClass = "success fw-bold";
                response.SingleProduct = product.SingleProduct;
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
