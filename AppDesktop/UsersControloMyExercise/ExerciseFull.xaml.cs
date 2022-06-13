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
                string uri = "http://localhost:3000/uploads/" + exerciseUrl;
                exerciseImage.Source = new BitmapImage(new Uri( uri ));
            } 
        }
        public string Title { get => titleLbl.Content.ToString(); set => titleLbl.Content = value; }
        public string Description { get => descriptionLbl.Content.ToString(); set => descriptionLbl.Content = value; }
        public string Value { get => valueLbl.Content.ToString(); set => valueLbl.Content = value; }
        public string User { get => userLbl.Content.ToString(); set => userLbl.Content = value; }

        private void heartImage_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void heartBtn_Click(object sender, RoutedEventArgs e)
        {
            Boolean flag = true;
            if (flag == true)
            {
                heartImage.Source = new BitmapImage(new Uri("http://localhost:3000/uploads/heart_full.jpg"));
                valueLbl.Content = "51";
                flag = false;
            } else
            {
                heartImage.Source = new BitmapImage(new Uri("http://localhost:3000/uploads/heart_empty.png"));
                valueLbl.Content = "50";
                flag = true;
            }
            
        }
    }
}
