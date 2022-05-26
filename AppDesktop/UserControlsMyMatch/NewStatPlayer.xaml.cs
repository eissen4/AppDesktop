using AppDesktop.Entity;
using System;
using System.Collections.Generic;
using System.Text;
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

namespace AppDesktop.UserControlsMyMatch
{
    /// <summary>
    /// Lógica de interacción para NewStatPlayer.xaml
    /// </summary>
    public partial class NewStatPlayer : UserControl
    {
        public NewStatPlayer()
        {
            getData(); 
            InitializeComponent();
        }

        private async Task getData()
        {
            List<Player> = await ApiConnection.ApiConnection.GetPlayersAsync(Selection.teamSelected._id);

        }

        private async Task getPlayerMatches()
        {
            await ApiConnection.ApiConnection.GetPlayerMatchesAsync();
        }
    }
}
