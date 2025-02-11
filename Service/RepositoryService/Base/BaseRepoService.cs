using Common.Models.Interfaces;
using Repository.Repositories.Base;

namespace Service.RepositoryService.Base
{
    public class BaseRepoService<T> : IBaseRepoService<T> where T : IModel
    {
        private readonly IRepository<T> _repository;

        public BaseRepoService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public int Insert(T entity)
        {
            return _repository.Insert(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
