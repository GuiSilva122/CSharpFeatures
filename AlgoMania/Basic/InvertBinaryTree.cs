namespace AlgoMania
{

    public static class InvertBinaryTree
    {
        /*
        Neste desafio você deverá construir uma função que recebe uma árvore binária 
        e inverta seus itens filhos, ou seja, o nó filho da direita do item atual deve ser 
        invertido com o nó filho da esquerda.
        Os nós podem ter valores ou até mesmo serem nulos (indicando que não possuem filhos).

        Sua função receberá uma árvore binária da seguinte forma:
                 1
               /   \
              2     3
             / \   /  \
            4   5  6   7
           / \
          8   9

        E deverá retornar a árvore binária da seguinte forma:
                 1
               /   \
              3     2
             / \   /  \
            7   6  5   4
           / \
          9   8
         */
        public static BinaryTree Invert(BinaryTree tree)
        {
            if (tree.Left is null && tree.Right is null) 
                return tree;

            (tree.Left, tree.Right) = (tree.Right, tree.Left);

            if (tree.Left is not null)
                tree.Left = Invert(tree.Left);

            if (tree.Right is not null)
                tree.Right = Invert(tree.Right);

            return tree;
        }
    }
}
