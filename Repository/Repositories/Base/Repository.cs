using System.Data;
using Common.Models;
using Common.Models.Interfaces;
using Dapper;

namespace Repository.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : IModel
    {
        protected readonly IDbConnection _connection;
        protected abstract string TableName { get; }

        public Repository(IDbConnection connection)
        {
            _connection = connection;
        }

        public int Insert(T entity)
        {
            if (entity is BaseModel baseModel)
            {
                baseModel.DtCadastro = DateTime.Now;
                baseModel.DtModificado = DateTime.Now;
            }

            string sql = $@"INSERT INTO {TableName} ({GetColunas()}) 
                            VALUES ({GetParametros()});
                            SELECT last_insert_rowid();";

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            // Executa a query e retorna o ID gerado
            int id = _connection.QuerySingle<int>(sql, entity);
            return id;
        }

        public void Update(T entity)
        {
            if (entity is BaseModel baseModel)
            {
                baseModel.DtModificado = DateTime.Now;
            }

            string sql = $"UPDATE {TableName} SET {GetCamposAtualizar()} WHERE Id = @Id";

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            _connection.Execute(sql, entity);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {TableName} WHERE Id = @Id";
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            _connection.Execute(sql, new { Id = id });
        }

        public IEnumerable<T> GetAll()
        {
            string sql = $"SELECT * FROM {TableName}";

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection.Query<T>(sql).ToList();

        }

        public T GetById(int id)
        {
            string sql = $"SELECT * FROM {TableName} WHERE Id = @Id";

            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            return _connection.QueryFirstOrDefault<T>(sql, new { Id = id });

        }

        private string GetColunas()
        {
            return string.Join(", ", typeof(T).GetProperties()
                .Where(p => p.Name != "Id")
                .Select(p => p.Name));
        }

        private string GetParametros()
        {
            return string.Join(", ", typeof(T).GetProperties()
                .Where(p => p.Name != "Id")
                .Select(p => $"@{p.Name}"));
        }

        private string GetCamposAtualizar()
        {
            return string.Join(", ", typeof(T).GetProperties()
                .Where(p => p.Name != "Id")
                .Select(p => $"{p.Name} = @{p.Name}"));
        }
    }
}
