using AppDesktop.Entity;
using System;
using System.Collections.Generic;
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

namespace AppDesktop.UserControls
{
    /// <summary>
    /// Lógica de interacción para NewPlayer.xaml
    /// </summary>
    public partial class NewPlayer : UserControl
    {
        List<Team> teams;
        public NewPlayer()
        {
            InitializeComponent();
            GetTeams();
        }

        private async Task GetTeams()
        {
            teams = await ApiConnection.ApiConnection.GetTeamAsync();
            foreach (Team team in teams)
            {
                comboBoxTeams.Items.Add(team.name);
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Player player = new Player()
            {
                name = nameTxt.Text.ToString(),
                team = teams[comboBoxTeams.SelectedIndex]._id,
                height = heightTxt.Text.ToString(),
                weight = weightTxt.Text.ToString(),
                image = "nada.jpg"
            };
            ApiConnection.ApiConnection.PostPlayerAsync(player);
        }
    }
}
