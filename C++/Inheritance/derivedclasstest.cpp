#include "payroll1.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double GetIncomeTax(const Employee& entry)
{
	double i = entry.GetIncome(); //Employee::GetIncome(&entry)
	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

double GetIncomeTax(const SalesPerson& entry)
{
	double i = entry.GetIncome(); //SalesPerson::GetIncome(&entry)
	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

int main(void)
{
	Employee jack;
	jack.SetHours(186);
	jack.SetRate(52);

	SalesPerson jill(186, 52, 48000);

	cout << "Jack's Income is "
		 << jack.GetIncome() //Employee::GetIncome(&jack)
		 << " and Tax is "
		 << GetIncomeTax(jack)
		 << endl;
	cout << "Jill's Income is "
		 << jill.GetIncome() //SalesPerson::GetIncome(&jill)
		 << " and Tax is "
		 << GetIncomeTax(jill)
		 << endl;
}

