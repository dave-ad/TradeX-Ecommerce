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

    //[Authorize(Roles = "Admin")]
    [HttpPost("Add")]
    public async Task<ActionResult<ServiceModel<Category>>> AddCategory(Category newCategory) => Ok(await categoryRepo.AddCategory(newCategory));

    //[Authorize(Roles = "Admin")]
    [HttpDelete("Delete{id:int}")]
    public async Task<ActionResult<ServiceModel<Category>>> DeleteCategory(int id) => Ok(await categoryRepo.DeleteCategory(id));

    [HttpGet("All")]
    public async Task<ActionResult<ServiceModel<Category>>> GetCategories() => Ok(await categoryRepo.GetCategories());

    //[Authorize(Policy = "Admin")]
    [HttpGet("GetCategory/{id:int}")]
    public async Task<ActionResult<ServiceModel<Category>>> GetCategory(int id) => Ok(await categoryRepo.GetCategory(id));

    //[Authorize(Roles = "Admin")]
    [HttpPut("Update")]
    public async Task<ActionResult<ServiceModel<Category>>> UpdateCategory(Category newCategory) => Ok(await categoryRepo.UpdateCategory(newCategory));
}