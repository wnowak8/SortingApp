using System;
using System.Collections.Generic;

namespace TechnikiObiektoweProjekt
{
    public class SelectionSortStrategy : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            int n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }

                int temp = list[minIndex];
                list[minIndex] = list[i];
                list[i] = temp;
            }
        }
    }
}
