using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CSharp8Features.DefaultInterfaceMethods;

namespace CSharp8Features
{
    public class CSharp8Features
    {
        //----------------------------------Readonly members----------------------------------
        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public readonly double Distance => Math.Sqrt(X * X + Y * Y);
            public readonly override string ToString() => $"({X}, {Y}) is {Distance} from the origin";
        }

        //----------------------------------Default interface methods----------------------------------
        private static SampleCustomer CreateSampleCustumer()
        {
            SampleCustomer c = new SampleCustomer("customer one", new DateTime(2010, 5, 31))
            {
                Reminders =
                {
                    { new DateTime(2010, 08, 12), "childs's birthday" },
                    { new DateTime(1012, 11, 15), "anniversary" }
                }
            };

            SampleOrder o = new SampleOrder(new DateTime(2012, 6, 1), 5m);
            c.AddOrder(o);

            o = new SampleOrder(new DateTime(2103, 7, 4), 25m);
            c.AddOrder(o);
            return c;
        }

        public static void DefaultInterfaceMethodsImplementationV1()
        {
            SampleCustomer c = CreateSampleCustumer();

            // Check the discount:
            ICustomerV1 theCustomer = c;
            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");
        }

        public static void DefaultInterfaceMethodsImplementationV2()
        {
            SampleCustomer c = CreateSampleCustumer();

            // Check the discount:
            ICustomerV2 theCustomer = c;
            ICustomerV2.SetLoyaltyThresholds(new TimeSpan(30, 0, 0, 0), 1, 0.25m);
            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");
        }

        public static void DefaultInterfaceMethodsImplementationV3()
        {
            SampleCustomer c = CreateSampleCustumer();

            ICustomerV3 theCustomer = c;
            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");

            // Add more orders to get the discount:
            SampleOrder o;
            DateTime recurring = new DateTime(2013, 3, 15);
            for (int i = 0; i < 15; i++)
            {
                o = new SampleOrder(recurring, 19.23m * i);
                c.AddOrder(o);
                recurring.AddMonths(2);
            }

            Console.WriteLine($"Data about {c.Name}");
            Console.WriteLine($"Joined on {c.DateJoined}. Made {c.PreviousOrders.Count()} orders, the last on {c.LastOrder}");
            Console.WriteLine("Reminders:");
            foreach (var item in c.Reminders)
                Console.WriteLine($"\t{item.Value} on {item.Key}");

            foreach (IOrder order in c.PreviousOrders)
                Console.WriteLine($"Order on {order.Purchased} for {order.Cost}");

            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");

            ICustomerV3.SetLoyaltyThresholds(new TimeSpan(30, 0, 0, 0), 1, 0.25m);
            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");
        }



        //----------------------------------Switch expressions----------------------------------
        public enum Rainbow
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }
        public static RGBColor FromRainbow(Rainbow colorBand) =>
            colorBand switch
            {
                Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
                Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
                Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
                Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
                Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
                Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
                Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
            };

        //----------------------------------Property patterns----------------------------------
        public static decimal ComputeSalesTax(Address location, decimal salePrice) =>
            location switch
            {
                { State: "WA" } => salePrice * 0.06M,
                { State: "MN" } => salePrice * 0.075M,
                { State: "MI" } => salePrice * 0.05M,
                _ => 0M
            };
        //----------------------------------Tupple patterns----------------------------------
        public static string RockPaperScissors(string first, string second)
            => (first, second) switch
            {
                ("rock", "paper") => "rock is covered by paper. Paper wins.",
                ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                ("paper", "rock") => "paper covers rock. Paper wins.",
                ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
                ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
                ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
                (_, _) => "tie"
            };
        //----------------------------------Positional patterns----------------------------------
        public class Pointt
        {
            public int X { get; }
            public int Y { get; }
            public Pointt(int x, int y) => (X, Y) = (x, y);
            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        }
        public enum Quadrant
        {
            Unknown,
            Origin,
            One,
            Two,
            Three,
            Four,
            OnBorder
        }
        static Quadrant GetQuadrant(Pointt point)
            => point switch
            {
                (0, 0) => Quadrant.Origin,
                var (x, y) when x > 0 && y > 0 => Quadrant.One,
                var (x, y) when x < 0 && y > 0 => Quadrant.Two,
                var (x, y) when x < 0 && y < 0 => Quadrant.Three,
                var (x, y) when x > 0 && y < 0 => Quadrant.Four,
                var (_, _) => Quadrant.OnBorder,
                _ => Quadrant.Unknown
            };


        //----------------------------------Using Declarations----------------------------------
        static int WriteLinesToFile(IEnumerable<string> lines)
        {
            using var file = new System.IO.StreamWriter("WriteLines2.txt");
            int skippedLines = 0;
            foreach (string line in lines)
            {
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
                else
                {
                    skippedLines++;
                }
            }
            // Notice how skippedLines is in scope here.
            return skippedLines;
            // file is disposed here
        }

        //----------------------------------Static Local Functions----------------------------------
        int M()
        {
            int y = 5;
            int x = 7;
            return Add(x, y);

            static int Add(int left, int right) => left + right;
        }

        //----------------------------------Nullable reference types----------------------------------

        //Nullability of types
        //Any reference type can have one of four nullabilities, which describes when warnings are generated:

        //Nonnullable: Null can't be assigned to variables of this type.
        //Variables of this type don't need to be null-checked before dereferencing.

        //Nullable: Null can be assigned to variables of this type.
        //Dereferencing variables of this type without first checking for null causes a warning.

        //Oblivious: Oblivious is the pre-C# 8.0 state.
        //Variables of this type can be dereferenced or assigned without warnings.

        //Unknown: Unknown is generally for type parameters where constraints don't tell the compiler
        //that the type must be nullable or nonnullable


        //----------------------------------Asynchronous streams----------------------------------
        //Producing an asyncrhonous stream
        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
        //Consuming an asyncrhonous stream
        public static async Task Consuming()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }
        }


        //----------------------------------Indices and ranges----------------------------------
        public static void IndicesAndRanges()
        {
            var words = new string[]
            {
                            // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };              // 9 (or words.Length) ^0
            //0 index is the same as sequence[0]
            //^0 index is the same as sequence[sequence.length] (this throws an exception)
            //[0..n] .. is the range operator, the '[' is inclusive but the ']' it's not.
            //The range[0..^0] represents the entire range, just as [0..sequence.Length] too.
            
            Console.WriteLine($"The last word is {words[^1]}"); // writes "dog"
            var quickBrownFox = words[1..4]; //quick, brown, fox
            var lazyDog = words[^2..^0]; //lazy, dog

            var allWords = words[..]; // contains "The" through "dog".
            var firstPhrase = words[..4]; // contains "The" through "fox"
            var lastPhrase = words[6..]; // contains "the", "lazy" and "dog"

            Range phrase = 1..4;
            Console.WriteLine($"Range phrase: {phrase}");
            var text = words[phrase];

            Console.WriteLine($"Text using range: {String.Join(',', text)}");
        }

        //----------------------------------Null-coalescing assignment----------------------------------
        public static void NullCoalescingAssignment()
        {
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
            Console.WriteLine(i);  // output: 17
        }
    }
}
