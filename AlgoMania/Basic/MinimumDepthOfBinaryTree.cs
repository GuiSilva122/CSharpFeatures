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
        
        public class DtoSearchLevel
        {
            public DtoSearchLevel(int level, BinaryTree node)
            {
                Level = level;
                Node = node;
            }

            public int Level { get; }
            public BinaryTree Node { get; }
        }

        //Breadth-First-Search (BFS)
        public static int Solution(BinaryTree root)
        {
            var queue = new Queue<DtoSearchLevel>();
            if (root != null) queue.Enqueue(new DtoSearchLevel(1, root));

            while (queue.Count > 0)
            {
                var searchLevel = queue.Dequeue();
                var node = searchLevel.Node;
                var level = searchLevel.Level;

                if (node.Left == null && node.Right == null) return level;

                level++;

                if (node.Left != null) queue.Enqueue(new DtoSearchLevel(level, node.Left));
                if (node.Right != null) queue.Enqueue(new DtoSearchLevel(level, node.Right));
            }

            return 0;
        }
    }
}