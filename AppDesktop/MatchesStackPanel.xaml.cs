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
using AppDesktop.UserControlsMyMatch;

namespace AppDesktop
{
    /// <summary>
    /// Lógica de interacción para StackPanelRaw.xaml
    /// </summary>
    public partial class MatchesStackPanel : UserControl
    {
        List<Match> matches;
        StackPanel newPanelOne;
        StackPanel newPanelTwo;
        public MatchesStackPanel(StackPanel panelOne, StackPanel panelTwo)
        {
            InitializeComponent();
            UpdateMatches();
            newPanelOne = panelOne;
            newPanelTwo = panelTwo; 
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
            matches = await ApiConnection.ApiConnection.GetMatchesAsync(Selection.teamSelected._id);
            

            matches.ForEach(match =>
            {
                MatchItem matchItem = new MatchItem()
                {
                    ResultMatchlbl = "Resultado: Equipo1" + " " + match.scoreOne.ToString() + " - " + match.ScoreTwo.ToString() + " " + match.opponent.ToString(),
                    Datelbl = match.Date.ToString()                
                };
                matchItem.MouseLeftButtonUp += (sender, e) => MatchItem_MouseLeftButtonUp(sender, e, match._Id.ToString());
                newPanelOne.Children.Add(matchItem);
            });
        }

        private void MatchItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e, string id)
        {            
            StatMatch statMatch = new StatMatch(id);
            newPanelTwo.Children.Clear();
            newPanelTwo.Children.Add(statMatch);
        }
    }
}
