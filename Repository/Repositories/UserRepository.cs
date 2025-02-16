using System.Data;
using Common.Models;
using Repository.Repositories.Base;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : Repository<User>
    {
        protected override string TableName => "Usuarios";

        public UserRepository(IDbConnection connection) : base(connection)
        {
        }
    }
}
