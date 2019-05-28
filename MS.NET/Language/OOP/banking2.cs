using System;

namespace Banking
{
	public class InsufficientFundsException : ApplicationException {}

	public abstract class Account
	{
		public int Id {get; internal set;}

		public double Balance {get; protected set;}

		public abstract void Deposit(double amount);

		public abstract void Withdraw(double amount);

		public void Transfer(double amount, Account that)
		{
			if(!ReferenceEquals(this, that))
			{
				this.Withdraw(amount);
				that.Deposit(amount);
			}
		}

	}

	public interface IProfitable
	{
		double GetInterest(int months);
	}

	public interface ITaxable
	{
		void Deduct();
	}

	public interface IChargeable
	{
		void Deduct();
	}

	sealed class SavingsAccount : Account, IProfitable
	{
		const double MinBalance = 5000;

		internal SavingsAccount()
		{
			Balance = MinBalance;
		}

		public override void Deposit(double amount)
		{
			Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			if(Balance - amount < MinBalance)
				throw new InsufficientFundsException();
			Balance -= amount;
		}

		public double GetInterest(int months)
		{
			float rate = Balance < 4 * MinBalance ? 4 : 5;
			return Balance * months * rate / 1200;
		}
	}

	sealed class CurrentAccount : Account, ITaxable, IChargeable
	{
		public override void Withdraw(double amount)
		{
			Balance -= amount;
		}

		public override void Deposit(double amount)
		{
			if(Balance < 0)
				amount *= 0.9;
			Balance += amount;			
		}

		//explicit implementation of ITaxable::Deduct
		void ITaxable.Deduct()
		{
			double extra = Balance - 25000;
			if(extra > 0)
				Balance -= 0.05 * extra;
		}

		void IChargeable.Deduct()
		{
			if(Balance < 50000)
				Balance -= 1000;
		}
	}

	public static class Banker
	{
		private static int nid = Environment.TickCount % 100000;

		public static Account OpenCurrentAccount()
		{
			var acc = new CurrentAccount();
			acc.Id = 1000000 + nid++;
			return acc;
		}

		public static Account OpenSavingsAccount()
		{
			var acc = new SavingsAccount();
			acc.Id = 2000000 + nid++;
			return acc;
		}
	}
}
