using AppDesktop.ApiConnection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDesktop.UserControlsLoginRegister
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            ApiMethods apiMethods = new ApiMethods();
            string token = await ApiConnection.ApiConnection.Login(usernameTxt.Text, passwordTxt.Text);
            apiMethods.Token = token;
            MainWindow mainWindow = new MainWindow();
            mainWindow.getTeams();
        }
    }
}
