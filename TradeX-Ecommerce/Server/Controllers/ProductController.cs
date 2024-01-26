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
    public async Task<ActionResult<ServiceModel>> AddProduct(Product NewProduct)
    {
        return Ok(await productRepo.AddProduct(NewProduct));
    }

    [HttpGet("Get-Products")]
    public async Task<ActionResult<ServiceModel>> GetProducts() => Ok(await productRepo.GetProducts());
    
    [HttpGet("Get-Product/{ProductId:int}")]
    public async Task<ActionResult<ServiceModel>> GetProduct(int ProductId) => Ok(await productRepo.GetProduct(ProductId));
}
