using Template.Trunk.Data.DbContexts;
using Template.Trunk.Data.Entities.User;

namespace Template.Trunk.Data.Repositories.Users;

public class UserRepository
    : BaseApplicationRepository<UserEntity>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
