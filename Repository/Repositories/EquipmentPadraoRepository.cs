using System.Data;
using Common.Models;
using Dapper;
using Repository.Repositories.Base;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class EquipmentPadraoRepository : Repository<EquipmentPadrao>, IEquipmentPadraoRepository
    {
        protected override string TableName => "EquipamentsPadroes";

        public EquipmentPadraoRepository(IDbConnection connection) : base(connection)
        {
        }

        public override void Delete(int id)
        {
            throw new NotSupportedException("O método Delete(int id) não é suportado para EquipmentsPadroes. Use DeleteBy(int idEquipamento)");
        }

        public void DeleteByEquipmentId(int EquipmentId)
        {
            string sql = $"DELETE FROM {TableName} WHERE EquipmentId = @EquipmentId";
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            _connection.Execute(sql, EquipmentId);
        }
    }
}
