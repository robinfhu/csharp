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
        //My quicksort function takes a List and returns a List.
        public static List<int> robinQuickSort(List<int> inputList)
        {
            if (inputList.Count <= 1)
            {
                //Recursive stop condition. Don't sort if the list is one item or fewer.
                return inputList;
            }

            int pivot = inputList[0];   //Get a pivot.

            inputList.RemoveAt(0);      //It's important to remove the pivot.

            List<int> smallerHalf = new List<int>();
            List<int> greaterHalf = new List<int>();

            //Split the input list into two parts: values less than pivot, and values greater than pivot.
            foreach(int item in inputList) {
                if (item <= pivot) {
                    smallerHalf.Add(item);
                }
                else{
                    greaterHalf.Add(item);
                }
            }

            //Recursively quicksort the two smaller lists.
            List<int> sortedSmallerHalf = robinQuickSort(smallerHalf);
            List<int> sortedGreaterHalf = robinQuickSort(greaterHalf);

            //Concactenate the two sorted lists, with the pivot in the center.
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
