using Common.Interfaces;
using Common.Models.Interfaces;

namespace Repository.Repositories.Base
{
    public interface IRepository<T> : IBaseCrudOperations<T> where T : IModel
    {

    }
}
