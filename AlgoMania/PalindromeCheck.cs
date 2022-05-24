namespace AlgoMania
{
    public class PalindromeCheck
    {
        public static bool IsPalindrome(string parameter)
        {
            var letters = parameter.ToCharArray();
            int i = 0, j = letters.Length - 1;

            while (i < letters.Length && j > 0)
            {
                if (i == j) return true;
                if (letters[i] != letters[j]) return false;
                i++;
                j--;
            }
            return true;
        }

        public static bool IsPalindrome(long number)
        {
            long reversed = 0;
            long temp = number;
            while (number > 0)
            {
                reversed = reversed * 10 + number % 10; //multiplying the sum with 10 and adding remainder
                number /= 10; //for getting quotient by dividing with 10
            }
            return reversed == temp;
        }
    }
}