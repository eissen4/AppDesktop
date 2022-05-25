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
        string selection = "team";
        public MainWindow()
        {
            InitializeComponent();
            getToken();
        }

        private async Task getToken()
        {
            ApiMethods apiMethods = new ApiMethods();
            string token = await ApiConnection.ApiConnection.Login("1", "1");
            apiMethods.Token = token;
            getTeams();
            NavBar navBar = new NavBar(panelOne, panelTwo, selection);
            navBarBorder.Child = navBar;
        }

        private void getMatches(string team)
        {
            MatchesStackPanel matchesStackPanel = new MatchesStackPanel(panelTwo, team);
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

        public void Prueba()
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

        private void comboBoxMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(comboBoxMenu.SelectedItem.ToString());
            getMatches(comboBoxMenu.SelectedItem.ToString());
        }
    }
}
