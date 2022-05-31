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
using AppDesktop.UserControlsLoginRegister;
using AppDesktop.UserControlsTheWorld;
using AppDesktop.UsersControloMyExercise;

namespace AppDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Team> teams;
        public MainWindow()
        {
            InitializeComponent();
            LoginPanel();
            RegisterPanel();
        }

        private void LoginPanel()
        {
            Login login = new Login();
            panelOne.Children.Add(login);
        }

        private void RegisterPanel()
        {

        }

        private async Task getToken(string username, string password)
        {
            ApiMethods apiMethods = new ApiMethods();
            string token = await ApiConnection.ApiConnection.Login(username, password);
            apiMethods.Token = token;
            getTeams();
        }

        private void getMatches()
        {
            MatchesStackPanel matchesStackPanel = new MatchesStackPanel(panelOne,panelTwo);
            panelOne.Children.Add(matchesStackPanel);
        }

        public async void getTeams()
        {
            teams = await ApiConnection.ApiConnection.GetTeamAsync();
            foreach (Team team in teams)
            {
                comboBoxMenu.Items.Add(team.name);
            }
            comboBoxMenu.SelectedIndex = 0;
            NavBar navBar = new NavBar(panelOne, panelTwo);
            navBarBorder.Child = navBar;
        }

        private void myExercisePanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Selection.selection = 3;
            ChangeColorBorder(myExercisePanel);
            Exercises exercises = new Exercises(panelOne, panelTwo);
        }

        private void comboBoxMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selection.teamSelected = teams[comboBoxMenu.SelectedIndex];
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Selection.selection = 1;
            ChangeColorBorder(myTeamPanel);
            panelOne.Children.Clear();
            TeamPanel teamPanel = new TeamPanel(panelTwo);
            panelOne.Children.Add(teamPanel);
        }

        private void ChangeColorBorder(Border border)
        {
            myTeamPanel.Background = Brushes.LightSeaGreen;
            myExercisePanel.Background = Brushes.LightSeaGreen;
            myMatchesPanel.Background = Brushes.LightSeaGreen;
            theWorldPanel.Background = Brushes.LightSeaGreen;
            border.Background = Brushes.SteelBlue;
            panelOne.Children.Clear();
            panelTwo.Children.Clear();
        }

        private void myMatchesPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Selection.selection = 2;
            ChangeColorBorder(myMatchesPanel);
            getMatches();
        }

        private void theWorldPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Selection.selection = 4;
            ChangeColorBorder(theWorldPanel);
            TheWorldPanel newWorldPanel = new TheWorldPanel(panelTwo);
            panelOne.Children.Add(newWorldPanel);
        }
    }
    public class Selection
    {
        public static int selection { get; set; }
        public static Team teamSelected { get; set; }
    }
}

