using ConsoleUI.Utils;
using PainterLibrary;
using PainterLibrary.Singles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var painters = new List<IPainter>
            {
                new SeniorPainter { Name = "Jason", IsAvailable = true },
                new JuniorPainter { Name = "Julia", IsAvailable = true },
                new MediumPainter { Name = "Mark", IsAvailable = true }
            };

            double sqMeters = 3;

            //var cheapest = FindCheapest(sqMeters, painters);

            //Console.WriteLine(cheapest.Name);

            var groupOfPainters = WorkTogether(sqMeters, painters);

            Console.WriteLine($"total cost: { groupOfPainters.EstimateCost(sqMeters) }");
            Console.WriteLine($"total time in hrs: { groupOfPainters.EstimateTimeToPaint(sqMeters) }");

        }

        private static IPainter FindCheapest(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters.Where(x => x.IsAvailable)
                .WithMinimum(x => x.EstimateCost(sqMeters));
        }

        private static IPainter FindFastest(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters.Where(x => x.IsAvailable)
                .WithMinimum(x => x.EstimateTimeToPaint(sqMeters));
        }

        private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {
            var sumOfTimeProportions = painters.Where(x => x.IsAvailable)
                .Select(x => 1 / x.EstimateTimeToPaint(sqMeters).TotalHours)
                .Sum();

            TimeSpan time = TimeSpan.FromHours(1 / sumOfTimeProportions);

            var cost = painters.Where(x => x.IsAvailable)
                .Select(x => x.EstimateCost(sqMeters) / x.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                .Sum();

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }
    }
}
