using Common.Models;

namespace Service.RepositoryService.Interfaces
{
    public interface IEquipmentPadraoRepoService
    {
        void DeleteByEquipmentId(int equipmentId);
        IEnumerable<EquipmentPadrao> GetAllByEquipamentId(int equipmentId);
    }
}