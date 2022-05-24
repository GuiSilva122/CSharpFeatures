using System;
// C# 6
using static System.Math;
using static System.Linq.Enumerable;
using static System.String;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CSharp6Features
{

    public class CSharp6Features
    {
        //------------------------------------Using Static------------------------------------

        // Classic C#
        public static Tuple<double, double> SolarAngleOld(double latitude, double declination, double hourAngle)
        {
            var tmp = Math.Sin(latitude) * Math.Sin(declination) + Math.Cos(latitude) * Math.Cos(declination) * Math.Cos(hourAngle);
            return Tuple.Create(Math.Asin(tmp), Math.Acos(tmp));
        }
        // C# 6
        public static Tuple<double, double> SolarAngleNew(double latitude, double declination, double hourAngle)
        {
            //PI is const, not static, so requires Math.PI
            for (var angle = 0.0; angle <= Math.PI * 2.0; angle += Math.PI / 8) { }

            var tmp = Asin(latitude) * Sin(declination) + Cos(latitude) * Cos(declination) * Cos(hourAngle);
            return Tuple.Create(Asin(tmp), Acos(tmp));
        }

        public static void UsingStaticWithExtensionMethods()
        {
            var values = new int[] { 1, 2, 3, 4 };
            var evenValues = values.Where(i => i % 2 == 0);
            Console.WriteLine(Join(",", evenValues));
        }


        //------------------------------------NameOf------------------------------------
        public static void UsingNameOf()
        {
            String nameArgument = "teste";
            Console.WriteLine(nameof(nameArgument));
        }

        //------------------------------------NullConditionalOperatorUsing------------------------------------
        public static void NullConditionalOperatorUsing()
        {
            var ss = new string[] { "Foo", null };
            var length0 = ss[0]?.Length; // 3
            var length1 = ss[1]?.Length; // null
            var lengths = ss.Select(s => s?.Length ?? 0); //[3, 0]
        }

        //------------------------------------String Interpolation------------------------------------

        public static void StringInterpolation()
        {
            var ss = $"Timestamp: {DateTime.Now.ToString("s", System.Globalization.CultureInfo.InvariantCulture)}";

            var values = new int[] { 1, 2, 3, 4, 12, 123456 };
            foreach (var s in values.Select(i => $"The value is { i,10:N2}."))
                Console.WriteLine(s);

            Console.WriteLine($"Minimum is { values.Min(i => i):N2}.");
        }

        //------------------------------------Auto-property Initialization------------------------------------
        public DateTime Due { get; set; } = DateTime.Now.AddDays(1);
        public DateTime Created { get; } = DateTime.Now;

        //------------------------------------Index Initializers------------------------------------
        public static void IndexInitializer()
        {
            var userInfo = new Dictionary<String, Int32>
            {
                ["Created"] = 1,
                ["Due"] = 2
            };
        }

        //------------------------------------Expression-bodied Function Members------------------------------------

        public override string ToString() => $"{1} {2}";
        public void Log(string message) => Console.WriteLine($"{DateTime.Now.ToString("s", CultureInfo.InvariantCulture)}: {message}");

        //A method, so async is valid
        public async Task DelayInSeconds(int seconds) => await Task.Delay(seconds * 1000);
        //The following property will not compile
        //public async Task<int> LeisureHours => await Task.FromResult<char>(DateTime.Now.DayOfWeek.ToString().First()) == 'S' ? 16 : 5;


        //------------------------------------Exception Filters------------------------------------
        public void ExceptionFilters(string aFloat, string date, string anInt)
        {
            try
            {
                var f = Double.Parse(aFloat);
                var d = DateTime.Parse(date);
                var n = Int32.Parse(anInt);
            }
            catch (FormatException e) when (e.Message.IndexOf("DateTime") > -1)
            {
                Console.WriteLine($"Problem parsing \"{nameof(date)}\" argument");
            }
            catch (FormatException x)
            {
                Console.WriteLine("Problem parsing some other argument");
            }
        }

        //------------------------------------await in catch...finally------------------------------------
        async void SomeMethod()
        {
            try
            {
                //...etc...
            }
            catch (Exception x)
            {
                //var diagnosticData = await GenerateDiagnosticsAsync(x);
                //Logger.log(diagnosticData);
            }
            finally
            {
                //await someObject.FinalizeAsync();
            }
        }

    }
}
