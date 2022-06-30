using System;
using System.Linq;

namespace HackerHank
{
    public class Pangran
    {
        public static string pangrams(string s)
            => s.ToLower()
                .Where(x => Char.IsLetter(x))
                .GroupBy(x => x)
                .Count() == 26
            ? "pangram" : "not pangram";
    }
}