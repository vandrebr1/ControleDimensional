using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models.Interfaces;

namespace Service.RepositoryService.Base
{
    public interface IBaseRepoService<T> where T : IModel
    {
        int Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
