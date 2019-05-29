using System;

static class Program
{
	/*
	private static double Select(int sign, double first, double second)
	{
		if(sign < 0)
			return first;
		return second;
	}

	private static string Select(int sign, string first, string second)
	{
		if(sign < 0)
			return first;
		return second;
	}
	*/

	private static object Select(int sign, object first, object second)
	{
		if(sign < 0)
			return first;
		return second;
	}

	public static void Main(string[] args)
	{
		int s = int.Parse(args[0]);

		double sd = (double)Select(s, 6.75, 4.25);
		Console.WriteLine($"Selected double = {sd}");

		string ss = (string)Select(s, "Monday", "Tuesday");
		Console.WriteLine($"Selected string = {ss}");

		Interval si = (Interval)Select(s, new Interval(4, 50), new Interval(3, 40));
		Console.WriteLine($"Selected Interval = {si}");

		long sl = (long)Select(s, 1234L, "abcd");
		Console.WriteLine($"Selected long = {sl}");

	}
}
