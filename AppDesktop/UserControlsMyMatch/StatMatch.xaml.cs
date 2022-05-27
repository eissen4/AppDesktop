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
    /// Lógica de interacción para StatMatch.xaml
    /// </summary>
    public partial class StatMatch : UserControl
    {
        string newId;
        public StatMatch(string id)
        {
            newId = id;
            getStatsFromMatch();
            InitializeComponent();
        }

        private async Task getStatsFromMatch()
        {
            List<StatPlayer> statPlayer = await ApiConnection.ApiConnection.GetStatsMatchAsync(newId);
            List<StatsPlayerList> statsPlayerLists = new List<StatsPlayerList>();
            foreach (StatPlayer player in statPlayer)
            {
                statsPlayerLists.Add(new StatsPlayerList()
                {
                    Player = player.playerName,
                    Points = player.points,
                    Rebounds = player.rebounds,
                    Assists = player.assists
                });
            };
            statsLst.ItemsSource = statsPlayerLists;
        }
    }
    public class StatsPlayerList
    {
        public string Player { get; set; }
        public int Points { get; set; }
        public int Rebounds { get; set; }
        public int Assists { get; set; }
    }
}
