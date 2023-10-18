using System.Collections.Generic;

namespace AlgorythmLab2.Model
{
    public class Stage
    {
        public Stack<int> kernel1;
        public Stack<int> kernel2;
        public Stack<int> kernel3;

        public Stage()
        {
            kernel1 = new Stack<int>();
            kernel2 = new Stack<int>();
            kernel3 = new Stack<int>();
        }
    }
}