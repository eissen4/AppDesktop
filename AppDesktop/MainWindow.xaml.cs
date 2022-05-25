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
using AppDesktop.UserControls;

namespace AppDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string selection = "team";
        List<Team> teams;
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
            teams = await ApiConnection.ApiConnection.GetTeamAsync();
            foreach (Team team in teams )
            {
                comboBoxMenu.Items.Add(team.name);
            } 
        }

        private void myExercisePanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ChangeColorBorder(myExercisePanel);
            panelOne.Children.Clear();
            InkCanvas inkCanvas = new InkCanvas();
            panelOne.Children.Add(inkCanvas);
        }

        private void comboBoxMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ChangeColorBorder(myTeamPanel);
            panelOne.Children.Clear();
            TeamPanel teamPanel = new TeamPanel(teams[comboBoxMenu.SelectedIndex]);
            panelOne.Children.Add(teamPanel);
        }

        private void ChangeColorBorder(Border border)
        {
            myTeamPanel.Background = Brushes.LightSeaGreen;
            myExercisePanel.Background = Brushes.LightSeaGreen;
            myMatchesPanel.Background = Brushes.LightSeaGreen;
            theWorldPanel.Background = Brushes.LightSeaGreen;
            border.Background = Brushes.SteelBlue;
        }
    }
}
