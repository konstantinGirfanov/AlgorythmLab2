using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmLab2.Model
{
    public class Tower
    {
        public float CoorX { get; }
        public List<Image> Rings { get; set; }

        public Tower(float coorX)
        {
            CoorX = coorX;
            Rings = new List<Image>();
        }
    }
}
