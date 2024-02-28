using Microsoft.AspNetCore.Authorization;

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

    //[Authorize(Roles = "Admin")]
    [HttpGet("GetCategory/{id:int}")]
    public async Task<ActionResult<ServiceModel<Category>>> GetCategory(int id)
    {
        return Ok (await categoryRepo.GetCategory(id));
    }

    //[Authorize(Roles = "Admin")]
    [HttpPost("Add")]
    public async Task<ActionResult<ServiceModel<Category>>> AddCategory(Category newCategory)
    {
        return Ok (await categoryRepo.AddCategory(newCategory));
    }
    
    //[Authorize(Roles = "Admin")]
    [HttpDelete("Delete{id:int}")]

    public async Task<ActionResult<ServiceModel<Category>>> DeleteCategory(int id)
    {
        return Ok (await categoryRepo.DeleteCategory(id));
    }

    //[Authorize(Roles = "Admin")]
    [HttpPut("Update")]
    public async Task<ActionResult<ServiceModel<Category>>> UpdateCategory(Category newCategory)
    {
        return Ok (await categoryRepo.UpdateCategory(newCategory));
    }
}