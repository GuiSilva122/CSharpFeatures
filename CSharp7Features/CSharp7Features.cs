using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp7Features
{
    public class CSharp7Features
    {
        public class Point
        {
            public Point(double x, double y) => (X, Y) = (x, y);

            public double X { get; }
            public double Y { get; }

            public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);
        }


        //---------------------------------Tuples---------------------------------
        public static void Tuples()
        {
            (string Alpha, string Beta) namedLetters = ("a", "b");
            Console.WriteLine($"{namedLetters.Alpha}, {namedLetters.Beta}");

            var alphabetStart = (Alpha: "a", Beta: "b");
            Console.WriteLine($"{alphabetStart.Alpha}, {alphabetStart.Beta}");

            //This unpackaging is called deconstructing the tuple
            var p = new Point(3.14, 2.71);
            (double X, double Y) = p;

            int count = 5;
            string label = "Colors used in the map";
            var pair = (count, label); // element names are "count" and "label"
        }



        //---------------------------------Discards---------------------------------


        //Discards are supported in the following scenarios:
        //- When deconstructing tuples or user-defined types.
        //- When calling methods with out parameters.
        //- In a pattern matching operation with the is and switch statements.
        //- As a standalone identifier when you want to explicitly identify the value of an assignment as a discard.
        public static void Discards()
        {
            var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);

            Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");

            static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
            {
                int population1 = 0, population2 = 0;
                double area = 0;

                if (name == "New York City")
                {
                    area = 468.48;
                    if (year1 == 1960) population1 = 7781984;
                    if (year2 == 2010) population2 = 8175133;
                    return (name, area, year1, population1, year2, population2);
                }
                return ("", 0, 0, 0, 0, 0);
            }

            String[] dateStrings = { "", "" };
            foreach (string dateString in dateStrings)
                if (DateTime.TryParse(dateString, out _))
                    Console.WriteLine($"'{dateString}': valid");

            String arg = String.Empty;
            _ = arg ?? throw new ArgumentNullException(paramName: nameof(arg), message: "arg can't be null");

            // Do work with arg.


            static void ShowValue(int _)
            {
                byte[] arr = { 0, 0, 1, 2 };
                _ = BitConverter.ToInt32(arr, 0);
                Console.WriteLine(_);

                // The example displays the following output:
                // 33619968
            }
        }

        //---------------------------------Pattern matching---------------------------------
        public static void PatternMatching()
        {
            int input = 10;
            int sum = 0;
            if (input is int count) sum += count;

            static int SumPositiveNumbers(IEnumerable<object> sequence)
            {
                int sum = 0;
                foreach (var i in sequence)
                {
                    switch (i)
                    {
                        case 0: break;

                        case IEnumerable<int> childSequence:
                            {
                                foreach (var item in childSequence)
                                    sum += (item > 0) ? item : 0;
                                break;
                            }

                        case int n when n > 0:
                            sum += n;
                            break;

                        case null: throw new NullReferenceException("Null found in sequence");

                        default: throw new InvalidOperationException("Unrecognized type");
                    }
                }
                return sum;
            }
        }



        //---------------------------------Method main now can be async---------------------------------
        public static async Task<Int32> DoAsyncWork() => 1;
        //Before
        static int Mainn() => DoAsyncWork().GetAwaiter().GetResult();
        //Now
        static async Task<int> Mainnn() => await DoAsyncWork();


        //---------------------------------Local functions---------------------------------
        public static IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            return alphabetSubsetImplementation();

            IEnumerable<char> alphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++) yield return c;
            }
        }

        public Task<string> PerformLongRunningWork(string address, int index, string name)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(message: "An address is required", paramName: nameof(address));
            if (index < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

            return longRunningWorkImplementation();

            //to ensure that exceptions arising from argument validation are thrown before the asynchronous work begins:
            async Task<string> longRunningWorkImplementation() => "";
        }


        //---------------------------------More expression-bodied members---------------------------------

        // Expression-bodied constructor
        public CSharp7Features(string label) => this.Label = label;

        // Expression-bodied finalizer
        ~CSharp7Features() => Console.Error.WriteLine("Finalized!");

        private string label;

        // Expression-bodied get / set accessors.
        public string Label
        {
            get => label;
            set => this.label = value ?? "Default label";
        }


        //---------------------------------Throw Expressions---------------------------------

        private static void DisplayFirstNumber(string[] args)
        {
            string arg = args.Length >= 1 ? args[0] :
                throw new ArgumentException("You must supply an argument");
            if (Int64.TryParse(arg, out var number))
                Console.WriteLine($"You entered {number:F0}");
            else
                Console.WriteLine($"{arg} is not a number.");
        }
        private string name;
        public string Name
        {
            get => name;
            set => name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
        }

        //---------------------------------Default literal expressions---------------------------------

        //before
        Func<string, bool> whereClause = default(Func<string, bool>);
        //now
        Func<string, bool> whereClauseNow = default;


        //----------------------------------Numeric literal syntax improvements---------------------------------
        public const int Sixteen = 0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;
        public const long BillionsAndBillions = 100_000_000_000;
        public const double AvogadroConstant = 6.022_140_857_747_474e23;
        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;


        //----------------------------------out Variables---------------------------------

        public static void OutVariables(string input)
        {
            if (int.TryParse(input, out int result))
                Console.WriteLine(result);

            if (int.TryParse(input, out var answer))
                Console.WriteLine(answer);
        }
        public class B
        {
            public B(int i, out int j) => j = i;
        }

        public class D : B
        {
            public D(int i) : base(i, out var j) => Console.WriteLine($"The value of 'j' is {j}");
        }

        //----------------------------------Named Arguments and optional Arguments----------------------------------
        public static void NamedArguments()
        {
            // The method can be called in the normal way, by using positional arguments.
            PrintOrderDetails("Gift Shop", 31, "Red Mug");

            // Named arguments can be supplied for the parameters in any order.
            PrintOrderDetails(orderNum: 31, productName: "Red Mug", sellerName: "Gift Shop");
            PrintOrderDetails(productName: "Red Mug", sellerName: "Gift Shop", orderNum: 31);

            // Named arguments mixed with positional arguments are valid
            // as long as they are used in their correct position.
            PrintOrderDetails("Gift Shop", 31, productName: "Red Mug");
            PrintOrderDetails(sellerName: "Gift Shop", 31, productName: "Red Mug");    // C# 7.2 onwards
            PrintOrderDetails("Gift Shop", orderNum: 31, "Red Mug");                   // C# 7.2 onwards

            // However, mixed arguments are invalid if used out-of-order.
            // The following statements will cause a compiler error.
            // PrintOrderDetails(productName: "Red Mug", 31, "Gift Shop");
            // PrintOrderDetails(31, sellerName: "Gift Shop", "Red Mug");
            // PrintOrderDetails(31, "Red Mug", sellerName: "Gift Shop");
            static void PrintOrderDetails(string sellerName, int orderNum, string productName)
            {
                if (string.IsNullOrWhiteSpace(sellerName))
                    throw new ArgumentException(message: "Seller name cannot be null or empty.", paramName: nameof(sellerName));

                Console.WriteLine($"Seller: {sellerName}, Order #: {orderNum}, Product: {productName}");
            }
        }

        public static void OptionalArguments()
        {
            static void ExampleMethod(int required, string optionalstr = "default string", int optionalint = 10)
            { }

            //causes a compiler error, because an argument is provided for the third parameter but not for the second.
            //ExampleMethod(3, ,4);

            ExampleMethod(3, optionalint: 4);

        }

        
        //----------------------------------private protected access modifier----------------------------------
        
        //A new compound access modifier: private protected indicates that a member may be accessed
        //by containing class or derived classes that are declared in the same assembly.
        //While protected internal allows access by derived classes or classes that are in the same assembly,
        //private protected limits access to derived types declared in the same assembly.
        private protected class TestClass {}



        //----------------------------------Enabling more efficient safe code----------------------------------

        //You don't want callers modifying the origin, so you should return the value by ref readonly
        public struct Point3D
        {
            public Point3D(double x, double y, double z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }

            public double X { get; }
            public double Y { get; }
            public double Z { get; }

            private static Point3D origin = new Point3D(0, 0, 0);

            public static ref readonly Point3D Origin => ref origin;
        }


        //----------------------------------Ref locals and returns----------------------------------

        public static void UsingRefLocalsAndReturns()
        {
            static ref int Find(int[,] matrix, Func<int, bool> predicate)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        if (predicate(matrix[i, j]))
                            return ref matrix[i, j]; //<------------
                throw new InvalidOperationException("Not found");
            }

            int[,] matrix = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            ref var item = ref Find(matrix, (val) => val == 8); //<------------
            Console.WriteLine(item);
            item = 24;
            Console.WriteLine(matrix[3, 1]);

            //Conditional ref expressions
            var arr = new Int32[] { 1, 2 };
            var otherArr = new Int32[] { 1, 2 };
            ref var r = ref (arr != null ? ref arr[0] : ref otherArr[0]);

        }


        //----------------------------------in keyword----------------------------------
        public class SS { }
        static void M(SS arg) { }
        static void M(in SS arg) { }


        //----------------------------------Indexing fixed fields does not require pinning----------------------------------

        unsafe struct S
        {
            public fixed int myFixedField[10];
        }
        class C
        {
            static S s = new S();

            unsafe public void M()
            {
                int p = s.myFixedField[5];
            }
        }


        //----------------------------------ValueTask----------------------------------

        public async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }
    }
}
