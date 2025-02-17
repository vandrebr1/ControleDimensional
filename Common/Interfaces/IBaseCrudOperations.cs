using Common.Models.Interfaces;

namespace Common.Interfaces
{
    public interface IBaseCrudOperations<T> where T : IModel
    {
        int Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
