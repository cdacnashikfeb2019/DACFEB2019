using System;

static class Program
{
	private static double GetIncome(double invest, int duration=3, string risk="medium")
	{
		float rate;
		switch(risk)
		{
			case "low":
				rate = 4;
				break;
			case "high":
				rate = 9;
				break;
			default:
				rate = 6;
				break;
		}

		double amount = invest * Math.Pow(1 + rate / 100, duration);
		return amount - invest;
	}

	public static void Main(string[] args)
	{
		try
		{
			double inv = Convert.ToDouble(args[0]);
			Console.WriteLine("Income in gold scheme: {0:0.00}", GetIncome(inv, 2, "high"));
			Console.WriteLine("Income in silver scheme: {0:0.00}", GetIncome(inv, 4));
			Console.WriteLine("Income in bronze scheme: {0:0.00}", GetIncome(inv, risk: "low"));
		}
		catch(IndexOutOfRangeException)
		{
			Console.WriteLine("Usage: methodtest2 amount-to-invest");
		}
		catch(FormatException)
		{
			Console.WriteLine("Error: amount-to-invest is not a number");
		}
	}
}
