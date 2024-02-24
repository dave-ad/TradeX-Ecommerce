using Microsoft.AspNetCore.Authorization;

namespace TradeXEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepo productRepo;
    public ProductController(IProductRepo productRepo)
    {
        this.productRepo = productRepo;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("AddProduct")]
    public async Task<ActionResult<ServiceModel<Product>>> AddProduct(Product NewProduct)
    {
        return Ok(await productRepo.AddProduct(NewProduct));
    }

    [HttpGet]
    public async Task<ActionResult<ServiceModel<Product>>> GetProducts() => Ok(await productRepo.GetProducts());

    [Authorize(Roles = "Admin")]
    [HttpGet("GetProduct/{ProductId:int}")]
    public async Task<ActionResult<ServiceModel<Product>>> GetProduct(int ProductId) => Ok(await productRepo.GetProduct(ProductId));

    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteProduct/{id:int}")]
    public async Task<ActionResult<ServiceModel<Product>>> DeleteProduct(int id)
    {
        return Ok(await productRepo.DeleteProduct(id));
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("UpdateProduct")]
    public async Task<ActionResult<ServiceModel<Product>>> UpdateProduct(Product NewProduct)
    {
        return Ok(await productRepo.UpdateProduct(NewProduct));
    }

    [HttpGet("Category/{url}")]
    public async Task<ActionResult<ServiceModel<Product>>> GetProduct(string url) => Ok(await productRepo.GetProductByCategory(url));
}