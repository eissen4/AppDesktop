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

namespace AppDesktop.UsersControloMyExercise
{
    /// <summary>
    /// Lógica de interacción para ExerciseFull.xaml
    /// </summary>
    public partial class ExerciseFull : UserControl
    {
        public ExerciseFull(string exerciseUrl)
        {
            InitializeComponent();
            if (exerciseUrl != null)
            {
                exerciseImage.Source = new BitmapImage(new Uri(exerciseUrl, UriKind.Absolute));
            }
            
        }
        public string Title { get => titleLbl.Content.ToString(); set => titleLbl.Content = value; }
        public string Description { get => descriptionLbl.Content.ToString(); set => descriptionLbl.Content = value; }
        public string Value { get => valueLbl.Content.ToString(); set => valueLbl.Content = value; }
        public string User { get => userLbl.Content.ToString(); set => userLbl.Content = value; }
    }
}
