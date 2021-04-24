using PainterLibrary;
using PainterLibrary.Collection;
using PainterLibrary.Singles;
using PainterLibrary.Special;
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

            //var collectionOfPainters = new Painters(painters);

            //var cheapest = FindCheapestOnCollection(sqMeters, collectionOfPainters);

            //Console.WriteLine(cheapest.Name);

            var proportionalPainters = new List<ProportionalPainter>
            {
                new ProportionalPainter { DollarsPerHour = 10, TimePerSqMeter = TimeSpan.FromHours(4) },
                new ProportionalPainter { DollarsPerHour = 5, TimePerSqMeter = TimeSpan.FromHours(6) },
                new ProportionalPainter { DollarsPerHour = 3, TimePerSqMeter = TimeSpan.FromHours(8) },
            };

            var paintingGroup = new PaintingGroup(proportionalPainters);

            Console.WriteLine($"cost: { paintingGroup.EstimateCost(sqMeters) }");
            Console.WriteLine($"time: { paintingGroup.EstimateTimeToPaint(sqMeters).TotalHours }");


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

        private static IPainter FindFastestOnCollection(double sqMeters, Painters painters)
        {
            return painters.GetAvailable().GetFastestOne(sqMeters);
        }

    }
}
