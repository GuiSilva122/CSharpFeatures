using System;

namespace CSharpFeatures
{
    public static class ProblemsEuler
    {
        static void Main(string[] args)
        {
        }

        public  static int SumNumbersDivisibleBy3And5(int inferiorLimit, int superiorLimit)
        {
            int sum = 0;
            for (int i = inferiorLimit; i < superiorLimit; i++)
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            return sum;
        }

        public static int SumOfEvenTermsOfFibonacci(int superiorLimit)
        {
            int lastterm = 1;
            int actualterm = 1;
            int sum = 0;
            int aux = 0;

            while (actualterm <= superiorLimit)
            {
                aux = actualterm;
                actualterm += lastterm;
                lastterm = aux;

                if (actualterm % 2 == 0) sum += actualterm;
            }

            return sum;
        }

        public static long LargestPrimeFactor(long num)
        {
            long largest = 0;

            while (num % 2 == 0)
            {
                num /= 2;
                if (2 > largest) largest = 2;
            }

            long factor = 3;
            while(factor * factor <= num)
            {
                if (num % factor == 0)
                {
                    num /= factor;
                    if (factor > largest) largest = factor;
                }
                else
                {
                    factor += 2;
                }
            }

            if (num > 1 && num > largest) largest = num;

            return largest;
        }

        internal static long LargestPalindromeProductOfTwoNDigitsNumber(int numberOfDigits)
        {
            long largest = 0;
            long start = (long)Math.Pow(10, numberOfDigits - 1);
            long end = (long)Math.Pow(10, numberOfDigits) - 1;

            for(long i = end; i >= start; i--)
            {
                for(long j = i; j >= i; j--)
                {
                    long number = i * j;
                    if (number <= largest) break;
                    if (IsPalindrome(number)) largest = number;
                }
            }

            return largest;
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

        private static long NumberOfDigits(long number)
        {
            return (long)Math.Floor(Math.Log10(number) + 1);
        }

        public static long SmallestNumberDividedBy1To20()
        {
            long start = 1;
            while (start < long.MaxValue)
            {
                int i = 2;
                while (i <= 20)
                {
                    if (start % i > 0) break;
                    i++;
                }
                if (i >= 20)
                    return start;
                else start++;
            }
            return -1;
        }

        public static long DifferenceSumSquaresFirstHundredAndSquareOfSum()
        {
            long sum = 100*(100 + 1) / 2;
            long sumSquare = 0;
            for (int i = 1; i <= 100; i++)
            {
                sumSquare += i * i;
            }
            sum = sum * sum;
            return (sum * sum ) - sumSquare;
        }

        public static long The10001thPrime()
        {
            int positionTh = 0;
            long iteration = 2;
            long lastPrime = 0;

            while (positionTh < 10001)
            {
                for (long i = iteration -1; i > 0; i--)
                {
                    if (i != 1 && iteration % i == 0) break;
                    else if (i == 1)
                    {
                        lastPrime = iteration;
                        positionTh++;
                    }
                }
                iteration++;
            }
            return lastPrime;
        }

        public static long teste()
        {
            long limit = 10001;
            long count = 1; //we know that 2 is prime
            long candidate = 1;
            do
            {
                candidate = candidate + 2;
                if (IsPrime(candidate)) count++;
            } while (count < limit);

            return candidate;
        }

        public static bool IsPrime(long n)
        {
            if (n == 1) return false;
            else if (n < 4) return true;
            else if (n % 2 == 0) return false;
            else if (n < 9) return true;
            else if (n % 3 == 0) return false;
            else
            {
                long r = (long)Math.Floor(Math.Sqrt(n));
                long f = 5;

                while (f <= r)
                {
                    if (n % f == 0) return false;
                    if (n % (f + 2) == 0) return false;
                    f += 6;
                }
                return true;
            }
        }

        public static long TripletPytagorean()
        {
            int a, b, c = 0;

            for (int i = 1; i < 10000; i++)
            {
                a = i;
                for(int j = a + 1; j < 10000; j++)
                {
                    b = j;
                    for(int l = b + 1; l < 10000; l++)
                    {
                        c = l;
                        if ((a * a) + (b * b) == (c * c))
                        {
                            if (a + b + c == 1000)
                                return a * b * c;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
