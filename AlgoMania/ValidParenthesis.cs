using System.Collections.Generic;

namespace AlgoMania
{
    public static class ValidParenthesis
    {
        /*
        Dada uma string com apenas os seguintes caracteres '(', ')', '{', '}', '[', ']' determine se uma determinada string é válida.
        Uma string é considerada válida se:
        Caracteres de abertura devem ser fechadas pelo mesmo tipo. 
        Abertura devem ser fechados com uma chave correspondente. Uma string vazia é considerada válida.

        Exemplos:
        Entrada: '[]'
        Saída: True

        Entrada: '[()]'
        Saída: True

        Entrada: '['
        Saída: False

        Entrada: '[('
        Saída: False

        Entrada: ')[('
        Saída: False
        */
        //O(n) - O(n)
        public static bool ValidateParenthesis(string value)
        {
            var stack = new Stack<char>(value.Length);
            Dictionary<char, char> mapping = new()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            foreach (char s in value)
                if (!(mapping.ContainsKey(s) && (stack.Count > 0 && mapping[s] == stack.Pop())))
                    stack.Push(s);

            return stack.Count == 0;
        }
    }
}
