using System;

namespace AlgoMania
{
    public class Algomania
    {
        static void Main(string[] args)
        {
            //var result = TwoSum.TwoSum3(new List<int>() { 4, 1, 2, -2, 11, 16, 1, -1, -6, -4 }, 9);
            //Console.WriteLine("Hello World!");

            Console.WriteLine(PalindromeCheck.IsPalindrome("ana"));
            Console.WriteLine(PalindromeCheck.IsPalindrome("teste"));
            Console.WriteLine(PalindromeCheck.IsPalindrome("subinoonibus"));

            Console.WriteLine(PalindromeCheck.IsPalindrome(124));

            var binaryTree = new MinimumDepthOfBinaryTree.BinaryTree();

            binaryTree.Add(3);
            binaryTree.Add(9);
            binaryTree.Add(20);
            binaryTree.Add(15);
            binaryTree.Add(7);

            Console.WriteLine($"Breadth First Search: {MinimumDepthOfBinaryTree.Solution(binaryTree.Root)}");
        }
    }
}
