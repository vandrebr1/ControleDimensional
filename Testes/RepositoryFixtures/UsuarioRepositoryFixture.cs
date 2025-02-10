﻿using Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Base;
using Service.RepositoryService.Interfaces;
using Testes.RepositoryFixtures.Base;

namespace Testes.RepositoryFixtures
{
    [Collection("DatabaseCollection")]
    public class UsuarioRepositoryFixture : RepositoryFixtureBase
    {
        private readonly IBaseRepositoryService<User> _userRepoService;
        private readonly User _user;

        public UsuarioRepositoryFixture()
        {
            _user = ReturnUser();
            _userRepoService = _serviceProvider.GetRequiredService<IBaseRepositoryService<User>>();
        }

        protected override void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton<IRepository<User>, UserRepository>();
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
            _user.Id = _userRepoService.Insert(_user);

            // Assert
            var usuarioInserido = _userRepoService.GetById(_user.Id);
            Assert.NotNull(usuarioInserido);
            Assert.Equal(_user.Nome, usuarioInserido.Nome);
            Assert.Equal(_user.Login, usuarioInserido.Login);
            Assert.Equal(_user.Senha, usuarioInserido.Senha);
            Assert.Equal(_user.TipoAcesso, usuarioInserido.TipoAcesso);
        }


        private void Update_ShouldUpdatUser()
        {
            _user.Nome = "João da Silva";
            _user.Login = "joao.dasilva";

            // Act
            _userRepoService.Update(_user);

            // Assert
            var usuarioAtualizado = _userRepoService.GetById(_user.Id);
            Assert.NotNull(usuarioAtualizado);
            Assert.Equal("João da Silva", usuarioAtualizado.Nome);
            Assert.Equal("joao.dasilva", usuarioAtualizado.Login);

        }

        private void Delete_ShouldRemoveUser()
        {
            // Act
            _userRepoService.Delete(_user.Id);

            // Assert
            var usuarioRemovido = _userRepoService.GetById(_user.Id);
            Assert.Null(usuarioRemovido);
        }

        private User ReturnUser()
        {
            return new User
            {
                Nome = "João Silva",
                Login = "joao.silva",
                Senha = "senha123",
                TipoAcesso = TipoAcesso.User,
                CadastradoPor = "SYSTEM",
                ModificadoPor = "SYSTEM",
                IsDeleted = false
            };
        }
    }
}
