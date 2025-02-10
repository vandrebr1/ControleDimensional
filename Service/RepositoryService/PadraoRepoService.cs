using Common.Models;
using Repository.Repositories.Base;

namespace Service.RepositoryService
{
    public class PadraoRepoService(IRepository<Padrao> repository) : BaseRepositoryService<Padrao>(repository)
    {
    }
}
