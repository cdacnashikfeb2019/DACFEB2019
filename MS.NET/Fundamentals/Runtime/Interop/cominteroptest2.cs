using FinanceLib;
using System;
using System.Runtime.InteropServices;

[ComImport]
[Guid("1A87402F-A9F3-449F-ACB3-714A9275BEE0")]
class RBLoan {}

class PersonalLoanScheme : ILoanScheme
{
	public float GetInterestRate(short period)
	{
		return 9 + 0.5f * (period / 3);
	}
}

static class Program
{
	[STAThread]
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		short n = short.Parse(args[1]);

		var loan = (ILoan)new RBLoan();

		try
		{
			loan.Acquire(p, n);
			Console.WriteLine("E.M.I for education loan: {0:0.00}", loan.GetInstallmentUsingRate(6));
			//when a managed object is passed to a COM interface method, a CCW of that object is sent to
			//that method so that it can forward COM calls back to that managed object
			Console.WriteLine("E.M.I for personal loan : {0:0.00}", loan.GetInstallmentForScheme(new PersonalLoanScheme()));
			
		}
		catch(COMException ex)
		{
			Console.WriteLine("Cannot acquire loan: {0}", (LoanError)ex.HResult);
		}
	}
}
