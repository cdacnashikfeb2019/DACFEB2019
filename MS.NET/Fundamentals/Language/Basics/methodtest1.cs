using System;

static class Program
{
	private static double Average(double first, double second)
	{
		return (first + second) / 2;
	}

	private static double Average(double first, double second, double third) => (first + second + third) / 3;

	private static double Average(double first, double second, params double[] other)
	{
		double total = first + second;
		foreach(double value in other)
			total += value;
		return total / (other.Length + 2);
	}

	public static void Main()
	{
		Console.WriteLine("Average of {0} values = {1}", "two", Average(22.3, 27.4));
		Console.WriteLine("Average of {0} values = {1}", "three", Average(22.3, 27.4, 23.2));
		Console.WriteLine("Average of {0} values = {1}", "five", Average(22.3, 27.4, 23.2, 17.6, 32.7)); // Average(22.3, 27.4, new double[]{23.2, 17.6, 32.7})

	}
}
