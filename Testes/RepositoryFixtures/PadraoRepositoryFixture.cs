using Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Base;
using Service.RepositoryService.Interfaces;
using Testes.RepositoryFixtures.Base;

namespace Testes.RepositoryFixtures
{
    [Collection("DatabaseCollection")]
    public class PadraoRepositoryFixture : RepositoryFixtureBase
    {
        private readonly IBaseRepositoryService<Padrao> _userRepoService;
        private readonly Padrao _padrao;

        public PadraoRepositoryFixture()
        {
            _padrao = ReturnUser();
            _userRepoService = _serviceProvider.GetRequiredService<IBaseRepositoryService<Padrao>>();

        }

        protected override void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton<IRepository<Padrao>, PadraoRepository>();
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
            _padrao.Id = _userRepoService.Insert(_padrao);

            // Assert
            var padraoInderido = _userRepoService.GetById(_padrao.Id);
            Assert.NotNull(padraoInderido);
            Assert.Equal(_padrao.Nome, padraoInderido.Nome);
            Assert.Equal(_padrao.Ferramental, padraoInderido.Ferramental);
            Assert.Equal(_padrao.UnidadeMedida, padraoInderido.UnidadeMedida);
        }


        private void Update_ShouldUpdatUser()
        {
            _padrao.Nome = "Ø Rodapé";
            _padrao.Ferramental = "Paquimetro";

            // Act
            _userRepoService.Update(_padrao);

            // Assert
            var padraoAtualizado = _userRepoService.GetById(_padrao.Id);
            Assert.NotNull(padraoAtualizado);
            Assert.Equal("Ø Rodapé", padraoAtualizado.Nome);
            Assert.Equal("Paquimetro", padraoAtualizado.Ferramental);

        }

        private void Delete_ShouldRemoveUser()
        {
            // Act
            _userRepoService.Delete(_padrao.Id);

            // Assert
            var usuarioRemovido = _userRepoService.GetById(_padrao.Id);
            Assert.Null(usuarioRemovido);
        }

        private Padrao ReturnUser()
        {
            return new Padrao
            {
                Nome = "Ø Colo",
                Ferramental = "Calibre / Paquimetro",
                UnidadeMedida = "mm",
                CadastradoPor = "SYSTEM",
                ModificadoPor = "SYSTEM",
                IsDeleted = false
            };
        }
    }
}
