using Payroll;
using System;

static class Program
{
	private static double GetAverageIncome(Employee[] group)
	{
		double sum = 0;

		foreach(Employee emp in group)
		{
			sum += emp.GetIncome();
		}

		return sum / group.Length;
	}

	private static double GetTotalBonus(Employee[] group)
	{
		double sum = 0;

		foreach(Employee emp in group)
		{
			//if(emp.Id == 103 || emp.Id == 105)
			if(emp is SalesPerson)
				sum += 300;
			else
				sum += 500;
		}

		return sum;
	}

	private static double GetTotalSales(Employee[] group)
	{
		double sum = 0;

		foreach(Employee emp in group)
		{
			SalesPerson sp = emp as SalesPerson;
			if(sp != null)
				sum += sp.Sales;
		}

		return sum;
	}

	public static void Main()
	{
		Employee[] dept = new Employee[5];
		dept[0] = new Employee(186, 52);
		dept[1] = new Employee(175, 95);
		dept[2] = new SalesPerson(160, 45, 35000);
		dept[3] = new Employee(190, 200);
		dept[4] = new SalesPerson(180, 55, 65000);

		Console.WriteLine("Average Income = {0:0.00}", GetAverageIncome(dept));
		Console.WriteLine("Total Bonus = {0:0.00}", GetTotalBonus(dept));
		Console.WriteLine("Total Sales = {0:0.00}", GetTotalSales(dept));

	}
}
