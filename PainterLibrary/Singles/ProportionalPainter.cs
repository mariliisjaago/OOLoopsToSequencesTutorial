using System;
using System.Collections.Generic;
using System.Text;

namespace PainterLibrary.Singles
{
    public class ProportionalPainter : IPainter
    {
        public TimeSpan TimePerSqMeter { get; set; }
        public double DollarsPerHour { get; set; }

        public string Name { get; set; }

        public bool IsAvailable => true;

        public double EstimateCost(double sqMeters)
        {
            return EstimateTimeToPaint(sqMeters).TotalHours * DollarsPerHour;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            return TimeSpan.FromHours(TimePerSqMeter.TotalHours * sqMeters);
        }
    }
}
