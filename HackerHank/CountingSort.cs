using System.Collections.Generic;
using System.Linq;

namespace HackerHank
{
    public static class CountingSort
    {
        /*        
        Given a list of integers, count and return the number of times each value appears as an array of integers.
        
        arr[n]: an array of integers
        Returns

        int[100]: a frequency array
        */
        public static List<int> countingSort(List<int> arr)
        {
            int[] range = new int[100];

            foreach (int value in arr)
                range[value]++;

            return range.ToList();
        }
    }
}
