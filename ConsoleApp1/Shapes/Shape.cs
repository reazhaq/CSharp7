using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Shapes
{
	class Shape
	{
		public string Name { get; private set; }
		public int Corners { get; private set; }

		public Shape(string name, int corners)
		{
			Name = name; Corners = corners;
		}
	}
}
