using Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Base;
using Service.RepositoryService.Base;
using Testes.RepositoryFixtures.Base;

namespace Testes.RepositoryFixtures
{
    [Collection("DatabaseCollection")]
    public class EquipamentRepositoryFixture : RepositoryFixtureBase
    {
        private readonly IBaseRepoService<Equipment> _equipmentRepoService;
        private readonly Equipment _equipament;

        public EquipamentRepositoryFixture()
        {
            _equipament = ReturnEquipment();
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

        }


        private void Update_ShouldUpdatUser()
        {
            

        }

        private void Delete_ShouldRemoveUser()
        {
            
        }

        private Equipment ReturnEquipment()
        {
            return new Equipment
            {
            };
        }
    }
}
