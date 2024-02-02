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

    [HttpPost("Add-Product")]
    public async Task<ActionResult<ServiceModel<Product>>> AddProduct(Product NewProduct)
    {
        return Ok(await productRepo.AddProduct(NewProduct));
    }

    [HttpGet]
    public async Task<ActionResult<ServiceModel<Product>>> GetProducts() => Ok(await productRepo.GetProducts());
    
    [HttpGet("Get-Product/{ProductId:int}")]
    public async Task<ActionResult<ServiceModel<Product>>> GetProduct(int ProductId) => Ok(await productRepo.GetProduct(ProductId));

    [HttpDelete("Delete-Product/{id:int}")]
    public async Task<ActionResult<ServiceModel<Product>>> DeleteProduct(int id)
    {
        return Ok(await productRepo.DeleteProduct(id));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceModel<Product>>> UpdateProduct(Product NewProduct)
    {
        return Ok(await productRepo.UpdateProduct(NewProduct));
    }
}