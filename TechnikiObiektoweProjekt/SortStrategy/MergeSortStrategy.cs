using System;
using System.Collections.Generic;

namespace TechnikiObiektoweProjekt
{
    public class MergeSortStrategy : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            MergeSort(list, 0, list.Count - 1);
        }

        private void MergeSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(list, left, middle);
                MergeSort(list, middle + 1, right);

                Merge(list, left, middle, right);
            }
        }

        private void Merge(List<int> list, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            List<int> leftArr = new List<int>(n1);
            List<int> rightArr = new List<int>(n2);

            for (int leftIndex = 0; leftIndex < n1; ++leftIndex)
                leftArr.Add(list[left + leftIndex]);

            for (int rightIndex = 0; rightIndex < n2; ++rightIndex)
                rightArr.Add(list[middle + 1 + rightIndex]);

            int mergeIndex = left;
            int leftArrIndex = 0, rightArrIndex = 0;

            while (leftArrIndex < n1 && rightArrIndex < n2)
            {
                if (leftArr[leftArrIndex] <= rightArr[rightArrIndex])
                {
                    list[mergeIndex] = leftArr[leftArrIndex];
                    leftArrIndex++;
                }
                else
                {
                    list[mergeIndex] = rightArr[rightArrIndex];
                    rightArrIndex++;
                }
                mergeIndex++;
            }

            while (leftArrIndex < n1)
            {
                list[mergeIndex] = leftArr[leftArrIndex];
                leftArrIndex++;
                mergeIndex++;
            }

            while (rightArrIndex < n2)
            {
                list[mergeIndex] = rightArr[rightArrIndex];
                rightArrIndex++;
                mergeIndex++;
            }
        }

    }
}
