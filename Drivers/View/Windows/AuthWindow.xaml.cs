using Drivers.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Drivers.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        AuthWindowViewModel viewModel;

        public AuthWindow()
        {
            InitializeComponent();

            DataContext = viewModel = new AuthWindowViewModel();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as AuthWindowViewModel).Password = passwordBox.Password;
        }

        private void buttonAuth_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AuthCheck();

            passwordBox.Password = null;
        }
    }
}
