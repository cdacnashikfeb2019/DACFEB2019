using System;

static class Program
{
	private static T Select<T>(int sign, T first, T second)
	{
		if(sign < 0)
			return first;
		return second;
	}

	public static void Main(string[] args)
	{
		int s = int.Parse(args[0]);

		double sd = Select(s, 6.75, 4.25);
		Console.WriteLine($"Selected double = {sd}");

		string ss = Select(s, "Monday", "Tuesday");
		Console.WriteLine($"Selected string = {ss}");

		Interval si = Select(s, new Interval(4, 50), new Interval(3, 40));
		Console.WriteLine($"Selected Interval = {si}");

		//long sl = Select(s, 1234L, "abcd");
		long sl = Select(s, 1234L, 4321L);
		Console.WriteLine($"Selected long = {sl}");

	}
}
