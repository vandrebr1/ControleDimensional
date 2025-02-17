using Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Service.RepositoryService.Base;
using Testes.RepositoryFixtures.Base;

namespace Testes.RepositoryFixtures
{
    [Collection("DatabaseCollection")]
    public class PadraoRepositoryFixture : RepositoryFixtureBase
    {
        private readonly IBaseRepoService<Padrao> _padraoRepoService;
        private readonly Padrao _padrao;

        public PadraoRepositoryFixture()
        {
            _padrao = ReturnPadrao();
            _padraoRepoService = _serviceProvider.GetRequiredService<IBaseRepoService<Padrao>>();

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
            // Act
            _padrao.Id = _padraoRepoService.Insert(_padrao);

            // Assert
            var padraoInderido = _padraoRepoService.GetById(_padrao.Id);
            Assert.NotNull(padraoInderido);
            Assert.Equal(_padrao.Nome, padraoInderido.Nome);
            Assert.Equal(_padrao.Ferramental, padraoInderido.Ferramental);
            Assert.Equal(_padrao.UnidadeMedida, padraoInderido.UnidadeMedida);
        }


        private void Update_ShouldUpdate()
        {
            _padrao.Nome = "Ø Rodapé";
            _padrao.Ferramental = "Paquimetro";

            // Act
            _padraoRepoService.Update(_padrao);

            // Assert
            var padraoAtualizado = _padraoRepoService.GetById(_padrao.Id);
            Assert.NotNull(padraoAtualizado);
            Assert.Equal("Ø Rodapé", padraoAtualizado.Nome);
            Assert.Equal("Paquimetro", padraoAtualizado.Ferramental);

        }

        private void Delete_ShouldRemove()
        {
            // Act
            _padraoRepoService.Delete(_padrao.Id);

            // Assert
            var usuarioRemovido = _padraoRepoService.GetById(_padrao.Id);
            Assert.Null(usuarioRemovido);
        }

        private Padrao ReturnPadrao()
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
