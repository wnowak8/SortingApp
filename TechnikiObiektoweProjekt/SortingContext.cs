using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TechnikiObiektoweProjekt
{
    public class SortingContext
    {
        private ISortStrategy sortStrategy;
        public double SortingTime { get; set; }

        private static SortingContext instance;


        public static SortingContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SortingContext();
                }
                return instance;
            }
        }

        public void SetStrategy(ISortStrategy strategy)
        {
            sortStrategy = strategy;
        }

        public void ExecuteSort(List<int> list)
        {
            sortStrategy.Sort(list);

        }
    }
}
