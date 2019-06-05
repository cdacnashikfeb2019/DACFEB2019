using Banking;
using System;

static class Program
{
	public static void Main(string[] args)
	{
		Account jack = Banker.OpenCurrentAccount();
		jack.Deposit(15000);
	
		Account jill = Banker.OpenSavingsAccount();
		jill.Deposit(10000);

		try
		{
			double payment = double.Parse(args[0]);
			jill.Transfer(payment, jack);
			Console.WriteLine("Payment transferred.");
		}
		catch(InsufficientFundsException)
		{
			Console.WriteLine("Payment transfer failed due to lack of funds!");
		}
		catch
		{
			Console.WriteLine("Usage: abstractclasstest payment-to-transfer");
		}

		Console.WriteLine($"Jack's Account ID is {jack.Id} and Balance is {jack.Balance}");
		Console.WriteLine($"Jill's Account ID is {jill.Id} and Balance is {jill.Balance}");
	}
}
