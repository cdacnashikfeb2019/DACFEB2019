using System;

namespace Finance
{	
	public interface ILoanPolicy
	{
		float GetInterestRate(int period);
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class MaxDurationAttribute : Attribute
	{
		public int Limit {get; set;}

		public MaxDurationAttribute(int value=5) => Limit = value;
		
	}

	[MaxDuration(12)]
	public class HomeLoan : ILoanPolicy
	{
		public float GetInterestRate(int period)
		{
			return period < 10 ? 7 : 8;
		}
	}

	[MaxDuration]
	public class EducationLoan : ILoanPolicy
	{
		public float GetInterestRate(int period)
		{
			return 6;
		}
	}

	[MaxDuration(Limit=4)]
	public class PersonalLoan : ILoanPolicy
	{
		public float GetInterestRate(int period)
		{
			return period < 3 ? 8 : 9;
		}

		public float GetInterestRateForEmployees(int period)
		{
			return period < 5 ? 4 : 5;			
		}
	}

	[Serializable]
	public class BusinessLoan
	{
		public float RateOfInterest(int period)
		{
			return 10 + 0.5f * (period / 3);
		}
	}

}
