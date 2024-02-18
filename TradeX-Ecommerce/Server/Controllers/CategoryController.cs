namespace TradeXEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepo categoryRepo;

    public CategoryController(ICategoryRepo categoryRepo)
    {
        this.categoryRepo = categoryRepo;
    }

    [HttpGet("All")]
    public async Task<ActionResult<ServiceModel<Category>>> GetCategories()
    {
        return Ok (await categoryRepo.GetCategories());
    }

    [HttpGet("GetCategory/{id:int}")]
    public async Task<ActionResult<ServiceModel<Category>>> GetCategory(int id)
    {
        return Ok (await categoryRepo.GetCategory(id));
    }
    
    [HttpPost("Add")]
    public async Task<ActionResult<ServiceModel<Category>>> AddCategory(Category newCategory)
    {
        return Ok (await categoryRepo.AddCategory(newCategory));
    }
    
    [HttpDelete("Delete/{id:int}")]
    public async Task<ActionResult<ServiceModel<Category>>> DeleteCategory(int id)
    {
        return Ok (await categoryRepo.DeleteCategory(id));
    }
    
    [HttpPut("Update")]
    public async Task<ActionResult<ServiceModel<Category>>> UpdateCategory(Category newCategory)
    {
        return Ok (await categoryRepo.UpdateCategory(newCategory));
    }
}