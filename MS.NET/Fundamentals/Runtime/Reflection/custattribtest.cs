using Finance;
using System;
using System.Reflection;

static class Program
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		Type t = Type.GetType(args[1], true);
		MethodInfo mi = t.GetMethod(args[2], new Type[]{typeof(int)});
		object pol = Activator.CreateInstance(t);
		int m = 10;

		if(t.IsDefined(typeof(MaxDurationAttribute), false))
		{
			var md = (MaxDurationAttribute)Attribute.GetCustomAttribute(t, typeof(MaxDurationAttribute));
			m = md.Limit;
		}

		for(int n = 1; n <= m; ++n)
		{
			float r = (float)mi.Invoke(pol, new object[]{n});
			float i = r / 1200;
			double emi = p * i / (1 - Math.Pow(1 + i, -12 * n));
			Console.WriteLine("{0, -4}{1, 12:0.00}", n, emi);
		}
	}
}


