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
using SkiaSharp;
using System.Windows.Media;
using AlgorythmLab2.Model;
using static AlgorythmLab2.View.TowersWindow;

namespace AlgorythmLab2.ViewModel
{
    
    public static class HanoiAnimator
    {
        static int firstPoint = 800;
        static string path = "C:\\Users\\User\\source\\repos\\AlgorythmLab2.2\\.vs\\source\\";
        static HanoiTowers hanoi = new HanoiTowers();
        static List<Tuple<int, int>> moves = new List<Tuple<int, int>>();
        public static List<Tower> Towers { get; set; }

        public static void HanoiAnimatorInit(TowersWindow window,int ringCount) 
        {
            bool isNull = Towers is null;
            if (!isNull) Clear(window);
            Towers = new List<Tower>();
            BlockDrawing(window);
            RingsDrawing(window, ringCount);
            hanoi.Execute(ringCount);
            moves = hanoi.GetTransitions();
        }   

        private static void BlockDrawing(TowersWindow window)
        {
            Towers.Add(new Tower(-firstPoint));
            Towers.Add(new Tower(0));
            Towers.Add(new Tower(firstPoint));
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(path + "Block.bmp", UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();

            Image firstTower = new Image();
            Image secondTower = new Image();
            Image thirdTower = new Image();
            int betweenRange = firstPoint;
            
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
        private static void RingsDrawing (TowersWindow window, int ringsCount) 
        {
            List<Image> rings = new List<Image>();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path + "Ring1.bmp", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            double width = 350; // задайте нужные размеры
            double height = 200;
            int upper = -900;
            for (int i = 0; i < ringsCount; i++)
            {
                Image image = new Image();

                image.Source = bitmap;
                Grid.SetColumn(image, 1);
                Grid.SetRowSpan(image, 2);
                image.Margin = new Thickness(-firstPoint, 0, 0, upper);
                image.Stretch = Stretch.None;
                image.Width = width;
                image.Height = height;
                window.TowersGrid.Children.Add(image);
                width -= 12;
                upper += 70;
                rings.Add(image);
                Towers[0].Rings.Add(image); 
            }
            
            
        }
        public static void MoveTheRing(int step)
        {
            int from = 0, to = 0;
            Tower fromTower, toTower;
            
            if (step == 1)
            {
                if (CurrentStep > moves.Count - 1)
                    return;
                Tuple<int, int> move = moves[CurrentStep];
                from = move.Item1;
                to = move.Item2;
            }
            else if (step == -1)
            {
                if (CurrentStep == 0)
                    return;
                Tuple<int, int> move = moves[CurrentStep - 1];
                to = move.Item1;
                from = move.Item2;
            }
            CurrentStep += step;
            fromTower = Towers[from];
            toTower = Towers[to];
            Image ring = fromTower.Rings[fromTower.Rings.Count - 1];
            fromTower.Rings.Remove(ring);
            toTower.Rings.Add(ring);
            ring.Margin = new Thickness(toTower.CoorX, 900 - (toTower.Rings.Count - 1) * 70, 0, 0);
        }

        private static void Clear(TowersWindow window)
        {
            for (int i = 0; i < Towers.Count; i++)
            {
                Tower t = Towers[i];
                for (int j = 0; j < t.Rings.Count; j++)
                {
                    Image ring = t.Rings[j];
                    window.TowersGrid.Children.Remove(ring);
                    t.Rings.Remove(ring);
                }
            }
        }
    }
}
