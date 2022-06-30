using System.Collections.Generic;

namespace AlgoMania
{
    /*
    Dadas duas árvores binárias, escreva uma função que indique se elas são iguais ou não.
    As duas árvores binárias são consideradas as mesmas se elas forem estruturalmente identicas 
    e os nós estiverem com o mesmo valor.
    Entrada:

       1          1         
      / \        / \   
     2   3      2   3    
    [1,2,3],   [1,2,3]

    Deverá retornar true pois as duas arvores são identicas.
    */
    public class BinaryTreeEquals
    {
        //Deep first search
        public static bool IsBinaryTreeEquals(BinaryTree tree1, BinaryTree tree2)
        {
            if (tree1 is null || tree2 is null)
                return (tree1 == tree2);
         
            if (tree1.Value == tree2.Value)
                return IsBinaryTreeEquals(tree1.Left, tree2.Left) && IsBinaryTreeEquals(tree1.Right, tree2.Right);
            
            return false;
        }

        //Breadth first search
        public static bool IsBinaryTreeEqualsV2(BinaryTree tree1, BinaryTree tree2)
        {
            var queue = new Queue<(BinaryTree, BinaryTree)>();
            queue.Enqueue((tree1, tree2));

            while(queue.Count > 0)
            {
                var (t1, t2) = queue.Dequeue();

                if (t1 is null || t2 is null)
                {
                    if (t1 == t2) 
                        continue;
                    else 
                        return false;
                }

                if (t1.Value != t2.Value) 
                    return false;

                queue.Enqueue((t1.Left, t2.Left));
                queue.Enqueue((t1.Right, t2.Right));
            }

            return true;
        }
    }
}