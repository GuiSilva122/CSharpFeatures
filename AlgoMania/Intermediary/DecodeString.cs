using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoMania
{
    public static class DecodeString
    {
        /*
        Dada uma string codificada, retorne a string decodificada.
        A regra de codificação é: k[string_codificada], onde a string_codificada dentro dos colchetes 
        serão repetidas o número de k vezes. O valor de k será sempre um número positivo.

        Você deve assumir que as strings de entrada são sempre válidas, sem espaço e os colchetes estão bem formatados.

        Exemplos:
        s = "2[a]3[bc]", retornará "aabcbcbc".
        s = "3[a2[c]]", retornará "accaccacc".
        s = "2[abc]3[cd]ef", retornará "abcabccdcdcdef".
        */

        //O(n)
        public static string decodeString(string value)
        {
            var stack = new Stack<string>();
            int number = 0;
            string temp_str = "";
            
            foreach (char s in value)
            {
                if (s == '[')
                {
                    if (!String.IsNullOrEmpty(temp_str))
                    {
                        stack.Push(temp_str);
                        temp_str = "";
                    }
                    stack.Push(number.ToString());
                    number = 0;
                }
                else if (s == ']')
                {
                    if (!String.IsNullOrEmpty(temp_str))
                    {
                        stack.Push(temp_str);
                        temp_str = "";
                    }
                    string new_str = "";
                    var first = stack.Pop();
                    int firstNumber = 0;

                    while (!String.IsNullOrEmpty(first) && !int.TryParse(first, out firstNumber))
                    {
                        new_str = first + new_str;
                        first = stack.Pop();
                    }
                    new_str = string.Concat(Enumerable.Repeat(new_str, firstNumber));
                    stack.Push(new_str);
                }
                else
                {
                    if (Char.IsDigit(s))
                        number = 10 * number + Convert.ToInt32(s);
                    else
                        temp_str += s;
                }
            }
            if (!string.IsNullOrEmpty(temp_str))
                stack.Push(temp_str);

            return string.Join("", stack.ToList());
        }
    }
}
