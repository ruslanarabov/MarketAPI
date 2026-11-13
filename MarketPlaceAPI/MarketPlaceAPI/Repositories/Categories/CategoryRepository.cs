namespace MarketPlaceAPI.Repositories.Categories;

public class CategoryRepository(AppDbContext context) 
    : GenericRepository<Category>(context) , ICategoryRepository
{
    
}