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
        List<Player> players;
        StackPanel newPanelTwo;
        public TeamPanel(StackPanel panelTwo)
        {
            newPanelTwo = panelTwo;
            InitializeComponent();
            teamLbl.Content = Selection.teamSelected.Name;
            GetPlayers();
        }

        private async void GetPlayers()
        {
            players = await ApiConnection.ApiConnection.GetPlayersAsync(Selection.teamSelected._id);
            foreach(Player player in players)
            {
                PlayerItem playerItem = new PlayerItem()
                {
                    NamePlayerLbl = "Nombre: " + player.name.ToString(),
                    HeightPlayerLbl = "Altura: " + player.height.ToString(),
                    WeightPlayerLbl = "Peso: " + player.weight.ToString()
                };
                playerItem.MouseLeftButtonUp += (sender, e) => PlayerItem_MouseLeftButtonUp(sender, e, player._Id.ToString());
                playerPanel.Children.Add(playerItem);
            }
        }

        private async void PlayerItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e, string playerId)
        {
            newPanelTwo.Children.Clear();
            List<StatPlayer> statPlayers = new List<StatPlayer>();
            statPlayers = await ApiConnection.ApiConnection.GetPlayersStatsAsync(playerId);
            foreach (StatPlayer player in statPlayers)
            {
                PlayerMyTeamItem item = new PlayerMyTeamItem()
                {
                    ResultMatchlbl = player.opponent,
                    Datelbl = player.date.ToString(),
                    PointsLbl ="Puntos: " + player.points.ToString(),
                    ReboundsLbl ="Rebotes: " + player.rebounds.ToString(),
                    AssistsLbl ="Asistencias: " + player.assists.ToString()
                };
                newPanelTwo.Children.Add(item);
            }
        }
    }
}
