using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Shapes;

namespace ConsoleApp1
{
    // pattern matching helps write simpler code; specially when used with inline variable
    // also makes nicer switch-case statements (like switch on types)
	class Experiment4PatternMatching
	{
        // shape is our base class with two properties: name and number of corners
        // other derived classes have additional properties
		public void SomeMethod()
		{
			WhoAmI(null);
			WhoAmI(new Rectangle("rectangle", 4) { Height = 3, Width = 2 });
			WhoAmI(new Rectangle("rectangle", 4) { Height = 3, Width = 3 });
			WhoAmI(new Pentagon("pentagon", 5) { Side1 = 1, Side2 = 2, Side3 = 3, Side4 = 4, Side5 = 5 });

			WhoAmI2(new Shape("shape", -1));
			WhoAmI2(new Circle("circle", 0) { Radius = 2 });
			WhoAmI2(new Triangle("triangle", 3) { Base = 2, Height = 3 });
			WhoAmI2(new Rectangle("recSquare", 4) { Height = 2, Width = 2 });
			WhoAmI2(new Rectangle("rectangle", 4) { Height = 3, Width = 2 });
			WhoAmI2(new Pentagon("pentagon", 5) { Side1 = 1, Side2 = 2, Side3 = 3, Side4 = 4, Side5 = 5 });
            WhoAmI2(null);
		}

        // if-else.... using pathern matching
        // notice the inline variable declarations
		private void WhoAmI(Shape someShape)
		{
			// is expression with constant pattern "null"
			if (someShape is null)
				Console.WriteLine("nothing to write");
			else if (someShape is Rectangle r && r.Height == r.Width)
				Console.WriteLine($"this rectangle should have been a sq with h=w={r.Width}");
			else if (someShape is Rectangle r2)
				Console.WriteLine($"this is a rectangle with h={r2.Height} and w={r2.Width}");
			else if (someShape.Corners > 0)
				Console.WriteLine(new string('#', someShape.Corners));
		}

        // switch-case use as limited to some kind of constant (like int, string, enum...)
        // with pattern matching we can switch on types
        // also note the inline variable declaration
        // make sure the base one goes to the bottom; else everything shall be ignored
		private void WhoAmI2(Shape someShape)
		{
			switch (someShape)
			{
				case Circle c:
					Console.WriteLine($"this is a circle with radius: {c.Radius}{Environment.NewLine}");
					break;

				case Triangle t:
					Console.WriteLine($"this is a triangle with base: {t.Base} and height: {t.Height}{Environment.NewLine}");
					break;

                // doesn't matter where default goes
                default:
                    Console.WriteLine($"have no clue here{Environment.NewLine}");
                    break;

                case Square s:
					Console.WriteLine($"this is a square with side: {s.Side}{Environment.NewLine}");
					break;

				case Rectangle r when (r.Height == r.Width):
					Console.WriteLine($"this rectangle should have been a square with height=width={r.Height}{Environment.NewLine}");
					break;

				case Rectangle r:
					Console.WriteLine($"this is a rectangle with height={r.Height} and width={r.Width}{Environment.NewLine}");
					break;

				case Pentagon p:
					Console.WriteLine($"this is a pentagon..... corners: {p.Corners}{Environment.NewLine}");
					break;

				// NOTE: .... the base class thing has to be at the bottom
				case Shape s:
					Console.WriteLine($"this is a shape with name: {s.Name} and corners: {s.Corners}{Environment.NewLine}");
					break;

				case null:
					Console.WriteLine($"this was a null shape{Environment.NewLine}");
					break;
			}
		}
	}
}
