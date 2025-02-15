using Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Base;
using Service.RepositoryService;
using Service.RepositoryService.Base;
using Testes.RepositoryFixtures.Base;

namespace Testes.RepositoryFixtures
{
    [Collection("DatabaseCollection")]
    public class EquipmentRepositoryFixture : RepositoryFixtureBase
    {
        private readonly IBaseRepoService<Equipment> _equipmentRepoService;
        private readonly Equipment _equipment;

        public EquipmentRepositoryFixture()
        {
            _equipment = ReturnEquipment();
            _equipmentRepoService = _serviceProvider.GetRequiredService<IBaseRepoService<Equipment>>();
        }

        protected override void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton<IRepository<Equipment>, EquipmentRepository>();
        }

        [Fact]
        public void CRUD_CheckOperations()
        {
            Insert_ShouldInsertUser();
            Update_ShouldUpdatUser();
            Delete_ShouldRemoveUser();
        }

        private void Insert_ShouldInsertUser()
        {
            // Act
            _equipment.Id = _equipmentRepoService.Insert(_equipment);

            // Assert
            var equipment = _equipmentRepoService.GetById(_equipment.Id);

            Assert.NotNull(equipment);
            Assert.Equal(_equipment.Name, equipment.Name);
            Assert.Equal(_equipment.Abbreviation, equipment.Abbreviation);

        }


        private void Update_ShouldUpdatUser()
        {
            _equipment.Name = "FORMA 1";
            _equipment.Abbreviation = "FO1";

            // Act
            _equipmentRepoService.Update(_equipment);

            // Assert
            var equipmentUpdated = _equipmentRepoService.GetById(_equipment.Id);
            Assert.NotNull(equipmentUpdated);
            Assert.Equal("FORMA 1", equipmentUpdated.Name);
            Assert.Equal("FO1", equipmentUpdated.Abbreviation);

        }

        private void Delete_ShouldRemoveUser()
        {
            // Act
            _equipmentRepoService.Delete(_equipment.Id);

            // Assert
            var equipmentDeleted = _equipmentRepoService.GetById(_equipment.Id);
            Assert.Null(equipmentDeleted);
        }

        private Equipment ReturnEquipment()
        {
            return new Equipment
            {
                Name = "FORMA",
                Abbreviation = "FO",
                CadastradoPor = "SYSTEM",
                ModificadoPor = "SYSTEM",
                IsDeleted = false
            };
        }
    }
}
