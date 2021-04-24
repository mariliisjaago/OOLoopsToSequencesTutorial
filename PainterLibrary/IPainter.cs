using System;

namespace PainterLibrary
{
    public interface IPainter
    {
        bool IsAvailable { get; }
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCost(double sqMeters);
    }
}
