using System;
using System.Collections.Generic;

namespace HackerHank
{
    public static class DiagonalSquare
    {
        /*
        Given a square matrix, calculate the absolute difference between the sums of its diagonals.
        For example, the square matrix  is shown below:
        
        1 2 3
        4 5 6
        9 8 9

        The left-to-right diagonal = 1 + 5 + 9 = 15
        The right to left diagonal = 3 + 5 + 9 = 17

        Their absolute difference is | 15 - 17 | = 2

        */
        //O(n²)
        public static int DiagonalDifference(List<List<int>> arr)
        {
            //The condition for the primary diagonal is --> row = column
            //The condition for the secondary diagonal is --> (row + column) = (numberOfRows -1)

            int principal = 0, secondary = 0;
            int n = arr.Count;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) // Condition for principal diagonal
                        principal += arr[i][j];
                    
                    if ((i + j) == (n - 1)) // Condition for secondary diagonal
                        secondary += arr[i][j];
                }
            }

            return (int)Math.Abs(secondary - principal);
        }

        //O(n)
        public static int DiagonalDifferenceV2(List<List<int>> arr)
        {
            //The condition for the primary diagonal is --> row = column
            //The condition for the secondary diagonal is --> (row + column) = (numberOfRows -1)

            int principal = 0, secondary = 0;
            int n = arr.Count;

            for (int i = 0; i < n; i++)
            {
                principal += arr[i][i];
                secondary += arr[i][n - i - 1];
            }

            return (int)Math.Abs(secondary - principal);
        }
    }
}