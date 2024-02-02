namespace TradeXEcommerce.Server.Repositories.Interfaces;

public interface ICategoryRepo
{
    Task<ServiceModel<Category>> AddCategory(Category newCategory);
    Task<ServiceModel<Category>> DeleteCategory(int id);
    Task<ServiceModel<Category>> GetCategories();
    Task<ServiceModel<Category>> GetCategory(int id);
    Task<ServiceModel<Category>> UpdateCategory(Category newCategory);
}
