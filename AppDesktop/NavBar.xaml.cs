using AppDesktop.UserControls;
using AppDesktop.UserControlsMyMatch;
using AppDesktop.UsersControloMyExercise;
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

namespace AppDesktop
{
    /// <summary>
    /// Lógica de interacción para NavBar.xaml
    /// </summary>
    public partial class NavBar : UserControl
    {
        StackPanel newPanelOne;
        StackPanel newPanelTwo;
        public NavBar(StackPanel panelOne, StackPanel panelTwo)
        {
            InitializeComponent();
            newPanelOne = panelOne;
            newPanelTwo = panelTwo;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Selection.selection == 1) AddPanelNewTeam();
            if (Selection.selection == 2) AddPanelNewMatch();
            if (Selection.selection == 3) AddPanelNewExercise();         
        }

        private void AddPanelNewExercise()
        {
            newPanelOne.Children.Clear();
            NewExercise newExercise = new NewExercise();
            newPanelOne.Children.Add(newExercise);
            newPanelTwo.Children.Clear();
        }

        private void AddPanelNewMatch()
        {
            newPanelOne.Children.Clear();
            NewMatch newMatch = new NewMatch();
            newPanelOne.Children.Add(newMatch);
            newPanelTwo.Children.Clear();   
            NewStatPlayer newStatPlayer = new NewStatPlayer();  
            newPanelTwo.Children.Add(newStatPlayer);
        }

        private void AddPanelNewTeam()
        {
            newPanelOne.Children.Clear();
            NewTeam newTeam = new NewTeam(saveBtn);
            newPanelOne.Children.Add(newTeam);
            newPanelTwo.Children.Clear();
            NewPlayer newPlayer = new NewPlayer();
            newPanelTwo.Children.Add(newPlayer);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
