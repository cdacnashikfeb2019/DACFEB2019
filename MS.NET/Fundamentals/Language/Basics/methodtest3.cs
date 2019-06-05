using System;

static class Program
{
	private static void Swap(ref float first, ref float second)
	{
		float third = first;
		first = second;
		second = third;
	}

	private static float Average(float first, float second, out float dev)
	{
		dev = first > second ? (first - second) / 2 : (second - first) / 2;
		return (first + second) / 2;
	}

	public static void Main(string[] args)
	{
		try
		{
			float x = Convert.ToSingle(args[0]);
			float y = Convert.ToSingle(args[1]);
			Console.WriteLine($"Original values = {x}, {y}");
			Swap(ref x, ref y);
			Console.WriteLine($"Swapped values = {x}, {y}");

			float d;
			float a = Average(x, y, out d);
			Console.WriteLine($"Average is {a} with a deviation of {d}");

		}
		catch
		{
			Console.WriteLine("Usage: methodtest3 first-number second-number");
		}
	}
}
