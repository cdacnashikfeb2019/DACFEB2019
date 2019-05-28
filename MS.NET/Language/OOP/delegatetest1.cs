using System;

delegate bool Filter(int value);

static class Counter
{
	public static int CountIf(int[] values, Filter check)
	{
		int count = 0;

		foreach(int v in values)
		{
			if(check.Invoke(v))
				count += 1;
		}

		return count;
	}
}

static class Program
{
	private static bool IsOdd(int n)
	{
		return (n % 2) == 1;
	}

	//nested class
	class IsBiggerThan
	{
		private int limit;

		public IsBiggerThan(int l) => limit = l;

		public bool Confirm(int value)
		{
			return value > limit;
		}
	}

	public static void Main()
	{
		int[] squares = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};
		Console.Write("All squares:");
		foreach(int s in squares)
			Console.Write($" {s}");
		Console.WriteLine();

		Console.WriteLine("Number of odd squares = {0}", Counter.CountIf(squares, IsOdd));
		Console.WriteLine("Number of big squares = {0}", Counter.CountIf(squares, new IsBiggerThan(50).Confirm));
	}
}
