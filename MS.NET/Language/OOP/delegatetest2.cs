using System;

delegate bool Filter(int value);

static class Counter
{
	public static int CountIf(int[] values, Filter check)
	{
		int count = 0;

		foreach(int v in values)
		{
			if(check(v))
				count += 1;
		}

		return count;
	}
}

static class Program
{

	public static void Main()
	{
		int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};
		Console.Write("All squares:");
		foreach(int s in squares)
			Console.Write($" {s}");
		Console.WriteLine();

		//passing anonymous method for delegate
		Console.WriteLine("Number of odd squares = {0}", Counter.CountIf(squares, delegate(int n){return (n % 2) == 1;}));
		//passing lambda expression for delegate
		Console.WriteLine("Number of big squares = {0}", Counter.CountIf(squares, n => n > 50));
	}
}
