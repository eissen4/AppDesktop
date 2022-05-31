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
    /// Lógica de interacción para ExerciseItem.xaml
    /// </summary>
    public partial class ExerciseItem : UserControl
    {
        public ExerciseItem()
        {
            InitializeComponent();
        }
        public string TitleLbl { get => titleLbl.Content.ToString(); set => titleLbl.Content = value; }
        public string ValueLbl { get => valueLbl.Content.ToString(); set => valueLbl.Content = value; }
        public string UserLbl { get => userLbl.Content.ToString(); set => userLbl.Content = value; }
        public string DescriptionLbl { get => descriptionLbl.Content.ToString(); set => descriptionLbl.Content = value; }   
    }
}
