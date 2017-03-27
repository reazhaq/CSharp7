using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Shapes
{
	class Pentagon : Shape
	{
		public Pentagon(string name, int corners) : base(name, corners)
		{
		}

		public int Side1 { get; set; }
		public int Side2 { get; set; }
		public int Side3 { get; set; }
		public int Side4 { get; set; }
		public int Side5 { get; set; }
	}
}
