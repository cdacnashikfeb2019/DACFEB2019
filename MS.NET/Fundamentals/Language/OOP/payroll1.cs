namespace Payroll
{
	public class Employee
	{
		public int Id {get;}

		public int Hours {get; set;}

		public float Rate {get; set;}

		private static int count;

		public Employee(int hours, float rate)
		{
			Id = 101 + count++;
			Hours = hours;
			Rate = rate;
		}

		public Employee() : this(0, 40) {}

		public double GetIncome()
		{
			double income = Hours * Rate;
			int ot = Hours - 180;
			
			if(ot > 0)
				income += 50 * ot;

			return income;
		}
	}

	public class SalesPerson : Employee
	{
		public double Sales {get;}

		public SalesPerson(int hours, float rate, double sales) : base(hours, rate)
		{
			Sales = sales;
		}

		//hiding (by signature) base class method
		public new double GetIncome()
		{
			double income = base.GetIncome();

			if(Sales >= 25000)
				income += 0.05 * Sales;

			return income;
		}
	}
}
