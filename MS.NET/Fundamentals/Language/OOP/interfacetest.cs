using Banking;
using System;

static class Program
{
	private static void PayQuarterlyInterest(Account[] accounts)
	{
		foreach(Account acc in accounts)
		{
			IProfitable p = acc as IProfitable;
			if(p != null)
			{
				double interest = p.GetInterest(3);
				acc.Deposit(interest);
			}
		}
	}

	private static void DeductAnnualTax(Account[] accounts)
	{
		foreach(Account acc in accounts)
		{
			ITaxable t = acc as ITaxable;
			t?.Deduct(); //if(t != null) t.Deduct()
		}
	}

	public static void Main()
	{
		Account[] bank = new Account[5];
		bank[0] = Banker.OpenSavingsAccount();
		bank[0].Deposit(5000);
		bank[1] = Banker.OpenCurrentAccount();
		bank[1].Deposit(20000);
		bank[2] = Banker.OpenSavingsAccount();
		bank[2].Deposit(25000);
		bank[3] = Banker.OpenCurrentAccount();
		bank[3].Deposit(40000);
		bank[4] = Banker.OpenSavingsAccount();
		bank[4].Deposit(45000);

		PayQuarterlyInterest(bank);
		DeductAnnualTax(bank);

		foreach(var acc in bank)
			Console.WriteLine($"{acc.Id}\t{acc.Balance}");


	}
}
