using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AlgorythmLab2.Model;
using MathNet.Numerics;
using ScottPlot;
using ScottPlot.Plottables;

namespace AlgorythmLab2.ViewModel
{
    public class GraphicBuilder
    {
        public static void BuildGraph(List<double> dataX, List<double> dataY, string name)
        {
            Plot plot = new Plot();
            plot.Title(name);
            Func<double, double> f = Fit.LinearCombinationFunc(
                dataX.GetRange(0, dataX.Count - 1).ToArray(),
                dataY.GetRange(0, dataY.Count - 1).ToArray(),
                x => Math.Pow(2, x));

            Scatter scatter1 = plot.Add.Scatter(dataX, dataY, Color.FromHex("0f03fc"));
            scatter1.Label = "Real Time";
            
            Scatter scatter2 = plot.Add.Scatter(dataX, dataX.Select(x => f(x)).ToArray(), Color.FromHex("fa0202"));
            scatter2.Label = "Approximation";

            plot.XLabel("Count of rings");
            plot.YLabel("Time, ms");
            plot.Legend();
            plot.SavePng("test.png", 700, 700);
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]

        public static void Draw(int countOfRings)
        {
            double[] times = HanoiTowers.TakeMeasurements(countOfRings);
            List<double> list = new List<double>();
            foreach (var i in Enumerable.Range(1, countOfRings)) list.Add(i);
            BuildGraph(list, times.ToList(), "Hanoi Tower");
        }
    }
}