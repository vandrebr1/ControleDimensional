using Common.Models;
using Repository.Repositories.Base;

namespace Repository.Repositories.Interfaces
{
    public interface IEquipmentPadraoRepository : IRepository<EquipmentPadrao>
    {
        public void DeleteByEquipmentId(int EquipmentId);

        public IEnumerable<EquipmentPadrao> GetAllByEquipamentId(int EquipmentId);
    }
}
