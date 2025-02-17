using Common.Models;
using Repository.Repositories.Base;
using Repository.Repositories.Interfaces;
using Service.RepositoryService.Base;

namespace Service.RepositoryService
{
    public class UserRepoService(IUserRepository repository) : BaseRepoService<User>(repository)
    {
    }
}
