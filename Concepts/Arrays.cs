namespace Concepts
{
    public static class Arrays
    {
        public static void MultidimensionalArrays()
        {
            // Two-dimensional array.
            int[,] array2D = new int[,] 
            { 
                { 1, 2 }, 
                { 3, 4 }, 
                { 5, 6 }, 
                { 7, 8 } 
            };

            // The same array with dimensions specified.
            int[,] array2Da = new int[4, 2] 
            { 
                { 1, 2 }, 
                { 3, 4 }, 
                { 5, 6 }, 
                { 7, 8 } 
            };

            // A similar array with string elements.
            string[,] array2Db = new string[3, 2] 
            { 
                { "one", "two" }, 
                { "three", "four" },
                { "five", "six" } 
            };

            // Three-dimensional array.
            int[,,] array3D = new int[,,] 
            { 
                { { 1, 2, 3 }, { 4, 5, 6 } },
                { { 7, 8, 9 }, { 10, 11, 12 } }
            };

            // The same array with dimensions specified.
            int[,,] array3Da = new int[2, 2, 3] 
            { 
                { { 1, 2, 3 }, { 4, 5, 6 } },
                { { 7, 8, 9 }, { 10, 11, 12 } } 
            };

            // Accessing array elements.
            System.Console.WriteLine(array2D[0, 0]);
            System.Console.WriteLine(array2D[0, 1]);
            System.Console.WriteLine(array2D[1, 0]);
            System.Console.WriteLine(array2D[1, 1]);
            System.Console.WriteLine(array2D[3, 0]);
            System.Console.WriteLine(array2Db[1, 0]);
            System.Console.WriteLine(array3Da[1, 0, 1]);
            System.Console.WriteLine(array3D[1, 1, 2]);

            // Getting the total count of elements or the length of a given dimension.
            var allLength = array3D.Length;
            var total = 1;
            for (int i = 0; i < array3D.Rank; i++)
                total *= array3D.GetLength(i);
            
            System.Console.WriteLine("{0} equals {1}", allLength, total);
        }

        public static void JaggedArrays()
        {
            //A jagged array is an array whose elements are arrays, possibly of different sizes.
            //A jagged array is sometimes called an "array of arrays."

            //The following is a declaration of a single - dimensional array that has three elements,
            //each of which is a single - dimensional array of integers:
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[4];
            jaggedArray[2] = new int[2];

            jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
            jaggedArray[1] = new int[] { 0, 2, 4, 6 };
            jaggedArray[2] = new int[] { 11, 22 };

            int[][] jaggedArray2 = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 0, 2, 4, 6 },
                new int[] { 11, 22 }
            };
            int[][] jaggedArray3 =
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 0, 2, 4, 6 },
                new int[] { 11, 22 }
            };

            //It's possible to mix jagged and multidimensional arrays.
            //The following is a declaration and initialization of a single-dimensional jagged array
            //that contains three two-dimensional array elements of different sizes.
            int[][,] jaggedArray4 = new int[3][,]
            {
                new int[,] { {1,3}, {5,7} },
                new int[,] { {0,2}, {4,6}, {8,10} },
                new int[,] { {11,22}, {99,88}, {0,9} }
            };
            System.Console.Write("{0}", jaggedArray4[0][1, 0]); //5
        }
    }
}
