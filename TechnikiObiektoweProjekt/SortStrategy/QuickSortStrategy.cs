using System;
using System.Collections.Generic;

namespace TechnikiObiektoweProjekt
{
    public class QuickSortStrategy : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            QuickSort(list, 0, list.Count - 1);

        }

        private void QuickSort(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(list, low, high);

                QuickSort(list, low, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, high);
            }
        }

        private int Partition(List<int> list, int low, int high)
        {
            int pivot = list[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    int temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }

            int tempPivot = list[i + 1];
            list[i + 1] = list[high];
            list[high] = tempPivot;

            return i + 1;
        }
    }
}
