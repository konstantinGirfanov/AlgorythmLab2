using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;

namespace AlgorythmLab2.Model
{
    public class HanoiTowers
    {
        private List<Tuple<int, int>> transitions;
        private long time;

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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            SolutionHanoibns(countOfRings, 1, 2, 3);
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
        }

        private void SolutionHanoibns(int k, int a, int b, int c)
        {
            if (k > 1) SolutionHanoibns(k - 1, a, c, b);
            transitions.Add(new Tuple<int, int>(a, b));
            if (k > 1) SolutionHanoibns(k - 1, c, b, a);
        }

        public static long[] TakeMeasurements(int countOfRings)
        {
            long[] averageTimes = new long[countOfRings];
            for (int i = 1; i <= countOfRings; i++)
            {
                List<long> timesOnValue = new List<long>();
                for (int j = 0; j < 3; j++)
                {
                    HanoiTowers ht = new HanoiTowers();
                    ht.Execute(i);
                    timesOnValue.Add(ht.time);
                }

                averageTimes[i - 1] = (long)timesOnValue.Average();
            }

            return averageTimes;
        }
    }
}