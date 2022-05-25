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
        StackPanel newPanel;
        public MatchesStackPanel(StackPanel panel, string team)
        {
            InitializeComponent();
            UpdateMatches(team);
            newPanel = panel;
        }

        private async void UpdateMatches(string team)
        {
            //string URL = "http://localhost:3000";
            //string uri1 = URL + "/team/";

            //string teamJson = await ApiMethods.Get(uri1);
            //string hola = JsonSerializer.Deserialize<string>(teamJson);

            //Team team = await ApiConnection.ApiConnection.GetTeamAsync();

            //string uri = URL + "match/getAllMatchesFromUser/";
            //string matchJson = await ApiMethods.Get(uri);
            //matches = JsonSerializer.Deserialize<List<Match>>(matchJson);
            matches = await ApiConnection.ApiConnection.GetMatchesAsync(team);

            matches.ForEach(match =>
            {
                MatchItem matchItem = new MatchItem()
                {
                    ResultMatchlbl = "Resultado: Equipo1" + " " + match.scoreOne.ToString() + " - " + match.ScoreTwo.ToString() + " " + match.opponent.ToString(),
                    Datelbl = match.ScoreTwo.ToString(),
                    //Id = match._id.ToString()
                    Id = match._id.ToString()                 
                };
                matchItem.MouseLeftButtonUp += (sender, e) => MatchItem_MouseLeftButtonUp(sender, e, match._Id.ToString());
                matchesPanel.Children.Add(matchItem);
            });
        }

        private void MatchItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e, string id)
        {            
            Label label = new Label();
            label.Content = id;
            newPanel.Children.Clear();
            newPanel.Children.Add(label);
        }
    }
}
