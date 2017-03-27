using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // now we don't need to declare out vairable on a separate line
    // it is inline and scope is still the same
	class Experiment3OutVariable
	{
		public void SomeMethod()
		{
			var someNumberAsAString = "99";

            // old style; declare the variable in a separate line
			int myInt;
			if (int.TryParse(someNumberAsAString, out myInt))
				Console.WriteLine($"\"{someNumberAsAString}\" was parsed -> {myInt}{Environment.NewLine}");

            // new style; one line
			if (int.TryParse(someNumberAsAString, out int myInt2))
				Console.WriteLine($"\"{someNumberAsAString}\" was parsed -> {myInt2}{Environment.NewLine}");

            // still in scope
            Console.WriteLine($"inline out vairable myInt2 ({myInt2}) is still visible{Environment.NewLine}");

            ////// Note: it same not true for ref variable
            ///******
            //    if (MethodWithRefVariable(ref int myInt3))
            //        Console.WriteLine($"ref value: {myInt3}");
            //*****/

            //////// wildcard in the event that out variable is not needed
            //////// not working yet
            /////******
            //    if (int.TryParse(someNumberAsAString, out *))
            //    Console.WriteLine($"\"{someNumberAsAString}\" was parsed -> ...");
            ////*****/
        }

        public bool MethodWithRefVariable(ref int something)
        {
            something = 10;
            return true;
        }
	}
}
