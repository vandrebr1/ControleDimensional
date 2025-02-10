using Common.Models;
using Repository.Repositories.Base;

namespace Service.RepositoryService
{
    public class UserRepoService(IRepository<User> repository) : BaseRepositoryService<User>(repository)
    {
    }
}
