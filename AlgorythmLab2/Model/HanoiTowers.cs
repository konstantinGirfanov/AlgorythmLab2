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
        private List<Stage> stages;

        public HanoiTowers()
        {
            transitions = new List<Tuple<int, int>>();
        }

        public List<Tuple<int, int>> GetTransitions()
        {
            return new List<Tuple<int, int>>(transitions);
        }

        public List<Stage> GetStages()
        {
            return stages;
        }

        public void Execute(int countOfRings)
        {
            transitions.Clear();
            Stage stage = new Stage();
            for (int i = countOfRings; i > 0 ; i--)
            {
                stage.kernel1.Push(i);
            }
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            SolutionHanoibns(countOfRings, 0, 2, 1);
            
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
        }

        private void SolutionHanoibns(int k, int a, int b, int c)
        {
            if (k > 1) SolutionHanoibns(k - 1, a, c, b);
            Stage stage = new Stage();
            transitions.Add(new Tuple<int, int>(a, b));
            if (k > 1) SolutionHanoibns(k - 1, c, b, a);
        }
        
      /*  private void SolutionHanoibns2(int k, Stack<int> kernel1, Stack<int> kernel2, Stack<int> kernel3)
        {
            if (k > 1) SolutionHanoibns2(k - 1, kernel1, kernel3, kernel2);
            kernel2.Push(kernel1.Pop());
            Stage stage = new Stage();
            stage.kernel1 = kernel1;
            stage.kernel2 = kernel2;
            stage.kernel3 = kernel3;
            stages.Add(stage);
            if (k > 1) SolutionHanoibns2(k - 1, kernel3, kernel2, kernel1);
        } */


        public static double[] TakeMeasurements(int countOfRings)
        {
            double[] averageTimes = new double[countOfRings];
            for (int i = 1; i <= countOfRings; i++)
            {
                List<long> timesOnValue = new List<long>();
                for (int j = 0; j < 3; j++)
                {
                    HanoiTowers ht = new HanoiTowers();
                    ht.Execute(i);
                    timesOnValue.Add(ht.time);
                }

                averageTimes[i - 1] = timesOnValue.Average();
            }

            return averageTimes;
        }
    }
}