using Common.Models;

namespace Service.RepositoryService
{
    public interface IEquipmentPadraoRepoService
    {
        void DeleteByEquipmentId(int equipmentId);
        IEnumerable<EquipmentPadrao> GetAllByEquipamentId(int equipmentId);
    }
}