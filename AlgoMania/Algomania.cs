using System;
using System.Collections.Generic;

namespace AlgoMania
{
    public class Algomania
    {
        static void Main(string[] args)
        {
            DecodeStringTest();
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
            BinaryTree node20 = new()
            {
                Value = 20,
                Left = new() { Value = 15 },
                Right = new() { Value = 7 }
            };
            BinaryTree root = new()
            {
                Value = 3,
                Left = new() { Value = 9 },
                Right = node20
            };

            BinaryTree node55 = new()
            {
                Value = 55,
                Left = new() { Value = 99 },
                Right = new() { Value = 23 }
            };
            BinaryTree node2 = new()
            {
                Value = 2,
                Left = node55,
                Right = new() { Value = 0 }
            };
            BinaryTree node3 = new()
            {
                Value = 3,
                Left = node2,
                Right = new() { Value = 4 }
            };
            BinaryTree node1 = new()
            {
                Value = 1,
                Left = new() { Value = 6 },
                Right = new() { Value = 8 }
            };
            BinaryTree root2 = new()
            {
                Value = 9,
                Left = node3,
                Right = node1
            };
            Console.WriteLine($"Breadth First Search: {AlgoMania.MinimumDepthOfBinaryTree.Solution(root2)}");
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

        static void ValidateParenthesis()
        {
            string value = "{{}}";
            Console.WriteLine($"Validating the string: {value}");
            Console.WriteLine($"the string is valid = {ValidParenthesis.ValidateParenthesis(value)}");

            value = "{(}}";
            Console.WriteLine($"Validating the string: {value}");
            Console.WriteLine($"the string is valid = {ValidParenthesis.ValidateParenthesis(value)}");
        }

        static void InvertBinaryTreeTest()
        {
            BinaryTree node4 = new() { Value = 4 };
            BinaryTree nodeLeft4 = new() { Value = 8 };
            BinaryTree nodeRight4 = new() { Value = 9 };
            node4.Left = nodeLeft4;
            node4.Right = nodeRight4;

            BinaryTree node2 = new() { Value = 2 };
            BinaryTree nodeRight2 = new() { Value = 5 };
            node2.Left = node4;
            node2.Right = nodeRight2;

            BinaryTree node3 = new() { Value = 3 };
            BinaryTree nodeLeft3 = new() { Value = 6 };
            BinaryTree nodeRight3 = new() { Value = 7 };
            node3.Left = nodeLeft3;
            node3.Right = nodeRight3;

            BinaryTree node1 = new() { Value = 1 };
            node1.Left = node2;
            node1.Right = node3;

            var invertedTree = InvertBinaryTree.Invert(node1);
        }

        static void BinaryTreeEqualsTest()
        {
            BinaryTree rootTreeEqual = new()
            {
                Value = 1,
                Left = new() { Value = 2 },
                Right = new() { Value = 3 }
            };
            BinaryTree rootTreeEqual2 = new()
            {
                Value = 1,
                Left = new() { Value = 2 },
                Right = new() { Value = 3 }
            };

            BinaryTree rightNode = new()
            {
                Value = 3,
                Left = new() { Value = 4 },
                Right = new() { Value = 5 }
            };
            BinaryTree rootTreeDifferent = new()
            {
                Value = 1,
                Left = new() { Value = 2 },
                Right = rightNode
            };

            var equals = BinaryTreeEquals.IsBinaryTreeEquals(rootTreeEqual, rootTreeEqual2);
            var equalsV2 = BinaryTreeEquals.IsBinaryTreeEqualsV2(rootTreeEqual, rootTreeEqual2);
            Console.WriteLine($"Deep Search First, for equals = {equals}");
            Console.WriteLine($"Breadth Search First, for equals = {equalsV2}");

            equals = BinaryTreeEquals.IsBinaryTreeEquals(rootTreeDifferent, rootTreeEqual2);
            equalsV2 = BinaryTreeEquals.IsBinaryTreeEqualsV2(rootTreeDifferent, rootTreeEqual2);
            Console.WriteLine($"Deep Search First, for different equals = {equals}");
            Console.WriteLine($"Breadth Search First, for different equals = {equalsV2}");
        }

        private static void GreaterSubStringNotRepeatedTest()
        {
            var result = GreaterSubStringNotRepeated.greaterSubStringNotRepeated("abcabcbb");
            Console.WriteLine($"Length of the greatest substring not repeated is = {result}");
        }

        private static void SimplifyPathTest()
        {
            var path = "/home/../";
            var result = SimplifyPath.simplifyPath(path);
            Console.WriteLine($"Simplify Path Entrada: '{path}' Saída esperada: '/', Saída recebida {result}");
        }

        private static void PathSum2Test()
        {
            BinaryTree node11 = new BinaryTree() 
            {
                Value = 11,
                Left = new() { Value = 7 },
                Right = new() { Value = 2 } 
            };
            BinaryTree node4Son = new BinaryTree()
            {
                Value = 4,
                Left = new() { Value = 5 },
                Right = new() { Value = 1 }
            };

            BinaryTree node4Parent = new BinaryTree()
            {
                Value = 4,
                Left = node11,
                Right = null
            };
            BinaryTree node8Parent = new BinaryTree()
            {
                Value = 8,
                Left = new() { Value = 13 },
                Right = node4Son
            };
            BinaryTree root = new BinaryTree() 
            { 
                Value = 5,
                Left = node4Parent,
                Right = node8Parent
            };
            var result = PathSum2.pathSum2(root, 22);
        }

        private static void DecodeStringTest()
        {
            string value1 = "2[a]3[bc]";
            string value2 = "3[a2[c]]";
            string value3 = "2[abc]3[cd]ef";
            
            Console.WriteLine($"string = {value1}, expected = {"aabcbcbc"}, result = {DecodeString.decodeString(value1)}");
            Console.WriteLine($"string = {value2}, expected = { "accaccacc"}, result = {DecodeString.decodeString(value2)}");
            Console.WriteLine($"string = {value3}, expected = {"abcabccdcdcdef"}, result = {DecodeString.decodeString(value3)}");
        }
    }
}
