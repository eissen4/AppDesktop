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

namespace AppDesktop.UserControlsMyTeam
{
    /// <summary>
    /// Lógica de interacción para PlayerMyTeamItem.xaml
    /// </summary>
    public partial class PlayerMyTeamItem : UserControl
    {
        public PlayerMyTeamItem()
        {
            InitializeComponent();
        }
        public string ResultMatchlbl { set => resultlbl.Content = value; get => resultlbl.Content.ToString(); }
        public string Datelbl { set => datelbl.Content = value; get => datelbl.Content.ToString(); }
        public string PointsLbl { set => pointsLbl.Content = value; get => pointsLbl.Content.ToString(); }
        public string ReboundsLbl { set => reboundsLbl.Content = value; get => reboundsLbl.Content.ToString(); }
        public string AssistsLbl { set => assistsLbl.Content = value; get => assistsLbl.Content.ToString(); }
    }
}
