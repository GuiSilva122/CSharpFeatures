using System.Collections.Generic;

namespace Turing
{
    public class Turing
    {
        public static void Main()
        {
            findJudgeTest();
        }

        public static void findJudgeTest()
        {
            int[][] array = new int[2][];
            array[0] = new int[2] { 1, 3 };
            array[1] = new int[2] { 2, 3};
            findJudge(2, array);

            int[][] jaggedArray2 = new int[3][]
            {
                new int[] { 1, 3 },
                new int[] { 2, 3 },
                new int[] { 3, 1 }
            };
            findJudge(3, jaggedArray2);
        }
        public static int findJudge(int N, int[][] trust)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            int trusted = -1;
            for (int i = 0; i < trust.Length; i++)
            {
                if (hash.ContainsKey(trust[i][1]))
                    trusted = -1;
                else
                {
                    hash[trust[i][0]] = trust[i][1];
                    trusted = trust[i][1];
                }
            }
            return trusted;
        }

        public static void RotateArrayTest()
        {
            RotateArrayV3(new int[] { 1, 2, 3, 5, 6, 7 }, 3);
        }

        public static int[] RotateArrayV1(int[] nums, int k)
        {
            int n = nums.Length;
            if (k > n) 
                k %= n;

            for (int i = 0; i < k; i++)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    // move each number by 1 place
                    int temp = nums[j];
                    nums[j] = nums[j - 1];
                    nums[j - 1] = temp;
                }
            }
            return nums;
        }

        public static int[] RotateArrayV2(int[] nums, int k)
        {
            int n = nums.Length;
            if (k > n) 
                k %= n;

            int[] result = new int[n];

            for (int i = 0; i < k; i++)
                result[i] = nums[n - k + i];

            int index = 0;
            for (int i = k; i < n; i++)
                result[i] = nums[index++];

            return result;
        }

        public static int[] RotateArrayV3(int[] nums, int k)
        {
            int n = nums.Length;
            if (k > n) 
                k %= n;

            nums = reverse(nums, 0, n - 1);
            nums = reverse(nums, 0, k - 1);
            nums = reverse(nums, k, n - 1);
            
            return nums;
        }
        private static int[] reverse(int[] nums, int start, int end)
        {
            while (start <= end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
            return nums;
        }
    }
}