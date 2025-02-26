using Common.Models;
using Service.RepositoryService.Base;
using System.Collections.Generic;
using System.ComponentModel;

namespace UI.Usuario
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly IBaseRepoService<User> _userRepoService;
        private IEnumerable<User> _users;

        public UserViewModel(IBaseRepoService<User> userRepoService)
        {
            _userRepoService = userRepoService;
            CarregarUsuarios();
        }


        public IEnumerable<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private void CarregarUsuarios()
        {
            // Obtém a lista de usuários do serviço
            Users = _userRepoService.GetAll();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}