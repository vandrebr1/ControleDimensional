using Common.Models;
using Repository.Repositories.Base;
using Service.RepositoryService.Base;

namespace Service.RepositoryService
{
    public class EquipmentRepoService(IRepository<Equipment> repository) : BaseRepoService<Equipment>(repository)
    {
    }
}
