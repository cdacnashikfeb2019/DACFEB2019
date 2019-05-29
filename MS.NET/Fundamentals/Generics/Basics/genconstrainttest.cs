using System;

static class Program
{
	private static T Select<T>(T first, T second) where T : IComparable<T>
	{
		if(first.CompareTo(second) > 0)
			return first;
		return second;
	}

	public static void Main(string[] args)
	{
		double sd = Select(6.75, 4.25);
		Console.WriteLine($"Selected double = {sd}");

		string ss = Select("Monday", "Tuesday");
		Console.WriteLine($"Selected string = {ss}");

		Interval si = Select(new Interval(4, 50), new Interval(3, 40));
		Console.WriteLine($"Selected Interval = {si}");

	}
}
