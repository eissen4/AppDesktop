using AppDesktop.Entity;
using AppDesktop.UserControlsMyTeam;
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
    /// Lógica de interacción para TeamPanel.xaml
    /// </summary>
    public partial class TeamPanel : UserControl
    {
        Team newTeam;
        List<Player> players;
        public TeamPanel(Team team)
        {
            InitializeComponent();
            newTeam = team;
            teamLbl.Content = team.name;
            GetPlayers(team);
        }

        private async void GetPlayers(Team team)
        {
            players = await ApiConnection.ApiConnection.GetPlayersAsync(team._id);
            foreach(Player player in players)
            {
                PlayerItem playerItem = new PlayerItem();
            }
        }
    }
}
