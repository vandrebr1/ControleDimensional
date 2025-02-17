using Common.Models;
using Repository.Repositories.Interfaces;
using Service.RepositoryService.Base;

namespace Service.RepositoryService
{
    public class EquipmentRepoService(IEquipmentRepository repository,
                                      IEquipmentPadraoRepository equipmentPadraoRepository,
                                      IPadraoRepository padraoRepository) : BaseRepoService<Equipment>(repository)
    {

        private readonly IEquipmentPadraoRepository _equipmentPadraoRepoService = equipmentPadraoRepository;
        private readonly IPadraoRepository _padraoRepository = padraoRepository;


        public override int Insert(Equipment entity)
        {
            var id = base.Insert(entity);
            entity.Id = id;

            EquipmentPadraoInsert(entity);

            return id;
        }

        public override void Update(Equipment entity)
        {
            base.Update(entity);
            EquipmentPadraoInsert(entity);
        }

        public override void Delete(int id)
        {
            RemoveOldAssociationWithEquipamentId(new Equipment { Id = id });
            base.Delete(id);
        }

        public override Equipment GetById(int equipmentId)
        {
            var equipment = base.GetById(equipmentId);

            if (equipment != null)
                FetchPadroes(equipment);

            return equipment;
        }

        private void FetchPadroes(Equipment? equipment)
        {
            var equipmentPadroes = _equipmentPadraoRepoService.GetAllByEquipamentId(equipment.Id).ToList();

            var padroes = new List<Padrao>();

            foreach (var equipmentPadrao in equipmentPadroes)
            {
                padroes.Add(_padraoRepository.GetById(equipmentPadrao.PadraoId));
            }

            equipment.Padroes = padroes;
        }

        private void EquipmentPadraoInsert(Equipment entity)
        {
            RemoveOldAssociationWithEquipamentId(entity);

            foreach (var padrao in entity.Padroes)
            {
                var equipmentPadrao = new EquipmentPadrao
                {
                    EquipmentId = entity.Id,
                    PadraoId = padrao.Id,
                    CadastradoPor = "SYSTEM",
                    ModificadoPor = "SYSTEM"
                };

                _equipmentPadraoRepoService.Insert(equipmentPadrao);
            }
        }

        private void RemoveOldAssociationWithEquipamentId(Equipment entity)
        {
            _equipmentPadraoRepoService.DeleteByEquipmentId(entity.Id);
        }
    }
}
