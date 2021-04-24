using System;

namespace PainterLibrary
{
    public class JuniorPainter : IPainter
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public double EstimateCost(double sqMeters)
        {
            return 2 * sqMeters;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            TimeSpan oneSqMeterTimeSpan = TimeSpan.FromHours(4);

            return sqMeters * oneSqMeterTimeSpan;
        }
    }
}
