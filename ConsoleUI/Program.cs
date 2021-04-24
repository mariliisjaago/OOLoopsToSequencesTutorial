using PainterLibrary;
using PainterLibrary.Collection;
using PainterLibrary.Singles;
using PainterLibrary.Utils;
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
                new JuniorPainter { Name = "Julia", IsAvailable = false },
                new MediumPainter { Name = "Mark", IsAvailable = true }
            };

            double sqMeters = 3;

            //var cheapest = FindCheapest(sqMeters, painters);

            //Console.WriteLine(cheapest.Name);

            //var groupOfPainters = WorkTogether(sqMeters, painters);

            //Console.WriteLine($"total cost: { groupOfPainters.EstimateCost(sqMeters) }");
            //Console.WriteLine($"total time in hrs: { groupOfPainters.EstimateTimeToPaint(sqMeters) }");

            var collectionOfPainters = new Painters(painters);

            var cheapest = FindCheapestOnCollection(sqMeters, collectionOfPainters);

            Console.WriteLine(cheapest.Name);

        }

        private static IPainter FindCheapest(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters.Where(x => x.IsAvailable)
                .WithMinimum(x => x.EstimateCost(sqMeters));
        }

        private static IPainter FindCheapestOnCollection(double sqMeters, Painters painters)
        {
            return painters.GetAvailable().GetCheapestOne(sqMeters);
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
