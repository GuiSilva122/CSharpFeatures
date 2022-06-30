using System.Collections.Generic;

namespace AlgoMania
{
    public static class TwoSum
    {
        /*
        Desafio 1
        O Two Sum é bastante comum durante entrevistas.
        Seu objetivo é identificar um par de números que somados batam com o valor da
        variável target.
        Ele pode ser escrito em um algoritmo que roda no tempo O(n).
        Exemplos:
        Se o array é [4, 1, 2, -2, 11, 15, 1, -1, -6, -4] e o target é 9. Neste caso, seu programa deve retornar:
        [-2, 11]
        O motivo é bastante simples:
        -2 + 11 = 9
        */
        //O(n²)
        public static List<int> TwoSum1(List<int> numbers, int target_sum)
        {
            for (int i = 0; i < numbers.Count; i++)
                for (int j = i; j < numbers.Count; j++)
                    if (numbers[i] + numbers[j] == target_sum)
                        return new List<int>() { numbers[i], numbers[j] };                
            
            return new List<int>();
        }

        //O(n)
        //target_sum = X + Y
        //Y = target_sum - X, where X is numbers[i] and Y is in the Hash
        public static List<int> TwoSum2(List<int> numbers, int target_sum)
        {
            Dictionary<int, bool> calc_numbers = new();

            for (int i = 0; i < numbers.Count; i++)
            {
                int y = target_sum - numbers[i];
                if (calc_numbers.ContainsKey(y)) 
                    return new List<int>() { y, numbers[i] };

                calc_numbers.TryAdd(numbers[i], true);
            }
            return new List<int>();
        }

        //O(n log(n))
        public static List<int> TwoSum3(List<int> numbers, int target_sum)
        {
            numbers.Sort();

            for (int i = 0, j = numbers.Count - 1; i < j;)
            {
                int numbersSum = numbers[i] + numbers[j];

                if (numbersSum == target_sum)
                    return new List<int>() { numbers[i], numbers[j] };
                else if (numbersSum < target_sum)
                    i++;
                else
                    j--;
            }
            return new List<int>();
        }
    }
}