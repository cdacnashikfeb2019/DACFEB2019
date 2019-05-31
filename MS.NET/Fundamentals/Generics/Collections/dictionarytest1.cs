using System;
using System.Collections.Generic;

static class Program
{
	public static void Main(string[] args)
	{
		IDictionary<string, Interval> store = new Dictionary<string, Interval>();
		store.Add("monday", new Interval(6, 41));
		store.Add("tuesday", new Interval(7, 32));
		store.Add("wednesday", new Interval(4, 53));
		store.Add("thursday", new Interval(3, 24));
		store.Add("friday", new Interval(5, 15));
		//store.Add("monday", new Interval(2, 10));

		if(args.Length > 0)
		{
			try
			{
				Console.WriteLine("Interval = {0}", store[args[0]]);
			}
			catch(KeyNotFoundException)
			{
				Console.WriteLine($"Cannot find {args[0]}!");
			}
		}
		else
		{
			foreach(var pair in store)
				Console.WriteLine("{0, -10}{1, 8}", pair.Key, pair.Value);
		}

	}
}
