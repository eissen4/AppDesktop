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
using System.Windows.Shapes;

namespace AppDesktop
{
    /// <summary>
    /// Lógica de interacción para LoginRegister.xaml
    /// </summary>
    public partial class LoginRegister : Window
    {
        public LoginRegister()
        {
            InitializeComponent();
        }
        private async void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEmptyBoxLogin())
                return;
            else
            {
                ApiMethods apiMethods = new ApiMethods();
                string token = await ApiConnection.ApiConnection.Login(usernameTxt.Text, passwordTxt.Text);
                if (token != null)
                {
                    apiMethods.Token = token;
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                }
                if (token == null)
                    MessageBox.Show("Usuario o contraseño incorrectos");
            }
            
        }

        private async void emailRegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (!CheckEmptyBoxRegister())
              //  return;
            //else
            //{
                Register register = await ApiConnection.ApiConnection.Register(usernameRegisterTxt.Text, passwordRegisterTxt.Text, emailRegisterTxt.Text);
                //if(register != null)
                //{
                    string token = await ApiConnection.ApiConnection.Login(usernameRegisterTxt.Text, passwordRegisterTxt.Text);
            ApiMethods apiMethods = new ApiMethods();
            apiMethods.Token = token;
            await ApiConnection.ApiConnection.PostTeamAsync("Benidorm");
            MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                //} else
                //{
                  //  MessageBox.Show("El usuario ya existe");
               // }
           // }
        }
        private Boolean CheckEmptyBoxLogin()
        {
            if (
                usernameTxt.Text == ""
                || passwordTxt.Text == "")
            {
                MessageBox.Show("Algún campo vacío");
                return false;
            }
            return true;
        }
        private Boolean CheckEmptyBoxRegister()
        {
            //if (usernameRegisterTxt.Text == ""
             //   || passwordRegisterTxt.Text == ""
             //   || emailRegisterTxt.Text == ""
             //   || teamRegisterTxt.Text == "")
            //{
             //   MessageBox.Show("Algún campo vacío o incorrecto");
             //   return false;
            //}
            return true;
        }
    }
}
