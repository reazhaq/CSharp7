using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Old Style Tuple returns REF type
    /// New Typle returns VALUE type with (optional) named items
    /// </summary>
	class Experiment1Tuple
	{
		public void SomeMethod()
		{
            var oldTuple = OldStyleTuple(null);
            Console.WriteLine($"OldStyleTuple returns (type:{oldTuple.GetType()})");
            Console.WriteLine($"values: {oldTuple.Item1} and {oldTuple.Item2}{Environment.NewLine}");

			var someNumbers = new[] { 1, 2, 3, 4, 5, 6, 7 };

            // returns a simple one; no calculation is done here
			var result1 = CalculateSumAndCount1(someNumbers);
            Console.WriteLine($"CalculateSumAndCount1 returns (type:{result1.GetType()})");
            Console.WriteLine($"values: {result1.Item1} and {result1.Item2}{Environment.NewLine}");

            // returns another simple one; no calculation - but return tuple with names
			var (s, c) = CalculateSumAndCount2(someNumbers);
            Console.WriteLine($"CalculateSumAndCount2 returns (type:{(s,c).GetType()})");
            Console.WriteLine($"values: {s} and {c}{Environment.NewLine}");

            // same as before; but returns a calculated tuple
            // result3 is a tuple; can be used with a dot(.) - much more read friendly
            var result3 = CalculateSumAndCount3(someNumbers);
            Console.WriteLine($"values: {result3.sum} and {result3.count}{Environment.NewLine}");

            // another simple example
            var customerRecord = GetCustomerRecord(4);
            Console.WriteLine($"customerRecord.firstName: {customerRecord.firstName}{Environment.NewLine}");

            /////// DURING THIS TALK AT AUSTIN .NET USER GROUP
            /////// SOMEONE HAD ASKED WHAT OTHER WAYS TO DECLARE RETURN VARIABLE INSTEAD OF 'var'
            /////// HERE ARE FEW EXAMPLES
            //// ValueTuple<int,int> is one simple way
            ValueTuple<int,int> blah = CalculateSumAndCount3(someNumbers);
            Console.WriteLine($"blah.Item1 = {blah.Item1}");
            //// (int, int) is another choice
		    (int, int) blah2 = CalculateSumAndCount3(someNumbers);
            Console.WriteLine($"blah2.Item1 = {blah2.Item1}");
            //// let's say we don't need the 2nd part of the tuple; use wildcard
		    var (s2, _) = CalculateSumAndCount3(someNumbers);
            Console.WriteLine($"var (s2, _) -> s2={s2}");




		    //////// splatting - not working yet
		    ////*******
		    //    var avg = CalculateAverage(CalculateSumAndCount3(someNumbers));
		    //*****//
		}

        // this could be used along with splatting; this was not release with the current version
        double CalculateAverage(int sum, int count) => count == 0 ? 0 : (sum / count);

        Tuple<int, int> OldStyleTuple(IEnumerable<int> someNumbers)
        {
            if (someNumbers == null)
                return Tuple.Create(0, 0);

            var sum = 0;
            var count = 0;
            foreach (var num in someNumbers)
            {
                sum += num;
                count++;
            }

            return new Tuple<int, int> (sum, count);
        }

		(int, int) CalculateSumAndCount1(IEnumerable<int> someNumbers) // note the return type
		{
			var r = (0, 0);
			return r;
		}

		(int sum, int count) CalculateSumAndCount2(IEnumerable<int> someNumbers) // note the names in the return type
		{
			return (0, 0);
		}

		(int sum, int count) CalculateSumAndCount3(IEnumerable<int> someNumbers)
		{
			var sumLocal = 0;
			var countLocal = 0;
			foreach (var num in someNumbers)
			{
				sumLocal += num;
				countLocal++;
			}

			return (sumLocal, countLocal); //don't need to match the names with the return
		}

        // nice way to return anonymous type looking object; but a value type
		(string firstName, string lastName, int age) GetCustomerRecord(int customerId)
		{
            var anonObject = new { fn = "first", ln = "last", a = 24 };

			// do something here.... like lookup the data
			return ("first", "last", 24);
		}
    }
}
