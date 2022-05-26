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
    /// Lógica de interacción para PlayerItem.xaml
    /// </summary>
    public partial class PlayerItem : UserControl
    {
        public PlayerItem()
        {
            InitializeComponent();
        }

        public string NamePlayerLbl { set => namePlayerLbl.Content = value; get => namePlayerLbl.Content.ToString(); }
        public string HeightPlayerLbl { set => heightPlayerLbl.Content = value; get => heightPlayerLbl.Content.ToString(); }
        public string WeightPlayerLbl { set => weightPlayerLbl.Content = value; get => weightPlayerLbl.Content.ToString(); }

    }
    public class StatsPlayer
    {
        public int Points { get; set; }
        public int Rebounds { get; set; }
        public int Assists { get; set; }
    }
}


