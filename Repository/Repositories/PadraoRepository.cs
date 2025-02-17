using System.Data;
using Common.Models;
using Repository.Repositories.Base;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class PadraoRepository : Repository<Padrao>, IPadraoRepository
    {
        protected override string TableName => "Padroes";

        public PadraoRepository(IDbConnection connection) : base(connection)
        {
        }
    }
}
