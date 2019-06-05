using System;
using System.Threading.Tasks;

static class Program
{
	public static void Main(string[] args)
	{
		int n = args.Length > 0 ? int.Parse(args[0]) : 20;
		long result = 0;

		int t1 = Environment.TickCount;
		/*
		for(int i = 1; i < n + 1; ++i)
		{
			Worker.DoWork(i);
			result += i * i;
		}
		*/
		Parallel.For(1, n + 1, i => 
		{
			Worker.DoWork(i);
			result += i * i;
		});
		int t2 = Environment.TickCount;

		Console.WriteLine("Result = {0}", result);
		Console.WriteLine("Computation time = {0:0.0}s", (t2 - t1) / 1000.0);
	}
}

