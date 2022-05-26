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
        public TeamPanel()
        {
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
                playerPanel.Children.Add(playerItem);
            }
        }
    }
}
