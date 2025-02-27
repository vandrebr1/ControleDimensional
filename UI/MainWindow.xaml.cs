﻿using System.Windows;
using UI.Equipamento;
using UI.Usuario;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserControlUsuario _userControlUsuario;

        public MainWindow(UserControlUsuario userControlUsuario)
        {
            InitializeComponent();
            _userControlUsuario = userControlUsuario;
        }

        private void btnPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void MenuUsuarios_Selected(object sender, RoutedEventArgs e)
        {
            MainContent.Content = _userControlUsuario;
        }

        private void MenuEquipamento_Selected(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UserControlEquipamento();
        }
    }
}