using Common.Models;
using Repository.Repositories.Base;
using Service.RepositoryService.Base;

namespace Service.RepositoryService
{
    public class EquipmentPadraoRepoService(IRepository<EquipmentPadrao> repository) : BaseRepoService<EquipmentPadrao>(repository)
    {
    }
}
