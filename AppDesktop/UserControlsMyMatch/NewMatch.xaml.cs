using AppDesktop.Entity;
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

namespace AppDesktop.UserControlsMyMatch
{
    /// <summary>
    /// Lógica de interacción para NewMatch.xaml
    /// </summary>
    public partial class NewMatch : UserControl
    {
        public NewMatch()
        {
            InitializeComponent();
            teamLbl.Content = "Equipo seleccionado: " + Selection.teamSelected.Name;
        }

        private void saveMatchBtn_Click(object sender, RoutedEventArgs e)
        {
            Match newMatch = new Match()
            {
                team = Selection.teamSelected._Id,
                opponent = opponentTxt.Text,
                scoreOne = Int32.Parse(scoreOneTxt.Text),
                scoreTwo = Int32.Parse(scoreTwoTxt.Text),
                date = calendarMatch.SelectedDate == null ? calendarMatch.DisplayDate : (DateTime)calendarMatch.SelectedDate
            };
            ApiConnection.ApiConnection.PostMatchAsync(newMatch);
        }
    }
}
