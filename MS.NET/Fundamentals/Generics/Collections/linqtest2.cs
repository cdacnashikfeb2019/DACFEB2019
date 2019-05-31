using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
	public static void Main(string[] args)
	{
		int limit = args.Length > 0 ? int.Parse(args[0]) : 0;
		double distance = 500;
		var intervals = new List<Interval>
		{
			new Interval(6, 30),
			new Interval(2, 21),
			new Interval(3, 42),
			new Interval(7, 23),
			new Interval(5, 14),
			new Interval(4, 55)
		};

		var selection = from i in intervals
				where i.Time > limit
				orderby i.Seconds 
				select new 
				{
					Duration = i,
					Speed = 3.6 * distance / i.Time
				};

		foreach(var entry in selection)
			Console.WriteLine($"{entry.Duration}\t{entry.Speed:0.0}");
	}
}
