using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 A really simple implementation of quicksort (not in place) in C#.
 * By Robin Hu
 * 3/23/2013
 */
namespace Design_Patterns
{
    class RobinQuickSort
    {
        public static List<int> robinQuickSort(List<int> inputList)
        {
            if (inputList.Count <= 1)
            {
                return inputList;
            }

            int pivot = inputList[0];

            inputList.RemoveAt(0);

            List<int> smallerHalf = new List<int>();
            List<int> greaterHalf = new List<int>();

            foreach(int item in inputList) {
                if (item <= pivot) {
                    smallerHalf.Add(item);
                }
                else{
                    greaterHalf.Add(item);
                }
            }

            List<int> sortedSmallerHalf = robinQuickSort(smallerHalf);
            List<int> sortedGreaterHalf = robinQuickSort(greaterHalf);

            sortedSmallerHalf.Add(pivot);
            sortedSmallerHalf.AddRange(sortedGreaterHalf);
            return sortedSmallerHalf;
        }

        static void Main(string[] args)
        {
            int[] unsortedInts = { 45, 6, 81, 10, 12, 99, 31, 43, 59, 103, 21, 10, 1, 0, 67 };
            List<int> unsortedList = new List<int>(unsortedInts);
            List<int> sorted = robinQuickSort(unsortedList);

            sorted.ForEach(delegate(int item)
            {
                Console.Write(item.ToString() + ", ");
            });
            Console.ReadLine();
        }
    }
}
