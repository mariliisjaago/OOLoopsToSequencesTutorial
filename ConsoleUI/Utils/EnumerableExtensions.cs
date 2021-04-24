using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ConsoleUI.Utils
{
    public static class EnumerableExtensions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey>
        {
            var output = sequence.Select(x => Tuple.Create(x, criterion(x)))
                .Aggregate(
                    (Tuple<T, TKey>)null,
                    (best, cur) =>
                    best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best
                    )
                .Item1;

            return output;
        }
    }
}
