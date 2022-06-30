using System.Collections.Generic;

namespace AlgoMania
{
    public static class PathSum2
    {
        /*
        Dada uma árvore binária e uma soma, busque todos os caminhos que tenham a somatória especificada.
        Importante: Um caminho válido é aquele que vá para a raiz até um nó sem nenhum filho.
        Exemplo:
        Data a árvore binária abaixo e a soma 22,
              5
             / \
            4   8
           /   / \
          11  13  4
         /  \    / \
        7    2  5   1
        Deverá retornar: 
        [
           [5,4,11,2],
           [5,8,4,5]
        ]
        Estes são os caminhos que a soma total é igual a 22.
        */
        public static List<List<int>> pathSum2(BinaryTree root, int expectedSum)
        {
            var result = new List<List<int>>();

            if (root is not null)
                DeepFirstSearch(root, new List<int>(), 0, expectedSum, result);

            return result;
        }

        public static void DeepFirstSearch(BinaryTree node, List<int> currentPath, int currentSum, int expectedSum, List<List<int>> result)
        {
            if (node is null) 
                return;

            currentSum += node.Value;

            var isNodeWithoutLeafs = node.Left is null && node.Right is null;
            if (isNodeWithoutLeafs && currentSum == expectedSum)
            {
                currentPath.Add(node.Value);
                result.Add(currentPath);
                return;
            }

            DeepFirstSearch(node.Left, new List<int>(currentPath) { node.Value }, currentSum, expectedSum, result);
            DeepFirstSearch(node.Right, new List<int>(currentPath) { node.Value }, currentSum, expectedSum, result);
        }
    }
}