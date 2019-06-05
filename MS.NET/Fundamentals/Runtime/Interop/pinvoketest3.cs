using System;
using System.Runtime.InteropServices;

static class Program
{
	[StructLayout(LayoutKind.Sequential)]
	struct FixedDeposit
	{
		public int Id;
		public double Amount;
		public int Period;
	}

	[DllImport("legacy\\x86\\invest.dll", CallingConvention=CallingConvention.Cdecl)]
	private extern static int InitFixedDeposit(double amount, int period, out FixedDeposit fd);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	delegate float Scheme(int years);

	[DllImport("legacy\\x86\\invest.dll", CallingConvention=CallingConvention.Cdecl)]
	private extern static double GetMaturityValue(ref FixedDeposit fd, Scheme policy);
	
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		int n = int.Parse(args[1]);
		FixedDeposit fd;

		InitFixedDeposit(p, n, out fd);
		Console.WriteLine($"New fixed-deposit ID: {fd.Id}");
		
		double mv = GetMaturityValue(ref fd, y => y < 3 ? 6 : 7);
		Console.WriteLine($"Maturity value: {mv:0.00}");
	}
}