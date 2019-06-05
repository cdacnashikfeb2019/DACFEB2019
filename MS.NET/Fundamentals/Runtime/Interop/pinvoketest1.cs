using System;
using System.Runtime.InteropServices;

static class Program
{
	[DllImport("legacy\\x86\\asset.dll", EntryPoint="DDB", CallingConvention=CallingConvention.Cdecl)]
	private extern static double GetPriceAfter(double cost, short life, short after);

	public static void Main(string[] args)
	{
		double c = double.Parse(args[0]);
		short l = short.Parse(args[1]);

		for(short y = 1; y <= l ;++y)
		{
			Console.WriteLine("{0}\t{1:0.00}", y, GetPriceAfter(c, l, y));
		}
	}
}