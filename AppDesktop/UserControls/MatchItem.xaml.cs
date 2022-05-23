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
        public MatchItem()
        {
            InitializeComponent();
        }
        public string ResultMatchlbl { set => resultlbl.Content = value; get => resultlbl.Content.ToString(); }
        public string Datelbl { set => datelbl.Content = value; get => datelbl.Content.ToString(); }
        public string Id { set => idlbl.Content = value; get => idlbl.Content.ToString(); }
    }
}
