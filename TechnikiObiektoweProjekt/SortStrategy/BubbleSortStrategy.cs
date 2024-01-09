using System;
using System.Collections.Generic;

namespace TechnikiObiektoweProjekt
{
    public class BubbleSortStrategy : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            int n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
    }
}
