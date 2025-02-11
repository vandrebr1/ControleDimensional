using System.Data;
using Common.Models;
using Repository.Repositories.Base;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        protected override string TableName => "Equipaments";

        public EquipmentRepository(IDbConnection connection) : base(connection)
        {
        }
    }
}
