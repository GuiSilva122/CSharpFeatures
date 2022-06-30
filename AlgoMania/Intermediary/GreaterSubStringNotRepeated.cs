using System;
using System.Collections.Generic;

namespace AlgoMania
{
    public class GreaterSubStringNotRepeated
    {
        /*
        Data uma string, retorne o tamanho da maior substring que não tenha nenhum caracter repetido.
        Exemplo 1:
        Entrada: abcabcbb Saida: 3
        Resposta: O valor encontrado é "abc", que tem o tamanho 3.
        
        Exemplo 2:
        Entrada: zzzabcdzzz
        Saida: 5
        Resposta: O valor encontrado é "zabcd", que tem o tamanho 5.
        */
        public static int greaterSubStringNotRepeated(string value)
        {
            int result = 0;
            for(int left_pointer = 0; left_pointer < value.Length; left_pointer++)
            {
                var hashTable = new Dictionary<char, bool> { { value[left_pointer], true } };
                int right_pointer = left_pointer;

                while (true)
                {
                    right_pointer++;
                    if (right_pointer >= value.Length || hashTable.ContainsKey(value[right_pointer]))
                    {
                        result = Math.Max(hashTable.Count, result);
                        break;
                    }
                    hashTable[value[right_pointer]] = true;
                }
            }
            return result;
        }
    }
}
