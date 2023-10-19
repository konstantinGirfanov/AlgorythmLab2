using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlgorythmLab2.Model
{
    public class CoordinateCalculator
    {
        private double _scale = 0.35;
        private int _depth;

        public List<Polyline> StarsPolylines { get; }

        public CoordinateCalculator(int depth)
        {
            //_scale = scale;
            StarsPolylines = new List<Polyline>();
            _depth = depth;
        }

        public void ChangeScale(double scale)
        {
            _scale = scale;
        }

        public void ChangeDepth(int depth)
        {
            if (depth <= 0 || depth >= 7) return;
            _depth = depth;
        }

        public void Execute(double xmid, double ymid)
        {
            StarsPolylines.Clear();
            CalculateStar(1, xmid, ymid, 100, -1);
        }

        private void CalculateStar(int level, double x, double y, double r, int skip, bool isRotate = true)
        {
            double offset = isRotate ? Math.PI / 2 : -Math.PI / 2;
            const double angle = 4 * Math.PI / 5;
            Polyline star = new Polyline();
            star.Stroke = Brushes.DarkRed;
            //image.Children.Add(star);


            for (int i = 0; i <= 5; i++)
            {
                var angleT = offset + i * angle;

                var lx = (int)(x + r * Math.Cos(angleT));
                var ly = (int)(y + r * Math.Sin(angleT));
                star.Points.Add(new Point(lx, ly));

                if (level < _depth)
                {
                    var newrad = r * _scale;
                    var lx2 = x + (r + newrad) * Math.Cos(angleT);
                    var ly2 = y + (r + newrad) * Math.Sin(angleT);
                    if (i != skip && i != 5)
                    {
                        CalculateStar(level + 1, lx2, ly2, newrad, i, !isRotate);
                    }
                }
            }
            
            StarsPolylines.Add(star);
        }
    }
}