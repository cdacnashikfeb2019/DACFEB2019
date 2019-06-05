using System;

static class Program
{
	public static void Main(string[] args)
	{
		short age = short.Parse(args[0]);

		using(var emp = new IjwBridge.LegacyTaxPayer(age))
		{
			emp.Income = double.Parse(args[1]);
			Console.WriteLine("Income Tax: {0:0.00}", emp.GetIncomeTax());
		}
	}
}
