using PainterLibrary;
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

            double sqMeters = 40;

            var cheapest = FindCheapest(sqMeters, new List<IPainter>());

            
        }

        private static IPainter FindCheapest(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters.Where(x => x.IsAvailable)
                .Aggregate((IPainter)null, (best, cur) =>
                    cur.EstimateCost(sqMeters) < best.EstimateCost(sqMeters) ? cur : best
                    );
            
        }
    }
}
