using Common.Models;
using Repository.Repositories.Interfaces;
using Service.RepositoryService.Base;
using Service.RepositoryService.Interfaces;

namespace Service.RepositoryService
{
    public class EquipmentPadraoRepoService(IEquipmentPadraoRepository repository) : BaseRepoService<EquipmentPadrao>(repository), IEquipmentPadraoRepoService
    {
        private readonly IEquipmentPadraoRepository equipmentPadraoRepository = repository;

        public override void Delete(int id)
        {
            throw new NotSupportedException("O método Delete(int id) não é suportado para EquipmentsPadroes. Use DeleteBy(int idEquipamento)");
        }

        public IEnumerable<EquipmentPadrao> GetAllByEquipamentId(int equipmentId)
        {
            return equipmentPadraoRepository.GetAllByEquipamentId(equipmentId);
        }

        public void DeleteByEquipmentId(int equipmentId)
        {
            equipmentPadraoRepository.DeleteByEquipmentId(equipmentId);
        }
    }
}
