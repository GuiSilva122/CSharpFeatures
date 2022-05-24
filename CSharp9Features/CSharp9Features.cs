using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp9Features
{
    public static class CSharp9Features
    {
        //----------------------------------Record Types----------------------------------
        public record PersonV1(string FirstName, string LastName); //Declared using positional syntax (imutable)
        public record PersonV2 //(imutable)
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }
        };
        public record PersonV3 //Can be mutable
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        };

        public record PersonV4(string FirstName, string LastName, string[] PhoneNumbers);

        public record Person(string FirstName, string LastName)
        {
            public string[] PhoneNumbers { get; init; }
        }

        public static void RecordTypes()
        {
            PersonV1 person = new("Nancy", "Davolio");
            Console.WriteLine(person); // output: Person { FirstName = Nancy, LastName = Davolio }

            //Equality
            //Value equality means that two variables of a record type are equal if the types match and all
            //property and field values match.
            //For other reference types, equality means identity.
            //That is, two variables of a reference type are equal
            //if they refer to the same object.

            var phoneNumbers = new string[2];
            PersonV4 person11 = new("Nancy", "Davolio", phoneNumbers);
            PersonV4 person22 = new("Nancy", "Davolio", phoneNumbers);
            Console.WriteLine(person11 == person22); // output: True

            person11.PhoneNumbers[0] = "555-1234";
            Console.WriteLine(person11 == person22); // output: True

            Console.WriteLine(ReferenceEquals(person11, person22)); // output: False

            String a = "";
            String b = "";
            String[] c = new string[2];
            (a, b, c) = person11;

            //Non destructive mutation
            Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] };
            Console.WriteLine(person1);
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }

            Person person2 = person1 with { FirstName = "John" };
            Console.WriteLine(person2);
            // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
            Console.WriteLine(person1 == person2); // output: False

            person2 = person1 with { PhoneNumbers = new string[1] };
            Console.WriteLine(person2);
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
            Console.WriteLine(person1 == person2); // output: False

            person2 = person1 with { };
            Console.WriteLine(person1 == person2); // output: True
        }

        //Inheritance
        //A record can inherit from another record. However, a record can't inherit from a class,
        //and a class can't inherit from a record.
        public abstract record Personn(string FirstName, string LastName);
        public record Teacher(string FirstName, string LastName, int Grade)
            : Personn(FirstName, LastName);
        public record Student(string FirstName, string LastName, int Grade)
            : Personn(FirstName, LastName);
        public static void RecordTypesInheritance()
        {
            Personn teacher = new Teacher("Nancy", "Davolio", 3);
            Console.WriteLine(teacher);
            // output: Teacher { FirstName = Nancy, LastName = Davolio, Grade = 3 }

            Personn teacherr = new Teacher("Nancy", "Davolio", 3);
            Personn studentt = new Student("Nancy", "Davolio", 3);
            Console.WriteLine(teacherr == studentt); // output: False

            Student student2 = new Student("Nancy", "Davolio", 3);
            Console.WriteLine(student2 == studentt); // output: True
        }


        //----------------------------------Init only setters----------------------------------
        public struct WeatherObservation
        {
            public DateTime RecordedAt { get; init; }
            public decimal TemperatureInCelsius { get; init; }
            public decimal PressureInMillibars { get; init; }

            public override string ToString() =>
                $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: " +
                $"Temp = {TemperatureInCelsius}, with {PressureInMillibars} pressure";
        }
        public static void InitOnlySetters()
        {
            var now = new WeatherObservation
            {
                RecordedAt = DateTime.Now,
                TemperatureInCelsius = 20,
                PressureInMillibars = 998.0m
            };
            // Error! CS8852.
            //now.TemperatureInCelsius = 18;
        }

        //----------------------------------Top Level Statements----------------------------------
        //Programs with can now have one line of code.


        //----------------------------------Pattern matching enhancements----------------------------------
        //Type patterns match a variable is a type
        //Parenthesized patterns enforce or emphasize the precedence of pattern combinations
        //Conjunctive and patterns require both patterns to match
        //Disjunctive or patterns require either pattern to match
        //Negated not patterns require that a pattern doesn't match
        //Relational patterns require the input be less than, greater than, less than or equal, or greater than or equal to a given constant.
        public static bool IsLetter(this char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';
        public static bool IsLetterOrSeparator(this char c)
            => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';
        public static bool CheckIfIsNotNull(this string c) => (c is not null);

        //Type Patterns
        public static void TypePattern()
        {
            object greeting = "Hello, World!";
            if (greeting is string message)
                Console.WriteLine(message.ToLower());  // output: hello, world!

            var numbers = new int[] { 10, 20, 30 };
            Console.WriteLine(GetSourceLabel(numbers));  // output: 1

            var letters = new List<char> { 'a', 'b', 'c', 'd' };
            Console.WriteLine(GetSourceLabel(letters));  // output: 2

            static int GetSourceLabel<T>(IEnumerable<T> source) => source switch
            {
                Array array => 1,
                ICollection<T> collection => 2,
                _ => 3,
            };


            int? xNullable = 7;
            int y = 23;
            object yBoxed = y;
            if (xNullable is int a && yBoxed is int b)
            {
                Console.WriteLine(a + b);  // output: 30
            }
        }

        //Constant pattern
        static decimal GetGroupTicketPrice(int visitorCount) => visitorCount switch
        {
            1 => 12.0m,
            2 => 20.0m,
            3 => 27.0m,
            4 => 32.0m,
            0 => 0.0m,
            _ => throw new ArgumentException($"Not supported number of visitors: {visitorCount}", nameof(visitorCount)),
        };
        static void NullCheck(object input)
        {
            if (input is null) return;
            if (input is not null) return;
        }

        //Relational patterns
        static string Classify(double measurement) => measurement switch
        {
            < -4.0 => "Too low",
            > 10.0 => "Too high",
            double.NaN => "Unknown",
            _ => "Acceptable",
        };

        //Logical patterns
        static string ClassifyV1(double measurement) => measurement switch
        {
            < -40.0 => "Too low",
            >= -40.0 and < 0 => "Low",
            >= 0 and < 10.0 => "Acceptable",
            >= 10.0 and < 20.0 => "High",
            >= 20.0 => "Too high",
            double.NaN => "Unknown",
        };
        static string GetCalendarSeason(DateTime date) => date.Month switch
        {
            3 or 4 or 5 => "spring",
            6 or 7 or 8 => "summer",
            9 or 10 or 11 => "autumn",
            12 or 1 or 2 => "winter",
            _ => throw new ArgumentOutOfRangeException(nameof(date), $"Date with unexpected month: {date.Month}."),
        };

        //Property pattern
        static bool IsConferenceDay(DateTime date) => date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };
        static void PropertyPattern()
        {
            Console.WriteLine(TakeFive("Hello, world!"));  // output: Hello
            Console.WriteLine(TakeFive("Hi!"));  // output: Hi!
            Console.WriteLine(TakeFive(new[] { '1', '2', '3', '4', '5', '6', '7' }));  // output: 12345
            Console.WriteLine(TakeFive(new[] { 'a', 'b', 'c' }));  // output: abc

            static string TakeFive(object input) => input switch
            {
                string { Length: >= 5 } s => s.Substring(0, 5),
                string s => s,
                ICollection<char> { Count: >= 5 } symbols => new string(symbols.Take(5).ToArray()),
                ICollection<char> symbols => new string(symbols.ToArray()),

                null => throw new ArgumentNullException(nameof(input)),
                _ => throw new ArgumentException("Not supported input type."),
            };
        }
        public record Point(int X, int Y);
        public record Segment(Point Start, Point End);
        static bool IsAnyEndAtOrigin(Segment segment) =>
            segment is { Start: { X: 0, Y: 0 } } or { End: { X: 0, Y: 0 } };

        //Positional pattern
        public readonly struct Pointt
        {
            public int X { get; }
            public int Y { get; }

            public Pointt(int x, int y) => (X, Y) = (x, y);

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
        }

        static string Classify(Pointt point) => point switch
        {
            (0, 0) => "Origin",
            (1, 0) => "positive X basis end",
            (0, 1) => "positive Y basis end",
            _ => "Just a point",
        };
        static decimal GetGroupTicketPriceDiscount(int groupSize, DateTime visitDate)
            => (groupSize, visitDate.DayOfWeek) switch
            {
                ( <= 0, _) => throw new ArgumentException("Group size must be positive."),
                (_, DayOfWeek.Saturday or DayOfWeek.Sunday) => 0.0m,
                ( >= 5 and < 10, DayOfWeek.Monday) => 20.0m,
                ( >= 10, DayOfWeek.Monday) => 30.0m,
                ( >= 5 and < 10, _) => 12.0m,
                ( >= 10, _) => 15.0m,
                _ => 0.0m,
            };

        //var pattern
        static bool IsAcceptable(int id, int absLimit)
            => SimulateDataFetch(id) is var results
                && results.Min() >= -absLimit
                && results.Max() <= absLimit;

        static int[] SimulateDataFetch(int id)
        {
            var rand = new Random();
            return Enumerable
                       .Range(start: 0, count: 5)
                       .Select(s => rand.Next(minValue: -10, maxValue: 11))
                       .ToArray();
        }
        //Discard pattern
        public static void DiscardPattern()
        {
            Console.WriteLine(GetDiscountInPercent(DayOfWeek.Friday));  // output: 5.0
            Console.WriteLine(GetDiscountInPercent(null));  // output: 0.0
            Console.WriteLine(GetDiscountInPercent((DayOfWeek)10));  // output: 0.0

            static decimal GetDiscountInPercent(DayOfWeek? dayOfWeek) => dayOfWeek switch
            {
                DayOfWeek.Monday => 0.5m,
                DayOfWeek.Tuesday => 12.5m,
                DayOfWeek.Wednesday => 7.5m,
                DayOfWeek.Thursday => 12.5m,
                DayOfWeek.Friday => 5.0m,
                DayOfWeek.Saturday => 2.5m,
                DayOfWeek.Sunday => 2.0m,
                _ => 0.0m,
            };
        }
        //Parenthesized pattern
        public static void ParenthesizedPattern(object input)
        {
            if (input is not (float or double))
            {
                return;
            }
        }

        //----------------------------------Fit and finish features----------------------------------
        private static List<WeatherObservation> _observations = new(); //ommited type on new()
        public class Teste 
        { 
            public string Location { get; init; } 
            public string OtherProp { get; set; } 
        }
        static Teste station = new() { Location = "Seattle, WA" };

    }
}
