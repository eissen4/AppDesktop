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

namespace AppDesktop.UserControls
{
    /// <summary>
    /// Lógica de interacción para NewTeam.xaml
    /// </summary>
    public partial class NewTeam : UserControl
    {
        Button newTeamSave;
        public NewTeam()
        {
            InitializeComponent();
            newTeamSave = saveBtn;
        }

        private void newTeamSave_Click(object sender, MouseButtonEventArgs e)
        {
            
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            await ApiConnection.ApiConnection.PostTeamAsync(nameTxt.Text);
        }
    }
}
