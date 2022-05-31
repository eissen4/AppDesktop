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

namespace AppDesktop.UsersControloMyExercise
{
    /// <summary>
    /// Lógica de interacción para Exercises.xaml
    /// </summary>
    public partial class Exercises : UserControl
    {
        List<Exercise> exercises;
        StackPanel newPanelTwo;
        StackPanel newPanelOne;
        public Exercises(StackPanel panelOne, StackPanel panelTwo)
        {
            InitializeComponent();
            UpdateExercise();
            newPanelOne = panelOne;
            newPanelTwo = panelTwo;
        }
        private async void UpdateExercise()
        {
            exercises = await ApiConnection.ApiConnection.GetExercisesAsync();

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
