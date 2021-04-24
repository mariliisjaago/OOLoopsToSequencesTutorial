using System;

namespace PainterLibrary
{
    public class HousePainter : IPainter
    {
        public bool IsAvailable { get; set; }

        public double EstimateCost(double sqMeters)
        {
            return 5 * sqMeters;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            TimeSpan oneSqMeterTimeSpan = TimeSpan.FromHours(2);

            return 5 * oneSqMeterTimeSpan;
        }
    }
}
