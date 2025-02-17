using Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Service.RepositoryService.Base;
using Service.RepositoryService.Interfaces;
using Testes.RepositoryFixtures.Base;

namespace Testes.RepositoryFixtures
{
    [Collection("DatabaseCollection")]
    public class EquipmentPadraoRepositoryFixture : RepositoryFixtureBase
    {
        private readonly IBaseRepoService<Equipment> _equipmentRepoService;
        private readonly IBaseRepoService<Padrao> _padraoRepoService;
        private readonly IEquipmentPadraoRepoService _equipmentPadraoRepoService;


        private Padrao _padrao1;
        private Padrao _padrao2;
        private Padrao _padrao3;
        private Equipment _equipment;

        public EquipmentPadraoRepositoryFixture()
        {
            _equipmentRepoService = _serviceProvider.GetRequiredService<IBaseRepoService<Equipment>>();
            _padraoRepoService = _serviceProvider.GetRequiredService<IBaseRepoService<Padrao>>();
            _equipmentPadraoRepoService = _serviceProvider.GetRequiredService<IEquipmentPadraoRepoService>();

            InsertPadroes();
        }

        [Fact]
        public void CRUD_CheckOperations()
        {
            Insert_ShouldInsert();
            Update_ShouldUpdate();
            Delete_ShouldRemove();
        }

        private void Insert_ShouldInsert()
        {

            //Arrange
            _equipment = new Equipment
            {
                Name = "FORMA",
                Abbreviation = "FO",
                CadastradoPor = "SYSTEM",
                ModificadoPor = "SYSTEM",
                Padroes = new List<Padrao> { _padrao1, _padrao2, _padrao3 }
            };

            // Act
            _equipment.Id = _equipmentRepoService.Insert(_equipment);

            // Assert
            var equipment = _equipmentRepoService.GetById(_equipment.Id);

            Assert.NotNull(equipment);
            Assert.Equal(_equipment.Name, equipment.Name);
            Assert.Equal(_equipment.Abbreviation, equipment.Abbreviation);
            Assert.Equal(3, _equipment.Padroes.Count());
        }

        private void Update_ShouldUpdate()
        {
            _equipment.Name = "FORMA 1";
            _equipment.Abbreviation = "FO1";
            _equipment.Padroes = new List<Padrao> { _padrao1, _padrao2 };

            // Act
            _equipmentRepoService.Update(_equipment);

            // Assert
            var equipmentUpdated = _equipmentRepoService.GetById(_equipment.Id);
            Assert.NotNull(equipmentUpdated);
            Assert.Equal("FORMA 1", equipmentUpdated.Name);
            Assert.Equal("FO1", equipmentUpdated.Abbreviation);
            Assert.Equal(2, _equipment.Padroes.Count());

        }

        private void Delete_ShouldRemove()
        {
            // Act
            _equipmentRepoService.Delete(_equipment.Id);


            // Assert
            var equipmentPadraoDeleted = _equipmentPadraoRepoService.GetAllByEquipamentId(_equipment.Id);
            Assert.Empty(equipmentPadraoDeleted);

        }

        private void InsertPadroes()
        {
            _padrao1 = new Padrao
            {
                Nome = "Ø Colo",
                Ferramental = "Calibre / Paquimetro",
                UnidadeMedida = "mm",
                CadastradoPor = "SYSTEM",
                ModificadoPor = "SYSTEM",
                IsDeleted = false
            };

            _padrao1.Id = _padraoRepoService.Insert(_padrao1);

            _padrao2 = new Padrao
            {
                Nome = "Ø Rodapé",
                Ferramental = "Paquimetro",
                UnidadeMedida = "mm",
                CadastradoPor = "SYSTEM",
                ModificadoPor = "SYSTEM",
                IsDeleted = false
            };

            _padrao2.Id = _padraoRepoService.Insert(_padrao2);

            _padrao3 = new Padrao
            {
                Nome = "Ø Rodapé 2",
                Ferramental = "Paquimetro",
                UnidadeMedida = "mm",
                CadastradoPor = "SYSTEM",
                ModificadoPor = "SYSTEM",
                IsDeleted = false
            };

            _padrao3.Id = _padraoRepoService.Insert(_padrao3);
        }
    }
}
