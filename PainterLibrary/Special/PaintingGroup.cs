using PainterLibrary.Singles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PainterLibrary.Special
{
    public class PaintingGroup : IPainter
    {
        private IEnumerable<ProportionalPainter> _painters { get; }

        public string Name { get; set; }

        public bool IsAvailable => _painters.Any(x => x.IsAvailable);

        public PaintingGroup(IEnumerable<ProportionalPainter> painters)
        {
            _painters = painters.ToList();
        }

        private IPainter Reduce(double sqMeters)
        {
            var sumOfTimeProportions = _painters.Where(x => x.IsAvailable)
                .Select(x => 1 / x.EstimateTimeToPaint(sqMeters).TotalHours)
                .Sum();

            TimeSpan time = TimeSpan.FromHours(1 / sumOfTimeProportions);

            var cost = _painters.Where(x => x.IsAvailable)
                .Select(x => x.EstimateCost(sqMeters) / x.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                .Sum();

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            return Reduce(sqMeters).EstimateTimeToPaint(sqMeters);
        }

        public double EstimateCost(double sqMeters)
        {
            return Reduce(sqMeters).EstimateCost(sqMeters);
        }
    }
}
