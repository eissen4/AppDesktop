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

namespace AppDesktop.UserControlsMyMatch
{
    /// <summary>
    /// Lógica de interacción para NewStatPlayer.xaml
    /// </summary>
    public partial class NewStatPlayer : UserControl
    {
        List<Match> matches;
        List<Player> players;
        public NewStatPlayer()
        {
            getDataPlayers(); 
            InitializeComponent();
        }

        private async Task getDataPlayers()
        {
            //List<Player> players;
            //List<Match> matches;
            //var tasks = new List<Task>()
            //{
            //    players = ApiConnection.ApiConnection.GetPlayersAsync(Selection.teamSelected._id),
            //    matches = ApiConnection.ApiConnection.GetMatchesAsync(Selection.teamSelected._id)
            //};
            //await Task.WhenAll(tasks);
            players = await ApiConnection.ApiConnection.GetPlayersAsync(Selection.teamSelected._id);
            matches = await ApiConnection.ApiConnection.GetMatchesAsync(Selection.teamSelected._id);
            
            foreach (Player player in players)
            {
                playerStatPlayerCmb.Items.Add(player.Name);
            }
            playerStatPlayerCmb.SelectedIndex = 0;
            foreach (Match match in matches)
            {
                matchStatPlayerCmb.Items.Add(match.Opponent + " " + match.date.ToString());
            }
            matchStatPlayerCmb.SelectedIndex = 0;
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StatPlayer statPlayer = new StatPlayer()
            {
                team = Selection.teamSelected._id,
                player = players[playerStatPlayerCmb.SelectedIndex]._id,
                match = matches[matchStatPlayerCmb.SelectedIndex]._id,
                opponent = matches[matchStatPlayerCmb.SelectedIndex].opponent,
                date = matches[matchStatPlayerCmb.SelectedIndex].date, 
                points = Int32.Parse(pointsTxt.Text),
                rebounds = Int32.Parse(reboundsTxt.Text),
                assists = Int32.Parse(assistsTxt.Text)
            };
            await ApiConnection.ApiConnection.PostStatPlayerAsync(statPlayer);
        }
    }
}
