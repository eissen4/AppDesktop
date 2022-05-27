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

        private void saveExercise_Click(object sender, RoutedEventArgs e)
        {
            ////int margin = (int)exerciseInk.Margin.Left;
            //int width = (int)exerciseInk.ActualWidth;
            //int height = (int)exerciseInk.ActualHeight;
            ////render ink to bitmap
            //RenderTargetBitmap renderBitmap =
            //new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
            //renderBitmap.Render(exerciseInk);
            ////save the ink to a memory stream
            //FileStream stream = new FileStream("file.jpg", FileMode.Create);
            //BitmapEncoder encoder;
            //encoder = new BmpBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
            //encoder.Save(stream);
            //stream.Close();
            //PresentationSource source = PresentationSource.FromVisual(exerciseInk);
            //RenderTargetBitmap rtb = new RenderTargetBitmap((int)exerciseInk.RenderSize.Width,
            //      (int)exerciseInk.RenderSize.Height, 96, 96, PixelFormats.Default);

            //VisualBrush sourceBrush = new VisualBrush(exerciseInk);
            //DrawingVisual drawingVisual = new DrawingVisual();
            //DrawingContext drawingContext = drawingVisual.RenderOpen();
            //using (drawingContext)
            //{
            //    drawingContext.DrawRectangle(sourceBrush, null, new Rect(new System.Windows.Point(0, 0),
            //          new System.Windows.Point((int)exerciseInk.RenderSize.Width, (int)exerciseInk.RenderSize.Height)));
            //}
            //rtb.Render(drawingVisual);
            //FileStream stream = new FileStream("file.jpg", FileMode.Create);
            //BitmapEncoder encoder;
            //encoder = new BmpBitmapEncoder();
            //encoder.Frames.Add(BitmapFrame.Create(rtb));
            //encoder.Save(stream);
            //stream.Close();
        }
    }
}
