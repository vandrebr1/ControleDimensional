using Common.Models;
using Repository.Repositories.Base;
using Repository.Repositories.Interfaces;
using Service.RepositoryService.Base;

namespace Service.RepositoryService
{
    public class PadraoRepoService(IPadraoRepository repository) : BaseRepoService<Padrao>(repository)
    {
    }
}
