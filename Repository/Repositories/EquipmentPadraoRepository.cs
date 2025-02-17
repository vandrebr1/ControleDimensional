using System.Data;
using Common.Models;
using Dapper;
using Repository.Repositories.Base;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class EquipmentPadraoRepository : Repository<EquipmentPadrao>, IEquipmentPadraoRepository
    {
        protected override string TableName => "EquipmentsPadroes";

        public EquipmentPadraoRepository(IDbConnection connection) : base(connection)
        {
        }

        public override void Delete(int id)
        {
            throw new NotSupportedException("O método Delete(int id) não é suportado para EquipmentsPadroes. Use DeleteBy(int idEquipamento)");
        }

        public IEnumerable<EquipmentPadrao> GetAllByEquipamentId(int equipmentId)
        {
            string sql = $"SELECT * FROM {TableName} WHERE EquipmentId = @equipmentId";
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection.Query<EquipmentPadrao>(sql, new { equipmentId });
        }

        public void DeleteByEquipmentId(int equipmentId)
        {
            string sql = $"DELETE FROM {TableName} WHERE EquipmentId = @equipmentId";
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            _connection.Execute(sql, new { equipmentId });
        }
    }
}
