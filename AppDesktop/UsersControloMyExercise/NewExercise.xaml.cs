using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace AppDesktop.UsersControloMyExercise
{
    /// <summary>
    /// Lógica de interacción para NewExercise.xaml
    /// </summary>
    public partial class NewExercise : UserControl
    {
        public NewExercise()
        {
            InitializeComponent();
        }

        private void redInkLbl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            exerciseInk.DefaultDrawingAttributes.Color = Colors.Red;
            colorsStck.Children.Clear();
            whiteSelectionBrd.Child = redSelectionBrd;
            colorsStck.Children.Add(blackSelectionBrd);
            colorsStck.Children.Add(whiteSelectionBrd);
            colorsStck.Children.Add(blueSelectionBrd);
            colorsStck.Children.Add(yellowSelectionBrd);

        }

        private void blackInkLbl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            exerciseInk.DefaultDrawingAttributes.Color = Colors.Black;
            colorsStck.Children.Clear();
            whiteSelectionBrd.Child = blackSelectionBrd;
            colorsStck.Children.Add(whiteSelectionBrd);
            colorsStck.Children.Add(redSelectionBrd);
            colorsStck.Children.Add(blueSelectionBrd);
            colorsStck.Children.Add(yellowSelectionBrd);
        }

        private void blueInkLbl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            exerciseInk.DefaultDrawingAttributes.Color = Colors.Blue;
            colorsStck.Children.Clear();
            whiteSelectionBrd.Child = blueSelectionBrd;
            colorsStck.Children.Add(blackSelectionBrd);
            colorsStck.Children.Add(redSelectionBrd);
            colorsStck.Children.Add(whiteSelectionBrd);
            colorsStck.Children.Add(yellowSelectionBrd);
        }

        private void yellowInkLbl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            exerciseInk.DefaultDrawingAttributes.Color = Colors.Yellow;
            colorsStck.Children.Clear();
            whiteSelectionBrd.Child = yellowSelectionBrd;
            colorsStck.Children.Add(blackSelectionBrd);
            colorsStck.Children.Add(redSelectionBrd);
            colorsStck.Children.Add(blueSelectionBrd);
            colorsStck.Children.Add(whiteSelectionBrd);
        }

        private void EraseIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            colorsStck.Children.Clear();
            inkStck.Children.Remove(exerciseInk);
            InkCanvas exerciseInk2 = new InkCanvas();
            exerciseInk2.Background = System.Windows.Media.Brushes.Transparent;
            inkStck.Children.Add(exerciseInk2);
            whiteSelectionBrd.Child = null;
            colorsStck.Children.Add(blackSelectionBrd);
            colorsStck.Children.Add(redSelectionBrd);
            colorsStck.Children.Add(blueSelectionBrd);
            colorsStck.Children.Add(yellowSelectionBrd);
        }

        private async void SaveIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var rect = new Rect(exerciseInk.RenderSize);
            var visual = new DrawingVisual();

            using (var dc = visual.RenderOpen())
            {
                dc.DrawRectangle(new VisualBrush(exerciseInk), null, rect);
            }

            var bitmap = new RenderTargetBitmap(
                (int)rect.Width, (int)rect.Height, 96, 96, PixelFormats.Default);
            bitmap.Render(visual);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            try
            {
                using (var file = File.OpenWrite("file.jpg"))
                {
                    encoder.Save(file);
                    file.Close();
                }
                await ApiConnection.ApiConnection.PostImage(titleTxt.Text, descriptionTxt.Text);
                MessageBox.Show("Guardado correctamente");
                colorsStck.Children.Clear();
                inkStck.Children.Remove(exerciseInk);
                InkCanvas exerciseInk2 = new InkCanvas();
                exerciseInk2.Background = System.Windows.Media.Brushes.Transparent;
                inkStck.Children.Add(exerciseInk2);
                whiteSelectionBrd.Child = null;
                colorsStck.Children.Add(blackSelectionBrd);
                colorsStck.Children.Add(redSelectionBrd);
                colorsStck.Children.Add(blueSelectionBrd);
                colorsStck.Children.Add(yellowSelectionBrd);
                titleTxt.Text = "";
                descriptionTxt.Text = "";
            } catch
            {
                MessageBox.Show("El ejercicio no se ha guardado");
            }
            
        }
    }
}
