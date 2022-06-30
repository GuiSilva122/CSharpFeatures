namespace HackerHank
{
    public class MarsExploration
    {
        public static int marsExploration(string s)
        {
            int numberOfDifferences = 0;

            for (int i = 0; i < s.Length; i += 3)
            {
                if (s[i] != 'S') numberOfDifferences++;
                if (s[i + 1] != 'O') numberOfDifferences++;
                if (s[i + 2] != 'S') numberOfDifferences++;
            }
            return numberOfDifferences;
        }
    }
}
