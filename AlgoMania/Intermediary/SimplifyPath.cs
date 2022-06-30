using System;
using System.Collections.Generic;

namespace AlgoMania
{
    /*
    Simplifique o path absoluto para um arquivo (no estilo Unix). 
    Em outras palavras, converta o mesmo para o modo canonico.
    Neste modo, o '.' se refere ao diretório atual. '..' se refere ao diretório acima.
    Lembre-se que o path neste formato deve sempre começar com '/' e sempre devera ter um '/' único entre os diretórios.

    Exemplo 1:
    Entrada: "/home/"
    Saída: "/home"

    Exemplo 2:
    Entrada: "/home/../"
    Saída: "/"

    Exemplo 3:
    Entrada: "/home/../home/./"
    Saída: "/home"

    Exemplo 4:
    Entrada: "/home/../home"
    Saída: "/home"
    */
    public static class SimplifyPath
    {
        //O(n), stack, two pointers
        public static string simplifyPath(string path)
        {
            int left = 0;
            var stack = new Stack<string>();

            if (path[^1] != '/') path += '/';

            for (int right = 0; right <path.Length; right++)
            {
                if (path[right] == '/')
                {
                    string current = path[left..right];
                    left = right;

                    if (!String.IsNullOrEmpty(current))
                    {
                        if (current == "/..")
                        {
                            if (stack.Count > 0) stack.Pop();
                        }
                        else if (current == "/." || current == "/")
                            continue;
                        else
                            stack.Push(current);
                    }
                }
            }

            if (stack.Count == 0) stack.Push("/");
            
            return string.Join("", stack.ToArray());
        }
    }
}