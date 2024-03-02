using TradeXEcommerce.Server.Repositories.Implementations;

namespace TradeXEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepo productRepo;
    private readonly ICategoryRepo categoryRepo;
    public ProductController(IProductRepo productRepo, ICategoryRepo categoryRepo)
    {
        this.productRepo = productRepo;
        this.categoryRepo = categoryRepo;
    }

    //[Authorize(Roles = "Admin")]
    [HttpPost("AddProduct")]
    public async Task<ActionResult<ServiceModel<Product>>> AddProduct(Product NewProduct)
    {
        string categoryName = "";
        return Ok(await productRepo.AddProduct(NewProduct, categoryName));
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