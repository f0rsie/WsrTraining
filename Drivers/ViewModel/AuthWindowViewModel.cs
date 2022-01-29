using Drivers.Domain;
using Drivers.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Drivers.ViewModel
{
    public class AuthWindowViewModel : BaseViewModel
    {
        private string login;
        private string password;

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public AuthWindowViewModel()
        {

        }

        public void AuthCheck()
        {
            var authBlock = new AuthBlock();

            if (authBlock.Auth(login, password))
            {
                MessageBox.Show("Авторизация прошла успешно");

                var mainWindow = new MainWindow();
                var appOld = App.Current.MainWindow;

                App.Current.MainWindow = mainWindow;

                mainWindow.Show();

                appOld.Close();

                return;
            }
            MessageBox.Show("Авторизация не удалась");

            Password = string.Empty;
        }
    }
}
