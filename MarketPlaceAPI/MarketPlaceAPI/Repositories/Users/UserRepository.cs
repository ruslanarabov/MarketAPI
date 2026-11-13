namespace MarketPlaceAPI.Repositories.Users;

public class UserRepository(AppDbContext context)
    : GenericRepository<User>(context), IUserRepository
{
    
}