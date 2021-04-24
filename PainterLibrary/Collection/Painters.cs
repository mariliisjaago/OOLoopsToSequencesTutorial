using PainterLibrary.Utils;
using System.Collections.Generic;
using System.Linq;

namespace PainterLibrary.Collection
{
    public class Painters
    {
        private IEnumerable<IPainter> _painters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            _painters = painters.ToList();
        }

        public Painters GetAvailable()
        {
            return new Painters(_painters.Where(x => x.IsAvailable));
        }

        public IPainter GetCheapestOne(double sqMeters)
        {
            return _painters.WithMinimum(x => x.EstimateCost(sqMeters));
        }

        public IPainter GetFastestOne(double sqMeters)
        {
            return _painters.WithMinimum(x => x.EstimateTimeToPaint(sqMeters));
        }
    }
}
