using Common.Models;
using Repository.Repositories.Base;
using Service.RepositoryService.Base;

namespace Service.RepositoryService
{
    public class PadraoRepoService(IRepository<Padrao> repository) : BaseRepoService<Padrao>(repository)
    {
    }
}
