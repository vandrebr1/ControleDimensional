using System.Windows.Controls;

namespace UI.Usuario
{
    public partial class UserControlUsuario : UserControl
    {
        public UserControlUsuario(UserViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}