using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace HackerRank
{
    public static class HackerRank
    {
        static void Main(string[] args)
        {
            lonelyinteger(new List<int>() { 0, 0, 1, 2, 1});
        }

        public static void miniMaxSum(List<int> arr)
        {
            long lesserValue = arr[0];
            long greaterValue = 0;
            long sum = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                sum += arr[i];
                if (arr[i] > greaterValue) greaterValue = arr[i];
                if (arr[i] < lesserValue) lesserValue = arr[i];
            }
            Console.WriteLine($"{sum - greaterValue} {sum - lesserValue}");
        }

        public static string timeConversion(string s)
        {
            DateTime dateTime = DateTime.ParseExact(s, "hh:mm:sstt", CultureInfo.InvariantCulture);
            return dateTime.TimeOfDay.ToString();
        }

        public static List<int> breakingRecords(List<int> scores)
        {
            int minimum = scores[0];
            int maximum = scores[0];
            int numberOfMaximumRecords = 0;
            int numberOfMinimumRecords = 0;

            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > maximum)
                {
                    maximum = scores[i];
                    numberOfMaximumRecords++;
                }
                else if (scores[i] < minimum)
                {
                    minimum = scores[i];
                    numberOfMinimumRecords++;
                }
            }
            return new List<int>() { numberOfMaximumRecords, numberOfMinimumRecords };
        }

        public static void CamelCaseOperations(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (String.IsNullOrEmpty(input) || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                var argParts = input.Split(';');
                var operation = argParts[0];
                var type = argParts[1];

                var transformedArg = TransformCamelCase(operation, type, argParts[2]);
                Console.Out.WriteLine(transformedArg);
            }
        }

        private static string TransformCamelCase(string operation, string type, string value)
        {
            if (operation == "S")
            {
                if (type == "M") value = value.Replace("()", "");
                value = String.Join(" ", Regex.Split(value, @"(?<!^)(?=[A-Z])")).ToLower();
                return value;
            }

            int startIndex = 1;
            if (type == "C") startIndex = 0;

            string[] wordsParts = ConvertWordParts(value, startIndex);
            value = String.Join("", wordsParts);

            if (type == "M") value += "()";

            return value;
        }

        private static string[] ConvertWordParts(string words, int startIndex)
        {
            var wordsParts = words.Split(' ');
            for (int i = startIndex; i < wordsParts.Length; i++)
                wordsParts[i] = Char.ToUpperInvariant(wordsParts[i][0]) + wordsParts[i].Substring(1);

            return wordsParts;
        }



        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int count = 0;
            Dictionary<int, int> hm = new Dictionary<int, int>();

            for (int i = 0; i < ar.Count; i++)
            {
                int key = ar[i] % k;
                int antKey = (k - key) % k;

                if (hm.ContainsKey(antKey)) 
                    count += hm[antKey];

                int tempKey = 0;
                hm.TryGetValue(key, out tempKey);
                hm[key] = tempKey + 1;
            }
            return count;
        }


        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {
            var results = new List<int>(queries.Count);

            for (int i = 0; i < queries.Count; i++)
                results.Add(strings.Where(x => x == queries[i]).Count());
            
            return results;
        }


        public static int findMedian(List<int> arr)
        {
            arr.Sort();
            return arr[(int)(arr.Count() / 2) ];
        }

        //Given five positive integers, find the minimum and maximum values that can be calculated
        //by summing exactly four of the five integers. Then print the respective minimum and maximum values as
        //a single line of two space-separated long integers.
        //Example: arr = [1,3,5,7,9], the minimum sum is 16, the maximum sum is 24 
        static void miniMaxSum2(List<int> arr)
        {
            arr.Sort();
            long sumAux = arr[1] + (long)arr[2] + arr[3];
            Console.WriteLine($"{(arr[0] + sumAux)} {(sumAux + arr[4])}");     
        }

        //Given an array of integers, where all elements but one occur twice, find the unique element.
        //Example a = [1,2,3,4,3,2,1]
        //The unique element is 4.
        public static int lonelyinteger(List<int> a)
        {
            int loneValue = a[0];
            for (int i = 1; i < a.Count; i++)
                loneValue ^= a[i];
            return loneValue;
        }
    }
}
