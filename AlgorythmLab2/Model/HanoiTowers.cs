using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace AlgorythmLab2.Model
{
    public class HanoiTowers
    {
        private List<Tuple<int, int>> transitions;

        public HanoiTowers()
        {
            transitions = new List<Tuple<int, int>>();
        }

        public List<Tuple<int, int>> GetTransitions()
        {
            return new List<Tuple<int, int>>(transitions);
        }

        public void Execute(int countOfRings)
        {
            transitions.Clear();
            SolutionHanoibns(countOfRings, 1, 2, 3);
        }

        public void SolutionHanoibns(int k, int a, int b, int c)
        {
            if (k > 1) SolutionHanoibns(k - 1, a, c, b);
            transitions.Add(new Tuple<int, int>(a, b));
            if (k > 1) SolutionHanoibns(k - 1, c, b, a);
        }
    }
}