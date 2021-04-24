using System;

namespace PainterLibrary
{
    public class MediumPainter : IPainter
    {
        public string Name { get; set; }

        public bool IsAvailable { get; set; }

        public double EstimateCost(double sqMeters)
        {
            return 3 * sqMeters;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            TimeSpan oneSqMeterTimeSpan = TimeSpan.FromHours(3);

            return sqMeters * oneSqMeterTimeSpan;
        }
    }
}
