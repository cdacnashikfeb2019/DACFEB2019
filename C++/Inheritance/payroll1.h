#ifndef PAYROLL1_H
#define PAYROLL1_H

#include <iostream>

namespace Payroll
{
	class Employee
	{
	public:
		explicit Employee(long h=0, float r=40)
		{
			hours = h;
			rate = r;
			#ifdef _TESTING
			std::cout << "Employee activated" << std::endl;
			#endif
		}

		long GetHours() const
		{
			return hours;
		}

		void SetHours(long value) 
		{
			hours = value;
		}

		float GetRate() const
		{
			return rate;
		}

		void SetRate(float value)
		{
			rate = value;
		}
		
		double GetIncome() const
		{
			double income = hours * rate;
			long ot = hours - 180;

			if(ot > 0)
				income += 50 * ot;

			return income;
		}

		~Employee()
		{
			#ifdef _TESTING
			std::cout << "Employee deactivated" << std::endl;
			#endif
		}
	private:
		long hours;
		float rate;
	};

	class SalesPerson : public Employee
	{
	public:
		SalesPerson(long h, float r, double s) : Employee(h, r)
		{
			sales = s;
		}

		double GetSales() const
		{
			return sales;
		}

		//hiding method of base class
		double GetIncome() const
		{
			double income = Employee::GetIncome();
			if(sales >= 10000)
				income += 0.05 * sales;
			return income;
		}
	private:
		double sales;
	};
}
#endif

