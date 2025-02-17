using Common.Interfaces;
using Common.Models.Interfaces;

namespace Service.RepositoryService.Base
{
    public interface IBaseRepoService<T> : IBaseCrudOperations<T> where T : IModel
    {
    }
}
