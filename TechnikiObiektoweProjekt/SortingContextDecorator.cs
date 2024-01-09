using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TechnikiObiektoweProjekt
{
    public class TimingDecorator : ISortStrategy
    {
        private readonly ISortStrategy decoratedSortStrategy;

        public TimingDecorator(ISortStrategy sortStrategy)
        {
            decoratedSortStrategy = sortStrategy;
        }

        public void Sort(List<int> list)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            decoratedSortStrategy.Sort(list);

            stopwatch.Stop();
            long elapsedTicks = stopwatch.ElapsedTicks;

            double nanoseconds = (double)elapsedTicks / Stopwatch.Frequency * 1_000_000_000;

            SortingContext.Instance.SortingTime = nanoseconds;
        }
    }
}
