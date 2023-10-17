using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Animation;
using System.Drawing;

namespace AlgorythmLab2.Model
{
    public class Star
    {
        private List<Point> _points;

        public void AddPoint(Point point)
        {
            _points.Add(point);
        }

        public List<Point> GetPoints()
        {
            return new List<Point>(_points);
        }
    }
}