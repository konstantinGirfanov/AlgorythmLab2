using AlgorythmLab2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Data.SqlTypes;

namespace AlgorythmLab2.ViewModel
{
    public class HanoiAnimator
    {
        string path = "C:\\Users\\User\\source\\repos\\AlgorythmLab2.2\\.vs\\source\\"; 
        public HanoiAnimator(TowersWindow window,int ringCount, int stepNumber) 
        {
            BlockDrawing(window);
        }

        private void BlockDrawing(TowersWindow window)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(path + "Block.bmp", UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();

            Image firstTower = new Image();
            Image secondTower = new Image();
            Image thirdTower = new Image();
            int betweenRange = 800;
            int firstPoint = betweenRange;
            Image[] images = { firstTower, secondTower, thirdTower };
            foreach (Image image in images)
            {
                Grid.SetColumn(image, 1);
                Grid.SetRowSpan(image, 2);
                image.Margin = new Thickness(betweenRange, 0, 0, 0);
                betweenRange -= firstPoint;
                image.Source = bitmapImage;
                window.TowersGrid.Children.Add(image);
            }
        }
        private void RingsDrawing (TowersWindow window, int stepNumber) 
        { 
        
        }
    }
}
