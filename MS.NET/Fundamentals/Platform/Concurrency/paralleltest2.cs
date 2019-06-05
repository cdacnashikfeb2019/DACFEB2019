using System;
using System.Linq;

static class Program
{
	public static void Main(string[] args)
	{
		int n = args.Length > 0 ? int.Parse(args[0]) : 20;
		var source = Enumerable.Range(1, n);

		int t1 = Environment.TickCount;
		long result = (from i in source.AsParallel() select i * Worker.DoWork(i)).Sum();
		int t2 = Environment.TickCount;

		Console.WriteLine("Result = {0}", result);
		Console.WriteLine("Computation time = {0:0.0}s", (t2 - t1) / 1000.0);
	}
}

