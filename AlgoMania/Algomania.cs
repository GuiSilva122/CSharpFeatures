using System;
using System.Collections.Generic;

namespace AlgoMania
{
    public class Algomania
    {
        static void Main(string[] args)
        {
            CreateLinkedList();
        }

        private static void TwoSum()
        {
            var result = AlgoMania.TwoSum.TwoSum3(new List<int>() { 4, 1, 2, -2, 11, 16, 1, -1, -6, -4 }, 9);
            Console.WriteLine("Hello World!");
        }

        private static void IsPalindrome()
        {
            Console.WriteLine(PalindromeCheck.IsPalindrome("ana"));
            Console.WriteLine(PalindromeCheck.IsPalindrome("teste"));
            Console.WriteLine(PalindromeCheck.IsPalindrome("subinoonibus"));

            Console.WriteLine(PalindromeCheck.IsPalindrome(124));
        }

        private static void MinimumDepthOfBinaryTree()
        {
            var binaryTree = new MinimumDepthOfBinaryTree.BinaryTree();

            binaryTree.Add(3);
            binaryTree.Add(9);
            binaryTree.Add(20);
            binaryTree.Add(15);
            binaryTree.Add(7);

            Console.WriteLine($"Breadth First Search: {AlgoMania.MinimumDepthOfBinaryTree.Solution(binaryTree.Root)}");
        }

        static void CreateLinkedList()
        {
            var linkedList = new MyLinkedList();
            Console.WriteLine($"IsEmpty: {linkedList.is_empty()}");
            linkedList.insert_node_to_head(new Node("50"));
            linkedList.insert_node_to_head(new Node("100"));
            linkedList.insert_node_to_tail(new Node("Tail"));
            Console.WriteLine($"Head: {linkedList.head().Value}");
            Console.WriteLine($"Tail: {linkedList.tail().Value}");
            Console.WriteLine($"IsEmpty: {linkedList.is_empty()}");
        }
    }
}
