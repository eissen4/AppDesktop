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

namespace AppDesktop.UserControls
{
    /// <summary>
    /// Lógica de interacción para Match.xaml
    /// </summary>
    public partial class MatchItem : UserControl
    {
        StackPanel newPanelOne;
        StackPanel newPanelTwo;
        public MatchItem(StackPanel panelOne, StackPanel panelTwo)
        {
            InitializeComponent();
            newPanelOne = panelOne;
            newPanelTwo = panelTwo;
        }
        public string ResultMatchlbl { set => resultlbl.Content = value; get => resultlbl.Content.ToString(); }
        public string Datelbl { set => datelbl.Content = value; get => datelbl.Content.ToString(); }
        public string Idlbl { set => idlbl.Content = value; get => idlbl.Content.ToString(); }

        private async void deleteMatchlbl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                await ApiConnection.ApiConnection.DeleteMatchAsync(Idlbl);
                newPanelOne.Children.Clear();
                newPanelTwo.Children.Clear();
                MatchesStackPanel matchesStackPanel = new MatchesStackPanel(newPanelOne, newPanelTwo);
                MessageBox.Show("Se ha borrado el partido...");
            } catch 
            {
                MessageBox.Show("NO se ha podido borrar correctemante el partido");
            }
            
        }
    }
}
