using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using AppDesktop.ApiConnection;

namespace AppDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            getTeams();
            getMatches();
        }

        private void getMatches()
        {
            MatchesStackPanel matchesStackPanel = new MatchesStackPanel(panelTwo);
            panelOne.Children.Add(matchesStackPanel);
        }

        private async void getTeams()
        {
            List<Team> teams = await ApiConnection.ApiConnection.GetTeamAsync();
            foreach (Team team in teams )
            {
                comboBoxMenu.Items.Add(team.name);
            } 
        }

        public async void Prueba()
        {
            //string URL = "http://localhost:3000";
            //string uri = URL + "/team/";

            //string teamJson = await ApiMethods.Get(uri);
            //string hola = JsonSerializer.Deserialize<string>(teamJson);

            //Team team = await ApiConnection.ApiConnection.GetTeamAsync();
            //prueba.Content = team.name;
        }

        private void myExercisePanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            panelOne.Children.Clear();
            InkCanvas inkCanvas = new InkCanvas();
            panelOne.Children.Add(inkCanvas);
        }
    }
}
