using Common.Models.Interfaces;

namespace Repository.Repositories.Base
{
    public interface IRepository<T> where T : IModel
    {
        /// <summary>
        /// Insert new data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The last insert rowid</returns>
        int Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
