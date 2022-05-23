using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppDesktop.ApiConnection;
using AppDesktop.Entity;
using AppDesktop.UserControls;

namespace AppDesktop
{
    /// <summary>
    /// Lógica de interacción para StackPanelRaw.xaml
    /// </summary>
    public partial class MatchesStackPanel : UserControl
    {
        List<Match> matches;
        public MatchesStackPanel()
        {
            InitializeComponent();
            UpdateMatches();
        }

        private async void UpdateMatches()
        {
            //string URL = "http://localhost:3000";
            //string uri1 = URL + "/team/";

            //string teamJson = await ApiMethods.Get(uri1);
            //string hola = JsonSerializer.Deserialize<string>(teamJson);

            //Team team = await ApiConnection.ApiConnection.GetTeamAsync();

            //string uri = URL + "match/getAllMatchesFromUser/";
            //string matchJson = await ApiMethods.Get(uri);
            //matches = JsonSerializer.Deserialize<List<Match>>(matchJson);
            matches = await ApiConnection.ApiConnection.GetMatchesAsync();

            matches.ForEach(match =>
            {
                MatchItem matchItem = new MatchItem()
                {
                    ResultMatchlbl = match.Opponent + match.scoreOne.ToString(),
                    Datelbl = match.ScoreTwo.ToString()
                };
                matchesPanel.Children.Add(matchItem);
            });
        }
    }
}
