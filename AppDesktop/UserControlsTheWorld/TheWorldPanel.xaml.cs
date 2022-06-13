using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using AppDesktop.Entity;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppDesktop.UsersControloMyExercise;

namespace AppDesktop.UserControlsTheWorld
{
    /// <summary>
    /// Lógica de interacción para TheWorldPanel.xaml
    /// </summary>
    public partial class TheWorldPanel : UserControl
    {
        StackPanel newPanelOne;
        StackPanel newPanelTwo;
        List<Exercise> exercises;
        public TheWorldPanel(StackPanel panelOne, StackPanel panelTwo)
        {
            InitializeComponent();
            newPanelOne = panelOne;
            newPanelTwo = panelTwo;
        }

        private async void buscadorBtn_Click(object sender, RoutedEventArgs e)
        {
           newPanelOne.Children.Clear();
            TheWorldPanel theWorldPanel = new TheWorldPanel(newPanelOne, newPanelTwo);
            newPanelOne.Children.Add(theWorldPanel);
            if (buscadorTxtB.Text != "")
            {
                exercises = await ApiConnection.ApiConnection.GetExercisesWorldAsync(buscadorTxtB.Text);
                exercises.ForEach(exercise =>
                {
                    ExerciseItem exerciseItem = new ExerciseItem()
                    {
                        TitleLbl = "Título: " + exercise.Title,
                        //Value = "Valoración: " + exercise.Value.ToString(),
                        DescriptionLbl = exercise.Description,
                    };
                    exerciseItem.MouseLeftButtonUp += (sender, e) => ExerciseItem_MouseLeftButtonUp(sender, e, exercise);
                    newPanelOne.Children.Add(exerciseItem);
                });
            } else
            {
                MessageBox.Show("Introduce al menos una palabra");
            }
           
        }

        private void ExerciseItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e, Exercise exercise)
        {
            newPanelTwo.Children.Clear();
            ExerciseFull exerciseFull = new ExerciseFull(exercise.ImageUrl)
            {
                Title = exercise.Title,
                //Value = exercise.Value.ToString(),
                Description = exercise.Description
            };
            newPanelTwo.Children.Add(exerciseFull);
        }

    }
}
