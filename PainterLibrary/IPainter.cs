using System;

namespace PainterLibrary
{
    public interface IPainter
    {
        string Name { get; }
        bool IsAvailable { get; }
        TimeSpan EstimateTimeToPaint(double sqMeters);
        double EstimateCost(double sqMeters);
    }
}
