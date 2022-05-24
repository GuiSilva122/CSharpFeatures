using System;
using System.Collections.Generic;

namespace AlgoMania
{
    public class MinimumDepthOfBinaryTree
    {
        //Dada uma árvore binária, encontre a menor profundidade da mesma.
        //A profundidade mínima é o número de nós que formam o menor caminho entre a raiz e o nó sem nenhum filho da árvore.
        //Nota: Um nó considerado sem nenhum filho é aquele em que o left e o right são nulos, ou seja, não tem nenhum filho.
        //Exemplo:
        //Dada a árvore binária [3, 9, 20, None, None, 15, 7],        
        //  3
        // / \
        //9  20
        //  /  \
        // 15   7
        //O resultado é 2 pois o menor caminho passa pelos números 3 e 9.
        public class Node
        {
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }
            public int Data { get; set; }
        }

        public class BinaryTree
        {
            public Node Root { get; set; }

            public bool Add(int value)
            {
                Node before = null, after = this.Root;

                while (after != null)
                {
                    before = after;
                    if (value < after.Data) //Is new node in left tree? 
                        after = after.LeftNode;
                    else if (value > after.Data) //Is new node in right tree?
                        after = after.RightNode;
                    else
                    {
                        //Exist same value
                        return false;
                    }
                }

                Node newNode = new Node();
                newNode.Data = value;

                if (this.Root == null)//Tree ise empty
                    this.Root = newNode;
                else
                {
                    if (value < before.Data)
                        before.LeftNode = newNode;
                    else
                        before.RightNode = newNode;
                }

                return true;
            }

            #region Details
            public Node Find(int value) => this.Find(value, this.Root);
            public void Remove(int value) => this.Root = Remove(this.Root, value);
            private Node Remove(Node parent, int key)
            {
                if (parent == null) return parent;

                if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
                else if (key > parent.Data)
                    parent.RightNode = Remove(parent.RightNode, key);

                // if value is same as parent's value, then this is the node to be deleted  
                else
                {
                    // node with only one child or no child  
                    if (parent.LeftNode == null)
                        return parent.RightNode;
                    else if (parent.RightNode == null)
                        return parent.LeftNode;

                    // node with two children: Get the inorder successor (smallest in the right subtree)  
                    parent.Data = MinValue(parent.RightNode);

                    // Delete the inorder successor  
                    parent.RightNode = Remove(parent.RightNode, parent.Data);
                }

                return parent;
            }

            private int MinValue(Node node)
            {
                int minv = node.Data;

                while (node.LeftNode != null)
                {
                    minv = node.LeftNode.Data;
                    node = node.LeftNode;
                }

                return minv;
            }

            private Node Find(int value, Node parent)
            {
                if (parent != null)
                {
                    if (value == parent.Data) return parent;
                    if (value < parent.Data)
                        return Find(value, parent.LeftNode);
                    else
                        return Find(value, parent.RightNode);
                }

                return null;
            }

            public int GetTreeDepth()
            {
                return this.GetTreeDepth(this.Root);
            }

            private int GetTreeDepth(Node parent)
            {
                return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
            }

            public void TraversePreOrder(Node parent)
            {
                if (parent != null)
                {
                    Console.Write(parent.Data + " ");
                    TraversePreOrder(parent.LeftNode);
                    TraversePreOrder(parent.RightNode);
                }
            }

            public void TraverseInOrder(Node parent)
            {
                if (parent != null)
                {
                    TraverseInOrder(parent.LeftNode);
                    Console.Write(parent.Data + " ");
                    TraverseInOrder(parent.RightNode);
                }
            }

            public void TraversePostOrder(Node parent)
            {
                if (parent != null)
                {
                    TraversePostOrder(parent.LeftNode);
                    TraversePostOrder(parent.RightNode);
                    Console.Write(parent.Data + " ");
                }
            }
            #endregion
        }

        public class DtoSearchLevel
        {
            public DtoSearchLevel(int level, Node node)
            {
                Level = level;
                Node = node;
            }

            public int Level { get; }
            public Node Node { get; }
        }

        //Breadth-First-Search (BFS)
        public static int Solution(Node root)
        {
            var queue = new Queue<DtoSearchLevel>();
            if (root != null) queue.Enqueue(new DtoSearchLevel(1, root));

            while (queue.Count > 0)
            {
                var searchLevel = queue.Dequeue();
                var node = searchLevel.Node;
                var level = searchLevel.Level;

                if (node.LeftNode == null && node.RightNode == null) return level;

                level++;

                if (node.LeftNode != null) queue.Enqueue(new DtoSearchLevel(level, node.LeftNode));
                if (node.RightNode != null) queue.Enqueue(new DtoSearchLevel(level, node.RightNode));
            }

            return 0;
        }
    }
}
